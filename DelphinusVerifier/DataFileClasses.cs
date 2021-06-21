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

//
// The set of classes below began as an XML deserialization of <doc type="data">.xml.
// It is unfinished because using XPath on the XmlDocument was simpler.
// It is left here if necessary for future work.
//
using System;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;

namespace Delphinus
{
    public class DataFile
    {
        public void ProcessDataFile(ZipArchive Archive, string Path)
        {
            ZipArchiveEntry Datafile = Archive.GetEntry(Path);
            if (Datafile != null)
            {
                using (Stream ZipEntryStream = Datafile.Open())
                {
                    XmlSerializer Serializer = new XmlSerializer(typeof(reportData));
                    reportData Deserialized = (reportData)Serializer.Deserialize(ZipEntryStream);
                    foreach (Tab tab in Deserialized.reportLayout)
                    {
                    }
                }
            }
        }
    }

    [XmlRoot]
    [Serializable()]
    public class reportData
    {
        [XmlElement] public SubmissionPropertyList submissionPropertyList { get; set; }
        [XmlElement] public UserRegistration userRegistration { get; set; }
        [XmlElement] public Tab[] reportLayout { get; set; }
        [XmlElement] public FileItem[] fileList { get; set; }
    }

    [Serializable()]
    public class SubmissionPropertyList
    {
        [XmlAttribute] public string submissionName { get; set; }
        [XmlAttribute] public string submissionGUID { get; set; }
        [XmlAttribute] public string submissionComment { get; set; }
        [XmlAttribute] public string modifiedDate { get; set; }
        [XmlAttribute] public string packagedDate { get; set; }
        [XmlAttribute] public string reportType { get; set; }
        [XmlAttribute] public string reportAssignedID { get; set; }
        [XmlAttribute] public string appVersionCreated { get; set; }
        [XmlAttribute] public string appVersionUpdated { get; set; }
        [XmlAttribute] public string templateFile { get; set; }
        [XmlAttribute] public string templateName { get; set; }
        [XmlAttribute] public string templateVersion { get; set; }
        [XmlAttribute] public string templateDate { get; set; }
    }

    [Serializable()]
    public class UserRegistration
    {
        [XmlAttribute] public string firstname { get; set; }
        [XmlAttribute] public string middlename { get; set; }
        [XmlAttribute] public string lastname { get; set; }
        [XmlAttribute] public string title { get; set; }
        [XmlAttribute] public string email { get; set; }
        [XmlAttribute] public string country { get; set; }
        [XmlAttribute] public string establishment { get; set; }
        [XmlAttribute] public string addressline1 { get; set; }
        [XmlAttribute] public string addressline2 { get; set; }
        [XmlAttribute] public string city { get; set; }
        [XmlAttribute] public string state { get; set; }
        [XmlAttribute] public string zipcode { get; set; }
        [XmlAttribute] public string telephone { get; set; }
    }

    [Serializable()]
    public class Tab
    {
        [XmlElement] public reportDataTabOutlineNodeList outlineNodeList { get; set; }

        [XmlAttribute] public string key { get; set; }
    }

    [Serializable()]
    public class reportDataTabOutlineNodeList
    {
        [XmlElement] public reportDataTabOutlineNodeListOutlineNode outlineNode { get; set; }
    }

    [Serializable()]
    public class reportDataTabOutlineNodeListOutlineNode
    {
        [XmlElement] public reportDataTabOutlineNodeListOutlineNodeDateList dateList { get; set; }
        [XmlArrayItem("outlineNode", IsNullable = false)]
        [XmlElement] public OutlineNode[] outlineNodeList { get; set; }

        [XmlAttribute] public string key { get; set; }
    }

    [Serializable()]
    public class reportDataTabOutlineNodeListOutlineNodeDateList
    {
        [XmlElement] public reportDataTabOutlineNodeListOutlineNodeDateListRow row { get; set; }
    }

    [Serializable()]
    public class reportDataTabOutlineNodeListOutlineNodeDateListRow
    {
        [XmlElement] public reportDataTabOutlineNodeListOutlineNodeDateListRowQuestion[] question { get; set; }

        [XmlAttribute] public string groupKey { get; set; }
        [XmlAttribute] public string key { get; set; }
    }

    [Serializable()]
    public class reportDataTabOutlineNodeListOutlineNodeDateListRowQuestion
    {
        [XmlAttribute] public string key { get; set; }
        [XmlAttribute] public string value { get; set; }
        [XmlAttribute] public string file { get; set; }
        [XmlAttribute] public string name { get; set; }
    }

    [Serializable()]
    public class OutlineNode
    {
        [XmlElement] public OutlineNodeDateList dateList { get; set; }
        [XmlElement] public object outlineNodeList { get; set; }

        [XmlAttribute] public string key { get; set; }
    }

    [Serializable()]
    public class OutlineNodeDateList
    {
        [XmlElement] public DateListRow row { get; set; }
    }

    [Serializable()]
    public class DateListRow
    {
        [XmlElement] public Question[] question { get; set; }

        [XmlAttribute] public string groupKey { get; set; }
        [XmlAttribute] public string key { get; set; }
    }

    [Serializable()]
    public class Question
    {
        [XmlAttribute] public string key { get; set; }
        [XmlAttribute] public string value { get; set; }
        [XmlAttribute] public string name { get; set; }
        [XmlAttribute] public string DUNS { get; set; }
        [XmlAttribute] public string FEI { get; set; }
        [XmlAttribute] public string titleName { get; set; }
        [XmlAttribute] public string firstName { get; set; }
        [XmlAttribute] public string middleName { get; set; }
        [XmlAttribute] public string lastName { get; set; }
        [XmlAttribute] public string suffixName { get; set; }
        [XmlAttribute] public string suffixGenerational { get; set; }
        [XmlAttribute] public string line1 { get; set; }
        [XmlAttribute] public string line2 { get; set; }
        [XmlAttribute] public string city { get; set; }
        [XmlAttribute] public string state { get; set; }
        [XmlAttribute] public string zipCode { get; set; }
        [XmlAttribute] public string country { get; set; }
        [XmlAttribute] public string email { get; set; }
        [XmlAttribute] public string telephone { get; set; }
        [XmlAttribute] public string fax { get; set; }
        [XmlAttribute] public string occupation { get; set; }
    }

    [Serializable()]
    public class FileItem
    {
        [XmlAttribute] public string key { get; set; }
        [XmlAttribute] public string fileName { get; set; }
        [XmlAttribute] public string fileNamePath { get; set; }
        [XmlAttribute] public string fileTitle { get; set; }
        [XmlAttribute] public string fileDescription { get; set; }
        [XmlAttribute] public string fileLanguage { get; set; }
        [XmlAttribute] public string fileQuestionCount { get; set; }
        [XmlAttribute] public string fileDate { get; set; }
        [XmlAttribute] public string fileSize { get; set; }
        [XmlAttribute] public string fileGUID { get; set; }
        [XmlAttribute] public string fileType { get; set; }
    }
}
