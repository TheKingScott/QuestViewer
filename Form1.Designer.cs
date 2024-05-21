namespace QuestEditor_V2
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            Generate_Client = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button13 = new Button();
            button12 = new Button();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(15, 22);
            button1.Name = "button1";
            button1.Size = new Size(126, 23);
            button1.TabIndex = 0;
            button1.Text = "Quest.dat _ Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(156, 22);
            button2.Name = "button2";
            button2.Size = new Size(233, 23);
            button2.TabIndex = 1;
            button2.Text = "HolyStoneKeepperQuest.dat _ Load";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(395, 22);
            button3.Name = "button3";
            button3.Size = new Size(189, 23);
            button3.TabIndex = 2;
            button3.Text = "QuestDummyEvent.dat_Load";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(19, 51);
            button4.Name = "button4";
            button4.Size = new Size(189, 23);
            button4.TabIndex = 3;
            button4.Text = "QuestGainItemEvent.dat_Load";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(224, 51);
            button5.Name = "button5";
            button5.Size = new Size(189, 23);
            button5.TabIndex = 4;
            button5.Text = "QuestGradeEvent.dat_Load";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(419, 51);
            button6.Name = "button6";
            button6.Size = new Size(208, 23);
            button6.TabIndex = 5;
            button6.Text = "QuestKillOtherRaceEvent.dat_Load";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(19, 80);
            button7.Name = "button7";
            button7.Size = new Size(189, 23);
            button7.TabIndex = 6;
            button7.Text = "QuestLvLimitEvent.dat_Load";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(224, 80);
            button8.Name = "button8";
            button8.Size = new Size(189, 23);
            button8.TabIndex = 7;
            button8.Text = "QuestLvUpEvent.dat_Load";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(419, 80);
            button9.Name = "button9";
            button9.Size = new Size(189, 23);
            button9.TabIndex = 8;
            button9.Text = "QuestMasteryEvent.dat_Load";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(19, 109);
            button10.Name = "button10";
            button10.Size = new Size(189, 23);
            button10.TabIndex = 9;
            button10.Text = "QuestNPCEvent.dat_Load";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(224, 109);
            button11.Name = "button11";
            button11.Size = new Size(189, 23);
            button11.TabIndex = 10;
            button11.Text = "QuestPromoteEvent.dat_Load";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // Generate_Client
            // 
            Generate_Client.Location = new Point(10, 22);
            Generate_Client.Name = "Generate_Client";
            Generate_Client.Size = new Size(106, 23);
            Generate_Client.TabIndex = 11;
            Generate_Client.Text = "Gen-Quest";
            Generate_Client.UseVisualStyleBackColor = true;
            Generate_Client.Click += TestValue_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button11);
            groupBox1.Controls.Add(button10);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button9);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button7);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 151);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Server_Files";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button13);
            groupBox2.Location = new Point(12, 169);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(633, 129);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Client Files";
            // 
            // button13
            // 
            button13.Location = new Point(11, 22);
            button13.Name = "button13";
            button13.Size = new Size(115, 23);
            button13.TabIndex = 0;
            button13.Text = "Quest.dat READ";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button12
            // 
            button12.Location = new Point(10, 51);
            button12.Name = "button12";
            button12.Size = new Size(106, 23);
            button12.TabIndex = 15;
            button12.Text = "Gen-NDQuest";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Generate_Client);
            groupBox3.Controls.Add(button12);
            groupBox3.Location = new Point(666, 21);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(122, 292);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Experimental";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Quest Viewer";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button Generate_Client;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button12;
        private Button button13;
        private GroupBox groupBox3;
    }
}