using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthIslandRacing
{
    public partial class MeetingForm : Form
    {
        private DataModule DM;
        private MainForm frmMenu;
        private CurrencyManager currencyManager;

        public MeetingForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            BindControls();
            pnlAddMeeting.Visible = false;
            pnlUpdateMeeting.Visible = false;

            dtpMeetingDate1.Format = DateTimePickerFormat.Custom;
            dtpMeetingDate1.CustomFormat = "dd'/'MM'/'yyyy'";

            dtpMeetingDate2.Format = DateTimePickerFormat.Custom;
            dtpMeetingDate2.CustomFormat = "dd'/'MM'/'yyyy'";

            lblMID2.Enabled = false;
            txtRaceCourseName2.Enabled = false;

            cmbStatus1.Items.Add("Confirmed");
            cmbStatus1.Items.Add("Unconfirmed");
            cmbStatus1.Items.Add("Cancelled");
            cmbStatus1.SelectedItem = "Unconfirmed";
            cmbStatus2.Items.Add("Confirmed");
            cmbStatus2.Items.Add("Unconfirmed");
            cmbStatus2.Items.Add("Cancelled");
            cmbStatus2.SelectedItem = "Unconfirmed";

            txtMeetingName.Enabled = false;
            txtRID.Enabled = false;
            txtRaceCourseName.Enabled = false;
            txtStatus.Enabled = false;
            txtCapacity.Enabled = false;
            txtMeetingDate.Enabled = false;
        }

        public void BindControls()
        {
            lblMID.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Meeting.MeetingID");
            txtMeetingName.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Meeting.meetingName");
            txtRID.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Meeting.RaceCourseID");
            txtStatus.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Meeting.Status");
            txtCapacity.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Meeting.Capacity");
            txtMeetingDate.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Meeting.MeetingDate");
            
            lstMeeting.DataSource = DM.dsNorthIslandRacing;
            lstMeeting.DisplayMember = "Meeting.MeetingID";
            lstMeeting.ValueMember = "Meeting.MeetingID";
            currencyManager = (CurrencyManager)this.BindingContext[DM.dsNorthIslandRacing, "MEETING"];
            
        }

        //This method finds the RaceCourseName relative to the RaceCourseID
        public void findNames()
        {
            string searchExpression = "RaceCourseID = " + txtRID.Text.ToString();
            DataRow[] dr = DM.dtRaceCourse.Select(searchExpression);


            foreach (DataRow row in dr)
            {
                if (row["RaceCourseID"].ToString() == txtRID.Text.ToString())
                {
                    txtRaceCourseName.Text = row["RaceCourseName"].ToString();
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currencyManager.Position > 0)
            {
                --currencyManager.Position;
                findNames();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currencyManager.Position < currencyManager.Count - 1)
            {
                ++currencyManager.Position;
                findNames();
            }
        }

        private void lstMeeting_Click(object sender, EventArgs e)
        {
            currencyManager.Position = lstMeeting.SelectedIndex;
            findNames();
        }

        private void MeetingForm_Shown(object sender, EventArgs e)
        {
            findNames();
        }

        private void btnAddMeeting_Click(object sender, EventArgs e)
        {
            pnlAddMeeting.Visible = true;
            lstMeeting.Visible = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnUpdateMeeting.Enabled = false;
            btnDeleteMeeting.Enabled = false;
            btnReturn.Enabled = false;
            

            cmbRID1.DataSource = DM.dsNorthIslandRacing;
            cmbRID1.ValueMember = "RaceCourse.RaceCourseID";
            cmbRaceCourseName1.DataSource = DM.dsNorthIslandRacing;
            cmbRaceCourseName1.ValueMember = "RaceCourse.RaceCourseName";
            
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            pnlAddMeeting.Visible = false;
            lstMeeting.Visible = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnUpdateMeeting.Enabled = true;
            btnDeleteMeeting.Enabled = true;
            btnReturn.Enabled = true;
        }

        private void btnSaveMeeting1_Click(object sender, EventArgs e)
        {
            DataRow newMeetingRow = DM.dtMeeting.NewRow();

            if ((txtMeetingName1.Text == "") || (numCapacity1.Value.ToString() == ""))
            {
                MessageBox.Show("You must enter a value for each of the text fields", "Error");
            }
            else if(int.Parse(numCapacity1.Value.ToString()) <= 1000 || int.Parse(numCapacity1.Value.ToString()) >= 20000)
            {
                MessageBox.Show("You must enter a value for capacity more than 1000 and less than 20000", "Error");
            }
            else
            {

                newMeetingRow["MeetingName"] = txtMeetingName1.Text;
                newMeetingRow["RaceCourseID"] = int.Parse(cmbRID1.Text);
                newMeetingRow["Status"] = cmbStatus1.Text;
                newMeetingRow["Capacity"] = int.Parse(numCapacity1.Value.ToString());
                newMeetingRow["MeetingDate"] = dtpMeetingDate1.Value.ToString();

                //Add the new row to the Table  
                DM.dtMeeting.Rows.Add(newMeetingRow);
                DM.UpdateMeeting();
                //Give the user a success message   
                MessageBox.Show("Meeting added successfully", "Success");

                pnlAddMeeting.Visible = false;
                lstMeeting.Visible = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnUpdateMeeting.Enabled = true;
                btnDeleteMeeting.Enabled = true;
                btnReturn.Enabled = true;
            }
        }

        private void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
            DataRow deleteMeetingRow = DM.dtMeeting.Rows[currencyManager.Position];
            DataRow[] RaceRow = DM.dtRace.Select("MeetingID = " + lblMID.Text);
            if (RaceRow.Length != 0)
            {
                MessageBox.Show("You may only delete meetings that have no races", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteMeetingRow.Delete();
                    DM.UpdateMeeting();
                    MessageBox.Show("Meeting deleted successfully", "Success");
                }
            }
        }

        private void btnUpdateMeeting_Click(object sender, EventArgs e)
        {
            pnlUpdateMeeting.Visible = true;
            lstMeeting.Visible = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnAddMeeting.Enabled = false;
            btnDeleteMeeting.Enabled = false;
            btnReturn.Enabled = false;

            lblMID2.Text = lblMID.Text;
            txtMeetingName2.Text = txtMeetingName.Text;
            txtRID2.Text = txtRID.Text;
            txtRaceCourseName2.Text = txtRaceCourseName.Text;
            
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            pnlUpdateMeeting.Visible = false;
            lstMeeting.Visible = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnAddMeeting.Enabled = true;
            btnDeleteMeeting.Enabled = true;
            btnReturn.Enabled = true;
        }

        private void btnSaveChanges2_Click(object sender, EventArgs e)
        {
            DataRow updateMeetingRow = DM.dtMeeting.Rows[currencyManager.Position];

            if ((txtMeetingName2.Text == "") || (numCapacity2.Value.ToString() == ""))
            {
                MessageBox.Show("You must enter a value for each of the text fields", "Error");
            }
            else if (int.Parse(numCapacity2.Value.ToString()) <= 1000 || int.Parse(numCapacity2.Value.ToString()) >= 20000)
            {
                MessageBox.Show("You must enter a value for capacity more than 1000 and less than 20000", "Error");
            }
            else
            {

                updateMeetingRow["MeetingName"] = txtMeetingName2.Text;
                updateMeetingRow["Status"] = cmbStatus2.Text;
                updateMeetingRow["Capacity"] = int.Parse(numCapacity2.Value.ToString());
                updateMeetingRow["MeetingDate"] = dtpMeetingDate2.Value.ToString();
                currencyManager.EndCurrentEdit();
                DM.UpdateMeeting();
                MessageBox.Show("Meeting updated successfully", "Success");

                pnlUpdateMeeting.Visible = false;
                lstMeeting.Visible = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnAddMeeting.Enabled = true;
                btnDeleteMeeting.Enabled = true;
                btnReturn.Enabled = true;
            }
        }
    }
}
