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
using static QuestEditor_V2.Structure;

namespace QuestEditor_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new _Quest_fld();
            myForm.ReadFile("Quest.dat");
            myForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new _Quest_fld();
            myForm.ReadFile("HolyStoneKeepperQuest.dat");
            myForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestDummyEvent.dat");//read
            myForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestGainItemEvent.dat");//read
            myForm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestGradeEvent.dat");//read
            myForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestKillOtherRaceEvent.dat");//read
            myForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestLvLimitEvent.dat");//read
            myForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestLvUpEvent.dat");//read
            myForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestMasteryEvent.dat");//read
            myForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestNPCEvent.dat");//read
            myForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestPromoteEvent.dat");//read
            myForm.Show();
        }

        private void TestValue_Click(object sender, EventArgs e)
        {
            var myQuest_fld = new _Quest_fld();
            var myQuestHappenEvent = new QuestHappenEvent();
            var Structure = new Structure();
            var List1 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestDummyEvent.dat");
            var List2 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestNPCEvent.dat");
            var List3 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestKillOtherRaceEvent.dat");
            var List4 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestLvUpEvent.dat");//data bugged
            var List5 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestPromoteEvent.dat"); //data bugged
            var List6 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestGradeEvent.dat"); //correct
            var List7 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestGainItemEvent.dat");
           // var List8 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestMasteryEvent.dat"); //not written          
           // var List9 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestLvLimitEvent.dat"); //not written

            var List10 = myQuest_fld.ReadFile_Quest_fld("Quest.dat");
            var List11 = myQuest_fld.ReadFile_Quest_fld("HolyStoneKeepperQuest.dat");


            myQuest_fld.PrepareQuestServerSide();

            myQuest_fld.Build_ClientQUestValues();

            System.IO.Directory.CreateDirectory("Client_Files");
            string fileName = "quest.dat";
            string path = Path.Combine(Environment.CurrentDirectory, @"Client_Files\", fileName);


            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var bin = new BinaryWriter(stream, Encoding.UTF8, false))
                {

                    bin.Write(List1.Length);
                    bin.Write(336);
                    foreach (var quest in List1)
                    {
                        myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestDummyEvent(bin, quest);
                    }
                    bin.Write(List2.Length);
                    bin.Write(336);
                    foreach (var quest in List2)
                    {
                        myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestNPCEvent(bin, quest);
                    }
                    bin.Write(List3.Length);
                    bin.Write(336);
                    foreach (var quest in List3)
                    {
                        myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestKillOtherRaceEvent(bin, quest);
                    }

                    bin.Write(List4.Length);
                    bin.Write(336);
                    foreach (var quest in List4)
                    {
                        myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestLvUpEvent(bin, quest);
                    }

                    bin.Write(List5.Length);
                    bin.Write(336);
                    foreach (var quest in List5)
                    {
                        myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestPromoteEvent(bin, quest);
                    }

                    bin.Write(List6.Length);
                    bin.Write(336);
                    foreach (var quest in List6)
                    {

                        myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestGradeEvent(bin, quest); //correect

                    }

                    bin.Write(List7.Length);
                    bin.Write(336);
                    foreach (var quest in List7)
                    {
                        myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestGainItemEvent(bin, quest);

                    }

                    /* bin.Write(List8.Length);
                     bin.Write(336);
                     foreach (var quest in List8)
                     {
                         myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestMasteryEvent(bin, quest);
                     }

                     bin.Write(List9.Length);
                     bin.Write(336);
                     foreach (var quest in List9)//
                     {
                         myQuestHappenEvent.Write_Client_QuestHappenEvent_QuestLvLimitEvent(bin, quest);
                     }
                     bin.Dispose();
                     bin.Close();
                    */

                    bin.Write(List10.Length + List11.Length);
                    bin.Write(424);

                    foreach (var quest in List10)
                    {
                        myQuest_fld.Write_Client_Quest(bin, quest);                    
                    }
                    foreach (var quest in List11)
                    {
                        myQuest_fld.Write_Client_HolyStoneKeepperQuest(bin, quest);   //todo fix the error                 
                    }

                    bin.Write(myQuest_fld.QuestItem.Count);
                    bin.Write(44);

                    foreach(var item in myQuest_fld.QuestItem)
                    {
                        Structure.Write_QuestItems(bin, item);
                    }
                    myQuest_fld.Write_QuestOrderLookUp(bin);

                    MessageBox.Show("end of write has happened");
                }
            }
            
            myQuest_fld.Dispose();
            myQuestHappenEvent.Dispose();
            myQuest_fld.Close();
            myQuestHappenEvent.Close();
            /* Helpers help = new Helpers();
             int writeme = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes("Q304500"));
             int writeme2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes("-1"));

            // var tryme = Convert.ToInt32(tester, 16);

             
             */


        }

        private void button12_Click(object sender, EventArgs e)
        {
            Helpers help = new Helpers();
            var test = help.Client_Hex("tibp001");
            System.IO.Directory.CreateDirectory("Client_Files");
            string fileName = "TestFile.dat";
            string path = Path.Combine(Environment.CurrentDirectory, @"Client_Files\", fileName);


            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var bin = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    //byte[] bytes = Encoding.UTF8.GetBytes(test);
                    bin.Write(test);
                }
            }
            // string test2 = help.Client_Hex("iyqst02");
            //iyqst01
            //iyqst02
            //iyqst03
            //iyqst04
            //iyqst05
            //iyqst06
            //iyqst07
            //iyqst08
            //iyqst09
            //iyqst10
            //iyqsa02
            //iyqsa07
            //iyqsa08
            //iyqsa09
            //iyqla10
            //iyqla14
            //iyqla20
            //iyqla28
            //iyqla42
            //iyqla47
            //iyqla51
            //iyqla56
            //iyqla61
            //iyqla76
            //iyqla78


        }

        private void button13_Click(object sender, EventArgs e)
        {
            var myForm = new Debug_Client();
           // myForm.ReadFile("QuestPromoteEvent.dat");//read
            myForm.Show();
        }
    }
}
