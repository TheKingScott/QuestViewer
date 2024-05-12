using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEditor_V2
{
    internal class Debug_Structure
    {
        public struct C_happen_event_condition_node
        {
                public byte m_nCondType;
                public byte m_nCondSubType;
                public short unknown;
                public int m_sCondVal;
                public int unknown1;
        };
        public C_happen_event_condition_node ReadC_happen_event_condition_node(BinaryReader Bin)
        {
            C_happen_event_condition_node node = new C_happen_event_condition_node();
            node.m_nCondType = Bin.ReadByte();
            node.m_nCondSubType = Bin.ReadByte();
            node.unknown = Bin.ReadInt16();
            node.m_sCondVal = Bin.ReadInt32();
            node.unknown1 = Bin.ReadInt32();
            return node;
        }
    /* 1144 */
        public struct C__happen_event_node
        {
            public int m_bUse;
            public int m_nQuestType;
            public C_happen_event_condition_node[] m_CondNode { get; set; }//5
            public byte[] m_strLinkQuest_0;//8
            public byte[] m_strLinkQuest_1;//8
            public byte[] m_strLinkQuest_2;//8
            public byte[] m_strLinkQuest_3;//8
            public byte[] m_strLinkQuest_4;//8
        };
        public C__happen_event_node Read_C__happen_event_node(BinaryReader Bin)
        {
            C__happen_event_node node = new C__happen_event_node();
            node.m_bUse = Bin.ReadInt32();
            node.m_nQuestType = Bin.ReadInt32();
            node.m_CondNode = new C_happen_event_condition_node[5];
            node.m_CondNode[0] = ReadC_happen_event_condition_node(Bin);
            node.m_CondNode[1] = ReadC_happen_event_condition_node(Bin);
            node.m_CondNode[2] = ReadC_happen_event_condition_node(Bin);
            node.m_CondNode[3] = ReadC_happen_event_condition_node(Bin);
            node.m_CondNode[4] = ReadC_happen_event_condition_node(Bin);
            node.m_strLinkQuest_0 = Bin.ReadBytes(8);
            node.m_strLinkQuest_1 = Bin.ReadBytes(8);
            node.m_strLinkQuest_2 = Bin.ReadBytes(8);
            node.m_strLinkQuest_3 = Bin.ReadBytes(8);
            node.m_strLinkQuest_4 = Bin.ReadBytes(8);
            
            return node;
        }

        public struct C_QuestHappenEvent_fld
        {
            public UInt32 m_dwIndex;
            public int m_strCode;
            public byte m_nEevntNo;
            public byte zero;
            public short zero1;
            public C__happen_event_node[] m_Node { get; set; }//3
        };

        public C_QuestHappenEvent_fld ReadC_QuestHappenEvent_fld(BinaryReader Bin)
        {
            C_QuestHappenEvent_fld node = new C_QuestHappenEvent_fld();
            node.m_dwIndex = Bin.ReadUInt32();
            node.m_strCode = Bin.ReadInt32();
            node.m_nEevntNo = Bin.ReadByte();
            node.zero = Bin.ReadByte();
            node.zero1 = Bin.ReadInt16();
            node.m_Node = new C__happen_event_node[3];
            node.m_Node[0] = Read_C__happen_event_node(Bin);
            node.m_Node[1] = Read_C__happen_event_node(Bin);
            node.m_Node[2] = Read_C__happen_event_node(Bin);

            return node;
        }

        /* 1146 */
        public struct C_action_node
        {
            public byte m_nActType;
            public byte zero;
            public short zer1;
            
            public int m_strActSub;
            public int m_strActSub2;
            public int m_strActArea;
            
            public int m_nReqAct;
            public int NDQuestQuestConditionContent;
            public int NDQuestQuestConditionResult;
            public int QuestItem;
        };
        public C_action_node ReadC_action_node(BinaryReader Bin)
        {
            C_action_node node = new C_action_node();
            node.m_nActType = Bin.ReadByte();
            node.zero = Bin.ReadByte();
            node.zer1 = Bin.ReadInt16();
      
            node.m_strActSub = Bin.ReadInt32();
            node.m_strActSub2 = Bin.ReadInt32();
            node.m_strActArea = Bin.ReadInt32();
      
            node.m_nReqAct = Bin.ReadInt32();
            node.NDQuestQuestConditionContent = Bin.ReadInt32();
            node.NDQuestQuestConditionResult = Bin.ReadInt32();
            node.QuestItem = Bin.ReadInt32();
            return node;
        }
        
        public struct C_quest_reward_item
        {
            public byte Item_Code;
            public byte zero;
            public short zero1;
            public int m_strConsITCode;
            public byte m_nConsITCnt;
            public byte zero2;
            public short zero3;
        };
        public C_quest_reward_item ReadC_quest_reward_item(BinaryReader Bin)
        {
            C_quest_reward_item node = new C_quest_reward_item();
             node.Item_Code = Bin.ReadByte();
             node.zero = Bin.ReadByte();
             node.zero1 = Bin.ReadInt16();
             node.m_strConsITCode = Bin.ReadInt32();
             node.m_nConsITCnt = Bin.ReadByte();
             node.zero2 = Bin.ReadByte();
             node.zero3 = Bin.ReadInt16();
            return node;
        }

        /* 1148 */
        public struct C_quest_reward_mastery
        {
            public short m_nConsMasteryID;
            public short zero;
            public int m_nConsMasteryCnt;
        };
        public C_quest_reward_mastery ReadC_quest_reward_mastery(BinaryReader Bin)
        {
            C_quest_reward_mastery node = new C_quest_reward_mastery();
            node.m_nConsMasteryID = Bin.ReadInt16();
            node.zero = Bin.ReadInt16();
            node.m_nConsMasteryCnt = Bin.ReadInt32();
            return node;
        }
        
        public struct C_FailQuestCheck
        {
            public int m_bFailCheck;
            public int m_nFailCondition;
            public int m_strFailCode;
        }
        public C_FailQuestCheck Read_C_FailQuestCheck(BinaryReader Bin)
        {
            C_FailQuestCheck node = new C_FailQuestCheck();
            node.m_bFailCheck = Bin.ReadInt32();
            node.m_nFailCondition = Bin.ReadInt32();
            node.m_strFailCode =  Bin.ReadInt32();
            return node;
        }

        
        public struct C_Quest_fld
        {
            public UInt16 nCount;
            public UInt16 unknown;
            public int m_strCode;
            public byte m_nQuestType;
            public byte m_nDifficultyLevel;
            public byte m_n2;
            public byte m_nLimLv;
            public byte zerrr;
            public byte AlwaysZero;
            public UInt16 AlwaysZero1;
            public C_action_node[] m_ActionNode { get; set; }//3
            public double m_dConsExp;
            public int m_nConsDalant;
            public int m_nConsGold;
            public int m_nConsContribution;
            public int m_nConspvppoi32;
            public C_quest_reward_item[] m_RewardItem { get; set; }//6
            public C_quest_reward_mastery[] m_RewardMastery { get; set; }//2
            public int ConsSkillCode;
            public int ConsSkillCnt;
            public int ConsForceCode;
            public int ConsForceCnt;
            public int NDQuest_QuestFinishContentSuccess_0;//5
            public int NDQuest_QuestFinishContentSuccess_1;
            public int NDQuest_QuestFinishContentSuccess_2;
            public int NDQuest_QuestFinishContentSuccess_3;
            public int NDQuest_QuestFinishContentSuccess_4;
            public int NDQuest_QuestFinishContentFail_0; //5
            public int NDQuest_QuestFinishContentFail_1;
            public int NDQuest_QuestFinishContentFail_2;
            public int NDQuest_QuestFinishContentFail_3;
            public int NDQuest_QuestFinishContentFail_4;
            public byte[] m_strLinkQuest_0;//8
            public byte[] m_strLinkQuest_1;//8
            public byte[] m_strLinkQuest_2;//8
            public byte[] m_strLinkQuest_3;//8
            public byte[] m_strLinkQuest_4;//8
            public int QuestNameContentIndex;
            public int QuestBriefContent_0;//5
            public int QuestBriefContent_1;
            public int QuestBriefContent_2;
            public int QuestBriefContent_3;
            public int QuestBriefContent_4;            
            public int QuestSummaryContent_0;//5           
            public int QuestSummaryContent_1;
            public int QuestSummaryContent_2;
            public int QuestSummaryContent_3;
            public int QuestSummaryContent_4;
            public int m_nStore_trade;
            public C_FailQuestCheck[] FailQuestCek { get; set; }//3
            public int Zero19;
            public int m_nViewportType;
            public int m_strViewportCode;
            public int Zero9;
            public int FailLinkQuest;
        }

        public C_Quest_fld ReadC_Quest_fld(BinaryReader Bin)
        {
            C_Quest_fld node = new C_Quest_fld();            
             node.nCount = Bin.ReadUInt16();
             node.unknown = Bin.ReadUInt16();
             node.m_strCode = Bin.ReadInt32();
             node.m_nQuestType = Bin.ReadByte();
             node.m_nDifficultyLevel = Bin.ReadByte();
             node.m_n2 = Bin.ReadByte();
             node.m_nLimLv = Bin.ReadByte();
             node.zerrr = Bin.ReadByte();
             node.AlwaysZero = Bin.ReadByte();
             node.AlwaysZero1 = Bin.ReadUInt16();
             node.m_ActionNode = new C_action_node[3];
             node.m_ActionNode[0] = ReadC_action_node(Bin);
             node.m_ActionNode[1] = ReadC_action_node(Bin);
             node.m_ActionNode[2] = ReadC_action_node(Bin);
             node.m_dConsExp = Bin.ReadDouble();
             node.m_nConsDalant = Bin.ReadInt32();
             node.m_nConsGold = Bin.ReadInt32();
             node.m_nConsContribution = Bin.ReadInt32();
             node.m_nConspvppoi32 = Bin.ReadInt32();
             node.m_RewardItem = new C_quest_reward_item[6];
             node.m_RewardItem[0] = ReadC_quest_reward_item(Bin);
             node.m_RewardItem[1] = ReadC_quest_reward_item(Bin);
             node.m_RewardItem[2] = ReadC_quest_reward_item(Bin);
             node.m_RewardItem[3] = ReadC_quest_reward_item(Bin);
             node.m_RewardItem[4] = ReadC_quest_reward_item(Bin);
             node.m_RewardItem[5] = ReadC_quest_reward_item(Bin);
             node.m_RewardMastery = new C_quest_reward_mastery[2];
             node.m_RewardMastery[0] = ReadC_quest_reward_mastery(Bin);
             node.m_RewardMastery[1] = ReadC_quest_reward_mastery(Bin);
             node.ConsSkillCode = Bin.ReadInt32();
             node.ConsSkillCnt = Bin.ReadInt32(); 
             node. ConsForceCode = Bin.ReadInt32();
             node. ConsForceCnt = Bin.ReadInt32();
             node. NDQuest_QuestFinishContentSuccess_0= Bin.ReadInt32();
             node. NDQuest_QuestFinishContentSuccess_1= Bin.ReadInt32();
             node. NDQuest_QuestFinishContentSuccess_2= Bin.ReadInt32();
             node. NDQuest_QuestFinishContentSuccess_3= Bin.ReadInt32();
             node. NDQuest_QuestFinishContentSuccess_4 = Bin.ReadInt32();
             node. NDQuest_QuestFinishContentFail_0= Bin.ReadInt32(); 
             node. NDQuest_QuestFinishContentFail_1= Bin.ReadInt32();
             node. NDQuest_QuestFinishContentFail_2= Bin.ReadInt32();
             node. NDQuest_QuestFinishContentFail_3= Bin.ReadInt32();
             node. NDQuest_QuestFinishContentFail_4 = Bin.ReadInt32();
             node.m_strLinkQuest_0 = Bin.ReadBytes(8);//8
             node.m_strLinkQuest_1 = Bin.ReadBytes(8);//8
             node.m_strLinkQuest_2 = Bin.ReadBytes(8);//8
             node.m_strLinkQuest_3 = Bin.ReadBytes(8);//8
             node.m_strLinkQuest_4 = Bin.ReadBytes(8);//8
             node.QuestNameContentIndex = Bin.ReadInt32();
             node.QuestBriefContent_0= Bin.ReadInt32();//5
             node.QuestBriefContent_1= Bin.ReadInt32();
             node.QuestBriefContent_2= Bin.ReadInt32();
             node.QuestBriefContent_3= Bin.ReadInt32();
             node.QuestBriefContent_4 = Bin.ReadInt32();
             node.QuestSummaryContent_0= Bin.ReadInt32();//5           
             node.QuestSummaryContent_1= Bin.ReadInt32();
             node.QuestSummaryContent_2= Bin.ReadInt32();
             node.QuestSummaryContent_3= Bin.ReadInt32();
             node.QuestSummaryContent_4 = Bin.ReadInt32();
             node.m_nStore_trade = Bin.ReadInt32();
             node.FailQuestCek = new C_FailQuestCheck[3];
             node.FailQuestCek[0] = Read_C_FailQuestCheck(Bin);
             node.FailQuestCek[1] = Read_C_FailQuestCheck(Bin);
             node.FailQuestCek[2] = Read_C_FailQuestCheck(Bin);
             node.Zero19 = Bin.ReadInt32();
             node.m_nViewportType = Bin.ReadInt32();
             node.m_strViewportCode = Bin.ReadInt32();
             node.Zero9 = Bin.ReadInt32();
             node.FailLinkQuest = Bin.ReadInt32();        
            return node;
         
        }

        /* 1151 */
        public struct C_QuestItem_fld
        {
           public int m_dwIndex;
           public int m_strCode;
           public int m_NumCode;
           public byte[] n_MonDesc; //32
        };
    }
}
