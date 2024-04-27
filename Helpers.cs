using System.Text;

namespace QuestEditor_V2
{
    internal class Helpers
    {
        public string ByteString(byte[] Bytes)
        {
            return (Encoding.UTF8.GetString(Bytes, 0, Bytes.Length)).Replace("\0", string.Empty);
        }
        public byte[] ByteExpand64(byte[] Bytes)
        {
            byte[] holder = new byte[64];
            for(int i = 0; i < 64; i++)
            {
                if (i < Bytes.Length)
                {
                    holder[i] = Bytes[i];
                }
                else
                {
                    holder[i] = 0;
                }
            }
            return holder;
        }


    }
}