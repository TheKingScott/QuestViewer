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
            myForm.ReadFile("QuestDummyEvent.dat");
            myForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestGainItemEvent.dat");
            myForm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestGradeEvent.dat");
            myForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestKillOtherRaceEvent.dat");
            myForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestLvLimitEvent.dat");
            myForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestLvUpEvent.dat");
            myForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestMasteryEvent.dat");
            myForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestNPCEvent.dat");
            myForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var myForm = new QuestHappenEvent();
            myForm.ReadFile("QuestPromoteEvent.dat");
            myForm.Show();
        }
    }
}
