namespace QuestEditor_V2
{
    partial class Debug_Client
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
            treeView1 = new TreeView();
            button1 = new Button();
            Debug_Output = new RichTextBox();
            Server_output = new RichTextBox();
            Test_Output = new RichTextBox();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(121, 386);
            treeView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(695, 30);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Debug_Output
            // 
            Debug_Output.Location = new Point(154, 12);
            Debug_Output.Name = "Debug_Output";
            Debug_Output.Size = new Size(144, 307);
            Debug_Output.TabIndex = 2;
            Debug_Output.Text = "";
            // 
            // Server_output
            // 
            Server_output.Location = new Point(332, 12);
            Server_output.Name = "Server_output";
            Server_output.Size = new Size(144, 307);
            Server_output.TabIndex = 3;
            Server_output.Text = "";
            // 
            // Test_Output
            // 
            Test_Output.Location = new Point(506, 12);
            Test_Output.Name = "Test_Output";
            Test_Output.Size = new Size(144, 307);
            Test_Output.TabIndex = 4;
            Test_Output.Text = "";
            // 
            // Debug_Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Test_Output);
            Controls.Add(Server_output);
            Controls.Add(Debug_Output);
            Controls.Add(button1);
            Controls.Add(treeView1);
            Name = "Debug_Client";
            Text = "Debug_Client";
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private Button button1;
        private RichTextBox Debug_Output;
        private RichTextBox Server_output;
        private RichTextBox Test_Output;
    }
}