namespace NorthIslandRacing
{
    partial class MainForm
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
            this.grpMaintanance = new System.Windows.Forms.GroupBox();
            this.btnEnterHorsesIntoRaces = new System.Windows.Forms.Button();
            this.btnHorse = new System.Windows.Forms.Button();
            this.btnOwner = new System.Windows.Forms.Button();
            this.btnRace = new System.Windows.Forms.Button();
            this.btnMeeting = new System.Windows.Forms.Button();
            this.btnRaceCourse = new System.Windows.Forms.Button();
            this.grpReporting = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOwnersReport = new System.Windows.Forms.Button();
            this.btnMeetingsReport = new System.Windows.Forms.Button();
            this.grpMaintanance.SuspendLayout();
            this.grpReporting.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMaintanance
            // 
            this.grpMaintanance.Controls.Add(this.btnEnterHorsesIntoRaces);
            this.grpMaintanance.Controls.Add(this.btnHorse);
            this.grpMaintanance.Controls.Add(this.btnOwner);
            this.grpMaintanance.Controls.Add(this.btnRace);
            this.grpMaintanance.Controls.Add(this.btnMeeting);
            this.grpMaintanance.Controls.Add(this.btnRaceCourse);
            this.grpMaintanance.Location = new System.Drawing.Point(68, 34);
            this.grpMaintanance.Name = "grpMaintanance";
            this.grpMaintanance.Size = new System.Drawing.Size(310, 393);
            this.grpMaintanance.TabIndex = 0;
            this.grpMaintanance.TabStop = false;
            this.grpMaintanance.Text = "Maintanance";
            // 
            // btnEnterHorsesIntoRaces
            // 
            this.btnEnterHorsesIntoRaces.Location = new System.Drawing.Point(36, 321);
            this.btnEnterHorsesIntoRaces.Name = "btnEnterHorsesIntoRaces";
            this.btnEnterHorsesIntoRaces.Size = new System.Drawing.Size(237, 32);
            this.btnEnterHorsesIntoRaces.TabIndex = 5;
            this.btnEnterHorsesIntoRaces.Text = "Enter Horses into Races";
            this.btnEnterHorsesIntoRaces.UseVisualStyleBackColor = true;
            this.btnEnterHorsesIntoRaces.Click += new System.EventHandler(this.btnEnterHorsesIntoRaces_Click);
            // 
            // btnHorse
            // 
            this.btnHorse.Location = new System.Drawing.Point(36, 261);
            this.btnHorse.Name = "btnHorse";
            this.btnHorse.Size = new System.Drawing.Size(237, 32);
            this.btnHorse.TabIndex = 4;
            this.btnHorse.Text = "Horse Maintanance";
            this.btnHorse.UseVisualStyleBackColor = true;
            this.btnHorse.Click += new System.EventHandler(this.btnHorse_Click);
            // 
            // btnOwner
            // 
            this.btnOwner.Location = new System.Drawing.Point(36, 203);
            this.btnOwner.Name = "btnOwner";
            this.btnOwner.Size = new System.Drawing.Size(237, 32);
            this.btnOwner.TabIndex = 3;
            this.btnOwner.Text = "Owner Maintanance";
            this.btnOwner.UseVisualStyleBackColor = true;
            this.btnOwner.Click += new System.EventHandler(this.btnOwner_Click);
            // 
            // btnRace
            // 
            this.btnRace.Location = new System.Drawing.Point(36, 145);
            this.btnRace.Name = "btnRace";
            this.btnRace.Size = new System.Drawing.Size(237, 32);
            this.btnRace.TabIndex = 2;
            this.btnRace.Text = "Race Maintanance";
            this.btnRace.UseVisualStyleBackColor = true;
            this.btnRace.Click += new System.EventHandler(this.btnRace_Click);
            // 
            // btnMeeting
            // 
            this.btnMeeting.Location = new System.Drawing.Point(36, 90);
            this.btnMeeting.Name = "btnMeeting";
            this.btnMeeting.Size = new System.Drawing.Size(237, 32);
            this.btnMeeting.TabIndex = 1;
            this.btnMeeting.Text = "Meeting Maintanance";
            this.btnMeeting.UseVisualStyleBackColor = true;
            this.btnMeeting.Click += new System.EventHandler(this.btnMeeting_Click);
            // 
            // btnRaceCourse
            // 
            this.btnRaceCourse.Location = new System.Drawing.Point(36, 37);
            this.btnRaceCourse.Name = "btnRaceCourse";
            this.btnRaceCourse.Size = new System.Drawing.Size(237, 32);
            this.btnRaceCourse.TabIndex = 0;
            this.btnRaceCourse.Text = "Race Course Maintanance";
            this.btnRaceCourse.UseVisualStyleBackColor = true;
            this.btnRaceCourse.Click += new System.EventHandler(this.btnRaceCourse_Click);
            // 
            // grpReporting
            // 
            this.grpReporting.Controls.Add(this.btnExit);
            this.grpReporting.Controls.Add(this.btnOwnersReport);
            this.grpReporting.Controls.Add(this.btnMeetingsReport);
            this.grpReporting.Location = new System.Drawing.Point(466, 44);
            this.grpReporting.Name = "grpReporting";
            this.grpReporting.Size = new System.Drawing.Size(241, 383);
            this.grpReporting.TabIndex = 1;
            this.grpReporting.TabStop = false;
            this.grpReporting.Text = "Reporting";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(21, 311);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(201, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOwnersReport
            // 
            this.btnOwnersReport.Location = new System.Drawing.Point(21, 80);
            this.btnOwnersReport.Name = "btnOwnersReport";
            this.btnOwnersReport.Size = new System.Drawing.Size(201, 32);
            this.btnOwnersReport.TabIndex = 2;
            this.btnOwnersReport.Text = "Owners Report";
            this.btnOwnersReport.UseVisualStyleBackColor = true;
            this.btnOwnersReport.Click += new System.EventHandler(this.btnOwnersReport_Click);
            // 
            // btnMeetingsReport
            // 
            this.btnMeetingsReport.Location = new System.Drawing.Point(21, 27);
            this.btnMeetingsReport.Name = "btnMeetingsReport";
            this.btnMeetingsReport.Size = new System.Drawing.Size(201, 32);
            this.btnMeetingsReport.TabIndex = 1;
            this.btnMeetingsReport.Text = "Meetings Report";
            this.btnMeetingsReport.UseVisualStyleBackColor = true;
            this.btnMeetingsReport.Click += new System.EventHandler(this.btnMeetingsReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpReporting);
            this.Controls.Add(this.grpMaintanance);
            this.Name = "MainForm";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpMaintanance.ResumeLayout(false);
            this.grpReporting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaintanance;
        private System.Windows.Forms.Button btnMeeting;
        private System.Windows.Forms.Button btnRaceCourse;
        private System.Windows.Forms.Button btnRace;
        private System.Windows.Forms.Button btnOwner;
        private System.Windows.Forms.Button btnHorse;
        private System.Windows.Forms.Button btnEnterHorsesIntoRaces;
        private System.Windows.Forms.GroupBox grpReporting;
        private System.Windows.Forms.Button btnOwnersReport;
        private System.Windows.Forms.Button btnMeetingsReport;
        private System.Windows.Forms.Button btnExit;
    }
}

