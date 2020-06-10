using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace NorthIslandRacing
{
    public partial class DataModule : Form
    {
        public DataTable dtEntry;
        public DataTable dtHorse;
        public DataTable dtRace;
        public DataTable dtRaceCourse;
        public DataTable dtOwner;
        public DataTable dtMeeting;
        //public DataTable dtEnterHorses;

        public DataView EntryView;
        public DataView HorseView;
        public DataView RaceView;
        public DataView RaceCourseView;
        public DataView OwnerView;
        public DataView MeetingView;
        public DataView EnterHorsesView;


        public DataModule()
        {
            InitializeComponent();

            dsNorthIslandRacing.EnforceConstraints = false;
            daEntry.Fill(dsNorthIslandRacing);
            daHorse.Fill(dsNorthIslandRacing);
            daRace.Fill(dsNorthIslandRacing);
            daRaceCourse.Fill(dsNorthIslandRacing);
            daOwner.Fill(dsNorthIslandRacing);
            daMeeting.Fill(dsNorthIslandRacing);
            //daEnterHorses.Fill(dsNorthIslandRacing); DOESNT NEED TO DO THIS AS IT DOESNT HAVE A DATA ADAPTER.

            dtEntry = dsNorthIslandRacing.Tables["ENTRY"];
            dtHorse = dsNorthIslandRacing.Tables["HORSE"];
            dtRace = dsNorthIslandRacing.Tables["RACE"];
            dtRaceCourse = dsNorthIslandRacing.Tables["RACECOURSE"];
            dtOwner = dsNorthIslandRacing.Tables["OWNER"];
            dtMeeting = dsNorthIslandRacing.Tables["MEETING"];

            EntryView = new DataView(dtEntry);
            EntryView.Sort = "RaceID, HorseID";
            HorseView = new DataView(dtHorse);
            HorseView.Sort = "HorseID";
            RaceView = new DataView(dtRace);
            RaceView.Sort = "RaceID";
            RaceCourseView = new DataView(dtRaceCourse);
            RaceCourseView.Sort = "RaceCourseID";
            OwnerView = new DataView(dtOwner);
            OwnerView.Sort = "OwnerID";
            MeetingView = new DataView(dtMeeting);
            MeetingView.Sort = "MeetingID";
            dsNorthIslandRacing.EnforceConstraints = true;
        }

        public void UpdateRaceCourse() {
            daRaceCourse.Update(dtRaceCourse);
        }

        public void UpdateOwner()
        {
            daOwner.Update(dtOwner);
        }

        public void UpdateRace()
        {
            daRace.Update(dtRace);   
        }

        public void UpdateHorse()
        {
            daHorse.Update(dtHorse);
        }

        public void UpdateMeeting()
        {
            daMeeting.Update(dtMeeting);
        }

        public void UpdateEntry()
        {
            daEntry.Update(dtEntry);
        }
    }
}
