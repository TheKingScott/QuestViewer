using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuestEditor_V2.Structure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuestEditor_V2
{
    public partial class QuestHappenEvent : Form
    {
        Structure STR = new Structure();
        _QuestHappenEvent_fld[] Quests { get; set; }
        NameValueCollection Quest_KV_List = new NameValueCollection();
        int Index = 0;
        string OpenFile;
        Helpers help = new Helpers();
        public QuestHappenEvent()
        {
            InitializeComponent();

        }
        //somewhere there is a missmatch
        public void Write_Client_QuestHappenEvent_QuestGainItemEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            
            Bin.Flush();
            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from.
                    m_sCondVal = help.m_sCondVal_ClassType(Quest.m_Node[i].m_CondNode[y].m_sCondVal);

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

               
            }
        }

        public void Write_Client_QuestHappenEvent_QuestGradeEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();
            
            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.m_sCondVal_Hex_Int(Encoding.UTF8.GetBytes(purge0)); //testing

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from.
                    m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }

        public void Write_Client_QuestHappenEvent_QuestLvLimitEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from.
                    m_sCondVal = help.m_sCondVal_ClassType(Quest.m_Node[i].m_CondNode[y].m_sCondVal);

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }


        public void Write_Client_QuestHappenEvent_QuestMasteryEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from.
                    m_sCondVal = help.m_sCondVal_ClassType(Quest.m_Node[i].m_CondNode[y].m_sCondVal);

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }

        public void Write_Client_QuestHappenEvent_QuestPromoteEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            //this is different
            int helperint = help.m_sCondVal_ClassType(Encoding.UTF8.GetBytes(purge0));
            
            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from.
                    m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }

        public void Write_Client_QuestHappenEvent_QuestLvUpEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.m_sCondVal_Hex_Int(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint); //was purge0
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from. error occurs because BWB0 
                    m_sCondVal = help.m_sCondVal_ClassType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); //edit

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }
        public void Write_Client_QuestHappenEvent_QuestKillOtherRaceEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from. i think its a error in base file but haven't tested it so working around it
                    m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);                    

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }

        public void Write_Client_QuestHappenEvent_QuestNPCEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    //this changes depending on file its from. i think its a error in base file but haven't tested it so working around it for now
                    if (m_nCondType == 0 && m_nCondSubType == 1)
                    {
                        m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    if (m_nCondType == 0 && m_nCondSubType == 2)
                    {
                        m_sCondVal = help.m_sCondVal_Dec_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else if (m_nCondType == 8)
                    {
                        m_sCondVal = help.m_sCondVal_Item_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else if (m_nCondType == 12)
                    {
                        m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else if (m_nCondSubType == 0)
                    {
                        m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else
                    {
                        m_sCondVal = help.m_sCondVal_Dec_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }

        public void Write_Client_QuestHappenEvent_QuestDummyEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                   //this changes depending on file its from. i think its a error in base file but haven't tested it so working around it for now
                    m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    

                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));


                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }
        }
            public void Write_Client_QuestHappenEvent(BinaryWriter Bin, Structure._QuestHappenEvent_fld Quest)
        {
            Helpers help = new Helpers();

            Bin.Write(Quest.m_dwIndex); //0
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint); 
            Bin.Write(base10);//4

            byte m_nEevntNo = (byte)Quest.m_nEevntNo;
            Bin.Write(m_nEevntNo); //8
            byte zero = 0;
            short zero1 = 0;
            Bin.Write(zero);//9
            Bin.Write(zero1);//10
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(Quest.m_Node[i].m_bUse); //12
                Bin.Write(Quest.m_Node[i].m_nQuestType); //16
                for (int y = 0; y < 5; y++)
                {                   
                    byte m_nCondType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondType;
                    Bin.Write(m_nCondType); //20

                    byte m_nCondSubType = (byte)Quest.m_Node[i].m_CondNode[y].m_nCondSubType;
                    Bin.Write(m_nCondSubType); //21 
                    short unknown = 0;
                    Bin.Write(unknown); //22
                    int m_sCondVal = 0;
                    if (m_nCondType == 0 && m_nCondSubType == 1)
                    {
                        m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    if (m_nCondType == 0 && m_nCondSubType == 2)
                    {
                        m_sCondVal = help.m_sCondVal_Dec_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else if (m_nCondType == 8)
                    {
                        m_sCondVal = help.m_sCondVal_Item_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else if (m_nCondType == 12)
                    {
                        m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else if (m_nCondSubType == 0)
                    {
                        m_sCondVal = help.m_sCondVal_Hex_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                    else
                    {
                        m_sCondVal = help.m_sCondVal_Dec_Int(Quest.m_Node[i].m_CondNode[y].m_sCondVal);
                    }
                   
                    Bin.Write(m_sCondVal); //24
                    int unknown1 = help.m_sCondVal_ItemType(Quest.m_Node[i].m_CondNode[y].m_sCondVal); ; //item type
                    Bin.Write(unknown1);//28
                }


                string ID1 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_0, 0, Quest.m_Node[i].m_strLinkQuest_0.Length);
                string purge1 = ID1.Replace("\0", string.Empty);
                int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

                string ID2 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_1, 0, Quest.m_Node[i].m_strLinkQuest_1.Length);
                string purge2 = ID2.Replace("\0", string.Empty);
                int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

                string ID3 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_2, 0, Quest.m_Node[i].m_strLinkQuest_2.Length);
                string purge3 = ID3.Replace("\0", string.Empty);
                int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge3));

                string ID4 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_3, 0, Quest.m_Node[i].m_strLinkQuest_3.Length);
                string purge4 = ID4.Replace("\0", string.Empty);
                int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

                string ID5 = Encoding.UTF8.GetString(Quest.m_Node[i].m_strLinkQuest_4, 0, Quest.m_Node[i].m_strLinkQuest_4.Length);
                string purge5 = ID5.Replace("\0", string.Empty);
                int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));

               
                Bin.Write(str_0);//80
                Bin.Write(str_0);
                Bin.Write(str_1);//88
                Bin.Write(str_1);
                Bin.Write(str_2);//96
                Bin.Write(str_2);
                Bin.Write(str_3);//104
                Bin.Write(str_3);
                Bin.Write(str_4);//112
                Bin.Write(str_4);

            }

        }

        public Structure._QuestHappenEvent_fld[] ReadFile_QuestHappenEvent_fld(string path)
        {
            using (var stream = System.IO.File.OpenRead(path))
            using (var reader = new BinaryReader(stream))
            {
                int _Header = reader.ReadInt32();
                int _columns = reader.ReadInt32();
                int _size = reader.ReadInt32();

                Quests = new _QuestHappenEvent_fld[_Header];
                for (int i = 0; i < _Header; i++)
                {
                    Quests[i] = (STR.Read_QuestHappenEvent_fld(reader));

                }

            }
            return Quests;
        }

            public void ReadFile(string path)
        {
            Index = 0;
            OpenFile = path;
            
            if (File.Exists(path))
            {
                this.Text = path;
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    Quests = new _QuestHappenEvent_fld[_Header];
                    for (int i = 0; i < _Header; i++)
                    {
                        Quests[i] = (STR.Read_QuestHappenEvent_fld(reader));

                    }


                    for (int i = 0; i < Quests.Length; i++)
                    {
                        string ID = Encoding.UTF8.GetString(Quests[i].m_strCode, 0, Quests[i].m_strCode.Length);
                        //add index value to compare here                                              
                        Quest_KV_List.Add(ID, i.ToString());
                        treeView1.Nodes.Add(ID);

                    }
                    GC.KeepAlive(Quests);
                    reader.Dispose();
                    reader.Close();
                }
            }
            Fill_Quest_Data();
        }

        private void Fill_Quest_Data()
        {
            if(treeView1.SelectedNode != null)
            {
                Index_Label.Text = treeView1.SelectedNode.Index.ToString();
            }
           
            m_nEevntNo.Text = Quests[Index].m_nEevntNo.ToString();
            m_bUse_0.Text = Quests[Index].m_Node[0].m_bUse.ToString();
            m_bQuestRepeat_0.Text = Quests[Index].m_Node[0].m_bQuestRepeat.ToString();
            m_nQuestType_0.Text = Quests[Index].m_Node[0].m_nQuestType.ToString();
            m_bSelectQuestManual_0.Text = Quests[Index].m_Node[0].m_bSelectQuestManual.ToString();
            m_nAcepProNum_0.Text = Quests[Index].m_Node[0].m_nAcepProNum.ToString();
            m_nAcepProDen_0.Text = Quests[Index].m_Node[0].m_nAcepProDen.ToString();
            //
            string ID0 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_strLinkQuest_0, 0, Quests[Index].m_Node[0].m_strLinkQuest_0.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            m_strLinkQuest_00.Text = purge0;
            string ID1 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_strLinkQuest_1, 0, Quests[Index].m_Node[0].m_strLinkQuest_1.Length);
            string purge1 = ID1.Replace("\0", string.Empty);
            m_strLinkQuest_10.Text = purge1;
            string ID2 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_strLinkQuest_2, 0, Quests[Index].m_Node[0].m_strLinkQuest_2.Length);
            string purge2 = ID2.Replace("\0", string.Empty);
            m_strLinkQuest_20.Text = purge2;
            string ID3 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_strLinkQuest_3, 0, Quests[Index].m_Node[0].m_strLinkQuest_3.Length);
            string purge3 = ID3.Replace("\0", string.Empty);
            m_strLinkQuest_30.Text = purge3;
            string ID4 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_strLinkQuest_4, 0, Quests[Index].m_Node[0].m_strLinkQuest_4.Length);
            string purge4 = ID4.Replace("\0", string.Empty);
            m_strLinkQuest_40.Text = purge4;


            //          
            m_bUse_1.Text = Quests[Index].m_Node[1].m_bUse.ToString();
            m_bQuestRepeat_1.Text = Quests[Index].m_Node[1].m_bQuestRepeat.ToString();
            m_nQuestType_1.Text = Quests[Index].m_Node[1].m_nQuestType.ToString();
            m_bSelectQuestManual_1.Text = Quests[Index].m_Node[1].m_bSelectQuestManual.ToString();
            m_nAcepProNum_1.Text = Quests[Index].m_Node[1].m_nAcepProNum.ToString();
            m_nAcepProDen_1.Text = Quests[Index].m_Node[1].m_nAcepProDen.ToString();

            string ID00 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_strLinkQuest_0, 0, Quests[Index].m_Node[1].m_strLinkQuest_0.Length);
            string purge00 = ID00.Replace("\0", string.Empty);
            m_strLinkQuest_01.Text = purge00;
            string ID10 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_strLinkQuest_1, 0, Quests[Index].m_Node[1].m_strLinkQuest_1.Length);
            string purge10 = ID10.Replace("\0", string.Empty);
            m_strLinkQuest_11.Text = purge10;
            string ID20 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_strLinkQuest_2, 0, Quests[Index].m_Node[1].m_strLinkQuest_2.Length);
            string purge20 = ID20.Replace("\0", string.Empty);
            m_strLinkQuest_21.Text = purge20;
            string ID30 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_strLinkQuest_3, 0, Quests[Index].m_Node[1].m_strLinkQuest_3.Length);
            string purge30 = ID30.Replace("\0", string.Empty);
            m_strLinkQuest_31.Text = purge30;
            string ID40 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_strLinkQuest_4, 0, Quests[Index].m_Node[1].m_strLinkQuest_4.Length);
            string purge40 = ID40.Replace("\0", string.Empty);
            m_strLinkQuest_41.Text = purge40;
            ///

            m_bUse_2.Text = Quests[Index].m_Node[2].m_bUse.ToString();
            m_bQuestRepeat_2.Text = Quests[Index].m_Node[2].m_bQuestRepeat.ToString();
            m_nQuestType_2.Text = Quests[Index].m_Node[2].m_nQuestType.ToString();
            m_bSelectQuestManual_2.Text = Quests[Index].m_Node[2].m_bSelectQuestManual.ToString();
            m_nAcepProNum_2.Text = Quests[Index].m_Node[2].m_nAcepProNum.ToString();
            m_nAcepProDen_2.Text = Quests[Index].m_Node[2].m_nAcepProDen.ToString();

            string ID000 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_strLinkQuest_0, 0, Quests[Index].m_Node[2].m_strLinkQuest_0.Length);
            string purge000 = ID000.Replace("\0", string.Empty);
            m_strLinkQuest_02.Text = purge000;
            string ID100 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_strLinkQuest_1, 0, Quests[Index].m_Node[2].m_strLinkQuest_1.Length);
            string purge100 = ID100.Replace("\0", string.Empty);
            m_strLinkQuest_12.Text = purge100;
            string ID200 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_strLinkQuest_2, 0, Quests[Index].m_Node[2].m_strLinkQuest_2.Length);
            string purge200 = ID200.Replace("\0", string.Empty);
            m_strLinkQuest_22.Text = purge200;
            string ID300 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_strLinkQuest_3, 0, Quests[Index].m_Node[2].m_strLinkQuest_3.Length);
            string purge300 = ID300.Replace("\0", string.Empty);
            m_strLinkQuest_32.Text = purge300;
            string ID400 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_strLinkQuest_4, 0, Quests[Index].m_Node[2].m_strLinkQuest_4.Length);
            string purge400 = ID400.Replace("\0", string.Empty);
            m_strLinkQuest_42.Text = purge400;

            //conditions

            m_nCondType_00.Text = Quests[Index].m_Node[0].m_CondNode[0].m_nCondType.ToString();
            m_nCondSubType_00.Text = Quests[Index].m_Node[0].m_CondNode[0].m_nCondSubType.ToString();
            string ED000 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_CondNode[0].m_sCondVal, 0, Quests[Index].m_Node[0].m_CondNode[0].m_sCondVal.Length);
            string purgeE00 = ED000.Replace("\0", string.Empty);
            m_sCondVal_00.Text = purgeE00;

            m_nCondType_10.Text = Quests[Index].m_Node[0].m_CondNode[1].m_nCondType.ToString();
            m_nCondSubType_10.Text = Quests[Index].m_Node[0].m_CondNode[1].m_nCondSubType.ToString();
            string ED010 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_CondNode[1].m_sCondVal, 0, Quests[Index].m_Node[0].m_CondNode[1].m_sCondVal.Length);
            string purgeE10 = ED010.Replace("\0", string.Empty);
            m_sCondVal_10.Text = purgeE10;

            m_nCondType_20.Text = Quests[Index].m_Node[0].m_CondNode[2].m_nCondType.ToString();
            m_nCondSubType_20.Text = Quests[Index].m_Node[0].m_CondNode[2].m_nCondSubType.ToString();
            string ED020 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_CondNode[2].m_sCondVal, 0, Quests[Index].m_Node[0].m_CondNode[2].m_sCondVal.Length);
            string purgeE20 = ED020.Replace("\0", string.Empty);
            m_sCondVal_20.Text = purgeE20;

            m_nCondType_30.Text = Quests[Index].m_Node[0].m_CondNode[3].m_nCondType.ToString();
            m_nCondSubType_30.Text = Quests[Index].m_Node[0].m_CondNode[3].m_nCondSubType.ToString();
            string ED030 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_CondNode[3].m_sCondVal, 0, Quests[Index].m_Node[0].m_CondNode[3].m_sCondVal.Length);
            string purgeE30 = ED030.Replace("\0", string.Empty);
            m_sCondVal_30.Text = purgeE30;

            m_nCondType_40.Text = Quests[Index].m_Node[0].m_CondNode[4].m_nCondType.ToString();
            m_nCondSubType_40.Text = Quests[Index].m_Node[0].m_CondNode[4].m_nCondSubType.ToString();
            string ED040 = Encoding.UTF8.GetString(Quests[Index].m_Node[0].m_CondNode[4].m_sCondVal, 0, Quests[Index].m_Node[0].m_CondNode[4].m_sCondVal.Length);
            string purgeE40 = ED040.Replace("\0", string.Empty);
            m_sCondVal_40.Text = purgeE40;

            /////
            m_nCondType_01.Text = Quests[Index].m_Node[1].m_CondNode[1].m_nCondType.ToString();
            m_nCondSubType_01.Text = Quests[Index].m_Node[1].m_CondNode[1].m_nCondSubType.ToString();
            string ED011 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_CondNode[1].m_sCondVal, 0, Quests[Index].m_Node[1].m_CondNode[1].m_sCondVal.Length);
            string purgeE01 = ED011.Replace("\0", string.Empty);
            m_sCondVal_01.Text = purgeE01;

            m_nCondType_11.Text = Quests[Index].m_Node[1].m_CondNode[1].m_nCondType.ToString();
            m_nCondSubType_11.Text = Quests[Index].m_Node[1].m_CondNode[1].m_nCondSubType.ToString();
            string ED111 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_CondNode[1].m_sCondVal, 0, Quests[Index].m_Node[1].m_CondNode[1].m_sCondVal.Length);
            string purgeE11 = ED111.Replace("\0", string.Empty);
            m_sCondVal_11.Text = purgeE11;

            m_nCondType_21.Text = Quests[Index].m_Node[1].m_CondNode[2].m_nCondType.ToString();
            m_nCondSubType_21.Text = Quests[Index].m_Node[1].m_CondNode[2].m_nCondSubType.ToString();
            string ED021 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_CondNode[2].m_sCondVal, 0, Quests[Index].m_Node[1].m_CondNode[2].m_sCondVal.Length);
            string purgeE21 = ED021.Replace("\0", string.Empty);
            m_sCondVal_21.Text = purgeE21;

            m_nCondType_31.Text = Quests[Index].m_Node[1].m_CondNode[3].m_nCondType.ToString();
            m_nCondSubType_31.Text = Quests[Index].m_Node[1].m_CondNode[3].m_nCondSubType.ToString();
            string ED031 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_CondNode[3].m_sCondVal, 0, Quests[Index].m_Node[1].m_CondNode[3].m_sCondVal.Length);
            string purgeE31 = ED031.Replace("\0", string.Empty);
            m_sCondVal_31.Text = purgeE31;

            m_nCondType_41.Text = Quests[Index].m_Node[1].m_CondNode[4].m_nCondType.ToString();
            m_nCondSubType_41.Text = Quests[Index].m_Node[1].m_CondNode[4].m_nCondSubType.ToString();
            string ED041 = Encoding.UTF8.GetString(Quests[Index].m_Node[1].m_CondNode[4].m_sCondVal, 0, Quests[Index].m_Node[1].m_CondNode[4].m_sCondVal.Length);
            string purgeE41 = ED041.Replace("\0", string.Empty);
            m_sCondVal_41.Text = purgeE41;
            ///////////////////////

            m_nCondType_02.Text = Quests[Index].m_Node[2].m_CondNode[2].m_nCondType.ToString();
            m_nCondSubType_02.Text = Quests[Index].m_Node[2].m_CondNode[2].m_nCondSubType.ToString();
            string ED022 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_CondNode[2].m_sCondVal, 0, Quests[Index].m_Node[2].m_CondNode[2].m_sCondVal.Length);
            string purgeE02 = ED022.Replace("\0", string.Empty);
            m_sCondVal_02.Text = purgeE02;

            m_nCondType_12.Text = Quests[Index].m_Node[2].m_CondNode[2].m_nCondType.ToString();
            m_nCondSubType_12.Text = Quests[Index].m_Node[2].m_CondNode[2].m_nCondSubType.ToString();
            string ED121 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_CondNode[2].m_sCondVal, 0, Quests[Index].m_Node[2].m_CondNode[2].m_sCondVal.Length);
            string purgeE12 = ED121.Replace("\0", string.Empty);
            m_sCondVal_12.Text = purgeE12;

            m_nCondType_22.Text = Quests[Index].m_Node[2].m_CondNode[2].m_nCondType.ToString();
            m_nCondSubType_22.Text = Quests[Index].m_Node[2].m_CondNode[2].m_nCondSubType.ToString();
            string ED22 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_CondNode[2].m_sCondVal, 0, Quests[Index].m_Node[2].m_CondNode[2].m_sCondVal.Length);
            string purgeE22 = ED22.Replace("\0", string.Empty);
            m_sCondVal_22.Text = purgeE22;

            m_nCondType_32.Text = Quests[Index].m_Node[2].m_CondNode[3].m_nCondType.ToString();
            m_nCondSubType_32.Text = Quests[Index].m_Node[2].m_CondNode[3].m_nCondSubType.ToString();
            string ED032 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_CondNode[3].m_sCondVal, 0, Quests[Index].m_Node[2].m_CondNode[3].m_sCondVal.Length);
            string purgeE32 = ED032.Replace("\0", string.Empty);
            m_sCondVal_32.Text = purgeE32;

            m_nCondType_42.Text = Quests[Index].m_Node[2].m_CondNode[4].m_nCondType.ToString();
            m_nCondSubType_42.Text = Quests[Index].m_Node[2].m_CondNode[4].m_nCondSubType.ToString();
            string ED042 = Encoding.UTF8.GetString(Quests[Index].m_Node[2].m_CondNode[4].m_sCondVal, 0, Quests[Index].m_Node[2].m_CondNode[4].m_sCondVal.Length);
            string purgeE42 = ED042.Replace("\0", string.Empty);
            m_sCondVal_42.Text = purgeE42;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            Quest_KV_List.Get(Index);
            string name = this.treeView1.SelectedNode.Text;
            string[] GetNames = Quest_KV_List.GetValues(name);

            int x = Int32.Parse(GetNames[0]);
            Index = Math.Clamp((int)Quests[x].m_dwIndex, 0, Quest_KV_List.Count - 1);

            Fill_Quest_Data();

        }

        private void m_sCondVal_20_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(m_sCondVal_20, "Race Flag BM,BF,CM,CF,AA");

        }

        private void Save_Edit_Button_Click(object sender, EventArgs e)
        {

            Quests[Index].m_Node[0].m_bUse = Int32.Parse(m_bUse_0.Text);
            Quests[Index].m_Node[0].m_bQuestRepeat = Int32.Parse(m_bQuestRepeat_0.Text);
            Quests[Index].m_Node[0].m_nQuestType = Int32.Parse(m_nQuestType_0.Text);
            Quests[Index].m_Node[0].m_bSelectQuestManual = Int32.Parse(m_bSelectQuestManual_0.Text);
            Quests[Index].m_Node[0].m_nAcepProNum = Int32.Parse(m_nAcepProNum_0.Text);
            Quests[Index].m_Node[0].m_nAcepProDen = Int32.Parse(m_nAcepProDen_0.Text);
            Quests[Index].m_Node[0].m_strLinkQuest_0 = Encoding.UTF8.GetBytes(m_strLinkQuest_00.Text);
            Quests[Index].m_Node[0].m_strLinkQuest_1 = Encoding.UTF8.GetBytes(m_strLinkQuest_10.Text);
            Quests[Index].m_Node[0].m_strLinkQuest_2 = Encoding.UTF8.GetBytes(m_strLinkQuest_20.Text);
            Quests[Index].m_Node[0].m_strLinkQuest_3 = Encoding.UTF8.GetBytes(m_strLinkQuest_30.Text);
            Quests[Index].m_Node[0].m_strLinkQuest_4 = Encoding.UTF8.GetBytes(m_strLinkQuest_40.Text);

            Quests[Index].m_Node[1].m_bUse = Int32.Parse(m_bUse_1.Text);
            Quests[Index].m_Node[1].m_bQuestRepeat = Int32.Parse(m_bQuestRepeat_1.Text);
            Quests[Index].m_Node[1].m_nQuestType = Int32.Parse(m_nQuestType_1.Text);
            Quests[Index].m_Node[1].m_bSelectQuestManual = Int32.Parse(m_bSelectQuestManual_1.Text);
            Quests[Index].m_Node[1].m_nAcepProNum = Int32.Parse(m_nAcepProNum_1.Text);
            Quests[Index].m_Node[1].m_nAcepProDen = Int32.Parse(m_nAcepProDen_1.Text);
            Quests[Index].m_Node[1].m_strLinkQuest_0 = Encoding.UTF8.GetBytes(m_strLinkQuest_01.Text);
            Quests[Index].m_Node[1].m_strLinkQuest_1 = Encoding.UTF8.GetBytes(m_strLinkQuest_11.Text);
            Quests[Index].m_Node[1].m_strLinkQuest_2 = Encoding.UTF8.GetBytes(m_strLinkQuest_21.Text);
            Quests[Index].m_Node[1].m_strLinkQuest_3 = Encoding.UTF8.GetBytes(m_strLinkQuest_31.Text);
            Quests[Index].m_Node[1].m_strLinkQuest_4 = Encoding.UTF8.GetBytes(m_strLinkQuest_41.Text);

            Quests[Index].m_Node[2].m_bUse = Int32.Parse(m_bUse_2.Text);
            Quests[Index].m_Node[2].m_bQuestRepeat = Int32.Parse(m_bQuestRepeat_2.Text);
            Quests[Index].m_Node[2].m_nQuestType = Int32.Parse(m_nQuestType_2.Text);
            Quests[Index].m_Node[2].m_bSelectQuestManual = Int32.Parse(m_bSelectQuestManual_2.Text);
            Quests[Index].m_Node[2].m_nAcepProNum = Int32.Parse(m_nAcepProNum_2.Text);
            Quests[Index].m_Node[2].m_nAcepProDen = Int32.Parse(m_nAcepProDen_2.Text);
            Quests[Index].m_Node[2].m_strLinkQuest_0 = Encoding.UTF8.GetBytes(m_strLinkQuest_02.Text);
            Quests[Index].m_Node[2].m_strLinkQuest_1 = Encoding.UTF8.GetBytes(m_strLinkQuest_12.Text);
            Quests[Index].m_Node[2].m_strLinkQuest_2 = Encoding.UTF8.GetBytes(m_strLinkQuest_22.Text);
            Quests[Index].m_Node[2].m_strLinkQuest_3 = Encoding.UTF8.GetBytes(m_strLinkQuest_32.Text);
            Quests[Index].m_Node[2].m_strLinkQuest_4 = Encoding.UTF8.GetBytes(m_strLinkQuest_42.Text);

            Quests[Index].m_Node[0].m_CondNode[0].m_nCondType = Int32.Parse(m_nCondType_00.Text);
            Quests[Index].m_Node[0].m_CondNode[0].m_nCondSubType = Int32.Parse(m_nCondSubType_00.Text);
            Quests[Index].m_Node[0].m_CondNode[0].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_00.Text);

            Quests[Index].m_Node[0].m_CondNode[1].m_nCondType = Int32.Parse(m_nCondType_10.Text);
            Quests[Index].m_Node[0].m_CondNode[1].m_nCondSubType = Int32.Parse(m_nCondSubType_10.Text);
            Quests[Index].m_Node[0].m_CondNode[1].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_10.Text);

            Quests[Index].m_Node[0].m_CondNode[2].m_nCondType = Int32.Parse(m_nCondType_20.Text);
            Quests[Index].m_Node[0].m_CondNode[2].m_nCondSubType = Int32.Parse(m_nCondSubType_20.Text);
            Quests[Index].m_Node[0].m_CondNode[2].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_20.Text);

            Quests[Index].m_Node[0].m_CondNode[3].m_nCondType = Int32.Parse(m_nCondType_30.Text);
            Quests[Index].m_Node[0].m_CondNode[3].m_nCondSubType = Int32.Parse(m_nCondSubType_30.Text);
            Quests[Index].m_Node[0].m_CondNode[3].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_30.Text);

            Quests[Index].m_Node[0].m_CondNode[4].m_nCondType = Int32.Parse(m_nCondType_40.Text);
            Quests[Index].m_Node[0].m_CondNode[4].m_nCondSubType = Int32.Parse(m_nCondSubType_40.Text);
            Quests[Index].m_Node[0].m_CondNode[4].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_40.Text);

            Quests[Index].m_Node[1].m_CondNode[0].m_nCondType = Int32.Parse(m_nCondType_01.Text);
            Quests[Index].m_Node[1].m_CondNode[0].m_nCondSubType = Int32.Parse(m_nCondSubType_01.Text);
            Quests[Index].m_Node[1].m_CondNode[0].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_01.Text);

            Quests[Index].m_Node[1].m_CondNode[1].m_nCondType = Int32.Parse(m_nCondType_11.Text);
            Quests[Index].m_Node[1].m_CondNode[1].m_nCondSubType = Int32.Parse(m_nCondSubType_11.Text);
            Quests[Index].m_Node[1].m_CondNode[1].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_11.Text);

            Quests[Index].m_Node[1].m_CondNode[2].m_nCondType = Int32.Parse(m_nCondType_21.Text);
            Quests[Index].m_Node[1].m_CondNode[2].m_nCondSubType = Int32.Parse(m_nCondSubType_21.Text);
            Quests[Index].m_Node[1].m_CondNode[2].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_21.Text);

            Quests[Index].m_Node[1].m_CondNode[3].m_nCondType = Int32.Parse(m_nCondType_31.Text);
            Quests[Index].m_Node[1].m_CondNode[3].m_nCondSubType = Int32.Parse(m_nCondSubType_31.Text);
            Quests[Index].m_Node[1].m_CondNode[3].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_31.Text);

            Quests[Index].m_Node[1].m_CondNode[4].m_nCondType = Int32.Parse(m_nCondType_41.Text);
            Quests[Index].m_Node[1].m_CondNode[4].m_nCondSubType = Int32.Parse(m_nCondSubType_41.Text);
            Quests[Index].m_Node[1].m_CondNode[4].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_41.Text);

            Quests[Index].m_Node[2].m_CondNode[0].m_nCondType = Int32.Parse(m_nCondType_02.Text);
            Quests[Index].m_Node[2].m_CondNode[0].m_nCondSubType = Int32.Parse(m_nCondSubType_02.Text);
            Quests[Index].m_Node[2].m_CondNode[0].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_02.Text);

            Quests[Index].m_Node[2].m_CondNode[1].m_nCondType = Int32.Parse(m_nCondType_12.Text);
            Quests[Index].m_Node[2].m_CondNode[1].m_nCondSubType = Int32.Parse(m_nCondSubType_12.Text);
            Quests[Index].m_Node[2].m_CondNode[1].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_12.Text);

            Quests[Index].m_Node[2].m_CondNode[2].m_nCondType = Int32.Parse(m_nCondType_22.Text);
            Quests[Index].m_Node[2].m_CondNode[2].m_nCondSubType = Int32.Parse(m_nCondSubType_22.Text);
            Quests[Index].m_Node[2].m_CondNode[2].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_22.Text);

            Quests[Index].m_Node[2].m_CondNode[3].m_nCondType = Int32.Parse(m_nCondType_32.Text);
            Quests[Index].m_Node[2].m_CondNode[3].m_nCondSubType = Int32.Parse(m_nCondSubType_32.Text);
            Quests[Index].m_Node[2].m_CondNode[3].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_32.Text);

            Quests[Index].m_Node[2].m_CondNode[4].m_nCondType = Int32.Parse(m_nCondType_42.Text);
            Quests[Index].m_Node[2].m_CondNode[4].m_nCondSubType = Int32.Parse(m_nCondSubType_42.Text);
            Quests[Index].m_Node[2].m_CondNode[4].m_sCondVal = Encoding.UTF8.GetBytes(m_sCondVal_42.Text);

        }

        private void Dat_Export_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory("Server_Files");
            string fileName = OpenFile;
            string path = Path.Combine(Environment.CurrentDirectory, @"Server_files\", fileName);

            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.ASCII, false))
                {
                    writer.Write(Quests.Length);
                    writer.Write(81);
                    writer.Write(2184);
                    for (int i = 0; i < Quests.Length; i++)
                    {
                        STR.Write__QuestHappenEvent_fld(writer, Quests[i]);
                    }

                }
            }

        }
    }
}
