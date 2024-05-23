using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestEditor_V2.Structure;
using static System.Collections.Specialized.BitVector32;

namespace QuestEditor_V2
{
    internal class ND_Quest
    {
        Structure STR = new Structure();

        List<STR_File> STR_QuestFinishContents;
        List<STR_File> STR_QuestSummaryContents;
        List<STR_File> STR_QuestBriefContents;
        List<STR_File> STR_QuestConditionResult;
        List<STR_File> STR_QuestMissingResult;
        List<STR_File> STR_QuestName;

        List<Value_16> Section2;

        NameValueCollection QuestBrief_KV_List = new NameValueCollection();
        NameValueCollection QuestCondition_KV_List = new NameValueCollection();
        NameValueCollection QuestMissing_KV_List = new NameValueCollection();
        NameValueCollection QuestFinish_KV_List = new NameValueCollection();
        NameValueCollection QuestSummary_KV_List = new NameValueCollection();
        NameValueCollection QuestName_KV_List = new NameValueCollection();

        public List<QuestItems> QuestItem;
        NameValueCollection QuestItem_KV_List = new NameValueCollection();

        #region client_read
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
            public byte unk_1;
            public byte Text_Location_file;
            public short SplitNameLength;           
            public short unk_3;
            public short unk_4;
            public short unk_5;

        }
        public Value_16 Read_Value_16(BinaryReader Bin)
        {
            Value_16 item = new Value_16();
            item.m_dwIndex = Bin.ReadInt32();
            item.unk_0 = Bin.ReadInt16();
            item.unk_1 = Bin.ReadByte();
            item.Text_Location_file = Bin.ReadByte();
            item.SplitNameLength = Bin.ReadInt16();           
            item.unk_3 = Bin.ReadInt16();
            item.unk_4 = Bin.ReadInt16();
            item.unk_5 = Bin.ReadInt16();
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
       
        public struct ND_Quest_Body
        {
            public _ND_Header section_0;
            public List<Value_32> data_0;
            public _ND_Header section_1;
            public List<Value_16> data_1;
            public List<Dynamic_String> data_2;

        }

        public ND_Quest_Body Read_ND_Quest(BinaryReader Bin)
        {
            ND_Quest_Body item = new ND_Quest_Body();
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

        #endregion
       
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

        private void QuestMissingValues()
        {
            STR_QuestMissingResult = new List<Structure.STR_File>();
           
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(0, Encoding.UTF8.GetBytes("X000000"), "Conversation with %MERCHANT"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(1, Encoding.UTF8.GetBytes("X000001"), "Level %VALUE accomplishment"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(2, Encoding.UTF8.GetBytes("X000002"), "%ITEM"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(3, Encoding.UTF8.GetBytes("X000003"), "Get rid of %MONSTER"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(4, Encoding.UTF8.GetBytes("X000004"), "Hunt %MONSTER"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(5, Encoding.UTF8.GetBytes("X000005"), "Catch %MONSTER"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(6, Encoding.UTF8.GetBytes("X000006"), "%ITEM Production"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(7, Encoding.UTF8.GetBytes("X000007"), "%ITEM Mining"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(8, Encoding.UTF8.GetBytes("X000008"), "%ITEM Processing"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(9, Encoding.UTF8.GetBytes("X000009"), "Deliver this item to %MERCHANT"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(10, Encoding.UTF8.GetBytes("X000010"), "Confim Briefing"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(11, Encoding.UTF8.GetBytes("X000011"), "Chip has received from Bellato's Control center"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(12, Encoding.UTF8.GetBytes("X000012"), "Chip has received from Cora's Control center"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(13, Encoding.UTF8.GetBytes("X000013"), "Chip has received from Accrecia's Control center"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(14, Encoding.UTF8.GetBytes("X000014"), "Receive more than %VALUE contribution points"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(15, Encoding.UTF8.GetBytes("X000015"), "Protect out Control Center"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(16, Encoding.UTF8.GetBytes("X000016"), "Collect Quest item from %MONSTER"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(17, Encoding.UTF8.GetBytes("X000017"), "Kill %SUM of %MONSTER"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(18, Encoding.UTF8.GetBytes("X000018"), "Acquire %ITEM Map"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(19, Encoding.UTF8.GetBytes("X000019"), "%ITEM Use"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(20, Encoding.UTF8.GetBytes("X000020"), "Eliminate %RACE"));
            STR_QuestMissingResult.Add(STR.Fake_Read_Quest_STR(21, Encoding.UTF8.GetBytes("X000021"), "Observe %MERCHANT"));
           
            foreach (var str in STR_QuestMissingResult)
            {
                string ID = Encoding.UTF8.GetString(str.m_strCode, 0, str.m_strCode.Length);
                string name = Encoding.UTF8.GetString(str.m_strName_3, 0, str.m_strName_3.Length);

                string purge0 = ID.Replace("\0", string.Empty);
                string purge1 = name.Replace("\0", string.Empty);

                QuestMissing_KV_List.Add(purge0, purge1);

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
                                    
                    foreach (var str in QuestItem)
                    {
                        string ID = Encoding.UTF8.GetString(str.m_strID, 0, str.m_strID.Length);
                        string purge0 = ID.Replace("\0", string.Empty);
                        string ID1 = Encoding.UTF8.GetString(str.m_strName, 0, str.m_strName.Length);
                        string purge1 = ID.Replace("\0", string.Empty);
                        QuestItem_KV_List.Add(purge0, purge1);                     

                    }

                    GC.KeepAlive(STR_QuestName);
                    reader.Dispose();
                    reader.Close();
                }

            }
        }


        public void Write_NDQUEST()
        {
            QuestNameContents();
            QuestBriefContents();
            QuestSummaryContents();
            QuestConditionResult();
            QuestMissingValues();
            QuestFinishContents();
            QuestItemContents();

            Helpers help = new Helpers();
            System.IO.Directory.CreateDirectory("Client_Files");
            string fileName = "NDQuest.dat";
            string path = Path.Combine(Environment.CurrentDirectory, @"Client_Files\", fileName);


            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var bin = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    
                    bin.Write(QuestItem_KV_List.Count);
                    bin.Write(32);
                    foreach (string key in QuestItem_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(QuestItem_KV_List[key]);
                        bin.Write(help.ByteExpand32(bytes));
                    }
                    Section2 = new List<Value_16>();
                    int index = 0;
                    foreach (string key in QuestName_KV_List)
                    {
                        Value_16 test = new Value_16();
                       int n = help.NDQUest_Hex(key);
                       byte[] str = BitConverter.GetBytes(n);                      

                        test.m_dwIndex = index;
                        test.unk_0 =  BitConverter.ToInt16(new byte[2] { (byte)str[0], (byte)str[1] }, 0); 
                        test.unk_1 = str[2];
                        test.Text_Location_file = str[3]; //always 16
                        test.unk_3 = 0;
                        test.unk_4 = 0;
                        test.unk_5 = 0;
                        test.SplitNameLength = (short)(QuestName_KV_List[key].Count()+ 1);
                        Section2.Add(test);
                        index++;
                    }
                    foreach (string key in QuestBrief_KV_List)
                    {
                        Value_16 test = new Value_16();
                        int n = help.NDQUest_Hex(key);
                        byte[] str = BitConverter.GetBytes(n);
                        test.m_dwIndex = index;
                        test.unk_0 = BitConverter.ToInt16(new byte[2] { (byte)str[0], (byte)str[1] }, 0);
                        test.unk_1 = str[2];
                        test.Text_Location_file = str[3]; //always 1
                        test.unk_3 = 0;
                        test.unk_4 = 0;
                        test.unk_5 = 0;
                        test.SplitNameLength = (short)(QuestBrief_KV_List[key].Count() + 1);
                        Section2.Add(test);
                        index++;
                    }
                    foreach (string key in QuestSummary_KV_List)
                    {
                        Value_16 test = new Value_16();
                        int n = help.NDQUest_Hex(key);
                        byte[] str = BitConverter.GetBytes(n);
                        test.m_dwIndex = index;
                        test.unk_0 = BitConverter.ToInt16(new byte[2] { (byte)str[0], (byte)str[1] }, 0);
                        test.unk_1 = str[2];
                        test.Text_Location_file = str[3]; //always 18
                        test.unk_3 = 0;
                        test.unk_4 = 0;
                        test.unk_5 = 0;
                        test.SplitNameLength = (short)(QuestSummary_KV_List[key].Count() + 1);
                        Section2.Add(test);
                        index++;
                    }
                    foreach (string key in QuestCondition_KV_List)
                    {
                        Value_16 test = new Value_16();
                        int n = help.NDQUest_Hex(key);
                        byte[] str = BitConverter.GetBytes(n);
                        test.m_dwIndex = index;
                        test.unk_0 = BitConverter.ToInt16(new byte[2] { (byte)str[0], (byte)str[1] }, 0);
                        test.unk_1 = str[2];
                        test.Text_Location_file = str[3]; //always 2
                        test.unk_3 = 0;
                        test.unk_4 = 0;
                        test.unk_5 = 0;
                        test.SplitNameLength = (short)(QuestCondition_KV_List[key].Count() + 1);
                        Section2.Add(test);
                        index++;
                    }

                    foreach (string key in QuestMissing_KV_List) // 22 string section missing has Text_Location_file as 17
                    {
                        Value_16 test = new Value_16();
                        int n = help.NDQUest_Hex(key);
                        byte[] str = BitConverter.GetBytes(n);
                        test.m_dwIndex = index;
                        test.unk_0 = BitConverter.ToInt16(new byte[2] { (byte)str[0], (byte)str[1] }, 0);
                        test.unk_1 = str[2];
                        test.Text_Location_file = str[3]; //always 11
                        test.unk_3 = 0;
                        test.unk_4 = 0;
                        test.unk_5 = 0;
                        test.SplitNameLength = (short)(QuestMissing_KV_List[key].Count() + 1);
                        Section2.Add(test);
                        index++;
                    }
                    
                    foreach (string key in QuestFinish_KV_List)
                    {
                        Value_16 test = new Value_16();
                        int n = help.NDQUest_Hex(key);
                        byte[] str = BitConverter.GetBytes(n);
                        test.m_dwIndex = index;
                        test.unk_0 = BitConverter.ToInt16(new byte[2] { (byte)str[0], (byte)str[1] }, 0);
                        test.unk_1 = str[2];                        
                        test.Text_Location_file = str[3]; //always 20 mostly fail is 5
                        test.unk_3 = 0;
                        test.unk_4 = 0;
                        test.unk_5 = 0;
                        test.SplitNameLength = (short)(QuestFinish_KV_List[key].Count() + 1);
                        Section2.Add(test);
                        index++;
                    }
                    bin.Write(Section2.Count);
                    
                    foreach(Value_16 value in Section2)
                    {
                        bin.Write(value.m_dwIndex);
                        bin.Write(value.unk_0);
                        bin.Write(value.unk_1);
                        bin.Write(value.Text_Location_file);
                        bin.Write(value.SplitNameLength);
                        bin.Write(value.unk_3);
                        bin.Write(value.unk_4);
                        bin.Write(value.unk_5);                      

                    }

                    foreach (string key in QuestName_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(QuestName_KV_List[key]);
                        bin.Write(bytes);
                        bin.Write((byte)0);
                    }
                    foreach (string key in QuestBrief_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(QuestBrief_KV_List[key]);
                        bin.Write(bytes);
                        bin.Write((byte)0);
                    }
                    foreach (string key in QuestSummary_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(QuestSummary_KV_List[key]);
                        bin.Write(bytes);
                        bin.Write((byte)0);
                    }
                    foreach (string key in QuestCondition_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(QuestCondition_KV_List[key]);
                        bin.Write(bytes);
                        bin.Write((byte)0);
                    }
                   
                    foreach (string key in QuestMissing_KV_List) // 22 string section missing 
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(QuestMissing_KV_List[key]);
                        bin.Write(bytes);
                        bin.Write((byte)0);
                    }

                    foreach (string key in QuestFinish_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(QuestFinish_KV_List[key]);
                        bin.Write(bytes);
                        bin.Write((byte)0);
                    }

                }
            }
        }

        public void WriteDesc()
        {
            QuestNameContents();
            QuestBriefContents();
            QuestSummaryContents();
            QuestConditionResult();
            QuestMissingValues();
            QuestFinishContents();

            int i = 0;
            System.IO.Directory.CreateDirectory("Client_Files");
            string fileName = "QuestDesc.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Client_Files\", fileName);


            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var bin = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    foreach (string key in QuestName_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(string.Format("{0},{1}{2}", i.ToString(), QuestName_KV_List[key], Environment.NewLine));                        
                        bin.Write(bytes);
                     
                        i++;
                    }

                    foreach (string key in QuestBrief_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(string.Format("{0},{1}{2}", i.ToString(), QuestBrief_KV_List[key], Environment.NewLine));
                        bin.Write(bytes);
                        i++;
                    }

                    foreach (string key in QuestSummary_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(string.Format("{0},{1}{2}", i.ToString(), QuestSummary_KV_List[key], Environment.NewLine));
                        bin.Write(bytes);
                        i++;
                    }
                    foreach (string key in QuestCondition_KV_List) 
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(string.Format("{0},{1}{2}", i.ToString(), QuestCondition_KV_List[key], Environment.NewLine));
                        bin.Write(bytes);
                        i++;
                    }
                    foreach (string key in QuestMissing_KV_List) 
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(string.Format("{0},{1}{2}", i.ToString(), QuestMissing_KV_List[key], Environment.NewLine));
                        bin.Write(bytes);
                        i++;
                    }

                    foreach (string key in QuestFinish_KV_List)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(string.Format("{0},{1}{2}", i.ToString(), QuestFinish_KV_List[key], Environment.NewLine));
                        bin.Write(bytes);
                        i++;
                    }

                }
            }
                   
           
        }
    }
}
