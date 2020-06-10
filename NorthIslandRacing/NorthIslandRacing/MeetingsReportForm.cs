using System;
using System.Collections;
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
    public partial class MeetingsReportForm : Form
    {
        private DataModule DM;
        private MainForm frmMenu;
        ArrayList PrintDataPages = new ArrayList();
        private int currentPrintIndex;

        public MeetingsReportForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            e.Graphics.DrawString((string)PrintDataPages[currentPrintIndex], new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
            ++currentPrintIndex;
            if (currentPrintIndex < PrintDataPages.Count)
            {
                e.HasMorePages = true;
                return;
            }
            e.HasMorePages = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        //This method generate all the data which neeeds to be printed
        public void generateContents()
        {
            CurrencyManager cmMeeting;
            cmMeeting = (CurrencyManager)this.BindingContext[DM.dsNorthIslandRacing, "MEETING"];

            foreach (DataRow drMeetings in DM.dtMeeting.Rows)
            {

                int aMeetingID = Convert.ToInt32(drMeetings["MeetingID"].ToString());
                cmMeeting.Position = DM.MeetingView.Find(aMeetingID);
                DataRow drMeeting = DM.dtMeeting.Rows[cmMeeting.Position];
                
                DataRow[] drMeeted = drMeeting.GetChildRows(DM.dtMeeting.ChildRelations["FK_MEETING_RACE"]);

                string data = "";
                data += "Meeting ID: " + drMeeting["MeetingID"] + "\r\n\r\n";
                data += drMeeting["MeetingName"] + "\r\n";

                string searchExpression = "RaceCourseID = " + drMeeting["RaceCourseID"].ToString();
                DataRow[] drRaceCourse = DM.dtRaceCourse.Select(searchExpression);
                foreach (DataRow racecourseRow in drRaceCourse)
                {
                    if (racecourseRow["RaceCourseID"].ToString() == drMeeting["RaceCourseID"].ToString())
                    {
                        data += racecourseRow["RaceCourseName"] + "\r\n";
                        data += racecourseRow["StreetAddress"] + "\r\n";
                        data += racecourseRow["Suburb"] + "\r\n";
                        data += racecourseRow["City"] + "\r\n\r\n";
                    }
                }
                data += "MeetingDate:\t" + drMeeting["MeetingDate"] + "\r\n\r\n";

                data += "Races:\r\n\r\n";

                if (drMeeted.Length > 0)
                {
                    data += "\t" + "ID" + "\t" + "Name" + "\t\t" + "Time" + "\r\n";


                    foreach (DataRow drM in drMeeted)
                    {
                        string searchExpressionRace = "RaceID = " + drM["RaceID"].ToString();
                        DataRow[] drRace = DM.dtRace.Select(searchExpressionRace);
                        foreach (DataRow raceRow in drRace)
                        {
                            if (raceRow["RaceID"].ToString() == drM["RaceID"].ToString())
                            {
                                data += "\t" + raceRow["RaceID"].ToString() + "\t" +
                                    raceRow["RaceName"].ToString() + "\t" + raceRow["RaceTime"] + "\r\n";
                            }
                        }
                        
                    }
                    data += "\r\n\r\n";
                    PrintDataPages.Add(data);
                }
                
            }
            

        }

        private void btnPrintMeeting_Click(object sender, EventArgs e)
        {
            generateContents();
            currentPrintIndex = 0;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
