using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuestEditor_V2.Structure;

namespace QuestEditor_V2
{
    public partial class HolyStone : Form
    {
        Structure STR = new Structure();
        int QuestIndex = 0;
        ND_Quest ND_Quests = new ND_Quest();
        List<_Quest_fld> Quests;
        List<STR_Monster> STR_Monsters;
        List<STR_Monster> STR_NPCs;
        List<STR_Monster> STR_ITEMS;
        NameValueCollection ITEM_KV_List = new NameValueCollection();
        NameValueCollection NPC_KV_List = new NameValueCollection();
        NameValueCollection Monster_KV_List = new NameValueCollection();
        NameValueCollection Quest_KV_List = new NameValueCollection();

        public HolyStone()
        {
            InitializeComponent();
            string path = "HolyStoneKeepperQuest.dat";
            if (File.Exists(path))
            {

                using (var stream = System.IO.File.OpenRead("HolyStoneKeepperQuest.dat"))
                using (var reader = new BinaryReader(stream))
                {
                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();

                    Quests = new List<_Quest_fld>();
                    for (int i = 0; i < _Header; i++)
                    {
                        Quests.Add(STR.Read_Quest_Fld(reader));

                    }

                    GC.KeepAlive(Quests);
                    reader.Dispose();
                    reader.Close();

                    TreeNode root0 = new TreeNode() { Name = "Bellato", Text = "Bellato" };
                    TreeNode root1 = new TreeNode() { Name = "Cora", Text = "Cora" };
                    TreeNode root2 = new TreeNode() { Name = "Acc", Text = "Acc" };
                    treeView1.Nodes.Add(root0);
                    treeView1.Nodes.Add(root1);
                    treeView1.Nodes.Add(root2);
                    for (int i = 0; i < Quests.Count; i++)
                    {
                        string ID = Encoding.UTF8.GetString(Quests[i].m_strCode, 0, Quests[i].m_strCode.Length);
                        //add index value to compare here
                        Quest_KV_List.Add(ID, i.ToString());

                        if (Quests[i].m_n2 == 0)
                        {
                            root0.Nodes.Add(ID);

                        }
                        else if (Quests[i].m_n2 == 1)
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
            ItemSTR();
            NDQuest();
            MonsterCharacter_str();
            NPCCharacter();
            Fill_Quest_Data();
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
                    STR_NPCs = new List<STR_Monster>();
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

        private void MonsterCharacter_str()
        {

            //hardcode chips
            Monster_KV_List.Add("09B00", "09B00 AKA BCC");
            Monster_KV_List.Add("09B01", "09B01 AKA CCC");
            Monster_KV_List.Add("09B02", "09B02 AKA ACC");
            
        }

        private void ItemSTR()
        {
            string path = "bootYItem_str.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("bootYItem_str.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    int _Header = reader.ReadInt32();
                    int _columns = reader.ReadInt32();
                    int _size = reader.ReadInt32();
                    Structure STR = new Structure();
                    STR_ITEMS = new List<STR_Monster>();
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

        private void NDQuest()
        {
            string path = "NDQuest.dat";
            if (File.Exists(path))
            {
                using (var stream = System.IO.File.OpenRead("NDQuest.dat"))
                using (var reader = new BinaryReader(stream))
                {

                    Structure STR = new Structure();
                    ND_Quests = STR.Read_ND_Quest(reader);

                    reader.Dispose();
                    reader.Close();
                }
            }
        }

        private void Fill_Quest_Data()
        {
            Helpers helper = new Helpers();
            _Quest_fld Quest = Quests[QuestIndex];
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

            try
            {
                ND_Quest_Item.Text = helper.ByteString(ND_Quests.data_0.ElementAt((int)Quest.m_dwIndex).m_str32);
            }
            catch
            {
                ND_Quest_Item.Text = "None";
            }
            if (ND_Quests.data_1 != null)
            {
                ND_Quest_Index.Text = ND_Quests.data_1.ElementAt((int)Quest.m_dwIndex).m_dwIndex.ToString();
                Description_Box.Text = helper.ByteString(ND_Quests.data_2.ElementAt((int)Quest.m_dwIndex).desc);

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
                QuestIndex = (int)Quests[x].m_dwIndex;
                Fill_Quest_Data();
            }
        }
    }
}
