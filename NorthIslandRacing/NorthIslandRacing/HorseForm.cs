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
    public partial class HorseForm : Form
    {
        private DataModule DM;
        private MainForm frmMenu;
        private CurrencyManager currencyManager;

        public HorseForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            BindControls();
            pnlAddHorse.Visible = false;
            pnlUpdateHorse.Visible = false;

            txtName.Enabled = false;
            txtGender.Enabled = false;
            txtDOB.Enabled = false;
            txtOwnerID.Enabled = false;
            txtOwnerLastName.Enabled = false;
            txtOwnerFirstName.Enabled = false;
            txtOwnerID2.Enabled = false;
            txtOwnerLastName2.Enabled = false;
            txtOwnerFirstName2.Enabled = false;

       
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.CustomFormat = "dd'/'MM'/'yyyy'";
            
            dtpDOB2.Format = DateTimePickerFormat.Custom;
            dtpDOB2.CustomFormat = "dd'/'MM'/'yyyy'";
            
            cmbGender1.Items.Add("Male");
            cmbGender1.Items.Add("Female");
            cmbGender1.Items.Add("Gelding");
            cmbGender1.SelectedItem = "Male";

            cmbGender2.Items.Add("Male");
            cmbGender2.Items.Add("Female");
            cmbGender2.Items.Add("Gelding");
        }

        public void BindControls()
        {
            lblHID.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Horse.HorseID");
            txtName.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Horse.HorseName");
            txtGender.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Horse.Gender");
            txtDOB.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Horse.DateOfBirth");
            txtOwnerID.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Horse.OwnerID");
            lstHorse.DataSource = DM.dsNorthIslandRacing;
            lstHorse.DisplayMember = "Horse.HorseID";
            lstHorse.ValueMember = "Horse.HorseID";
            currencyManager = (CurrencyManager)this.BindingContext[DM.dsNorthIslandRacing, "HORSE"];
        }
        

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstHorse_Click(object sender, EventArgs e)
        {
            currencyManager.Position = lstHorse.SelectedIndex;
            findNames();
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

        //This method finds the Owner's LastName and FirstName relative to the OwnerID
        public void findNames()
        {
            string searchExpression = "OwnerID = " + txtOwnerID.Text.ToString();
            DataRow[] dr = DM.dtOwner.Select(searchExpression);


            foreach (DataRow row in dr)
            {
                if (row["OwnerID"].ToString() == txtOwnerID.Text.ToString())
                {
                    txtOwnerLastName.Text = row["LastName"].ToString();
                    txtOwnerFirstName.Text = row["FirstName"].ToString();
                }
            }
        }

        private void btnAddHorse_Click(object sender, EventArgs e)
        {
            pnlAddHorse.Visible = true;
            lstHorse.Visible = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnUpdateHorse.Enabled = false;
            btnDeleteHorse.Enabled = false;
            btnReturn.Enabled = false;
            

            cmbOwnerID1.DataSource = DM.dsNorthIslandRacing;
            cmbOwnerID1.ValueMember = "Owner.OwnerID";
            cmbLastName1.DataSource = DM.dsNorthIslandRacing;
            cmbLastName1.ValueMember = "Owner.LastName";
            cmbFirstName1.DataSource = DM.dsNorthIslandRacing;
            cmbFirstName1.ValueMember = "Owner.FirstName";
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            pnlAddHorse.Visible = false;
            lstHorse.Visible = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnUpdateHorse.Enabled = true;
            btnDeleteHorse.Enabled = true;
            btnReturn.Enabled = true;
        }

        private void btnSaveHorse1_Click(object sender, EventArgs e)
        {
            DataRow newHorseRow = DM.dtHorse.NewRow();

            if ((txtName1.Text == ""))
            {
                MessageBox.Show("You must enter a value for each of the text fields", "Error");
            }

            else
            {

                newHorseRow["HorseName"] = txtName1.Text;
                newHorseRow["Gender"] = cmbGender1.Text;
                newHorseRow["OwnerID"] = int.Parse(cmbOwnerID1.Text);
                newHorseRow["DateOfBirth"] = dtpDOB.Value.ToString();

                //Add the new row to the Table  
                DM.dtHorse.Rows.Add(newHorseRow);
                DM.UpdateHorse();
                //Give the user a success message   
                MessageBox.Show("Horse added successfully", "Success");

                pnlAddHorse.Visible = false;
                lstHorse.Visible = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnUpdateHorse.Enabled = true;
                btnDeleteHorse.Enabled = true;
                btnReturn.Enabled = true;
            }
        }

        private void HorseForm_Shown(object sender, EventArgs e)
        {
            findNames();
        }

        private void btnUpdateHorse_Click(object sender, EventArgs e)
        {
            pnlUpdateHorse.Visible = true;
            lstHorse.Visible = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnAddHorse.Enabled = false;
            btnDeleteHorse.Enabled = false;
            btnReturn.Enabled = false;

            
            cmbGender2.SelectedItem = txtGender.Text;
            dtpDOB2.DataBindings.Clear();
            txtName2.DataBindings.Clear();
            txtName2.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Horse.HorseName");
            //txtMeetingName2.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Meeting.MeetingName");
            dtpDOB2.DataBindings.Add("Text", DM.dsNorthIslandRacing, "Horse.DateOfBirth");

            txtOwnerID2.Text = txtOwnerID.Text;
            txtOwnerLastName2.Text = txtOwnerLastName.Text;
            txtOwnerFirstName2.Text = txtOwnerFirstName.Text;

            

        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            pnlUpdateHorse.Visible = false;
            lstHorse.Visible = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnAddHorse.Enabled = true;
            btnDeleteHorse.Enabled = true;
            btnReturn.Enabled = true;
        }

        private void btnSaveChanges2_Click(object sender, EventArgs e)
        {
            DataRow updateHorseRow = DM.dtHorse.Rows[currencyManager.Position];

            if ((txtName2.Text == ""))
            {
                MessageBox.Show("You must enter a value for each of the text fields", "Error");
            }
            else
            {

                updateHorseRow["HorseName"] = txtName2.Text;
                updateHorseRow["Gender"] = cmbGender2.Text;
                updateHorseRow["DateOfBirth"] = dtpDOB2.Value.ToString();
                currencyManager.EndCurrentEdit();
                DM.UpdateHorse();
                MessageBox.Show("Horse updated successfully", "Success");

                pnlUpdateHorse.Visible = false;
                lstHorse.Visible = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnAddHorse.Enabled = true;
                btnDeleteHorse.Enabled = true;
                btnReturn.Enabled = true;
            }
        }

        private void btnDeleteHorse_Click(object sender, EventArgs e)
        {
            DataRow deleteHorseRow = DM.dtHorse.Rows[currencyManager.Position];
            DataRow[] EntryRow = DM.dtEntry.Select("HorseID = " + lblHID.Text);
            if (EntryRow.Length != 0)
            {
                MessageBox.Show("You may only delete horses that have no entries", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteHorseRow.Delete();
                    DM.UpdateHorse();
                    MessageBox.Show("Horse deleted successfully", "Success");
                }
            }
        }
    }
}
