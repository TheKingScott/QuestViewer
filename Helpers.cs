using System;
using System.Collections;
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
            for (int i = 0; i < 64; i++)
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

        public byte[] ByteShrink8(byte[] Bytes)
        {
            byte[] holder = new byte[8];
            for (int i = 0; i < 8; i++)
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
        public byte[] ByteShrink4(byte[] Bytes)
        {
            byte[] holder = new byte[4];
            for (int i = 0; i < 4; i++)
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

        public int m_sCondVal_To_Int(byte[] Bytes)
        {
            string ID = Encoding.UTF8.GetString(Bytes, 0, Bytes.Length);

            string purge0 = ID.Replace("\0", string.Empty);
            if(purge0 == "-1")
            {
                int value = -1;
                return value;
            }
            /* Todo handle these for NPCEvent write
            iyqla14
            iyqla28
            iyqla61
            iyqla76
            iyqla56*/
            int hex = Convert.ToInt32(purge0, 16);
            return hex;
        }


        public int Hex_ServerCodeToClient(byte[] Bytes)
        {
            if (Bytes.Length == 7)
            {           
                string result = System.Text.Encoding.UTF8.GetString(Bytes, 0, 7);
                string Last = System.Text.Encoding.UTF8.GetString(Bytes, 0, 1);
                string Last2 = System.Text.Encoding.UTF8.GetString(Bytes, 0, 2);
                string secondToLast = System.Text.Encoding.UTF8.GetString(Bytes, 1, 2);
                
                string thirdToLast = System.Text.Encoding.UTF8.GetString(Bytes, 3, 2);
                string FourthToLast = System.Text.Encoding.UTF8.GetString(Bytes, 5, 2);

                string happy;
               
                if (Last == "Q")
                {
                    Last = "10";
                    happy = Last + secondToLast + thirdToLast + FourthToLast;
                   int hex = Convert.ToInt32(happy, 16);
                    return hex;
                }
                if (Last == "e")
                {
                    Last = "64";
                    secondToLast = "65";
                    happy = Last + secondToLast + thirdToLast + FourthToLast;
                    int hex = Convert.ToInt32(happy, 16);
                    return hex;
                }
                else
                {
                    happy = secondToLast + thirdToLast + FourthToLast + Last;
                    int hex = Convert.ToInt32(happy, 16);
                    return hex;
                }
            }
            int hex1 = -1;
            return hex1;
           

            
        }



    }
}