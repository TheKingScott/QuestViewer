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
            var myQuest_fld  = new _Quest_fld();
            var myQuestHappenEvent = new QuestHappenEvent();
            
            var List1 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestDummyEvent.dat");
            var List2 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestNPCEvent.dat");
            var List3 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestKillOtherRaceEvent.dat");
            var List4 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestLvUpEvent.dat");
            var List5 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestPromoteEvent.dat");
            var List6 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestMasteryEvent.dat");
            var List7 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestLvLimitEvent.dat");
            var List8 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestGradeEvent.dat");
            var List9 = myQuestHappenEvent.ReadFile_QuestHappenEvent_fld("QuestGainItemEvent.dat");

            var list10 = myQuest_fld.ReadFile_Quest_fld("Quest.dat");
            var list11 = myQuest_fld.ReadFile_Quest_fld("HolyStoneKeepperQuest.dat");
            var test = 0;
            System.IO.Directory.CreateDirectory("Client_Files");
            string fileName = "quest.dat";
            string path = Path.Combine(Environment.CurrentDirectory, @"Client_Files\", fileName);


            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var bin = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    //bin.Write(List1.Length);
                   // bin.Write(336);
                   // foreach(var quest in List1)
                   // {
                   //     myQuestHappenEvent.Write_Client_QuestHappenEvent(bin,quest);
                   // }
                   bin.Write(List2.Length);
                   bin.Write(336);
                   foreach (var quest in List2)
                   {
                       myQuestHappenEvent.Write_Client_QuestHappenEvent(bin, quest);
                   }



                }
            }

            /* Helpers help = new Helpers();
             int writeme = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes("Q304500"));
             int writeme2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes("-1"));

            // var tryme = Convert.ToInt32(tester, 16);

             
             */


        }
    }
}
