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
namespace Delphinus
{
    partial class VerifierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifierForm));
            this.lblLogo = new System.Windows.Forms.PictureBox();
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblIntro = new System.Windows.Forms.Label();
            this.btnClipboard = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.lblMissingFiles = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).BeginInit();
            this.pnlHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.Image = global::Delphinus.Properties.Resources.DelphinusLogo_256;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(72, 72);
            this.lblLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblLogo.TabIndex = 13;
            this.lblLogo.TabStop = false;
            // 
            // pnlHeading
            // 
            this.pnlHeading.Controls.Add(this.lblCompany);
            this.pnlHeading.Controls.Add(this.lblTitle);
            this.pnlHeading.Controls.Add(this.lblLink);
            this.pnlHeading.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeading.Location = new System.Drawing.Point(72, 0);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(280, 72);
            this.pnlHeading.TabIndex = 19;
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblCompany.Location = new System.Drawing.Point(0, 26);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(298, 22);
            this.lblCompany.TabIndex = 6;
            this.lblCompany.Text = "Copyright 2021 Delphinus Consulting, LLC";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(298, 25);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "CTP Transmittal File Verification\r\n";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLink
            // 
            this.lblLink.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.LinkArea = new System.Windows.Forms.LinkArea(0, 27);
            this.lblLink.Location = new System.Drawing.Point(0, 50);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(298, 22);
            this.lblLink.TabIndex = 5;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "www.DelphinusConsulting.com";
            this.lblLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(10, 205);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(138, 43);
            this.btnSelect.TabIndex = 17;
            this.btnSelect.Text = "Select Zip File";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnReview
            // 
            this.btnReview.Enabled = false;
            this.btnReview.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReview.Location = new System.Drawing.Point(244, 207);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(138, 43);
            this.btnReview.TabIndex = 18;
            this.btnReview.Text = "Run Review";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(244, 318);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 43);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisclaimer.Location = new System.Drawing.Point(0, 376);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Padding = new System.Windows.Forms.Padding(6);
            this.lblDisclaimer.Size = new System.Drawing.Size(406, 84);
            this.lblDisclaimer.TabIndex = 22;
            this.lblDisclaimer.Text = resources.GetString("lblDisclaimer.Text");
            // 
            // lblFile
            // 
            this.lblFile.AutoEllipsis = true;
            this.lblFile.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(4, 281);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(417, 24);
            this.lblFile.TabIndex = 15;
            this.lblFile.Text = "(Select a zip file)";
            // 
            // lblIntro
            // 
            this.lblIntro.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.Location = new System.Drawing.Point(0, 81);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Padding = new System.Windows.Forms.Padding(6);
            this.lblIntro.Size = new System.Drawing.Size(406, 122);
            this.lblIntro.TabIndex = 16;
            this.lblIntro.Text = resources.GetString("lblIntro.Text");
            // 
            // btnClipboard
            // 
            this.btnClipboard.Enabled = false;
            this.btnClipboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClipboard.Location = new System.Drawing.Point(10, 318);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(138, 43);
            this.btnClipboard.TabIndex = 20;
            this.btnClipboard.Text = "Copy To Clipboard";
            this.btnClipboard.UseVisualStyleBackColor = true;
            this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(4, 262);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(110, 18);
            this.lblCaption.TabIndex = 14;
            this.lblCaption.Text = "Transmittal File:";
            // 
            // tbResults
            // 
            this.tbResults.Location = new System.Drawing.Point(424, 92);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.ShortcutsEnabled = false;
            this.tbResults.Size = new System.Drawing.Size(283, 368);
            this.tbResults.TabIndex = 23;
            this.tbResults.WordWrap = false;
            // 
            // lblMissingFiles
            // 
            this.lblMissingFiles.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblMissingFiles.Location = new System.Drawing.Point(424, 68);
            this.lblMissingFiles.Name = "lblMissingFiles";
            this.lblMissingFiles.Size = new System.Drawing.Size(283, 23);
            this.lblMissingFiles.TabIndex = 24;
            this.lblMissingFiles.Text = "Review Results:";
            this.lblMissingFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VerifierForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(707, 459);
            this.Controls.Add(this.lblMissingFiles);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.pnlHeading);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblDisclaimer);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.btnClipboard);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VerifierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delphinus Transmittal Verifier";
            ((System.ComponentModel.ISupportInitialize)(this.lblLogo)).EndInit();
            this.pnlHeading.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox lblLogo;
        private System.Windows.Forms.Panel pnlHeading;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel lblLink;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblDisclaimer;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Button btnClipboard;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Label lblMissingFiles;
    }
}

