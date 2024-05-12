using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuestEditor_V2.Debug_Structure;
using static QuestEditor_V2.Structure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuestEditor_V2
{
    public partial class Debug_Client : Form
    {
        //clientside
        Debug_Structure.C_QuestHappenEvent_fld[] Quests1;
        Debug_Structure.C_QuestHappenEvent_fld[] Quests2;
        Debug_Structure.C_QuestHappenEvent_fld[] Quests3;
        Debug_Structure.C_QuestHappenEvent_fld[] Quests4;
        Debug_Structure.C_QuestHappenEvent_fld[] Quests5;
        Debug_Structure.C_QuestHappenEvent_fld[] Quests6;
        Debug_Structure.C_QuestHappenEvent_fld[] Quests7;
        Debug_Structure.C_Quest_fld[] Quests8;
        //serverside
        List<QuestTextCode> QuestTextCodes;
        Structure STR = new Structure();

        public static readonly string AppRoot = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public Debug_Client()
        {
            InitializeComponent();
        }

        private void QuestTextCodeRead()
        {
            string path = "QuestTextCode.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    QuestTextCodes = new List<QuestTextCode>();
                    for (int i = 0; i < _Header; i++)
                    {
                        QuestTextCodes.Add(STR.Read_QuestTextCode(reader));

                    }
                    GC.KeepAlive(QuestTextCodes);
                    reader.Dispose();
                    reader.Close();
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestTextCodeRead();
            var Debug_Structure = new Debug_Structure();

            var fullPath = Path.Combine(AppRoot, "Client_Read/quest.dat");
            var exists = File.Exists(fullPath);

            if(exists)
            {
                using (var stream = System.IO.File.OpenRead(fullPath))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        int count = reader.ReadInt32();
                        int amount = reader.ReadInt32();

                        if (amount == 336)
                        {
                            Quests1 = new C_QuestHappenEvent_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests1[i] = Debug_Structure.ReadC_QuestHappenEvent_fld(reader);
                            }

                        }

                        count = reader.ReadInt32();
                        amount = reader.ReadInt32();
                        if (amount == 336)
                        {
                            Quests2 = new C_QuestHappenEvent_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests2[i] = Debug_Structure.ReadC_QuestHappenEvent_fld(reader);
                            }

                        }

                        count = reader.ReadInt32();
                        amount = reader.ReadInt32();
                        if (amount == 336)
                        {
                            Quests3 = new C_QuestHappenEvent_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests3[i] = Debug_Structure.ReadC_QuestHappenEvent_fld(reader);
                            }

                        }

                        count = reader.ReadInt32();
                        amount = reader.ReadInt32();
                        if (amount == 336)
                        {
                            Quests4 = new C_QuestHappenEvent_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests4[i] = Debug_Structure.ReadC_QuestHappenEvent_fld(reader);
                            }

                        }

                        count = reader.ReadInt32();
                        amount = reader.ReadInt32();
                        if (amount == 336)
                        {
                            Quests5 = new C_QuestHappenEvent_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests5[i] = Debug_Structure.ReadC_QuestHappenEvent_fld(reader);
                            }

                        }

                        count = reader.ReadInt32();
                        amount = reader.ReadInt32();
                        if (amount == 336)
                        {
                            Quests6 = new C_QuestHappenEvent_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests6[i] = Debug_Structure.ReadC_QuestHappenEvent_fld(reader);
                            }

                        }

                        count = reader.ReadInt32();
                        amount = reader.ReadInt32();
                        if (amount == 336)
                        {
                            Quests7 = new C_QuestHappenEvent_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests7[i] = Debug_Structure.ReadC_QuestHappenEvent_fld(reader);
                            }

                        }
                        count = reader.ReadInt32();
                        amount = reader.ReadInt32();
                        if (amount == 424)
                        {
                            Quests8 = new Debug_Structure.C_Quest_fld[count];
                            for (int i = 0; i < count; i++)
                            {
                                Quests8[i] = Debug_Structure.ReadC_Quest_fld(reader);
                            }

                        }


                        int hello = 0;

                    }

                }
            }
            Helpers helper = new Helpers();

            foreach (var text in QuestTextCodes)
            {
                string QB0 = helper.ByteString(text.m_strQuestBriefContents_0);
                
                string purge0 = QB0.Replace("\0", string.Empty);


                Server_output.AppendText(purge0 + "\n");
                int QB1 =helper.Quest_Hex(purge0);
                Test_Output.AppendText(QB1 + "\n");

            }

            foreach (var quest in Quests8)
            {
                Debug_Output.AppendText(quest.QuestBriefContent_0 + "\n");
            }
            // Read_QuestHappenEvent_fld(Bin)
        }
    }
}
