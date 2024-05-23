using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuestEditor_V2.Structure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuestEditor_V2
{
    public class Structure
    {
        public struct _action_node
        {
            public int m_nActType;
            public byte[] m_strActSub;//64
            public byte[] m_strActSub2;//64
            public byte[] m_strActArea;//64
            public int m_nReqAct;
            public int m_nSetCntPro_100;
            public byte[] m_strLinkQuestItem;//64
            public int m_nOrder;
        };

        public struct _quest_reward_item
        {
            public byte[] m_strConsITCode;//64
            public int m_nConsITCnt;
            public int m_nLinkQuestIdx;
        };
        public struct _quest_reward_mastery
        {
            public int m_nConsMasteryID;
            public int m_nConsMasterySubID;
            public int m_nConsMasteryCnt;
        };
        public struct _quest_fail_condition
        {
            public int m_nFailCondition;
            public byte[] m_strFailCode;//64
        };
        public struct _Quest_fld
        {
            public uint m_dwIndex;
            public byte[] m_strCode;//64
            public int m_nLimLv;
            public int m_nQuestType;
            public int m_bQuestRepeat;
            public double m_dRepeatTime; //8 bits
            public int m_nDifficultyLevel;
            public int m_n2;
            public int m_bSelectQuestMenual;
            public int m_bCompQuestType;
            public _action_node[] m_ActionNode { get; set; }//3
            public int m_nMaxLevel;
            public double m_dConsExp; //8 bits
            public int m_nConsContribution;
            public int m_nConsDalant;
            public int m_nConspvppoint;
            public int m_nConsGold;
            public int m_bSelectConsITMenual;
            public _quest_reward_item[] m_RewardItem { get; set; }//6
            public _quest_reward_mastery[] m_RewardMastery { get; set; }//2          
            public byte[] m_strConsSkillCode;//64
            public int m_nConsSkillCnt;
            public byte[] m_strConsForceCode;//64
            public int m_nConsForceCnt;
            public byte[] m_strLinkQuest_0;//64
            public byte[] m_strLinkQuest_1;//64
            public byte[] m_strLinkQuest_2;//64
            public byte[] m_strLinkQuest_3;//64
            public byte[] m_strLinkQuest_4;//64
            public int m_nLinkQuestGroupID;
            public int m_bFailCheck;
            public _quest_fail_condition[] m_QuestFailCond { get; set; }//3
            public byte[] m_strFailBriefCode;//64
            public int m_nLinkDummyCond;
            public byte[] m_strLinkDummyCode;//64
            public byte[] m_strFailLinkQuest;//64
            public int m_nViewportType;
            public byte[] m_strViewportCode;//64
            public int m_nStore_trade;
            public byte[] m_txtQTExp;//64
        };
        public _action_node Read_Action_Node(BinaryReader Bin)
        {
            _action_node header = new _action_node();
            header.m_nActType = Bin.ReadInt32();
            header.m_strActSub = Bin.ReadBytes(64);
            header.m_strActSub2 = Bin.ReadBytes(64);
            header.m_strActArea = Bin.ReadBytes(64);
            header.m_nReqAct = Bin.ReadInt32();
            header.m_nSetCntPro_100 = Bin.ReadInt32();
            header.m_strLinkQuestItem = Bin.ReadBytes(64);
            header.m_nOrder = Bin.ReadInt32();
            return header;
        }

        public void Write_Action_Node(BinaryWriter Bin, _action_node node)
        {
            Helpers helper = new Helpers();
            Bin.Write(node.m_nActType);
            Bin.Write(helper.ByteExpand64(node.m_strActSub));
            Bin.Write(helper.ByteExpand64(node.m_strActSub2));
            Bin.Write(helper.ByteExpand64(node.m_strActArea));
            Bin.Write(node.m_nReqAct);
            Bin.Write(node.m_nSetCntPro_100);
            Bin.Write(helper.ByteExpand64(node.m_strLinkQuestItem));
            Bin.Write(node.m_nOrder);
        }

        public _quest_reward_item Read_Quest_Reward_Item(BinaryReader Bin)
        {
            _quest_reward_item header = new _quest_reward_item();
            header.m_strConsITCode = Bin.ReadBytes(64);
            header.m_nConsITCnt = Bin.ReadInt32();
            header.m_nLinkQuestIdx = Bin.ReadInt32();
            return header;
        }

        public void Write_Quest_Reward_Item(BinaryWriter Bin, _quest_reward_item item)
        {
            Helpers helper = new Helpers();
            Bin.Write(helper.ByteExpand64(item.m_strConsITCode));
            Bin.Write(item.m_nConsITCnt);
            Bin.Write(item.m_nLinkQuestIdx);
        }

        public _quest_reward_mastery Read_Quest_Reward_Mastery(BinaryReader Bin)
        {
            _quest_reward_mastery header = new _quest_reward_mastery();
            header.m_nConsMasteryID = Bin.ReadInt32();
            header.m_nConsMasterySubID = Bin.ReadInt32();
            header.m_nConsMasteryCnt = Bin.ReadInt32();
            return header;
        }

        public void Write_Quest_Reward_Mastery(BinaryWriter Bin, _quest_reward_mastery mastery)
        {
            Bin.Write(mastery.m_nConsMasteryID);
            Bin.Write(mastery.m_nConsMasterySubID);
            Bin.Write(mastery.m_nConsMasteryCnt);
        }

        public _quest_fail_condition Read_Quest_Fail_Condition(BinaryReader Bin)
        {
            _quest_fail_condition header = new _quest_fail_condition();
            header.m_nFailCondition = Bin.ReadInt32();
            header.m_strFailCode = Bin.ReadBytes(64);

            return header;
        }

        public void Write_Quest_Fail_Condition(BinaryWriter Bin, _quest_fail_condition condition)
        {
            Helpers helper = new Helpers();
            Bin.Write(condition.m_nFailCondition);
            Bin.Write(helper.ByteExpand64(condition.m_strFailCode));
        }
        public _Quest_fld Read_Quest_Fld(BinaryReader Bin)
        {
            _Quest_fld header = new _Quest_fld();
            header.m_dwIndex = Bin.ReadUInt32();
            header.m_strCode = Bin.ReadBytes(64);
            header.m_nLimLv = Bin.ReadInt32();
            header.m_nQuestType = Bin.ReadInt32();
            header.m_bQuestRepeat = Bin.ReadInt32();
            header.m_dRepeatTime = Bin.ReadDouble(); //8 bits
            header.m_nDifficultyLevel = Bin.ReadInt32();
            header.m_n2 = Bin.ReadInt32();
            header.m_bSelectQuestMenual = Bin.ReadInt32();
            header.m_bCompQuestType = Bin.ReadInt32();
            //setup list
            header.m_ActionNode = new _action_node[3];
            header.m_ActionNode[0] = Read_Action_Node(Bin);
            header.m_ActionNode[1] = Read_Action_Node(Bin);
            header.m_ActionNode[2] = Read_Action_Node(Bin);

            header.m_nMaxLevel = Bin.ReadInt32();
            header.m_dConsExp = Bin.ReadDouble(); //8 bits
            header.m_nConsContribution = Bin.ReadInt32();
            header.m_nConsDalant = Bin.ReadInt32();
            header.m_nConspvppoint = Bin.ReadInt32();
            header.m_nConsGold = Bin.ReadInt32();
            header.m_bSelectConsITMenual = Bin.ReadInt32();
            header.m_RewardItem = new _quest_reward_item[6];
            header.m_RewardItem[0] = Read_Quest_Reward_Item(Bin);
            header.m_RewardItem[1] = Read_Quest_Reward_Item(Bin);
            header.m_RewardItem[2] = Read_Quest_Reward_Item(Bin);
            header.m_RewardItem[3] = Read_Quest_Reward_Item(Bin);
            header.m_RewardItem[4] = Read_Quest_Reward_Item(Bin);
            header.m_RewardItem[5] = Read_Quest_Reward_Item(Bin);
            header.m_RewardMastery = new _quest_reward_mastery[2];
            header.m_RewardMastery[0] = Read_Quest_Reward_Mastery(Bin);
            header.m_RewardMastery[1] = Read_Quest_Reward_Mastery(Bin);
            header.m_strConsSkillCode = Bin.ReadBytes(64);//64
            header.m_nConsSkillCnt = Bin.ReadInt32();
            header.m_strConsForceCode = Bin.ReadBytes(64);//64
            header.m_nConsForceCnt = Bin.ReadInt32();
            header.m_strLinkQuest_0 = Bin.ReadBytes(64);//64
            header.m_strLinkQuest_1 = Bin.ReadBytes(64);//64
            header.m_strLinkQuest_2 = Bin.ReadBytes(64);//64
            header.m_strLinkQuest_3 = Bin.ReadBytes(64);//64
            header.m_strLinkQuest_4 = Bin.ReadBytes(64);//64
            header.m_nLinkQuestGroupID = Bin.ReadInt32();
            header.m_bFailCheck = Bin.ReadInt32();
            header.m_QuestFailCond = new _quest_fail_condition[3];
            header.m_QuestFailCond[0] = Read_Quest_Fail_Condition(Bin);
            header.m_QuestFailCond[1] = Read_Quest_Fail_Condition(Bin);
            header.m_QuestFailCond[2] = Read_Quest_Fail_Condition(Bin);

            header.m_strFailBriefCode = Bin.ReadBytes(64);//64
            header.m_nLinkDummyCond = Bin.ReadInt32();
            header.m_strLinkDummyCode = Bin.ReadBytes(64);//64
            header.m_strFailLinkQuest = Bin.ReadBytes(64);//64
            header.m_nViewportType = Bin.ReadInt32();
            header.m_strViewportCode = Bin.ReadBytes(64);//64
            header.m_nStore_trade = Bin.ReadInt32();
            header.m_txtQTExp = Bin.ReadBytes(64);

            return header;
        }

        public void Write_Quest_Fld(BinaryWriter Bin, _Quest_fld Quest)
        {
            Helpers helper = new Helpers();
            Bin.Write(Quest.m_dwIndex);
            Bin.Write(helper.ByteExpand64(Quest.m_strCode));
            Bin.Write(Quest.m_nLimLv);
            Bin.Write(Quest.m_nQuestType);
            Bin.Write(Quest.m_bQuestRepeat);
            Bin.Write(Quest.m_dRepeatTime); //8 bits
            Bin.Write(Quest.m_nDifficultyLevel);
            Bin.Write(Quest.m_n2);
            Bin.Write(Quest.m_bSelectQuestMenual);
            Bin.Write(Quest.m_bCompQuestType);

            Write_Action_Node(Bin, Quest.m_ActionNode[0]);
            Write_Action_Node(Bin, Quest.m_ActionNode[1]);
            Write_Action_Node(Bin, Quest.m_ActionNode[2]);

            Bin.Write(Quest.m_nMaxLevel);
            Bin.Write(Quest.m_dConsExp); //8 bits
            Bin.Write(Quest.m_nConsContribution);
            Bin.Write(Quest.m_nConsDalant);
            Bin.Write(Quest.m_nConspvppoint);
            Bin.Write(Quest.m_nConsGold);
            Bin.Write(Quest.m_bSelectConsITMenual);

            Write_Quest_Reward_Item(Bin, Quest.m_RewardItem[0]);
            Write_Quest_Reward_Item(Bin, Quest.m_RewardItem[1]);
            Write_Quest_Reward_Item(Bin, Quest.m_RewardItem[2]);
            Write_Quest_Reward_Item(Bin, Quest.m_RewardItem[3]);
            Write_Quest_Reward_Item(Bin, Quest.m_RewardItem[4]);
            Write_Quest_Reward_Item(Bin, Quest.m_RewardItem[5]);

            Write_Quest_Reward_Mastery(Bin, Quest.m_RewardMastery[0]);
            Write_Quest_Reward_Mastery(Bin, Quest.m_RewardMastery[1]);

            Bin.Write(helper.ByteExpand64(Quest.m_strConsSkillCode));//64
            Bin.Write(Quest.m_nConsSkillCnt);
            Bin.Write(helper.ByteExpand64(Quest.m_strConsForceCode));//64
            Bin.Write(Quest.m_nConsForceCnt);
            Bin.Write(helper.ByteExpand64(Quest.m_strLinkQuest_0));//64
            Bin.Write(helper.ByteExpand64(Quest.m_strLinkQuest_1));//64
            Bin.Write(helper.ByteExpand64(Quest.m_strLinkQuest_2));//64
            Bin.Write(helper.ByteExpand64(Quest.m_strLinkQuest_3));//64
            Bin.Write(helper.ByteExpand64(Quest.m_strLinkQuest_4));//64
            Bin.Write(Quest.m_nLinkQuestGroupID);
            Bin.Write(Quest.m_bFailCheck);

            Write_Quest_Fail_Condition(Bin, Quest.m_QuestFailCond[0]);
            Write_Quest_Fail_Condition(Bin, Quest.m_QuestFailCond[1]);
            Write_Quest_Fail_Condition(Bin, Quest.m_QuestFailCond[2]);

            Bin.Write(helper.ByteExpand64(Quest.m_strFailBriefCode));//64
            Bin.Write(Quest.m_nLinkDummyCond);
            Bin.Write(helper.ByteExpand64(Quest.m_strLinkDummyCode));//64
            Bin.Write(helper.ByteExpand64(Quest.m_strFailLinkQuest));//64
            Bin.Write(Quest.m_nViewportType);
            Bin.Write(helper.ByteExpand64(Quest.m_strViewportCode));//64
            Bin.Write(Quest.m_nStore_trade);
            Bin.Write(helper.ByteExpand64(Quest.m_txtQTExp));
        }
        public string _Action_Node_m_nActTypes(int mActType)
        {
            string value = "Null";
            switch (mActType)
            {
                case 1: value = "Talk To"; break;
                case 2: value = "Talk To"; break;
                case 3: value = "Hunt"; break;
                case 4: value = "Collect Item"; break;
                case 6: value = "Reach Level"; break;
                case 14: value = "Talk to with item"; break;
                case 15: value = "Complete Quest"; break;
                case 17: value = "Look At"; break;
            }

            return value;

        }

        public struct STR_File
        {
            public int m_dwIndex;
            public byte[] m_strCode;//64
            public byte[] m_strName_0;//64
            public byte[] m_strName_1;
            public byte[] m_strName_2;
            public byte[] m_strName_3;
            public byte[] m_strName_4;
            public byte[] m_strName_5;
            public byte[] m_strName_6;
            public byte[] m_strName_7;
            public byte[] m_strName_8;
            public byte[] m_strName_9;
            public byte[] m_strName_10;

        }

        public STR_File Read_STR_Monster(BinaryReader Bin)
        {
            STR_File header = new STR_File();
            header.m_dwIndex = Bin.ReadInt32();
            header.m_strCode = Bin.ReadBytes(64);
            header.m_strName_0 = Bin.ReadBytes(64);
            header.m_strName_1 = Bin.ReadBytes(64);
            header.m_strName_2 = Bin.ReadBytes(64);
            header.m_strName_3 = Bin.ReadBytes(64);
            header.m_strName_4 = Bin.ReadBytes(64);
            header.m_strName_5 = Bin.ReadBytes(64);
            header.m_strName_6 = Bin.ReadBytes(64);
            header.m_strName_7 = Bin.ReadBytes(64);
            header.m_strName_8 = Bin.ReadBytes(64);
            header.m_strName_9 = Bin.ReadBytes(64);
            header.m_strName_10 = Bin.ReadBytes(64);

            return header;
        }


        public STR_File Read_Quest_STR(BinaryReader Bin)
        {
            STR_File header = new STR_File();
            header.m_dwIndex = Bin.ReadInt32();
            header.m_strCode = Bin.ReadBytes(64);
            header.m_strName_0 = Bin.ReadBytes(2560);
            header.m_strName_1 = Bin.ReadBytes(2560);
            header.m_strName_2 = Bin.ReadBytes(2560);
            header.m_strName_3 = Bin.ReadBytes(2560);
            header.m_strName_4 = Bin.ReadBytes(2560);
            header.m_strName_5 = Bin.ReadBytes(2560);
            header.m_strName_6 = Bin.ReadBytes(2560);
            header.m_strName_7 = Bin.ReadBytes(2560);
            header.m_strName_8 = Bin.ReadBytes(2560);
            header.m_strName_9 = Bin.ReadBytes(2560);
            header.m_strName_10 = Bin.ReadBytes(2560);

            return header;
        }
        public STR_File Fake_Read_Quest_STR(int Index, byte[] strCode, string strName3)
        {
            STR_File header = new STR_File();
            header.m_dwIndex = Index;
            byte[] bytes = Encoding.UTF8.GetBytes(strName3);
            header.m_strCode = strCode;
            header.m_strName_0 = new byte[0];
            header.m_strName_1 = new byte[0]; ;
            header.m_strName_2 = bytes;
            header.m_strName_3 = new byte[0];
            header.m_strName_4 = new byte[0];
            header.m_strName_5 = new byte[0];
            header.m_strName_6 = new byte[0];
            header.m_strName_7 = new byte[0];
            header.m_strName_8 = new byte[0];
            header.m_strName_9 = new byte[0];
            header.m_strName_10 = new byte[0];

            return header;
        }


        // Other quest files::

        public struct _happen_event_condition_node
        {
            public int m_nCondType;
            public int m_nCondSubType;
            public byte[] m_sCondVal;//64
        };

        public _happen_event_condition_node Read_happen_event_condition_node(BinaryReader Bin)
        {
            _happen_event_condition_node item = new _happen_event_condition_node();
            item.m_nCondType = Bin.ReadInt32();
            item.m_nCondSubType = Bin.ReadInt32();
            item.m_sCondVal = Bin.ReadBytes(64);
            return item;
        }

        public void Write__happen_event_condition_node(BinaryWriter Bin, _happen_event_condition_node node)
        {
            Helpers helper = new Helpers();
            Bin.Write(node.m_nCondType);
            Bin.Write(node.m_nCondSubType);
            Bin.Write(helper.ByteExpand64(node.m_sCondVal));
        }


        public struct _happen_event_node
        {
            public int m_bUse;
            public int m_bQuestRepeat;
            public int m_nQuestType;
            public int m_bSelectQuestManual;
            public int m_nAcepProNum;
            public int m_nAcepProDen;
            public _happen_event_condition_node[] m_CondNode;//5
            public byte[] m_strLinkQuest_0;//64
            public byte[] m_strLinkQuest_1;//64
            public byte[] m_strLinkQuest_2;//64
            public byte[] m_strLinkQuest_3;//64
            public byte[] m_strLinkQuest_4;//64
        };

        public void Write_happen_event_node(BinaryWriter Bin, _happen_event_node node)
        {
            Helpers helper = new Helpers();
            Bin.Write(node.m_bUse);
            Bin.Write(node.m_bQuestRepeat);
            Bin.Write(node.m_nQuestType);
            Bin.Write(node.m_bSelectQuestManual);
            Bin.Write(node.m_nAcepProNum);
            Bin.Write(node.m_nAcepProDen);
            Write__happen_event_condition_node(Bin, node.m_CondNode[0]);
            Write__happen_event_condition_node(Bin, node.m_CondNode[1]);
            Write__happen_event_condition_node(Bin, node.m_CondNode[2]);
            Write__happen_event_condition_node(Bin, node.m_CondNode[3]);
            Write__happen_event_condition_node(Bin, node.m_CondNode[4]);
            Bin.Write(helper.ByteExpand64(node.m_strLinkQuest_0));
            Bin.Write(helper.ByteExpand64(node.m_strLinkQuest_1));
            Bin.Write(helper.ByteExpand64(node.m_strLinkQuest_2));
            Bin.Write(helper.ByteExpand64(node.m_strLinkQuest_3));
            Bin.Write(helper.ByteExpand64(node.m_strLinkQuest_4));

        }

        public _happen_event_node Read_happen_event_node(BinaryReader Bin)
        {
            _happen_event_node item = new _happen_event_node();
            item.m_bUse = Bin.ReadInt32();
            item.m_bQuestRepeat = Bin.ReadInt32();
            item.m_nQuestType = Bin.ReadInt32();
            item.m_bSelectQuestManual = Bin.ReadInt32();
            item.m_nAcepProNum = Bin.ReadInt32();
            item.m_nAcepProDen = Bin.ReadInt32();
            item.m_CondNode = new _happen_event_condition_node[5];

            item.m_CondNode[0] = Read_happen_event_condition_node(Bin);
            item.m_CondNode[1] = Read_happen_event_condition_node(Bin);
            item.m_CondNode[2] = Read_happen_event_condition_node(Bin);
            item.m_CondNode[3] = Read_happen_event_condition_node(Bin);
            item.m_CondNode[4] = Read_happen_event_condition_node(Bin);

            item.m_strLinkQuest_0 = Bin.ReadBytes(64);
            item.m_strLinkQuest_1 = Bin.ReadBytes(64);
            item.m_strLinkQuest_2 = Bin.ReadBytes(64);
            item.m_strLinkQuest_3 = Bin.ReadBytes(64);
            item.m_strLinkQuest_4 = Bin.ReadBytes(64);
            return item;
        }

        public void Write__QuestHappenEvent_fld(BinaryWriter Bin, _QuestHappenEvent_fld Quest)
        {
            Helpers helper = new Helpers();
            Bin.Write(Quest.m_dwIndex);
            Bin.Write(helper.ByteExpand64(Quest.m_strCode));
            Bin.Write(Quest.m_nEevntNo);
            Write_happen_event_node(Bin, Quest.m_Node[0]);
            Write_happen_event_node(Bin, Quest.m_Node[1]);
            Write_happen_event_node(Bin, Quest.m_Node[2]);

        }

        public struct _QuestHappenEvent_fld
        {
            public uint m_dwIndex;
            public byte[] m_strCode;//64
            public int m_nEevntNo;
            public _happen_event_node[] m_Node;//3
        };

        public _QuestHappenEvent_fld Read_QuestHappenEvent_fld(BinaryReader Bin)
        {
            _QuestHappenEvent_fld item = new _QuestHappenEvent_fld();
            item.m_dwIndex = Bin.ReadUInt32();
            item.m_strCode = Bin.ReadBytes(64);
            item.m_nEevntNo = Bin.ReadInt32();
            item.m_Node = new _happen_event_node[3];

            item.m_Node[0] = Read_happen_event_node(Bin);
            item.m_Node[1] = Read_happen_event_node(Bin);
            item.m_Node[2] = Read_happen_event_node(Bin);
            return item;
        }

        //not from zoneheader reading
        public struct QuestTextCode
        {
            public int m_dwIndex;
            public byte[] m_strCode_0;
            public byte[] m_strQuestBriefContents_0;//
            public byte[] m_strQuestBriefContents_1;//
            public byte[] m_strQuestBriefContents_2;//
            public byte[] m_strQuestBriefContents_3;//
            public byte[] m_strQuestBriefContents_4;//
            public byte[] m_strQuestSummaryContents_0;
            public byte[] m_strQuestSummaryContents_1;
            public byte[] m_strQuestSummaryContents_2;
            public byte[] m_strQuestSummaryContents_3;
            public byte[] m_strQuestSummaryContents_4;
            public byte[] m_strQuestConditionResult_0;//
            public byte[] m_strQuestConditionResult_1;//
            public byte[] m_strQuestConditionResult_2;//
            public byte[] m_strQuestConditionResult_3;//
            public byte[] m_strQuestConditionResult_4;//
            public byte[] m_strQuestFinishContents_U0;
            public byte[] m_strQuestFinishContents_U1;
            public byte[] m_strQuestFinishContents_U2;
            public byte[] m_strQuestFinishContents_U3;
            public byte[] m_strQuestFinishContents_U4;
            public byte[] m_strQuestFinishContents_F0;
            public byte[] m_strQuestFinishContents_F1;
            public byte[] m_strQuestFinishContents_F2;
            public byte[] m_strQuestFinishContents_F3;
            public byte[] m_strQuestFinishContents_F4;

        }


        public QuestTextCode Read_QuestTextCode(BinaryReader Bin)
        {
            QuestTextCode header = new QuestTextCode();
            header.m_dwIndex = Bin.ReadInt32();
            header.m_strCode_0 = Bin.ReadBytes(64);
            header.m_strQuestBriefContents_0 = Bin.ReadBytes(64);
            header.m_strQuestBriefContents_1 = Bin.ReadBytes(64);
            header.m_strQuestBriefContents_2 = Bin.ReadBytes(64);
            header.m_strQuestBriefContents_3 = Bin.ReadBytes(64);
            header.m_strQuestBriefContents_4 = Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_0 = Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_1 = Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_2 = Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_3 = Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_4 = Bin.ReadBytes(64);
            header.m_strQuestConditionResult_0 = Bin.ReadBytes(64);
            header.m_strQuestConditionResult_1 = Bin.ReadBytes(64);
            header.m_strQuestConditionResult_2 = Bin.ReadBytes(64);
            header.m_strQuestConditionResult_3 = Bin.ReadBytes(64);
            header.m_strQuestConditionResult_4 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U0 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U1 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U2 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U3 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U4 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F0 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F1 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F2 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F3 = Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F4 = Bin.ReadBytes(64);

            return header;
        }


        public struct QuestTextNumbers
        {
            public string QuestNameIndex;
            public int QuestNameNumber;

            public int m_strQuestBriefContents_0;//
            public int m_strQuestBriefContents_1;//
            public int m_strQuestBriefContents_2;//
            public int m_strQuestBriefContents_3;//
            public int m_strQuestBriefContents_4;//
            public int m_strQuestSummaryContents_0;
            public int m_strQuestSummaryContents_1;
            public int m_strQuestSummaryContents_2;
            public int m_strQuestSummaryContents_3;
            public int m_strQuestSummaryContents_4;
            public int m_strQuestConditionResult_0;//
            public int m_strQuestConditionResult_1;//
            public int m_strQuestConditionResult_2;//
            public int m_strQuestConditionResult_3;//
            public int m_strQuestConditionResult_4;//
            public int m_strQuestFinishContents_U0;
            public int m_strQuestFinishContents_U1;
            public int m_strQuestFinishContents_U2;
            public int m_strQuestFinishContents_U3;
            public int m_strQuestFinishContents_U4;
            public int m_strQuestFinishContents_F0;
            public int m_strQuestFinishContents_F1;
            public int m_strQuestFinishContents_F2;
            public int m_strQuestFinishContents_F3;
            public int m_strQuestFinishContents_F4;

            public int[] Client_IsFailCheck;
        }

        public struct QuestItems
        {
            public int m_dwIndex;
            public byte[] m_strID;
            public int Unknown;
            public byte[] m_strName;
        }

        public QuestItems Read_QuestItems(BinaryReader Bin)
        {
            QuestItems header = new QuestItems();
            header.m_dwIndex = Bin.ReadInt32();
            header.m_strID = Bin.ReadBytes(64);
            header.Unknown = Bin.ReadInt32();
            header.m_strName = Bin.ReadBytes(64);

            return header;

        }

        public void Write_QuestItems(BinaryWriter Bin, QuestItems item)
        {
            Helpers helper = new Helpers();
            Bin.Write(item.m_dwIndex);
            string test =System.Text.Encoding.UTF8.GetString(item.m_strID);
            Bin.Write(helper.QuestItem_Hex(test));
            Bin.Write(item.m_dwIndex+1);
            Bin.Write(helper.ByteExpand32(item.m_strName));

        }

    }
}
