//
// Copyright 2021 Delphinus Consulting, LLC
//
// This file is part of Delphinus Verifier.
//
// Delphinus Verifier is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Delphinus Verifier is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Delphinus Verifier.  If not, see <https://www.gnu.org/licenses/>.
//
// Author:
// Jonathan W. Platt
// Datasoft, Inc.
// www.jwplatt.com
//
// These sources eschew elseif statements and use braces on their own lines for code block clarity.
// Please follow this format.  Reformatting otherwise will muddy the commit diff.
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Delphinus
{
    public partial class VerifierForm : Form
    {
        private const string ErrorNoManifestFound = "Please select a properly formatted Transmittal file.";
        private const string ErrorNoDataFileFound = "The data file is missing or invalid.";
        private const string ErrorNoStructuredDataFileFound = "The structuredData file is missing or invalid.";
        private const string ErrorNoDataFileEntryFound = "You must select the first Transmittal file.  The filename typically ends with '_001'.";
        private const string ErrorNoStructuredDataFileEntryFound = "The structuredData entry is missing from the manifest.";
        private const string ErrorOpenZipFile = "Error Opening Zip File.";
        private const string ErrorProcessingZipFiles = "Error Processing Zip Files.";
        private const string ErrorDataFileProcessing = "Error Processing Data File.";
        private const string ErrorStructuredDataFileProcessing = "Error Processing structuredData File.";
        private const string ErrorInvalidPackageCount = "Invalid Package Count In Manifest";
        private const string ErrorDuplicatePackageIndexFound = "Duplicate Package Index In Transmittal File.";
        private const string ErrorIncompleteTransmittal = "Could not find all Transmittal files for the selected Submission. " +
                                                          "\r\nIt is not possible to conduct a complete search or list all" +
                                                          "\r\nSubmitted files without all Transmittal Zip files." +
                                                          "\r\n" +
                                                          "\r\nAll files for a Submission must be in the same folder for a " +
                                                          "\r\ncomplete verification." +
                                                          "\r\n" +
                                                          "\r\nClick OK to show only dropped files, or Cancel to clear.";

        private const string TextNoMissingFiles = "No missing files were identified.";
        private const string TextFurtherAssitance = "Please contact Delphinus Consulting, LLC for further assistance at " +
                                                    "\r\nesubverifier@delphinusconsulting.com";
        private const string TextDirectiveNotice = "All missing files identified by this utility should be verified comparing " +
                                                   "\r\nthe files in the Transmittal file with the original file list.  This software " +
                                                   "\r\ncan identify files that were added as a Submission document and later removed.";

        private const string TextDroppedFilesHeading = "Dropped Files (added to eSubmitter but excluded from the Submission Report):";
        private const string TextMissingFilesHeading = "Missing Files (reported to FDA as part of the Submission but not submitted):";
        private const string TextExtraFilesHeading = "Extra Files (included in the Submission but not in the Submission Report):";
        private const string TextComprehensiveFilesHeading = "File List (all files included in the Transmittal files):";

        private string SelectedFilepath = string.Empty;
        private string SubmissionGUID = string.Empty;
        private int PackageCount = 0;
        private List<string> PackageIndexes = new List<string>();
        private XmlDocument DataXml = null;
        private XmlDocument StructuredDataXml = null;
        private List<string> ReportedList = new List<string>();
        private List<string> DroppedList = new List<string>();
        private List<string> MissingList = new List<string>();
        private List<string> ExtraList = new List<string>();
        private List<string> ComprehensiveList = new List<string>();


        public VerifierForm()
        {
            InitializeComponent();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblLink.LinkVisited = true;
            Process.Start("https://www.delphinusconsulting.com/");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Choose A Submittal Zip File",
                DefaultExt = "zip",
                Filter = "zip files (*.zip)|*.zip",
                CheckPathExists = true,
                CheckFileExists = true,
                Multiselect = false,
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SelectedFilepath = ofd.FileName;
                    Clear(SelectedFilepath);
                }
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            string Msg;

            Clear();

            if ((Msg = ProcessManifestZip(SelectedFilepath)) == string.Empty)
            {
                if ((Msg = ProcessDataXml(DataXml)) == string.Empty)
                {
                    if ((Msg = ProcessRemainingZips(SelectedFilepath)) == string.Empty)
                    {
                        if (PackageCount != PackageIndexes.Count)
                        {
                            if (PromptOKCancelWarning(ErrorIncompleteTransmittal) == DialogResult.OK)
                            {
                                DisplayResults();
                                SetButtons();
                            }
                            else
                            {
                                Clear();
                            }
                            return;
                        }

                        if ((Msg = ProcessStructuredDataXml(StructuredDataXml)) == string.Empty)
                        {
                            foreach (string Path in ReportedList)
                            {
                                if (!ComprehensiveList.Contains(Path)) MissingList.Add(Path);
                            }

                            foreach (string Path in ComprehensiveList)
                            {
                                if (!ReportedList.Contains(Path)) ExtraList.Add(Path);
                            }

                            DisplayResults();
                            SetButtons();
                        }
                    }
                }
            }

            ShowMessage(Msg);
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbResults.Text)) Clipboard.SetText(tbResults.Text); else Clipboard.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear(string ZipFilePath = "")
        {
            lblFile.Text = ZipFilePath;
            lblMissingFiles.Text = "";
            tbResults.Clear();

            SubmissionGUID = string.Empty;
            PackageCount = 0;
            PackageIndexes = new List<string>();
            DataXml = null;
            StructuredDataXml = null;
            ReportedList = new List<string>();

            DroppedList = new List<string>();
            MissingList = new List<string>();
            ExtraList = new List<string>();
            ComprehensiveList = new List<string>();

            SetButtons();
        }

        private void SetButtons()
        {
            btnClipboard.Enabled = btnClear.Enabled = !string.IsNullOrWhiteSpace(tbResults.Text);
            btnReview.Enabled = !string.IsNullOrWhiteSpace(lblFile.Text);
        }

        public string ProcessManifestZip(string ZipFilepath)
        {
            try
            {
                using (ZipArchive Archive = ZipFile.OpenRead(ZipFilepath))
                {
                    manifest Manifest = DeserializeZipManifest(Archive);
                    if (Manifest != null)
                    {
                        int.TryParse(Manifest.submission.packageCount, out PackageCount);
                        if (PackageCount > 0)
                        {
                            SubmissionGUID = Manifest.submission.guid;
                            PackageIndexes.Add(Manifest.submission.packageIndex);

                            string DataPath = string.Empty;
                            string structuredDataPath = string.Empty;

                            foreach (doc doc in Manifest.submission.attachment)
                            {
                                switch (doc.type)
                                {
                                    case "data": { DataPath = doc.path; DataXml = GetXmlDocument(Archive, doc.path); break; }
                                    case "structuredData": { structuredDataPath = doc.path;  StructuredDataXml = GetXmlDocument(Archive, doc.path); break; }
                                    case "plain":
                                    case "coverLetter": { if (!ComprehensiveList.Contains(doc.path)) ComprehensiveList.Add(doc.path); break; }
                                }
                            }
                            if (DataPath == string.Empty) return ErrorNoDataFileEntryFound; // No data file entry found in the manifest
                            if (structuredDataPath == string.Empty) return ErrorNoStructuredDataFileEntryFound; // No structuredData file entry found in the manifest
                            if (DataXml == null) return ErrorNoDataFileFound; // data file error or not found
                            if (StructuredDataXml == null) return ErrorNoStructuredDataFileFound; // structuredData file error or not found
                        }
                        else
                        {
                            return ErrorInvalidPackageCount; // The manifest package count is not numeric
                        }
                    }
                    else
                    {
                        return ErrorNoManifestFound; // manifest.xml not found
                    }
                }
            }
            catch
            {
                return ErrorOpenZipFile; // Zip file open error
            }

            return string.Empty;
        }

        public XmlDocument GetXmlDocument(ZipArchive Archive, string Path)
        {
            try
            {
                ZipArchiveEntry Datafile = Archive.GetEntry(Path);
                if (Datafile != null)
                {
                    using (Stream ZipEntryStream = Datafile.Open())
                    {
                        XmlDocument XmlDoc = new XmlDocument();
                        XmlDoc.Load(ZipEntryStream);
                        return XmlDoc;
                    }
                }
            }
            catch
            {
            }

            return null;
        }

        public string ProcessRemainingZips(string path)
        {
            try
            {
                string[] Files = Directory.GetFiles(Path.GetDirectoryName(path), "*.zip", SearchOption.TopDirectoryOnly);

                foreach (string ZipFilepath in Files)
                {
                    if (ZipFilepath != path)
                    {
                        using (ZipArchive Archive = ZipFile.OpenRead(ZipFilepath))
                        {
                            manifest Manifest = DeserializeZipManifest(Archive);
                            if (Manifest == null)
                            {
                                return ErrorNoManifestFound;
                            }
                            else
                            {
                                if (Manifest.submission.guid == SubmissionGUID)
                                {
                                    if (!PackageIndexes.Contains(Manifest.submission.packageIndex))
                                    {
                                        PackageIndexes.Add(Manifest.submission.packageIndex);
                                        foreach (doc doc in Manifest.submission.attachment)
                                        {
                                            switch (doc.type)
                                            {
                                                case "plain":
                                                case "coverLetter":
                                                    {
                                                        if (!ComprehensiveList.Contains(doc.path)) ComprehensiveList.Add(doc.path);
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return ErrorDuplicatePackageIndexFound; // Duplicate package index
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return ErrorProcessingZipFiles;
            }

            return string.Empty;
        }

        public manifest DeserializeZipManifest(ZipArchive Archive)
        {
            ZipArchiveEntry Manifest = Archive.GetEntry("manifest.xml");
            if (Manifest != null)
            {
                using (Stream ZipEntryStream = Manifest.Open())
                {
                    XmlSerializer Serializer = new XmlSerializer(typeof(manifest));
                    manifest Deserialized = (manifest)Serializer.Deserialize(ZipEntryStream);
                    return Deserialized;
                }
            }

            return null;
        }

        public string ProcessDataXml(XmlDocument XmlDoc)
        {
            try
            {
                List<string> Files = new List<string>();

                XmlNode TabNode = XmlDoc.SelectSingleNode("/reportData/reportLayout/tab[@key = 'TGENSUB.10']");

                foreach (XmlNode OutlineNode in TabNode["outlineNodeList"].ChildNodes)
                {
                    XmlNodeList CoverLetter = OutlineNode.SelectNodes(".//question[@name = 'coverLetterAttachment']");
                    Files.Add(CoverLetter[0]["file"].InnerText);

                    XmlNodeList InfoFileLists = OutlineNode.SelectNodes(".//question[@name = 'additionalInformationFiles']");
                    foreach (XmlNode InfoFileList in InfoFileLists)
                    {
                        foreach (XmlNode InfoFile in InfoFileList.ChildNodes)
                        {
                            Files.Add(InfoFile.InnerText);
                        }
                    }
                }

                XmlNode FileListNode = XmlDoc.SelectSingleNode("/reportData/fileList");
                foreach (XmlNode Child in FileListNode.ChildNodes)
                {
                    string key = Child.Attributes["key"]?.Value;
                    string fileNamePath = Child["fileNamePath"]?.InnerText;

                    if (!Files.Contains(key))
                    {
                        DroppedList.Add(fileNamePath);
                    }
                }
            }
            catch
            {
                return ErrorDataFileProcessing;
            }

            return string.Empty;
        }


        public string ProcessStructuredDataXml(XmlDocument XmlDoc)
        {
            try
            {
                XmlNode ListFiles = XmlDoc.SelectSingleNode("/tobaccoGenericTemplate/submissionAttachment"); // /submissionAttachmentFiles/listFiles");
                XmlNodeList FileLocations = ListFiles.SelectNodes(".//fileLocation");

                foreach (XmlNode FileLocation in FileLocations)
                {
                    ReportedList.Add(FileLocation.InnerText);
                }
            }
            catch
            {
                return ErrorStructuredDataFileProcessing;
            }

            return string.Empty;
        }

        private void DisplayResults()
        {
            if (DroppedList.Count + MissingList.Count + ExtraList.Count == 0)
            {
                tbResults.AppendText(TextNoMissingFiles + Environment.NewLine);
            }
            else
            {
                tbResults.AppendText(TextDirectiveNotice + Environment.NewLine + Environment.NewLine);
                DisplayList(DroppedList, TextDroppedFilesHeading);
                DisplayList(MissingList, TextMissingFilesHeading);
                DisplayList(ExtraList, TextExtraFilesHeading);
            }
            DisplayList(ComprehensiveList, TextComprehensiveFilesHeading);
            tbResults.AppendText(TextFurtherAssitance);

            tbResults.Select(0, 0);
            tbResults.ScrollToCaret();
        }

        private void DisplayList(List<string> List, string Heading)
        {
            if (List.Count > 0)
            {
                tbResults.AppendText("[" + List.Count.ToString() + "] " + Heading + Environment.NewLine + Environment.NewLine);

                foreach (string Path in List)
                {
                    tbResults.AppendText(Path + Environment.NewLine);
                }

                tbResults.AppendText(Environment.NewLine);
                tbResults.AppendText(Environment.NewLine);
            }
        }

        public void ShowMessage(string Text, string Caption = "Error")
        {
            if (!string.IsNullOrWhiteSpace(Text)) MessageBox.Show(this, Text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult PromptOKCancelWarning(string Text)
        {
            return MessageBox.Show(this, Text, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }

    [Serializable()]
    [XmlRoot]
    public class manifest
    {
        [XmlElement] public submission submission { get; set; }
    }

    [Serializable()]
    public class submission
    {
        [XmlArrayItem] public doc[] attachment { get; set; }

        [XmlAttribute] public string packageCount { get; set; }
        [XmlAttribute] public string packageGUID { get; set; }
        [XmlAttribute] public string packageIndex { get; set; }
        [XmlAttribute] public string guid { get; set; }
        [XmlAttribute] public string dateformat { get; set; }
        [XmlAttribute] public string date { get; set; }
        [XmlAttribute] public string type { get; set; }
        [XmlAttribute] public string source { get; set; }
    }

    [Serializable()]
    public class doc
    {
        [XmlAttribute] public string title { get; set; }
        [XmlAttribute] public string type { get; set; }
        [XmlAttribute] public string fileGUID { get; set; }
        [XmlAttribute] public string description { get; set; }
        [XmlAttribute] public string checksum { get; set; }
        [XmlAttribute] public string unpack { get; set; }
        [XmlAttribute] public string path { get; set; }
        [XmlAttribute] public string fileID { get; set; }
    }
}
