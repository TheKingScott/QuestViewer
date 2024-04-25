using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestEditor_V2.Structure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuestEditor_V2
{
    internal class Structure
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
            public List<_action_node> m_ActionNode;//3
            public int m_nMaxLevel;
            public double m_dConsExp; //8 bits
            public int m_nConsContribution;
            public int m_nConsDalant;
            public int m_nConspvppoint;
            public int m_nConsGold;
            public int m_bSelectConsITMenual;
            public List<_quest_reward_item> m_RewardItem;//6
            public List<_quest_reward_mastery> m_RewardMastery;//2          
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
            public List<_quest_fail_condition> m_QuestFailCond;//3
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

        public _quest_reward_item Read_Quest_Reward_Item(BinaryReader Bin)
        {
            _quest_reward_item header = new _quest_reward_item();
            header.m_strConsITCode = Bin.ReadBytes(64);
            header.m_nConsITCnt = Bin.ReadInt32();
            header.m_nLinkQuestIdx = Bin.ReadInt32();
            return header;
        }

        public _quest_reward_mastery Read_Quest_Reward_Mastery(BinaryReader Bin)
        {
            _quest_reward_mastery header = new _quest_reward_mastery();
            header.m_nConsMasteryID = Bin.ReadInt32();
            header.m_nConsMasterySubID = Bin.ReadInt32();
            header.m_nConsMasteryCnt = Bin.ReadInt32();
            return header;
        }

        public _quest_fail_condition Read_Quest_Fail_Condition(BinaryReader Bin)
        {
            _quest_fail_condition header = new _quest_fail_condition();
            header.m_nFailCondition = Bin.ReadInt32();
            header.m_strFailCode = Bin.ReadBytes(64);

            return header;
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
            header.m_ActionNode = new List<_action_node> { Read_Action_Node(Bin), Read_Action_Node(Bin), Read_Action_Node(Bin) };


            header.m_nMaxLevel = Bin.ReadInt32();
            header.m_dConsExp = Bin.ReadDouble(); //8 bits
            header.m_nConsContribution = Bin.ReadInt32();
            header.m_nConsDalant = Bin.ReadInt32();
            header.m_nConspvppoint = Bin.ReadInt32();
            header.m_nConsGold = Bin.ReadInt32();
            header.m_bSelectConsITMenual = Bin.ReadInt32();
            header.m_RewardItem = new List<_quest_reward_item> { Read_Quest_Reward_Item(Bin), Read_Quest_Reward_Item(Bin), Read_Quest_Reward_Item(Bin), Read_Quest_Reward_Item(Bin), Read_Quest_Reward_Item(Bin), Read_Quest_Reward_Item(Bin) };//6         
            header.m_RewardMastery = new List<_quest_reward_mastery> { Read_Quest_Reward_Mastery(Bin), Read_Quest_Reward_Mastery(Bin) };//2        
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
            header.m_QuestFailCond = new List<_quest_fail_condition> { Read_Quest_Fail_Condition(Bin), Read_Quest_Fail_Condition(Bin), Read_Quest_Fail_Condition(Bin) };//3        
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

        public struct _ND_Header
        {
            public int m_dwCount;
            public int m_dwSize;
        };

        public _ND_Header Read_ND_Header(BinaryReader Bin)
        {
            _ND_Header header = new _ND_Header();
            header.m_dwCount = Bin.ReadInt32();
            header.m_dwSize = Bin.ReadInt32();
            return header;
        }
        public struct Value_32
        {
            public byte[] m_str32;
        }
        public Value_32 Read_Value_32(BinaryReader Bin)
        {
            Value_32 item = new Value_32();
            item.m_str32 = Bin.ReadBytes(32);
            return item;
        }

        public struct Value_16
        {
            public int m_dwIndex;
            public short unk_0;
            public short unk_1;
            public short SplitNameLength;
            public short unk_2;
            public short unk_3;
            public short unk_4;

        }
        public Value_16 Read_Value_16(BinaryReader Bin)
        {
            Value_16 item = new Value_16();
            item.m_dwIndex = Bin.ReadInt32();
            item.unk_0 = Bin.ReadInt16();
            item.unk_1 = Bin.ReadInt16();
            item.SplitNameLength = Bin.ReadInt16();
            item.unk_2 = Bin.ReadInt16();
            item.unk_3 = Bin.ReadInt16();
            item.unk_4 = Bin.ReadInt16();
            return item;
        }

        public struct Dynamic_String
        {
            public byte[] desc;
        }
        public Dynamic_String Read_Dynamic_String(BinaryReader Bin, short length)
        {
            Dynamic_String item = new Dynamic_String();
            item.desc = Bin.ReadBytes(length);
            return item;
        }

        public struct ND_Quest
        {
            public _ND_Header section_0;
            public List<Value_32> data_0;
            public _ND_Header section_1;
            public List<Value_16> data_1;
            public List<Dynamic_String> data_2;

        }

        public ND_Quest Read_ND_Quest(BinaryReader Bin)
        {
            ND_Quest item = new ND_Quest();
            item.section_0 = Read_ND_Header(Bin);
            item.data_0 = new List<Value_32>();
            for (int i = 0; i < item.section_0.m_dwCount; i++)
            {
                item.data_0.Add(Read_Value_32(Bin));
            }
            item.section_1 = Read_ND_Header(Bin);
            item.data_1 = new List<Value_16>();
            for (int i = 0; i < item.section_1.m_dwCount; i++)
            {
                item.data_1.Add(Read_Value_16(Bin));
            }
            item.data_2 = new List<Dynamic_String>();
            for (int i = 0; i < item.section_1.m_dwCount; i++)
            {
                short index = item.data_1.ElementAt(i).SplitNameLength;
                item.data_2.Add(Read_Dynamic_String(Bin, index));
            }
            return item;
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

        public struct _happen_event_node
        {
            public int m_bUse;
            public int m_bQuestRepeat;
            public int m_nQuestType;
            public int m_bSelectQuestManual;
            public int m_nAcepProNum;
            public int m_nAcepProDen;
            public List<_happen_event_condition_node> m_CondNode;//5
            public byte[] m_strLinkQuest_0;//64
            public byte[] m_strLinkQuest_1;//64
            public byte[] m_strLinkQuest_2;//64
            public byte[] m_strLinkQuest_3;//64
            public byte[] m_strLinkQuest_4;//64
        };

        public _happen_event_node Read_happen_event_node(BinaryReader Bin)
        {
            _happen_event_node item = new _happen_event_node();
            item.m_bUse = Bin.ReadInt32();
            item.m_bQuestRepeat = Bin.ReadInt32();
            item.m_nQuestType = Bin.ReadInt32();
            item.m_bSelectQuestManual = Bin.ReadInt32();
            item.m_nAcepProNum = Bin.ReadInt32();
            item.m_nAcepProDen = Bin.ReadInt32();
            item.m_CondNode = new List<_happen_event_condition_node> { Read_happen_event_condition_node(Bin), Read_happen_event_condition_node(Bin), Read_happen_event_condition_node(Bin), Read_happen_event_condition_node(Bin), Read_happen_event_condition_node(Bin) };
            item.m_strLinkQuest_0 = Bin.ReadBytes(64);
            item.m_strLinkQuest_1 = Bin.ReadBytes(64);
            item.m_strLinkQuest_2 = Bin.ReadBytes(64);
            item.m_strLinkQuest_3 = Bin.ReadBytes(64);
            item.m_strLinkQuest_4 = Bin.ReadBytes(64);
            return item;
        }


        public struct _QuestHappenEvent_fld
        {
            public uint m_dwIndex;
            public byte[] m_strCode;//64
            public int m_nEevntNo;
            public List<_happen_event_node> m_Node;//3
        };

        public _QuestHappenEvent_fld Read_QuestHappenEvent_fld(BinaryReader Bin)
        {
            _QuestHappenEvent_fld item = new _QuestHappenEvent_fld();
            item.m_dwIndex = Bin.ReadUInt32();
            item.m_strCode = Bin.ReadBytes(64);
            item.m_nEevntNo = Bin.ReadInt32();
            item.m_Node = new List<_happen_event_node> { Read_happen_event_node(Bin), Read_happen_event_node(Bin), Read_happen_event_node(Bin) };
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
            header.m_strQuestBriefContents_0= Bin.ReadBytes(64);
            header.m_strQuestBriefContents_1= Bin.ReadBytes(64);
            header.m_strQuestBriefContents_2= Bin.ReadBytes(64);
            header.m_strQuestBriefContents_3= Bin.ReadBytes(64);
            header.m_strQuestBriefContents_4 = Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_0= Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_1= Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_2= Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_3= Bin.ReadBytes(64);
            header.m_strQuestSummaryContents_4 = Bin.ReadBytes(64);
            header.m_strQuestConditionResult_0= Bin.ReadBytes(64);
            header.m_strQuestConditionResult_1= Bin.ReadBytes(64);
            header.m_strQuestConditionResult_2= Bin.ReadBytes(64);
            header.m_strQuestConditionResult_3= Bin.ReadBytes(64);
            header.m_strQuestConditionResult_4= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U0= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U1= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U2= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U3= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_U4= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F0= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F1= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F2= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F3= Bin.ReadBytes(64);
            header.m_strQuestFinishContents_F4 = Bin.ReadBytes(64);

            return header;
        }
    }
}
