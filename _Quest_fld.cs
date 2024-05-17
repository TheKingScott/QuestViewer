using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static QuestEditor_V2.Structure;
using static System.Net.Mime.MediaTypeNames;

namespace QuestEditor_V2
{
    public partial class _Quest_fld : Form
    {
        Structure STR = new Structure();
        int QuestIndex = 0;
        string OpenFile;

        public Structure._Quest_fld[] QuestEdit { get; set; }

        List<STR_File> STR_Monsters;
        List<STR_File> STR_NPCs;
        List<STR_File> STR_ITEMS;
        List<QuestTextCode> QuestTextCodes;
        List<STR_File> STR_QuestFinishContents;
        List<STR_File> STR_QuestSummaryContents;
        List<STR_File> STR_QuestBriefContents;
        List<STR_File> STR_QuestConditionResult;
        List<STR_File> STR_QuestName;

        NameValueCollection ITEM_KV_List = new NameValueCollection();
        NameValueCollection NPC_KV_List = new NameValueCollection();
        NameValueCollection Monster_KV_List = new NameValueCollection();
        NameValueCollection Quest_KV_List = new NameValueCollection();
        NameValueCollection QuestBrief_KV_List = new NameValueCollection();
        NameValueCollection QuestCondition_KV_List = new NameValueCollection();
        NameValueCollection QuestFinish_KV_List = new NameValueCollection();
        NameValueCollection QuestSummary_KV_List = new NameValueCollection();
        NameValueCollection QuestName_KV_List = new NameValueCollection();
        List<QuestTextNumbers> DataPile = new List<QuestTextNumbers>(); //client data ints for export
        NameValueCollection QuestItem_KV_List = new NameValueCollection(); //clientdataExport
        public List<QuestItems> QuestItem;
        Helpers help = new Helpers();

        //Building Quest Order
        NameValueCollection BellQuestOrder = new NameValueCollection();
        NameValueCollection BellQuestOrder0 = new NameValueCollection();
        NameValueCollection CoraQuestOrder = new NameValueCollection();
        NameValueCollection CoraQuestOrder0 = new NameValueCollection();
        NameValueCollection AccQuestOrder = new NameValueCollection();
        NameValueCollection AccQuestOrder0 = new NameValueCollection();

        public _Quest_fld()
        {
            InitializeComponent();

        }

        public void Write_QuestOrderLookUp(BinaryWriter Bin)
        {
            Bin.Write(BellQuestOrder.Count);
            Bin.Write(4);
            for (int i = 0; i < BellQuestOrder.Count; i++)
            {
                int x = Int32.Parse(BellQuestOrder.Get(i));
                Bin.Write(x);               
            }

            Bin.Write(CoraQuestOrder.Count);
            Bin.Write(4);
            for (int i = 0; i < CoraQuestOrder.Count; i++)
            {
                int x = Int32.Parse(CoraQuestOrder.Get(i));
                Bin.Write(x);
            }
            Bin.Write(AccQuestOrder.Count);
            Bin.Write(4);
            for (int i = 0; i < AccQuestOrder.Count; i++)
            {
                int x = Int32.Parse(AccQuestOrder.Get(i));
                Bin.Write(x);
            }


        }
        public void Build_ClientQUestValues()
        {
            int test = Quest_KV_List.Count;
            int QuestBrief = QuestBrief_KV_List.Count;
            int QuestCondition = QuestCondition_KV_List.Count;
            int QuestFinish = QuestFinish_KV_List.Count; //test 4
            int QuestSummary = QuestSummary_KV_List.Count;
            int QuestName = QuestName_KV_List.Count;         
          
            int QBC = 0;
            int QSC = 0;
            int QCR = 0;
            int QFCU = 0;
            int QFCF = 0;
            int QuestTitle = 0;

            QuestTextCode previous = new QuestTextCode();
           // var items = QuestName_KV_List.AllKeys.SelectMany(QuestName_KV_List.GetValues, (k, v) => new { key = k, value = v });
            foreach (var item in QuestTextCodes)
            {
                QuestTextNumbers temp = new QuestTextNumbers();
                //if an negative number
                #region QTitle_CQ
                string Title = Encoding.UTF8.GetString(item.m_strCode_0, 0, item.m_strCode_0.Length);
                string purgezero = Title.Replace("\0", string.Empty);
                string[] values1 = QuestName_KV_List.GetValues(purgezero);
                if (values1 != null)
                {
                    temp.QuestNameNumber = QuestTitle;
                    QuestTitle++;
                }
                else
                {
                    temp.QuestNameNumber = -1;
                }
                #endregion

                
                #region QuestBriefContent_QDesc1_CR
                if (item.m_strQuestBriefContents_0[0] == 45)
                {
                    temp.m_strQuestBriefContents_0 = -1;
                }
                else
                {
                    temp.m_strQuestBriefContents_0 = QuestName + QBC;
                    if(previous.m_strQuestBriefContents_0 != item.m_strQuestBriefContents_0)
                    {
                        QBC++;
                    }
                    
                }
                if (item.m_strQuestBriefContents_1[0] == 45)
                {
                    temp.m_strQuestBriefContents_1 = -1;
                }
                else
                {
                    temp.m_strQuestBriefContents_1 = QuestName + QBC;
                    if (previous.m_strQuestBriefContents_1 != item.m_strQuestBriefContents_1)
                    {
                        QBC++;
                    }
                }
                if (item.m_strQuestBriefContents_2[0] == 45)
                {
                    temp.m_strQuestBriefContents_2 = -1;
                }
                else
                {
                    temp.m_strQuestBriefContents_2 = QuestName + QBC;
                    if (previous.m_strQuestBriefContents_2 != item.m_strQuestBriefContents_2)
                    {
                        QBC++;
                    }
                }
                if (item.m_strQuestBriefContents_3[0] == 45)
                {
                    temp.m_strQuestBriefContents_3 = -1;
                }
                else
                {
                    temp.m_strQuestBriefContents_3 = QuestName + QBC;
                    if (previous.m_strQuestBriefContents_3 != item.m_strQuestBriefContents_3)
                    {
                        QBC++;
                    }
                }
                if (item.m_strQuestBriefContents_4[0] == 45)
                {
                    temp.m_strQuestBriefContents_4 = -1;
                }
                else
                {
                    temp.m_strQuestBriefContents_4 = QuestName + QBC;
                    if (previous.m_strQuestBriefContents_4 != item.m_strQuestBriefContents_4)
                    {
                        QBC++;
                    }
                }
                #endregion

                #region QuestSummaryContent_BriefDesc_CW
                if (item.m_strQuestSummaryContents_0[0] == 45)
                {
                    temp.m_strQuestSummaryContents_0 = -1;
                }
                else
                {
                    temp.m_strQuestSummaryContents_0 = QuestName + QuestBrief + QSC;                  
                    if (previous.m_strQuestSummaryContents_0 != item.m_strQuestSummaryContents_0)
                    {
                        QSC++;
                    }
                }
                if (item.m_strQuestSummaryContents_1[0] == 45)
                {
                    temp.m_strQuestSummaryContents_1 = -1;
                }
                else
                {
                    temp.m_strQuestSummaryContents_1 = QuestName + QuestBrief + QSC;
                    if (previous.m_strQuestSummaryContents_1 != item.m_strQuestSummaryContents_1)
                    {
                        QSC++;
                    }
                }
                if (item.m_strQuestSummaryContents_2[0] == 45)
                {
                    temp.m_strQuestSummaryContents_2 = -1;
                }
                else
                {
                    temp.m_strQuestSummaryContents_2 = QuestName + QuestBrief + QSC;
                    if (previous.m_strQuestSummaryContents_2 != item.m_strQuestSummaryContents_2)
                    {
                        QSC++;
                    }
                }
                if (item.m_strQuestSummaryContents_3[0] == 45)
                {
                    temp.m_strQuestSummaryContents_3 = -1;
                }
                else
                {
                    temp.m_strQuestSummaryContents_3 = QuestName + QuestBrief + QSC;
                    if (previous.m_strQuestSummaryContents_3 != item.m_strQuestSummaryContents_3)
                    {
                        QSC++;
                    }
                }
                if (item.m_strQuestSummaryContents_4[0] == 45)
                {
                    temp.m_strQuestSummaryContents_4 = -1;
                }
                else
                {
                    temp.m_strQuestSummaryContents_4 = QuestName + QuestBrief + QSC;
                    if (previous.m_strQuestSummaryContents_4 != item.m_strQuestSummaryContents_4)
                    {
                        QSC++;
                    }
                }
                #endregion
               
                #region QuestConditionResult_TaskInGUI_AE
                if (item.m_strQuestConditionResult_0[0] == 45)
                {
                    temp.m_strQuestConditionResult_0 = -1;
                }
                else
                {
                    temp.m_strQuestConditionResult_0 = QuestName + QuestBrief + QuestSummary + QCR;                 
                    if (previous.m_strQuestConditionResult_0 != item.m_strQuestConditionResult_0)
                    {
                        QCR++;
                    }
                }
                if (item.m_strQuestConditionResult_1[0] == 45)
                {
                    temp.m_strQuestConditionResult_1 = -1;
                }
                else
                {
                    temp.m_strQuestConditionResult_1 = QuestName + QuestBrief + QuestSummary + QCR;
                    if (previous.m_strQuestConditionResult_1 != item.m_strQuestConditionResult_1)
                    {
                        QCR++;
                    }
                }
                if (item.m_strQuestConditionResult_2[0] == 45)
                {
                    temp.m_strQuestConditionResult_2 = -1;
                }
                else
                {
                    temp.m_strQuestConditionResult_2 = QuestName + QuestBrief + QuestSummary + QCR;
                    if (previous.m_strQuestConditionResult_2 != item.m_strQuestConditionResult_2)
                    {
                        QCR++;
                    }
                }
                if (item.m_strQuestConditionResult_3[0] == 45)
                {
                    temp.m_strQuestConditionResult_3 = -1;
                }
                else
                {
                    temp.m_strQuestConditionResult_3 = QuestName + QuestBrief + QuestSummary + QCR;
                    if (previous.m_strQuestConditionResult_3 != item.m_strQuestConditionResult_3)
                    {
                        QCR++;
                    }
                }
                if (item.m_strQuestConditionResult_4[0] == 45)
                {
                    temp.m_strQuestConditionResult_4 = -1;
                }
                else
                {
                    temp.m_strQuestConditionResult_4 = QuestName + QuestBrief + QuestSummary + QCR;
                    if (previous.m_strQuestConditionResult_4 != item.m_strQuestConditionResult_4)
                    {
                        QCR++;
                    }
                }
                #endregion
                
                #region QuestFinishContents_TaskInBrief_AF
                if (item.m_strQuestFinishContents_U0[0] == 45)
                {
                    temp.m_strQuestFinishContents_U0 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_U0 = QuestName + QuestBrief + QuestSummary + QuestCondition + QFCU;                   
                    if (previous.m_strQuestFinishContents_U0 != item.m_strQuestFinishContents_U0)
                    {
                        QFCU++;
                    }

                }
                if (item.m_strQuestFinishContents_U1[0] == 45)
                {
                    temp.m_strQuestFinishContents_U1 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_U1 = QuestName + QuestBrief + QuestSummary + QuestCondition + QFCU;
                    if (previous.m_strQuestFinishContents_U1 != item.m_strQuestFinishContents_U1)
                    {
                        QFCU++;
                    }
                }
                if (item.m_strQuestFinishContents_U2[0] == 45)
                {
                    temp.m_strQuestFinishContents_U2 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_U2 = QuestName + QuestBrief + QuestSummary + QuestCondition + QFCU;
                    if (previous.m_strQuestFinishContents_U2 != item.m_strQuestFinishContents_U2)
                    {
                        QFCU++;
                    }
                }
                if (item.m_strQuestFinishContents_U3[0] == 45)
                {
                    temp.m_strQuestFinishContents_U3 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_U3 = QuestName + QuestBrief + QuestSummary + QuestCondition + QFCU;
                    if (previous.m_strQuestFinishContents_U3 != item.m_strQuestFinishContents_U3)
                    {
                        QFCU++;
                    }
                }
                if (item.m_strQuestFinishContents_U4[0] == 45)
                {
                    temp.m_strQuestFinishContents_U4 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_U4 = QuestName + QuestBrief + QuestSummary + QuestCondition + QFCU;
                    if (previous.m_strQuestFinishContents_U4 != item.m_strQuestFinishContents_U4)
                    {
                        QFCU++;
                    }
                }
                #endregion

                #region QuestFinishContents_QSDesc1_BW
                temp.Client_IsFailCheck = new int[3];
                if (item.m_strQuestFinishContents_F0[0] == 45)
                {
                    temp.m_strQuestFinishContents_F0 = -1;
                    temp.Client_IsFailCheck[0] = 0;
                }
                else
                {
                    temp.Client_IsFailCheck[0] = 1;
                    temp.m_strQuestFinishContents_F0 = QuestName + QuestBrief + QuestSummary + QuestCondition + QuestFinish + QFCF;                 
                    if (previous.m_strQuestFinishContents_F0 != item.m_strQuestFinishContents_F0)
                    {
                        QFCF++;
                    }

                }
                temp.Client_IsFailCheck[1] = 0;
                temp.Client_IsFailCheck[2] = 0;
                if (item.m_strQuestFinishContents_F1[0] == 45)
                {
                    temp.m_strQuestFinishContents_F1 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_F1 = QuestName + QuestBrief + QuestSummary + QuestCondition + QuestFinish + QFCF;
                    if (previous.m_strQuestFinishContents_F1 != item.m_strQuestFinishContents_F1)
                    {
                        QFCF++;
                    }
                }
                if (item.m_strQuestFinishContents_F2[0] == 45)
                {
                    temp.m_strQuestFinishContents_F2 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_F2 = QuestName + QuestBrief + QuestSummary + QuestCondition + QuestFinish + QFCF;
                    if (previous.m_strQuestFinishContents_F2 != item.m_strQuestFinishContents_F2)
                    {
                        QFCF++;
                    }
                }
                if (item.m_strQuestFinishContents_F3[0] == 45)
                {
                    temp.m_strQuestFinishContents_F3 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_F3 = QuestName + QuestBrief + QuestSummary + QuestCondition + QuestFinish + QFCF;
                    if (previous.m_strQuestFinishContents_F3 != item.m_strQuestFinishContents_F3)
                    {
                        QFCF++;
                    }
                }
                if (item.m_strQuestFinishContents_F4[0] == 45)
                {
                    temp.m_strQuestFinishContents_F4 = -1;
                }
                else
                {
                    temp.m_strQuestFinishContents_F4 = QuestName + QuestBrief + QuestSummary + QuestCondition + QuestFinish + QFCF;
                    if (previous.m_strQuestFinishContents_F4 != item.m_strQuestFinishContents_F4)
                    {
                        QFCF++;
                    }
                }
                #endregion

                temp.QuestNameIndex = item.m_dwIndex.ToString();
                DataPile.Add(temp);
                previous = item;
            }
            int hello = 0;
        }

        public void Write_Client_Quest(BinaryWriter Bin, Structure._Quest_fld Quest)
        {
            Bin.Flush();
            Bin.Write(Quest.m_dwIndex);
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);


            Bin.Write((byte)Quest.m_nQuestType);
            Bin.Write((byte)Quest.m_nDifficultyLevel);
            Bin.Write((byte)Quest.m_n2);
            Bin.Write((sbyte)Quest.m_nLimLv);

            Bin.Write((short)0);
            Bin.Write((short)0); //22
            for (int i = 0; i < 3; i++) //34 * 3
            {

                Bin.Write((byte)Quest.m_ActionNode[i].m_nActType);
                Bin.Write((byte)0);
                Bin.Write((short)0);

                string IDN1 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strActSub, 0, Quest.m_ActionNode[i].m_strActSub.Length);
                string purgeN1 = IDN1.Replace("\0", string.Empty);
                string IDN2 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strActSub2, 0, Quest.m_ActionNode[i].m_strActSub2.Length);
                string purgeN2 = IDN2.Replace("\0", string.Empty);

                int m_strActSub;
                int m_strActSub2;
                if (Quest.m_ActionNode[i].m_nActType == 4)
                {
                    m_strActSub = help.Client_Hex(purgeN1);
                    m_strActSub2 = help.Client_Hex(purgeN2);
                }
                else if (Quest.m_ActionNode[i].m_nActType == 14)
                {
                    m_strActSub = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN1));
                    m_strActSub2 = help.Client_Hex(purgeN2);
                }
                else
                {
                    m_strActSub = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN1));
                    m_strActSub2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN2));
                }

                string IDN3 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strActArea, 0, Quest.m_ActionNode[i].m_strActArea.Length);
                string purgeN3 = IDN3.Replace("\0", string.Empty);
                int m_strActArea = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN3));

                Bin.Write(m_strActSub);
                Bin.Write(m_strActSub2);
                // Bin.Write(m_strActArea); //not used in spreadsheet

                Bin.Write(Quest.m_ActionNode[i].m_nReqAct);  //AD

                Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestConditionResult_0);  //AE
                Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U0);


                string IDN4 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strLinkQuestItem, 0, Quest.m_ActionNode[i].m_strLinkQuestItem.Length);
                string purgeN4 = IDN4.Replace("\0", string.Empty);
                int QuestItem;//= 0 based index array lookup
                if (purgeN4 == null)
                {
                    QuestItem = -1;
                }
                else
                {
                    var testing = QuestItem_KV_List.GetValues(purgeN4);
                    QuestItem = Convert.ToInt32(testing[0]);

                }
                Bin.Write(QuestItem); //AG


            } //124

            Bin.Write(Quest.m_dConsExp); //AH
            Bin.Write(Quest.m_nConsDalant);
            Bin.Write(Quest.m_nConsGold);
            Bin.Write(Quest.m_nConsContribution);
            Bin.Write(Quest.m_nConspvppoint); //144
            for (int i = 0; i < 6; i++) //14 * 6
            {

                // char Item_Code; Quest.m_RewardItem[i];
                Bin.Write(0);

                string IDI = Encoding.UTF8.GetString(Quest.m_RewardItem[i].m_strConsITCode, 0, Quest.m_RewardItem[i].m_strConsITCode.Length);
                string purgeI = IDI.Replace("\0", string.Empty);
                int m_strConsITCode;
                if (purgeI == null)
                {
                    m_strConsITCode = -1;
                }
                else if (purgeI == "-1")
                {
                    m_strConsITCode = -1;
                }
                else
                {

                    m_strConsITCode = help.Client_Hex(purgeI);
                }

                Bin.Write(m_strConsITCode);//AM

                Bin.Write((short)Quest.m_RewardItem[i].m_nConsITCnt);
                Bin.Write(0);


            }//228

            for (int i = 0; i < 2; i++)
            {

                Bin.Write((short)Quest.m_RewardMastery[i].m_nConsMasteryID); //BK
                Bin.Write((short)0);
                Bin.Write(Quest.m_RewardMastery[i].m_nConsMasteryCnt);
            }//248

            string ID1 = Encoding.UTF8.GetString(Quest.m_strConsSkillCode, 0, Quest.m_strConsSkillCode.Length);
            string purge1 = ID1.Replace("\0", string.Empty);
            int helperint1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

            string ID2 = Encoding.UTF8.GetString(Quest.m_strConsForceCode, 0, Quest.m_strConsForceCode.Length);
            string purge2 = ID2.Replace("\0", string.Empty);
            int helperint2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

            Bin.Write(helperint1);  //BS
            Bin.Write(Quest.m_nConsSkillCnt);
            Bin.Write(helperint2);
            Bin.Write(Quest.m_nConsForceCnt);
            ///BW m_strQuestFinishContents_F0
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F0);  //BX
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F4);

            //double check this section it may be wrong
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U0);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U4);
            //end of double check section

            // 308

            string ID10 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_0, 0, Quest.m_strLinkQuest_0.Length);
            string purge10 = ID10.Replace("\0", string.Empty);
            int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge10));

            string ID11 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_1, 0, Quest.m_strLinkQuest_1.Length);
            string purge11 = ID11.Replace("\0", string.Empty);
            int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge11));

            string ID12 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_2, 0, Quest.m_strLinkQuest_2.Length);
            string purge12 = ID12.Replace("\0", string.Empty);
            int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge12));

            string ID13 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_3, 0, Quest.m_strLinkQuest_3.Length);
            string purge13 = ID13.Replace("\0", string.Empty);
            int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge13));

            string ID14 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_4, 0, Quest.m_strLinkQuest_4.Length);
            string purge14 = ID14.Replace("\0", string.Empty);
            int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge14));

            Bin.Write(str_0);  //CG
            Bin.Write(str_0);
            Bin.Write(str_1);
            Bin.Write(str_1);
            Bin.Write(str_2);
            Bin.Write(str_2);
            Bin.Write(str_3);
            Bin.Write(str_3);
            Bin.Write(str_4);
            Bin.Write(str_4);  //CP

            Bin.Write(DataPile[(int)Quest.m_dwIndex].QuestNameNumber);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_0);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_4);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_0);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_4);

            Bin.Write(Quest.m_nStore_trade); //396
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(DataPile[(int)Quest.m_dwIndex].Client_IsFailCheck[i]);
                Bin.Write(Quest.m_QuestFailCond[i].m_nFailCondition);

                string IDF = Encoding.UTF8.GetString(Quest.m_QuestFailCond[i].m_strFailCode, 0, Quest.m_QuestFailCond[i].m_strFailCode.Length);
                string purgeF = IDF.Replace("\0", string.Empty);
                int str_F = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeF));

                Bin.Write(str_F);

            }//432

            Bin.Write(0);
            Bin.Write(Quest.m_nViewportType);

            string ID4 = Encoding.UTF8.GetString(Quest.m_strViewportCode, 0, Quest.m_strViewportCode.Length);
            string purge4 = ID4.Replace("\0", string.Empty);
            int m_strViewportCode = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

            string ID5 = Encoding.UTF8.GetString(Quest.m_strFailLinkQuest, 0, Quest.m_strFailLinkQuest.Length);
            string purge5 = ID5.Replace("\0", string.Empty);
            int FailLinkQuest = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));

            Bin.Write(m_strViewportCode);
            Bin.Write(0);
            Bin.Write(FailLinkQuest);

        }
        public void Write_Client_HolyStoneKeepperQuest(BinaryWriter Bin, Structure._Quest_fld Quest)
        {
            Bin.Flush();
            Bin.Write(Quest.m_dwIndex);
            string ID0 = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0 = ID0.Replace("\0", string.Empty);
            int helperint = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge0));

            int base10 = Convert.ToInt32(helperint);
            Bin.Write(base10);

           
            Bin.Write((byte)Quest.m_nQuestType);
            Bin.Write((byte)Quest.m_nDifficultyLevel);
            Bin.Write((byte)Quest.m_n2);
            Bin.Write((sbyte)Quest.m_nLimLv);
           
            Bin.Write((short)0);
            Bin.Write((short)0); //22
            for(int i = 0; i < 3; i++) //34 * 3
            {
                
                Bin.Write((byte)Quest.m_ActionNode[i].m_nActType);
                Bin.Write((byte)0);
                Bin.Write((short)0);

                string IDN1 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strActSub, 0, Quest.m_ActionNode[i].m_strActSub.Length);
                string purgeN1 = IDN1.Replace("\0", string.Empty);
                string IDN2 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strActSub2, 0, Quest.m_ActionNode[i].m_strActSub2.Length);
                string purgeN2 = IDN2.Replace("\0", string.Empty);

                int m_strActSub;
                int m_strActSub2; 
                if (Quest.m_ActionNode[i].m_nActType == 4 )
                {
                    m_strActSub = help.Client_Hex(purgeN1);
                    m_strActSub2 = help.Client_Hex(purgeN2);
                }
                else if( Quest.m_ActionNode[i].m_nActType == 14)
                {
                    m_strActSub = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN1));
                    m_strActSub2 = help.Client_Hex(purgeN2);
                }
                else
                {
                    m_strActSub = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN1));
                    m_strActSub2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN2));
                }                           

                string IDN3 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strActArea, 0, Quest.m_ActionNode[i].m_strActArea.Length);
                string purgeN3 = IDN3.Replace("\0", string.Empty);
                int m_strActArea = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeN3));
                
                Bin.Write(m_strActSub);
                Bin.Write(m_strActSub2);
               // Bin.Write(m_strActArea); //not used in spreadsheet
               
                Bin.Write(Quest.m_ActionNode[i].m_nReqAct);  //AD

                Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestConditionResult_0);  //AE
                Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U0);
                

                string IDN4 = Encoding.UTF8.GetString(Quest.m_ActionNode[i].m_strLinkQuestItem, 0, Quest.m_ActionNode[i].m_strLinkQuestItem.Length);
                string purgeN4 = IDN4.Replace("\0", string.Empty);
                int QuestItem ;//= 0 based index array lookup
                if (purgeN4 == null)
                {
                    QuestItem = -1;
                }              
                else
                {                  
                    var testing = QuestItem_KV_List.GetValues(purgeN4);                
                    QuestItem = Convert.ToInt32(testing[0]);                                            
                    
                }
                Bin.Write(QuestItem); //AG


            } //124

            Bin.Write(Quest.m_dConsExp); //AH
            Bin.Write(Quest.m_nConsDalant);
            Bin.Write(Quest.m_nConsGold);
            Bin.Write(Quest.m_nConsContribution);
            Bin.Write(Quest.m_nConspvppoint); //144
            for(int i = 0; i < 6; i++) //14 * 6
            {             

               // char Item_Code; Quest.m_RewardItem[i];
                Bin.Write(0);
                
                string IDI = Encoding.UTF8.GetString(Quest.m_RewardItem[i].m_strConsITCode, 0, Quest.m_RewardItem[i].m_strConsITCode.Length);
                string purgeI = IDI.Replace("\0", string.Empty);
                int m_strConsITCode;
                if (purgeI == null)
                {
                    m_strConsITCode = -1;
                }
                else if (purgeI == "-1")
                {
                    m_strConsITCode = -1;
                }
                else
                {
                   
                    m_strConsITCode = help.Client_Hex(purgeI);
                }

                Bin.Write(m_strConsITCode);//AM

                Bin.Write((short)Quest.m_RewardItem[i].m_nConsITCnt);
                Bin.Write(0);


            }//228

            for(int i = 0; i < 2; i++)
            {             
               
                Bin.Write((short)Quest.m_RewardMastery[i].m_nConsMasteryID); //BK
                Bin.Write((short)0);                
                Bin.Write(Quest.m_RewardMastery[i].m_nConsMasteryCnt);
            }//248

            string ID1 = Encoding.UTF8.GetString(Quest.m_strConsSkillCode, 0, Quest.m_strConsSkillCode.Length);
            string purge1 = ID1.Replace("\0", string.Empty);
            int helperint1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge1));

            string ID2 = Encoding.UTF8.GetString(Quest.m_strConsForceCode, 0, Quest.m_strConsForceCode.Length);
            string purge2 = ID2.Replace("\0", string.Empty);
            int helperint2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge2));

            Bin.Write(helperint1);  //BS
            Bin.Write(Quest.m_nConsSkillCnt);
            Bin.Write(helperint2);
            Bin.Write(Quest.m_nConsForceCnt);
            ///BW m_strQuestFinishContents_F0
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F0);  //BX
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_F4);

            //double check this section it may be wrong
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U0);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestFinishContents_U4);
            //end of double check section
            
           // 308

            string ID10 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_0, 0, Quest.m_strLinkQuest_0.Length);
            string purge10 = ID10.Replace("\0", string.Empty);
            int str_0 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge10));

            string ID11 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_1, 0, Quest.m_strLinkQuest_1.Length);
            string purge11 = ID11.Replace("\0", string.Empty);
            int str_1 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge11));

            string ID12 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_2, 0, Quest.m_strLinkQuest_2.Length);
            string purge12 = ID12.Replace("\0", string.Empty);
            int str_2 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge12));

            string ID13 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_3, 0, Quest.m_strLinkQuest_3.Length);
            string purge13 = ID13.Replace("\0", string.Empty);
            int str_3 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge13));

            string ID14 = Encoding.UTF8.GetString(Quest.m_strLinkQuest_4, 0, Quest.m_strLinkQuest_4.Length);
            string purge14 = ID14.Replace("\0", string.Empty);
            int str_4 = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge14));

            Bin.Write(str_0);  //CG
            Bin.Write(str_0);  
            Bin.Write(str_1);
            Bin.Write(str_1);
            Bin.Write(str_2);
            Bin.Write(str_2);
            Bin.Write(str_3);
            Bin.Write(str_3);
            Bin.Write(str_4);
            Bin.Write(str_4);  //CP

            Bin.Write(DataPile[(int)Quest.m_dwIndex].QuestNameNumber);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_0);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestBriefContents_4);            
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_0);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_1);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_2);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_3);
            Bin.Write(DataPile[(int)Quest.m_dwIndex].m_strQuestSummaryContents_4);
           
            Bin.Write(Quest.m_nStore_trade); //396
            for (int i = 0; i < 3; i++)
            {
                Bin.Write(DataPile[(int)Quest.m_dwIndex].Client_IsFailCheck[i]);
                Bin.Write(Quest.m_QuestFailCond[i].m_nFailCondition);

                string IDF = Encoding.UTF8.GetString(Quest.m_QuestFailCond[i].m_strFailCode, 0, Quest.m_QuestFailCond[i].m_strFailCode.Length);
                string purgeF = IDF.Replace("\0", string.Empty);
                int str_F = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purgeF));

                Bin.Write(str_F);

            }//432

            Bin.Write(0);
            Bin.Write(Quest.m_nViewportType);

            string ID4 = Encoding.UTF8.GetString(Quest.m_strViewportCode, 0, Quest.m_strViewportCode.Length);
            string purge4 = ID4.Replace("\0", string.Empty);
            int m_strViewportCode = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge4));

            string ID5 = Encoding.UTF8.GetString(Quest.m_strFailLinkQuest, 0, Quest.m_strFailLinkQuest.Length);
            string purge5 = ID5.Replace("\0", string.Empty);
            int FailLinkQuest = help.Hex_ServerCodeToClient(Encoding.UTF8.GetBytes(purge5));

            Bin.Write(m_strViewportCode);           
            Bin.Write(0);
            Bin.Write(FailLinkQuest);                       

        }
        public Structure._Quest_fld[] ReadFile_Quest_fld(string path)
        {
            using (var stream = System.IO.File.OpenRead(path))
            using (var reader = new BinaryReader(stream))
            {
                int _Header = reader.ReadInt32();
                int _columns = reader.ReadInt32();
                int _size = reader.ReadInt32();
                QuestEdit = new Structure._Quest_fld[_Header];
                Helpers helper = new Helpers();

                for (int i = 0; i < _Header; i++)
                {
                    QuestEdit[i] = STR.Read_Quest_Fld(reader);
                    //build list of index during the read
                    if(QuestEdit[i].m_n2 == 0)
                    {
                        //bell                        
                        string ID0 = Encoding.UTF8.GetString(QuestEdit[i].m_strLinkQuest_0, 0, QuestEdit[i].m_strLinkQuest_0.Length);
                        string purge0 = ID0.Replace("\0", string.Empty);
                        //shrink to 7 bytes
                        string ID1 = Encoding.UTF8.GetString(QuestEdit[i].m_strCode, 0, QuestEdit[i].m_strCode.Length);
                        string purge1 = ID1.Replace("\0", string.Empty);

                        if (purge0.Length == 7)
                        {
                            //add to the index
                            BellQuestOrder.Add(purge1, QuestEdit[i].m_dwIndex.ToString()); 
                            BellQuestOrder0.Add(purge0, QuestEdit[i].m_dwIndex.ToString()); 

                        }
                        else
                        {
                            string[] tester = BellQuestOrder0.GetValues(purge1);
                            if (tester != null)
                            {
                                BellQuestOrder.Add(purge1, QuestEdit[i].m_dwIndex.ToString());
                            }
                        }
                        


                    }
                    else if (QuestEdit[i].m_n2 == 1)
                    {
                        //cora
                        string ID0 = Encoding.UTF8.GetString(QuestEdit[i].m_strLinkQuest_0, 0, QuestEdit[i].m_strLinkQuest_0.Length);
                        string purge0 = ID0.Replace("\0", string.Empty);
                        //shrink to 7 bytes
                        string ID1 = Encoding.UTF8.GetString(QuestEdit[i].m_strCode, 0, QuestEdit[i].m_strCode.Length);
                        string purge1 = ID1.Replace("\0", string.Empty);

                        if (purge0.Length == 7)
                        {
                            //add to the index
                            CoraQuestOrder.Add(purge1, QuestEdit[i].m_dwIndex.ToString());
                            CoraQuestOrder0.Add(purge0, QuestEdit[i].m_dwIndex.ToString());

                        }
                        else
                        {
                            string[] tester = CoraQuestOrder0.GetValues(purge1);
                            if (tester != null)
                            {
                                CoraQuestOrder.Add(purge1, QuestEdit[i].m_dwIndex.ToString());
                            }
                        }
                    }
                    else if (QuestEdit[i].m_n2 == 2)
                    {
                        //acc
                        string ID0 = Encoding.UTF8.GetString(QuestEdit[i].m_strLinkQuest_0, 0, QuestEdit[i].m_strLinkQuest_0.Length);
                        string purge0 = ID0.Replace("\0", string.Empty);
                        //shrink to 7 bytes
                        string ID1 = Encoding.UTF8.GetString(QuestEdit[i].m_strCode, 0, QuestEdit[i].m_strCode.Length);
                        string purge1 = ID1.Replace("\0", string.Empty);

                        if (purge0.Length == 7)
                        {
                            //add to the index
                            AccQuestOrder.Add(purge1, QuestEdit[i].m_dwIndex.ToString());
                            AccQuestOrder0.Add(purge0, QuestEdit[i].m_dwIndex.ToString());

                        }
                        else
                        {
                            string[] tester = AccQuestOrder0.GetValues(purge1);
                            if (tester != null)
                            {
                                AccQuestOrder.Add(purge1, QuestEdit[i].m_dwIndex.ToString());
                            }
                        }
                    }

                }
               
            }
            return QuestEdit;
        }

        public void ReadFile(string path)
        {
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
                    QuestEdit = new Structure._Quest_fld[_Header];

                    for (int i = 0; i < _Header; i++)
                    {
                        QuestEdit[i] = STR.Read_Quest_Fld(reader);

                    }

                    GC.KeepAlive(QuestEdit);


                    reader.Dispose();
                    reader.Close();

                    TreeNode root0 = new TreeNode() { Name = "Bellato", Text = "Bellato" };
                    TreeNode root1 = new TreeNode() { Name = "Cora", Text = "Cora" };
                    TreeNode root2 = new TreeNode() { Name = "Acc", Text = "Acc" };
                    treeView1.Nodes.Add(root0);
                    treeView1.Nodes.Add(root1);
                    treeView1.Nodes.Add(root2);
                    for (int i = 0; i < _Header; i++)
                    {
                        string ID = Encoding.UTF8.GetString(QuestEdit[i].m_strCode, 0, QuestEdit[i].m_strCode.Length);
                        //add index value to compare here
                        Quest_KV_List.Add(ID, i.ToString());

                        if (QuestEdit[i].m_n2 == 0)
                        {
                            root0.Nodes.Add(ID);

                        }
                        else if (QuestEdit[i].m_n2 == 1)
                        {
                            root1.Nodes.Add(ID);

                        }
                        else
                        {
                            root2.Nodes.Add(ID);

                        }

                    }


                }
            }


            if (path == "HolyStoneKeepperQuest.dat")
            {
                Monster_KV_List.Add("09B00", "09B00 AKA BCC");
                Monster_KV_List.Add("09B01", "09B01 AKA CCC");
                Monster_KV_List.Add("09B02", "09B02 AKA ACC");
            }
            else
            {
                ItemSTR();
                MonsterCharacter_str();
                NPCCharacter();

            }
            PrepareQuestServerSide();


            Fill_Quest_Data();
            
        }
        public void PrepareQuestServerSide()
        {
            QuestNameContents();
            QuestItemContents();
            QuestBriefContents(); 
            QuestSummaryContents();
            QuestConditionResult();
            QuestFinishContents();
            QuestTextCodeRead();
        }
        private void QuestItemContents()
        {
            string path = "QuestItem.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    QuestItem = new List<QuestItems>();
                    for (int i = 0; i < _Header; i++)
                    {
                        QuestItem.Add(STR.Read_QuestItems(reader));

                    }
                    int indexvalue = 0;
                    QuestItem_KV_List.Add("-1", "-1");
                    QuestItem_KV_List.Add("0", "0"); //HolyStoneKeeperQuest
                    foreach (var str in QuestItem)
                    {
                        string ID = Encoding.UTF8.GetString(str.m_strID, 0, str.m_strID.Length);                       
                        string purge0 = ID.Replace("\0", string.Empty);                       
                        QuestItem_KV_List.Add(purge0, indexvalue.ToString());
                        indexvalue++;

                    }

                    GC.KeepAlive(STR_QuestName);
                    reader.Dispose();
                    reader.Close();
                }

            }
        }

        private void QuestNameContents()
        {
            string path = "QuestNameContents_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    STR_QuestName = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_QuestName.Add(STR.Read_Quest_STR(reader));

                    }
                    foreach (var str in STR_QuestName)
                    {
                        string ID = Encoding.UTF8.GetString(str.m_strCode, 0, str.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(str.m_strName_3, 0, str.m_strName_3.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);

                        QuestName_KV_List.Add(purge0, purge1);

                    }

                    GC.KeepAlive(STR_QuestName);
                    reader.Dispose();
                    reader.Close();
                }

            }
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

        private void QuestConditionResult()
        {
            string path = "QuestConditionResult_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    STR_QuestConditionResult = new List<Structure.STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_QuestConditionResult.Add(STR.Read_Quest_STR(reader));

                    }
                    foreach (var str in STR_QuestConditionResult)
                    {
                        string ID = Encoding.UTF8.GetString(str.m_strCode, 0, str.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(str.m_strName_3, 0, str.m_strName_3.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);

                        QuestCondition_KV_List.Add(purge0, purge1);

                    }
                }

            }

        }

        private void QuestBriefContents()
        {
            string path = "QuestBriefContents_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    STR_QuestBriefContents = new List<Structure.STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_QuestBriefContents.Add(STR.Read_Quest_STR(reader));
                    }
                    foreach (var str in STR_QuestBriefContents)
                    {
                        string ID = Encoding.UTF8.GetString(str.m_strCode, 0, str.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(str.m_strName_3, 0, str.m_strName_3.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);

                        QuestBrief_KV_List.Add(purge0, purge1);

                    }


                }

            }

        }

        private void QuestSummaryContents()
        {
            string path = "QuestSummaryContents_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    STR_QuestSummaryContents = new List<Structure.STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_QuestSummaryContents.Add(STR.Read_Quest_STR(reader));

                    }
                    foreach (var str in STR_QuestSummaryContents)
                    {
                        string ID = Encoding.UTF8.GetString(str.m_strCode, 0, str.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(str.m_strName_3, 0, str.m_strName_3.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);

                        QuestSummary_KV_List.Add(purge0, purge1);

                    }
                }

            }

        }

        private void QuestFinishContents()
        {
            string path = "QuestFinishContents_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead(path))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    STR_QuestFinishContents = new List<Structure.STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_QuestFinishContents.Add(STR.Read_Quest_STR(reader));

                    }
                    foreach (var str in STR_QuestFinishContents)
                    {
                        string ID = Encoding.UTF8.GetString(str.m_strCode, 0, str.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(str.m_strName_3, 0, str.m_strName_3.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);

                        QuestFinish_KV_List.Add(purge0, purge1);

                    }

                }

            }

        }

        private void NPCCharacter()
        {
            string path = "NPCharacter_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("NPCharacter_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_NPCs = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_NPCs.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var npc in STR_NPCs)
                    {
                        string ID = Encoding.UTF8.GetString(npc.m_strCode, 0, npc.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(npc.m_strName_4, 0, npc.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        NPC_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }


        }

        private void ItemSTR()
        {
            string path = "TOWNItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("TOWNItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }

            path = "PotionItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("PotionItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }

            path = "BoxItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("BoxItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "WeaponItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("WeaponItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "shielDItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("shielDItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "bagItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("bagItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_3, 0, item.m_strName_3.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "BulletItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("BulletItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "forCeItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("forCeItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "baTteryItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("baTteryItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_3, 0, item.m_strName_3.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "UpperItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("UpperItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "ShoeItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("ShoeItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "LowerItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("LowerItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "GauntletItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("GauntletItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "HelmetItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("HelmetItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "rIngItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("rIngItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "AmuletItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("AmuletItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "bootYItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("bootYItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "ResourceItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("ResourceItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "cloaKItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("cloaKItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "AnimusItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("AnimusItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "RadarItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("RadarItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "TicketItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("TicketItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            path = "RecoveryItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("RecoveryItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_File>();
                    for (int i = 0; i < _Header; i++)
                    {
                        STR_ITEMS.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var item in STR_ITEMS)
                    {
                        string ID = Encoding.UTF8.GetString(item.m_strCode, 0, item.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(item.m_strName_4, 0, item.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        ITEM_KV_List.Add(purge0, nodename);

                    }
                    reader.Dispose();
                    reader.Close();
                }
            }


        }

        private void MonsterCharacter_str()
        {
            string path = "MonsterCharacter_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("MonsterCharacter_str.dat"))
                using (var reader = new BinaryReader(stream))
                {
                    STR_Monsters = new List<STR_File>();
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();

                    for (int i = 0; i < _Header; i++)
                    {
                        STR_Monsters.Add(STR.Read_STR_Monster(reader));
                    }
                    foreach (var monster in STR_Monsters)
                    {
                        string ID = Encoding.UTF8.GetString(monster.m_strCode, 0, monster.m_strCode.Length);
                        string name = Encoding.UTF8.GetString(monster.m_strName_4, 0, monster.m_strName_4.Length);

                        string purge0 = ID.Replace("\0", string.Empty);
                        string purge1 = name.Replace("\0", string.Empty);
                        string nodename = string.Format("{0} AKA {1}", purge0, purge1);

                        Monster_KV_List.Add(purge0, nodename);

                    }                   
                    reader.Dispose();
                    reader.Close();
                }
            }


        }

        public void Fill_Quest_Data()
        {
            Helpers helper = new Helpers();
            Structure._Quest_fld Quest = QuestEdit[QuestIndex];
            m_nActType_0.Text = Quest.m_ActionNode[0].m_nActType.ToString();
            Enum_ActType_0.Text = STR._Action_Node_m_nActTypes(Quest.m_ActionNode[0].m_nActType);
            if (Quest.m_ActionNode[0].m_nActType == 3)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_ActionNode[0].m_strActSub, 0, Quest.m_ActionNode[0].m_strActSub.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = Monster_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Monster_node_0.Text = values[0];
                    }


                }
                catch
                {
                    Monster_node_0.Text = "catch";
                }

            }
            else if (Quest.m_ActionNode[0].m_nActType == 1 || Quest.m_ActionNode[0].m_nActType == 14 || Quest.m_ActionNode[0].m_nActType == 17)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_ActionNode[0].m_strActSub, 0, Quest.m_ActionNode[0].m_strActSub.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = NPC_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Monster_node_0.Text = values[0];
                    }
                }
                catch
                {
                    Monster_node_0.Text = "";
                }
            }

            else
            {
                Monster_node_0.Text = "";
            }
            m_strActSub_0.Text = helper.ByteString(Quest.m_ActionNode[0].m_strActSub);
            m_strActSub2_0.Text = helper.ByteString(Quest.m_ActionNode[0].m_strActSub2);
            m_strActArea_0.Text = helper.ByteString(Quest.m_ActionNode[0].m_strActArea);
            m_nReqAct_0.Text = Quest.m_ActionNode[0].m_nReqAct.ToString();
            m_nSetCntPro_100_0.Text = Quest.m_ActionNode[0].m_nSetCntPro_100.ToString();
            m_strLinkQuestItem_0.Text = helper.ByteString(Quest.m_ActionNode[0].m_strLinkQuestItem);
            m_nOrder_0.Text = Quest.m_ActionNode[0].m_nOrder.ToString();

            m_nActType_1.Text = Quest.m_ActionNode[1].m_nActType.ToString();
            Enum_ActType_1.Text = STR._Action_Node_m_nActTypes(Quest.m_ActionNode[1].m_nActType);
            if (Quest.m_ActionNode[1].m_nActType == 3)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_ActionNode[1].m_strActSub, 0, Quest.m_ActionNode[1].m_strActSub.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = Monster_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Monster_node_1.Text = values[0];
                    }

                }
                catch
                {
                    Monster_node_1.Text = "";
                }

            }
            else if (Quest.m_ActionNode[1].m_nActType == 1 || Quest.m_ActionNode[1].m_nActType == 14 || Quest.m_ActionNode[1].m_nActType == 17)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_ActionNode[1].m_strActSub, 0, Quest.m_ActionNode[1].m_strActSub.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = NPC_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Monster_node_1.Text = values[0];
                    }
                }
                catch
                {
                    Monster_node_1.Text = "";
                }
            }
            else
            {
                Monster_node_1.Text = "";
            }

            m_strActSub_1.Text = helper.ByteString(Quest.m_ActionNode[1].m_strActSub);
            m_strActSub2_1.Text = helper.ByteString(Quest.m_ActionNode[1].m_strActSub2);
            m_strActArea_1.Text = helper.ByteString(Quest.m_ActionNode[1].m_strActArea);
            m_nReqAct_1.Text = Quest.m_ActionNode[1].m_nReqAct.ToString();
            m_nSetCntPro_100_1.Text = Quest.m_ActionNode[1].m_nSetCntPro_100.ToString();
            m_strLinkQuestItem_1.Text = helper.ByteString(Quest.m_ActionNode[1].m_strLinkQuestItem);
            m_nOrder_1.Text = Quest.m_ActionNode[1].m_nOrder.ToString();

            m_nActType_2.Text = Quest.m_ActionNode[2].m_nActType.ToString();
            Enum_ActType_2.Text = STR._Action_Node_m_nActTypes(Quest.m_ActionNode[2].m_nActType);
            if (Quest.m_ActionNode[2].m_nActType == 3)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_ActionNode[2].m_strActSub, 0, Quest.m_ActionNode[2].m_strActSub.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = Monster_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Monster_node_2.Text = values[0];
                    }

                }
                catch
                {
                    Monster_node_2.Text = "";
                }

            }
            else if (Quest.m_ActionNode[2].m_nActType == 1 || Quest.m_ActionNode[2].m_nActType == 14 || Quest.m_ActionNode[2].m_nActType == 17)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_ActionNode[2].m_strActSub, 0, Quest.m_ActionNode[2].m_strActSub.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = NPC_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Monster_node_2.Text = values[0];
                    }

                }
                catch
                {
                    Monster_node_2.Text = "";
                }
            }

            else
            {
                Monster_node_2.Text = "";
            }

            m_strActSub_2.Text = helper.ByteString(Quest.m_ActionNode[2].m_strActSub);
            m_strActSub2_2.Text = helper.ByteString(Quest.m_ActionNode[2].m_strActSub2);
            m_strActArea_2.Text = helper.ByteString(Quest.m_ActionNode[2].m_strActArea);
            m_nReqAct_2.Text = Quest.m_ActionNode[2].m_nReqAct.ToString();
            m_nSetCntPro_100_2.Text = Quest.m_ActionNode[2].m_nSetCntPro_100.ToString();
            m_strLinkQuestItem_2.Text = helper.ByteString(Quest.m_ActionNode[2].m_strLinkQuestItem);
            m_nOrder_2.Text = Quest.m_ActionNode[2].m_nOrder.ToString();


            //Items
            m_strConsITCode_0.Text = helper.ByteString(Quest.m_RewardItem[0].m_strConsITCode);
            m_nConsITCnt_0.Text = Quest.m_RewardItem[0].m_nConsITCnt.ToString();
            m_nLinkQuestIdx_0.Text = Quest.m_RewardItem[0].m_nLinkQuestIdx.ToString();
            m_strConsITCode_1.Text = helper.ByteString(Quest.m_RewardItem[1].m_strConsITCode);
            m_nConsITCnt_1.Text = Quest.m_RewardItem[1].m_nConsITCnt.ToString();
            m_nLinkQuestIdx_1.Text = Quest.m_RewardItem[1].m_nLinkQuestIdx.ToString();
            m_strConsITCode_2.Text = helper.ByteString(Quest.m_RewardItem[2].m_strConsITCode);
            m_nConsITCnt_2.Text = Quest.m_RewardItem[2].m_nConsITCnt.ToString();
            m_nLinkQuestIdx_2.Text = Quest.m_RewardItem[2].m_nLinkQuestIdx.ToString();
            m_strConsITCode_3.Text = helper.ByteString(Quest.m_RewardItem[3].m_strConsITCode);
            m_nConsITCnt_3.Text = Quest.m_RewardItem[3].m_nConsITCnt.ToString();
            m_nLinkQuestIdx_3.Text = Quest.m_RewardItem[3].m_nLinkQuestIdx.ToString();
            m_strConsITCode_4.Text = helper.ByteString(Quest.m_RewardItem[4].m_strConsITCode);
            m_nConsITCnt_4.Text = Quest.m_RewardItem[4].m_nConsITCnt.ToString();
            m_nLinkQuestIdx_4.Text = Quest.m_RewardItem[4].m_nLinkQuestIdx.ToString();
            m_strConsITCode_5.Text = helper.ByteString(Quest.m_RewardItem[5].m_strConsITCode);
            m_nConsITCnt_5.Text = Quest.m_RewardItem[5].m_nConsITCnt.ToString();
            m_nLinkQuestIdx_5.Text = Quest.m_RewardItem[5].m_nLinkQuestIdx.ToString();


            if (Quest.m_RewardItem[0].m_nConsITCnt > 0)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_RewardItem[0].m_strConsITCode, 0, Quest.m_RewardItem[0].m_strConsITCode.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = ITEM_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Reward_Item_0.Text = values[0];
                    }

                }
                catch
                {
                    Reward_Item_0.Text = "";
                }

            }
            else
            {
                Reward_Item_0.Text = "";
            }

            if (Quest.m_RewardItem[1].m_nConsITCnt > 0)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_RewardItem[1].m_strConsITCode, 0, Quest.m_RewardItem[1].m_strConsITCode.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = ITEM_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Reward_Item_1.Text = values[0];
                    }
                }
                catch
                {
                    Reward_Item_1.Text = "";
                }

            }
            else
            {
                Reward_Item_1.Text = "";
            }

            if (Quest.m_RewardItem[2].m_nConsITCnt > 0)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_RewardItem[2].m_strConsITCode, 0, Quest.m_RewardItem[2].m_strConsITCode.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = ITEM_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Reward_Item_2.Text = values[0];
                    }
                }
                catch
                {
                    Reward_Item_2.Text = "";
                }

            }
            else
            {
                Reward_Item_2.Text = "";
            }

            if (Quest.m_RewardItem[3].m_nConsITCnt > 0)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_RewardItem[3].m_strConsITCode, 0, Quest.m_RewardItem[3].m_strConsITCode.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = ITEM_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Reward_Item_3.Text = values[0];
                    }
                }
                catch
                {
                    Reward_Item_3.Text = "";
                }

            }
            else
            {
                Reward_Item_3.Text = "";
            }

            if (Quest.m_RewardItem[4].m_nConsITCnt > 0)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_RewardItem[4].m_strConsITCode, 0, Quest.m_RewardItem[4].m_strConsITCode.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = ITEM_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Reward_Item_4.Text = values[0];
                    }

                }
                catch
                {
                    Reward_Item_4.Text = "";
                }

            }
            else
            {
                Reward_Item_4.Text = "";
            }

            if (Quest.m_RewardItem[5].m_nConsITCnt > 0)
            {
                string ID = Encoding.UTF8.GetString(Quest.m_RewardItem[5].m_strConsITCode, 0, Quest.m_RewardItem[5].m_strConsITCode.Length);
                string purge0 = ID.Replace("\0", string.Empty);
                try
                {
                    string[] values = ITEM_KV_List.GetValues(purge0);
                    if (values != null)
                    {
                        Reward_Item_5.Text = values[0];
                    }
                }
                catch
                {
                    Reward_Item_5.Text = "";
                }

            }
            else
            {
                Reward_Item_5.Text = "";
            }



            m_nConsMasteryID_0.Text = Quest.m_RewardMastery[0].m_nConsMasteryID.ToString();
            m_nConsMasterySubID_0.Text = Quest.m_RewardMastery[0].m_nConsMasterySubID.ToString();
            m_nConsMasteryCnt_0.Text = Quest.m_RewardMastery[0].m_nConsMasteryCnt.ToString();
            m_nConsMasteryID_1.Text = Quest.m_RewardMastery[1].m_nConsMasteryID.ToString();
            m_nConsMasterySubID_1.Text = Quest.m_RewardMastery[1].m_nConsMasterySubID.ToString();
            m_nConsMasteryCnt_1.Text = Quest.m_RewardMastery[1].m_nConsMasteryCnt.ToString();


            m_nFailCondition_0.Text = Quest.m_QuestFailCond[0].m_nFailCondition.ToString();
            m_strFailCode_0.Text = helper.ByteString(Quest.m_QuestFailCond[0].m_strFailCode);
            m_nFailCondition_1.Text = Quest.m_QuestFailCond[1].m_nFailCondition.ToString();
            m_strFailCode_1.Text = helper.ByteString(Quest.m_QuestFailCond[1].m_strFailCode);
            m_nFailCondition_2.Text = Quest.m_QuestFailCond[2].m_nFailCondition.ToString();
            m_strFailCode_2.Text = helper.ByteString(Quest.m_QuestFailCond[2].m_strFailCode);

            m_nLimLv.Text = Quest.m_nLimLv.ToString();
            m_nQuestType.Text = Quest.m_nQuestType.ToString();
            m_bQuestRepeat.Text = Quest.m_bQuestRepeat.ToString();
            m_dRepeatTime.Text = Quest.m_dRepeatTime.ToString();
            m_nDifficultyLevel.Text = Quest.m_nDifficultyLevel.ToString();

            m_bSelectQuestMenual.Text = Quest.m_bSelectQuestMenual.ToString();
            m_bCompQuestType.Text = Quest.m_bCompQuestType.ToString();

            m_nMaxLevel.Text = Quest.m_nMaxLevel.ToString();
            m_dConsExp.Text = Quest.m_dConsExp.ToString();
            m_nConsContribution.Text = Quest.m_nConsContribution.ToString();
            m_nConsDalant.Text = Quest.m_nConsDalant.ToString();
            m_nConspvppoint.Text = Quest.m_nConspvppoint.ToString();
            m_nConsGold.Text = Quest.m_nConsGold.ToString();
            m_bSelectConsITMenual.Text = Quest.m_bSelectConsITMenual.ToString();

            m_strConsSkillCode.Text = helper.ByteString(Quest.m_strConsSkillCode);
            m_nConsSkillCnt.Text = Quest.m_nConsSkillCnt.ToString();
            m_strConsForceCode.Text = helper.ByteString(Quest.m_strConsForceCode);
            m_nConsForceCnt.Text = Quest.m_nConsForceCnt.ToString();
            m_strLinkQuest_0.Text = helper.ByteString(Quest.m_strLinkQuest_0);
            m_strLinkQuest_1.Text = helper.ByteString(Quest.m_strLinkQuest_1);
            m_strLinkQuest_2.Text = helper.ByteString(Quest.m_strLinkQuest_2);
            m_strLinkQuest_3.Text = helper.ByteString(Quest.m_strLinkQuest_3);
            m_strLinkQuest_4.Text = helper.ByteString(Quest.m_strLinkQuest_4);
            m_nLinkQuestGroupID.Text = Quest.m_nLinkQuestGroupID.ToString();
            m_bFailCheck.Text = Quest.m_bFailCheck.ToString();

            m_strFailBriefCode.Text = helper.ByteString(Quest.m_strFailBriefCode);
            m_nLinkDummyCond.Text = Quest.m_nLinkDummyCond.ToString();
            m_strLinkDummyCode.Text = helper.ByteString(Quest.m_strLinkDummyCode);
            m_strFailLinkQuest.Text = helper.ByteString(Quest.m_strFailLinkQuest);
            m_nViewportType.Text = Quest.m_nViewportType.ToString();
            m_strViewportCode.Text = helper.ByteString(Quest.m_strViewportCode);
            m_nStore_trade.Text = Quest.m_nStore_trade.ToString();
            m_txtQTExp.Text = helper.ByteString(Quest.m_txtQTExp);

            //sometimes title doesnt update because no value exists for that index
            string Title = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purgezero = Title.Replace("\0", string.Empty);

            string[] values1 = QuestName_KV_List.GetValues(purgezero);
            if (values1 != null)
            {
                this.groupBox15.Text = purgezero + " " + values1[0];
            }
            else
            {
                this.groupBox15.Text = "title unavailable - QuestNameContents.dat missing name";
            }
            //Quest_STRs
            string ID_text = Encoding.UTF8.GetString(Quest.m_strCode, 0, Quest.m_strCode.Length);
            string purge0_text = ID_text.Replace("\0", string.Empty);

            QuestBrief.Clear();
            QuestCondition.Clear();
            QuestFinish_0.Clear();
            QuestFinish_1.Clear();
            QuestSummary.Clear();

            if (QuestTextCodes != null)
            {
                foreach (var text in QuestTextCodes)
                {
                    string ID1 = Encoding.UTF8.GetString(text.m_strCode_0, 0, text.m_strCode_0.Length);
                    string purge1 = ID1.Replace("\0", string.Empty);
                    if (purge0_text.Equals(purge1))
                    {
                        string QB0 = helper.ByteString(text.m_strQuestBriefContents_0);
                        string QB1 = helper.ByteString(text.m_strQuestBriefContents_1);
                        string QB2 = helper.ByteString(text.m_strQuestBriefContents_2);
                        string QB3 = helper.ByteString(text.m_strQuestBriefContents_3);
                        string QB4 = helper.ByteString(text.m_strQuestBriefContents_4);
                        QuestBrief.AppendText(QuestBrief_KV_List.Get(QB0));
                        QuestBrief.AppendText(Environment.NewLine + QuestBrief_KV_List.Get(QB1));
                        QuestBrief.AppendText(Environment.NewLine + QuestBrief_KV_List.Get(QB2));
                        QuestBrief.AppendText(Environment.NewLine + QuestBrief_KV_List.Get(QB3));
                        QuestBrief.AppendText(Environment.NewLine + QuestBrief_KV_List.Get(QB4));
                        QuestBrief.ScrollToCaret();

                        string QC0 = helper.ByteString(text.m_strQuestConditionResult_0);
                        string QC1 = helper.ByteString(text.m_strQuestConditionResult_1);
                        string QC2 = helper.ByteString(text.m_strQuestConditionResult_2);
                        string QC3 = helper.ByteString(text.m_strQuestConditionResult_3);
                        string QC4 = helper.ByteString(text.m_strQuestConditionResult_4);
                        QuestCondition.AppendText(QuestCondition_KV_List.Get(QC0));
                        QuestCondition.AppendText(Environment.NewLine + QuestCondition_KV_List.Get(QC1));
                        QuestCondition.AppendText(Environment.NewLine + QuestCondition_KV_List.Get(QC2));
                        QuestCondition.AppendText(Environment.NewLine + QuestCondition_KV_List.Get(QC3));
                        QuestCondition.AppendText(Environment.NewLine + QuestCondition_KV_List.Get(QC4));
                        QuestCondition.ScrollToCaret();

                        string QS0 = helper.ByteString(text.m_strQuestSummaryContents_0);
                        string QS1 = helper.ByteString(text.m_strQuestSummaryContents_1);
                        string QS2 = helper.ByteString(text.m_strQuestSummaryContents_2);
                        string QS3 = helper.ByteString(text.m_strQuestSummaryContents_3);
                        string QS4 = helper.ByteString(text.m_strQuestSummaryContents_4);
                        QuestSummary.AppendText(QuestSummary_KV_List.Get(QS0));
                        QuestSummary.AppendText(Environment.NewLine + QuestSummary_KV_List.Get(QS1));
                        QuestSummary.AppendText(Environment.NewLine + QuestSummary_KV_List.Get(QS2));
                        QuestSummary.AppendText(Environment.NewLine + QuestSummary_KV_List.Get(QS3));
                        QuestSummary.AppendText(Environment.NewLine + QuestSummary_KV_List.Get(QS4));
                        QuestSummary.ScrollToCaret();

                        string QF0 = helper.ByteString(text.m_strQuestFinishContents_U0);
                        string QF1 = helper.ByteString(text.m_strQuestFinishContents_U1);
                        string QF2 = helper.ByteString(text.m_strQuestFinishContents_U2);
                        string QF3 = helper.ByteString(text.m_strQuestFinishContents_U3);
                        string QF4 = helper.ByteString(text.m_strQuestFinishContents_U4);
                        QuestFinish_0.AppendText(QuestFinish_KV_List.Get(QF0));
                        QuestFinish_0.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF1));
                        QuestFinish_0.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF2));
                        QuestFinish_0.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF3));
                        QuestFinish_0.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF4));
                        QuestFinish_0.ScrollToCaret();

                        string QF5 = helper.ByteString(text.m_strQuestFinishContents_F0);
                        string QF6 = helper.ByteString(text.m_strQuestFinishContents_F1);
                        string QF7 = helper.ByteString(text.m_strQuestFinishContents_F2);
                        string QF8 = helper.ByteString(text.m_strQuestFinishContents_F3);
                        string QF9 = helper.ByteString(text.m_strQuestFinishContents_F4);
                        QuestFinish_1.AppendText(QuestFinish_KV_List.Get(QF5));
                        QuestFinish_1.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF6));
                        QuestFinish_1.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF7));
                        QuestFinish_1.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF8));
                        QuestFinish_1.AppendText(Environment.NewLine + QuestFinish_KV_List.Get(QF9));
                        QuestFinish_1.ScrollToCaret();

                        return;
                    }

                }
            }


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {


            if (this.treeView1.SelectedNode.Text == "Bellato" || this.treeView1.SelectedNode.Text == "Cora" || this.treeView1.SelectedNode.Text == "Acc")
            {
                return;
            }
            else
            {
                Quest_KV_List.Get(QuestIndex);
                string name = this.treeView1.SelectedNode.Text;
                string[] GetNames = Quest_KV_List.GetValues(name);

                int x = Int32.Parse(GetNames[0]);
                QuestIndex = (int)QuestEdit[x].m_dwIndex;

                Fill_Quest_Data();



            }



        }

        private void Save_Data_Button_Click(object sender, EventArgs e)
        {

            QuestEdit[QuestIndex].m_nLimLv = Int32.Parse(m_nLimLv.Text);
            QuestEdit[QuestIndex].m_nQuestType = Int32.Parse(m_nQuestType.Text);
            QuestEdit[QuestIndex].m_bQuestRepeat = Int32.Parse(m_bQuestRepeat.Text);
            QuestEdit[QuestIndex].m_dRepeatTime = Int32.Parse(m_dRepeatTime.Text);
            QuestEdit[QuestIndex].m_nDifficultyLevel = Int32.Parse(m_nDifficultyLevel.Text);
            QuestEdit[QuestIndex].m_bSelectQuestMenual = Int32.Parse(m_bSelectQuestMenual.Text);
            QuestEdit[QuestIndex].m_bCompQuestType = Int32.Parse(m_bCompQuestType.Text);
            QuestEdit[QuestIndex].m_nMaxLevel = Int32.Parse(m_nMaxLevel.Text);
            QuestEdit[QuestIndex].m_dConsExp = Int32.Parse(m_dConsExp.Text);
            QuestEdit[QuestIndex].m_nConsContribution = Int32.Parse(m_nConsContribution.Text);
            QuestEdit[QuestIndex].m_nConsDalant = Int32.Parse(m_nConsDalant.Text);
            QuestEdit[QuestIndex].m_nConspvppoint = Int32.Parse(m_nConspvppoint.Text);
            QuestEdit[QuestIndex].m_nConsGold = Int32.Parse(m_nConsGold.Text);
            QuestEdit[QuestIndex].m_bSelectConsITMenual = Int32.Parse(m_bSelectConsITMenual.Text);
            QuestEdit[QuestIndex].m_strConsSkillCode = Encoding.UTF8.GetBytes(m_strConsSkillCode.Text);
            QuestEdit[QuestIndex].m_nConsSkillCnt = Int32.Parse(m_nConsSkillCnt.Text);
            QuestEdit[QuestIndex].m_strConsForceCode = Encoding.UTF8.GetBytes(m_strConsForceCode.Text);
            QuestEdit[QuestIndex].m_nConsForceCnt = Int32.Parse(m_nConsForceCnt.Text);
            QuestEdit[QuestIndex].m_strLinkQuest_0 = Encoding.UTF8.GetBytes(m_strLinkQuest_0.Text);
            QuestEdit[QuestIndex].m_strLinkQuest_1 = Encoding.UTF8.GetBytes(m_strLinkQuest_1.Text);
            QuestEdit[QuestIndex].m_strLinkQuest_2 = Encoding.UTF8.GetBytes(m_strLinkQuest_2.Text);
            QuestEdit[QuestIndex].m_strLinkQuest_3 = Encoding.UTF8.GetBytes(m_strLinkQuest_3.Text);
            QuestEdit[QuestIndex].m_strLinkQuest_4 = Encoding.UTF8.GetBytes(m_strLinkQuest_4.Text);
            QuestEdit[QuestIndex].m_nLinkQuestGroupID = Int32.Parse(m_nLinkQuestGroupID.Text);
            QuestEdit[QuestIndex].m_bFailCheck = Int32.Parse(m_bFailCheck.Text);
            QuestEdit[QuestIndex].m_strFailBriefCode = Encoding.UTF8.GetBytes(m_strFailBriefCode.Text);
            QuestEdit[QuestIndex].m_nLinkDummyCond = Int32.Parse(m_nLinkDummyCond.Text);
            QuestEdit[QuestIndex].m_strLinkDummyCode = Encoding.UTF8.GetBytes(m_strLinkDummyCode.Text);
            QuestEdit[QuestIndex].m_strFailLinkQuest = Encoding.UTF8.GetBytes(m_strFailLinkQuest.Text);
            QuestEdit[QuestIndex].m_nViewportType = Int32.Parse(m_nViewportType.Text);
            QuestEdit[QuestIndex].m_strViewportCode = Encoding.UTF8.GetBytes(m_strFailLinkQuest.Text);
            QuestEdit[QuestIndex].m_nStore_trade = Int32.Parse(m_nStore_trade.Text);
            QuestEdit[QuestIndex].m_txtQTExp = Encoding.UTF8.GetBytes(m_txtQTExp.Text);


        }

        private void Action_Node_Save_Button_Click(object sender, EventArgs e)
        {
            QuestEdit[QuestIndex].m_ActionNode[0].m_nActType = Int32.Parse(m_nActType_0.Text);
            QuestEdit[QuestIndex].m_ActionNode[0].m_strActSub = Encoding.UTF8.GetBytes(m_strActSub_0.Text);
            QuestEdit[QuestIndex].m_ActionNode[0].m_strActSub2 = Encoding.UTF8.GetBytes(m_strActSub2_0.Text);
            QuestEdit[QuestIndex].m_ActionNode[0].m_strActArea = Encoding.UTF8.GetBytes(m_strActArea_0.Text);
            QuestEdit[QuestIndex].m_ActionNode[0].m_nReqAct = Int32.Parse(m_nReqAct_0.Text);
            QuestEdit[QuestIndex].m_ActionNode[0].m_nSetCntPro_100 = Int32.Parse(m_nSetCntPro_100_0.Text);
            QuestEdit[QuestIndex].m_ActionNode[0].m_strLinkQuestItem = Encoding.UTF8.GetBytes(m_strLinkQuestItem_0.Text);
            QuestEdit[QuestIndex].m_ActionNode[0].m_nOrder = Int32.Parse(m_nOrder_0.Text);

            QuestEdit[QuestIndex].m_ActionNode[1].m_nActType = Int32.Parse(m_nActType_1.Text);
            QuestEdit[QuestIndex].m_ActionNode[1].m_strActSub = Encoding.UTF8.GetBytes(m_strActSub_1.Text);
            QuestEdit[QuestIndex].m_ActionNode[1].m_strActSub2 = Encoding.UTF8.GetBytes(m_strActSub2_1.Text);
            QuestEdit[QuestIndex].m_ActionNode[1].m_strActArea = Encoding.UTF8.GetBytes(m_strActArea_1.Text);
            QuestEdit[QuestIndex].m_ActionNode[1].m_nReqAct = Int32.Parse(m_nReqAct_1.Text);
            QuestEdit[QuestIndex].m_ActionNode[1].m_nSetCntPro_100 = Int32.Parse(m_nSetCntPro_100_1.Text);
            QuestEdit[QuestIndex].m_ActionNode[1].m_strLinkQuestItem = Encoding.UTF8.GetBytes(m_strLinkQuestItem_1.Text);
            QuestEdit[QuestIndex].m_ActionNode[1].m_nOrder = Int32.Parse(m_nOrder_1.Text);

            QuestEdit[QuestIndex].m_ActionNode[2].m_nActType = Int32.Parse(m_nActType_2.Text);
            QuestEdit[QuestIndex].m_ActionNode[2].m_strActSub = Encoding.UTF8.GetBytes(m_strActSub_2.Text);
            QuestEdit[QuestIndex].m_ActionNode[2].m_strActSub2 = Encoding.UTF8.GetBytes(m_strActSub2_2.Text);
            QuestEdit[QuestIndex].m_ActionNode[2].m_strActArea = Encoding.UTF8.GetBytes(m_strActArea_2.Text);
            QuestEdit[QuestIndex].m_ActionNode[2].m_nReqAct = Int32.Parse(m_nReqAct_2.Text);
            QuestEdit[QuestIndex].m_ActionNode[2].m_nSetCntPro_100 = Int32.Parse(m_nSetCntPro_100_2.Text);
            QuestEdit[QuestIndex].m_ActionNode[2].m_strLinkQuestItem = Encoding.UTF8.GetBytes(m_strLinkQuestItem_2.Text);
            QuestEdit[QuestIndex].m_ActionNode[2].m_nOrder = Int32.Parse(m_nOrder_2.Text);

        }

        private void Reward_Save_Button_Click(object sender, EventArgs e)
        {
            QuestEdit[QuestIndex].m_RewardItem[0].m_strConsITCode = Encoding.UTF8.GetBytes(m_strConsITCode_0.Text);
            QuestEdit[QuestIndex].m_RewardItem[0].m_nConsITCnt = Int32.Parse(m_nConsITCnt_0.Text);
            QuestEdit[QuestIndex].m_RewardItem[0].m_nLinkQuestIdx = Int32.Parse(m_nLinkQuestIdx_0.Text);

            QuestEdit[QuestIndex].m_RewardItem[1].m_strConsITCode = Encoding.UTF8.GetBytes(m_strConsITCode_1.Text);
            QuestEdit[QuestIndex].m_RewardItem[1].m_nConsITCnt = Int32.Parse(m_nConsITCnt_1.Text);
            QuestEdit[QuestIndex].m_RewardItem[1].m_nLinkQuestIdx = Int32.Parse(m_nLinkQuestIdx_1.Text);

            QuestEdit[QuestIndex].m_RewardItem[2].m_strConsITCode = Encoding.UTF8.GetBytes(m_strConsITCode_2.Text);
            QuestEdit[QuestIndex].m_RewardItem[2].m_nConsITCnt = Int32.Parse(m_nConsITCnt_2.Text);
            QuestEdit[QuestIndex].m_RewardItem[2].m_nLinkQuestIdx = Int32.Parse(m_nLinkQuestIdx_2.Text);

            QuestEdit[QuestIndex].m_RewardItem[3].m_strConsITCode = Encoding.UTF8.GetBytes(m_strConsITCode_3.Text);
            QuestEdit[QuestIndex].m_RewardItem[3].m_nConsITCnt = Int32.Parse(m_nConsITCnt_3.Text);
            QuestEdit[QuestIndex].m_RewardItem[3].m_nLinkQuestIdx = Int32.Parse(m_nLinkQuestIdx_3.Text);

            QuestEdit[QuestIndex].m_RewardItem[4].m_strConsITCode = Encoding.UTF8.GetBytes(m_strConsITCode_4.Text);
            QuestEdit[QuestIndex].m_RewardItem[4].m_nConsITCnt = Int32.Parse(m_nConsITCnt_4.Text);
            QuestEdit[QuestIndex].m_RewardItem[4].m_nLinkQuestIdx = Int32.Parse(m_nLinkQuestIdx_4.Text);

            QuestEdit[QuestIndex].m_RewardItem[5].m_strConsITCode = Encoding.UTF8.GetBytes(m_strConsITCode_5.Text);
            QuestEdit[QuestIndex].m_RewardItem[5].m_nConsITCnt = Int32.Parse(m_nConsITCnt_5.Text);
            QuestEdit[QuestIndex].m_RewardItem[5].m_nLinkQuestIdx = Int32.Parse(m_nLinkQuestIdx_5.Text);
        }

        private void Reward_Mastery_Save_Button_Click(object sender, EventArgs e)
        {
            QuestEdit[QuestIndex].m_RewardMastery[0].m_nConsMasteryID = Int32.Parse(m_nConsMasteryID_0.Text);
            QuestEdit[QuestIndex].m_RewardMastery[0].m_nConsMasterySubID = Int32.Parse(m_nConsMasterySubID_0.Text);
            QuestEdit[QuestIndex].m_RewardMastery[0].m_nConsMasteryCnt = Int32.Parse(m_nConsMasteryCnt_0.Text);

        }

        private void Fail_Condition_Save_Button_Click(object sender, EventArgs e)
        {
            QuestEdit[QuestIndex].m_QuestFailCond[0].m_nFailCondition = Int32.Parse(m_nFailCondition_0.Text);
            QuestEdit[QuestIndex].m_QuestFailCond[0].m_strFailCode = Encoding.UTF8.GetBytes(m_strFailCode_0.Text);

            QuestEdit[QuestIndex].m_QuestFailCond[1].m_nFailCondition = Int32.Parse(m_nFailCondition_1.Text);
            QuestEdit[QuestIndex].m_QuestFailCond[1].m_strFailCode = Encoding.UTF8.GetBytes(m_strFailCode_1.Text);

            QuestEdit[QuestIndex].m_QuestFailCond[2].m_nFailCondition = Int32.Parse(m_nFailCondition_2.Text);
            QuestEdit[QuestIndex].m_QuestFailCond[2].m_strFailCode = Encoding.UTF8.GetBytes(m_strFailCode_2.Text);
        }

        private void Dat_Export_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory("Server_Files");
            string fileName = OpenFile;
            string path = Path.Combine(Environment.CurrentDirectory, @"Server_files\", fileName);
            

            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(QuestEdit.Length);
                    writer.Write(90);
                    writer.Write(2408);
                    for(int i = 0; i < QuestEdit.Length; i++)
                    {
                        STR.Write_Quest_Fld(writer, QuestEdit[i]);
                    }
               
                }
            }

            
        }
    }
}
