using System.Text;

namespace QuestEditor_V2
{
    internal class Helpers
    {
        public string ByteString(byte[] Bytes)
        {
            return (Encoding.UTF8.GetString(Bytes, 0, Bytes.Length)).Replace("\0", string.Empty);
        }
    }
}