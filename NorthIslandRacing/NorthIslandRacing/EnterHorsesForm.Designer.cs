namespace NorthIslandRacing
{
    partial class EnterHorsesForm
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
            this.dgvHorse = new System.Windows.Forms.DataGridView();
            this.dgvRace = new System.Windows.Forms.DataGridView();
            this.dgvEntry = new System.Windows.Forms.DataGridView();
            this.txtOwnerLastName = new System.Windows.Forms.TextBox();
            this.lblOwnerLastName = new System.Windows.Forms.Label();
            this.lblOwnerFirstName = new System.Windows.Forms.Label();
            this.txtOwnerFirstName = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblMeetingName = new System.Windows.Forms.Label();
            this.txtMeetingName = new System.Windows.Forms.TextBox();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.btnRemoveEntry = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHorse
            // 
            this.dgvHorse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorse.Location = new System.Drawing.Point(13, 12);
            this.dgvHorse.Name = "dgvHorse";
            this.dgvHorse.RowTemplate.Height = 28;
            this.dgvHorse.Size = new System.Drawing.Size(841, 300);
            this.dgvHorse.TabIndex = 0;
            this.dgvHorse.Click += new System.EventHandler(this.dgvHorse_Click);
            // 
            // dgvRace
            // 
            this.dgvRace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRace.Location = new System.Drawing.Point(13, 339);
            this.dgvRace.Name = "dgvRace";
            this.dgvRace.RowTemplate.Height = 28;
            this.dgvRace.Size = new System.Drawing.Size(986, 316);
            this.dgvRace.TabIndex = 1;
            this.dgvRace.Click += new System.EventHandler(this.dgvRace_Click);
            // 
            // dgvEntry
            // 
            this.dgvEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntry.Location = new System.Drawing.Point(1042, 339);
            this.dgvEntry.Name = "dgvEntry";
            this.dgvEntry.RowTemplate.Height = 28;
            this.dgvEntry.Size = new System.Drawing.Size(503, 316);
            this.dgvEntry.TabIndex = 2;
            // 
            // txtOwnerLastName
            // 
            this.txtOwnerLastName.Location = new System.Drawing.Point(1238, 34);
            this.txtOwnerLastName.Name = "txtOwnerLastName";
            this.txtOwnerLastName.Size = new System.Drawing.Size(182, 26);
            this.txtOwnerLastName.TabIndex = 3;
            // 
            // lblOwnerLastName
            // 
            this.lblOwnerLastName.AutoSize = true;
            this.lblOwnerLastName.Location = new System.Drawing.Point(1070, 34);
            this.lblOwnerLastName.Name = "lblOwnerLastName";
            this.lblOwnerLastName.Size = new System.Drawing.Size(140, 20);
            this.lblOwnerLastName.TabIndex = 4;
            this.lblOwnerLastName.Text = "Owner Last Name:";
            // 
            // lblOwnerFirstName
            // 
            this.lblOwnerFirstName.AutoSize = true;
            this.lblOwnerFirstName.Location = new System.Drawing.Point(1070, 83);
            this.lblOwnerFirstName.Name = "lblOwnerFirstName";
            this.lblOwnerFirstName.Size = new System.Drawing.Size(140, 20);
            this.lblOwnerFirstName.TabIndex = 5;
            this.lblOwnerFirstName.Text = "Owner First Name:";
            // 
            // txtOwnerFirstName
            // 
            this.txtOwnerFirstName.Location = new System.Drawing.Point(1238, 83);
            this.txtOwnerFirstName.Name = "txtOwnerFirstName";
            this.txtOwnerFirstName.Size = new System.Drawing.Size(182, 26);
            this.txtOwnerFirstName.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1150, 136);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(1238, 136);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 28);
            this.cmbStatus.TabIndex = 8;
            // 
            // lblMeetingName
            // 
            this.lblMeetingName.AutoSize = true;
            this.lblMeetingName.Location = new System.Drawing.Point(699, 689);
            this.lblMeetingName.Name = "lblMeetingName";
            this.lblMeetingName.Size = new System.Drawing.Size(116, 20);
            this.lblMeetingName.TabIndex = 9;
            this.lblMeetingName.Text = "Meeting Name:";
            // 
            // txtMeetingName
            // 
            this.txtMeetingName.Location = new System.Drawing.Point(849, 689);
            this.txtMeetingName.Name = "txtMeetingName";
            this.txtMeetingName.Size = new System.Drawing.Size(182, 26);
            this.txtMeetingName.TabIndex = 10;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(13, 756);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(151, 41);
            this.btnAddEntry.TabIndex = 64;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // btnRemoveEntry
            // 
            this.btnRemoveEntry.Location = new System.Drawing.Point(849, 756);
            this.btnRemoveEntry.Name = "btnRemoveEntry";
            this.btnRemoveEntry.Size = new System.Drawing.Size(151, 41);
            this.btnRemoveEntry.TabIndex = 65;
            this.btnRemoveEntry.Text = "Remove Entry";
            this.btnRemoveEntry.UseVisualStyleBackColor = true;
            this.btnRemoveEntry.Click += new System.EventHandler(this.btnRemoveEntry_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(1394, 756);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(151, 41);
            this.btnReturn.TabIndex = 66;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // EnterHorsesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 819);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRemoveEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.txtMeetingName);
            this.Controls.Add(this.lblMeetingName);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtOwnerFirstName);
            this.Controls.Add(this.lblOwnerFirstName);
            this.Controls.Add(this.lblOwnerLastName);
            this.Controls.Add(this.txtOwnerLastName);
            this.Controls.Add(this.dgvEntry);
            this.Controls.Add(this.dgvRace);
            this.Controls.Add(this.dgvHorse);
            this.Name = "EnterHorsesForm";
            this.Text = "Enter Horses Into Races";
            this.Shown += new System.EventHandler(this.EnterHorsesForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHorse;
        private System.Windows.Forms.DataGridView dgvRace;
        private System.Windows.Forms.DataGridView dgvEntry;
        private System.Windows.Forms.TextBox txtOwnerLastName;
        private System.Windows.Forms.Label lblOwnerLastName;
        private System.Windows.Forms.Label lblOwnerFirstName;
        private System.Windows.Forms.TextBox txtOwnerFirstName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblMeetingName;
        private System.Windows.Forms.TextBox txtMeetingName;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.Button btnRemoveEntry;
        private System.Windows.Forms.Button btnReturn;
    }
}