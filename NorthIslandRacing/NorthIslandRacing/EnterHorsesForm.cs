using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthIslandRacing
{
    public partial class EnterHorsesForm : Form
    {
        private DataModule DM;
        private MainForm frmMenu;
        private CurrencyManager cmHorse;
        private CurrencyManager cmRace;
        private CurrencyManager cmEntry;
        private string RaceStatus = "";

        public EnterHorsesForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            cmHorse = (CurrencyManager)this.BindingContext[DM.dsNorthIslandRacing, "HORSE"];
            cmRace = (CurrencyManager)this.BindingContext[DM.dsNorthIslandRacing, "RACE"];
            cmEntry = (CurrencyManager)this.BindingContext[DM.dsNorthIslandRacing, "ENTRY"];
            BindControls();
            
            txtOwnerLastName.Enabled = false;
            txtOwnerFirstName.Enabled = false;
            txtMeetingName.Enabled = false;

            cmbStatus.Items.Add("Confirmed");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Disqualified");
            cmbStatus.SelectedItem = "Confirmed";
            
        }

        public void BindControls()
        {
            dgvHorse.DataSource = DM.dsNorthIslandRacing;
            dgvHorse.DataMember = "Horse";

            dgvRace.DataSource = DM.dsNorthIslandRacing;
            dgvRace.DataMember = "Race";

            dgvEntry.DataSource = DM.dsNorthIslandRacing;
            dgvEntry.DataMember = "Entry";

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        //This method sets the LastName and FirstName of Owner relative to the OwnerID
        public void setOwnerFields()
        {
            int selectedrowindex = dgvHorse.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvHorse.Rows[selectedrowindex];
            
            string selectedID = Convert.ToString(selectedRow.Cells["OwnerID"].Value);
            string searchExpression = "OwnerID = " + selectedID;
            DataRow[] dr = DM.dtOwner.Select(searchExpression);


            foreach (DataRow row in dr)
            {
                if (row["OwnerID"].ToString() == selectedID)
                {
                    txtOwnerLastName.Text = row["LastName"].ToString();
                    txtOwnerFirstName.Text = row["FirstName"].ToString();
                }
            }
        }
        
        //This method sets the meeting name relative to MeetingID
        public void setMeetingField()
        {
            int selectedrowindex1 = dgvRace.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow1 = dgvRace.Rows[selectedrowindex1];
            string selectedID1 = Convert.ToString(selectedRow1.Cells["MeetingID"].Value);
            string searchExpression1 = "MeetingID = " + selectedID1;
            DataRow[] dr = DM.dtMeeting.Select(searchExpression1);


            foreach (DataRow row in dr)
            {
                if (row["MeetingID"].ToString() == selectedID1)
                {
                    txtMeetingName.Text = row["MeetingName"].ToString();
                }
            }
        }

        //This metod finds the Status of Race relative to the RaceID
        public void findRaceStatus()
        {
            int selectedrowindex2 = dgvRace.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow2 = dgvRace.Rows[selectedrowindex2];
            string selectedID2 = Convert.ToString(selectedRow2.Cells["RaceID"].Value);
            string searchExpression2 = "RaceID = " + selectedID2;
            DataRow[] dr = DM.dtRace.Select(searchExpression2);


            foreach (DataRow row in dr)
            {
                if (row["RaceID"].ToString() == selectedID2)
                {
                    RaceStatus = row["Status"].ToString();
                }
            }
        }

        private void dgvHorse_Click(object sender, EventArgs e)
        {
            setOwnerFields();
        }

        private void EnterHorsesForm_Shown(object sender, EventArgs e)
        {
            setOwnerFields();
            setMeetingField();
        }

        private void dgvRace_Click(object sender, EventArgs e)
        {
            setMeetingField();
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            findRaceStatus();
            try
            {
                if (RaceStatus == "Scheduled")
                {
                    DataRow newEntry = DM.dtEntry.NewRow();

                    int selectedRaceRow = dgvRace.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow1 = dgvRace.Rows[selectedRaceRow];
                    newEntry["RaceID"] = Convert.ToString(selectedRow1.Cells["RaceID"].Value);

                    int selectedHorseRow = dgvHorse.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvHorse.Rows[selectedHorseRow];
                    newEntry["HorseID"] = Convert.ToString(selectedRow.Cells["HorseID"].Value);
                    newEntry["Status"] = cmbStatus.Text;

                    DM.dsNorthIslandRacing.Tables["Entry"].Rows.Add(newEntry); //add a new row to dataset                  
                    DM.UpdateEntry(); //update database
                    MessageBox.Show("Entry added successfully", "Success");
                }
                else
                {
                    MessageBox.Show("Horses can only be entered to scheduled races", "Error");
                }
            }
            catch (ConstraintException)
            {
                MessageBox.Show("This horse has already been added to the race", "Error");
            }
        }

        private void btnRemoveEntry_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this entry?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Get the string value of raceId and HorseID
                int selectedEntryRow = dgvEntry.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow2 = dgvEntry.Rows[selectedEntryRow];
                string raceID = Convert.ToString(selectedRow2.Cells["RaceID"].Value);
                string horseID = dgvEntry.Rows[selectedEntryRow].Cells[1].Value.ToString();
                
                int row = 0;

                //Compare to retrieve the matching record in the datatable
                for (int i = 0; i < DM.dtEntry.Rows.Count; i++)
                {
                    string rID = DM.dtEntry.Rows[i]["RaceID"].ToString();
                    string hID = DM.dtEntry.Rows[i]["HorseID"].ToString();

                    if (raceID == rID && horseID == hID)
                    {
                        row = i;
                    }
                }

                DataRow dr = DM.dsNorthIslandRacing.Tables["Entry"].Rows[row];
                dr.Delete();
                DM.UpdateEntry();    //update database 
                MessageBox.Show("Entry removed successfully", "Success");
            }
        }
    }
}
