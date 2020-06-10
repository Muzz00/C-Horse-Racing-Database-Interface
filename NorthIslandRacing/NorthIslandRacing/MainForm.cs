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
    public partial class MainForm : Form
    {
        private DataModule DM;
        private HorseForm frmHorse;
        private RaceForm frmRace;
        private RaceCourseForm frmRaceCourse;
        private OwnerForm frmOwner;
        private MeetingForm frmMeeting;
        private EnterHorsesForm frmEnterHorses;
        private MeetingsReportForm frmMeetingsReport;
        private OwnersReportForm frmOwnersReport;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DM = new DataModule(); //create the data module and load the dataset 
        }

        private void btnRaceCourse_Click(object sender, EventArgs e)
        {
            if (frmRaceCourse == null)
            {
                frmRaceCourse = new RaceCourseForm(DM, this);
            }
            frmRaceCourse.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            if (frmOwner == null)
            {
                frmOwner = new OwnerForm(DM, this);
            }
            frmOwner.ShowDialog();
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            if (frmRace == null)
            {
                frmRace = new RaceForm(DM, this);
            }
            frmRace.ShowDialog();
        }

        private void btnHorse_Click(object sender, EventArgs e)
        {
            if (frmHorse == null)
            {
                frmHorse = new HorseForm(DM, this);
            }
            frmHorse.ShowDialog();
        }

        private void btnMeeting_Click(object sender, EventArgs e)
        {
            if (frmMeeting == null)
            {
                frmMeeting = new MeetingForm(DM, this);
            }
            frmMeeting.ShowDialog();
        }

        private void btnEnterHorsesIntoRaces_Click(object sender, EventArgs e)
        {
            if (frmEnterHorses == null)
            {
                frmEnterHorses = new EnterHorsesForm(DM, this);
                frmEnterHorses.Width = 1100;
                frmEnterHorses.Height = 600;
            }
            frmEnterHorses.ShowDialog();
        }

        private void btnOwnersReport_Click(object sender, EventArgs e)
        {
            if (frmOwnersReport == null)
            {
                frmOwnersReport = new OwnersReportForm(DM, this);
            }
            frmOwnersReport.ShowDialog();
        }

        private void btnMeetingsReport_Click(object sender, EventArgs e)
        {
            if (frmMeetingsReport == null)
            {
                frmMeetingsReport = new MeetingsReportForm(DM, this);
            }
            frmMeetingsReport.ShowDialog();
        }
    }
}
