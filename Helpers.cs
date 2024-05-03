using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
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

        //fixing client byte order
        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        public int Client_Hex(string item)
        {
            string PlaceOne;

            if(item.StartsWith("gt"))
            {
                PlaceOne = "160";
            }
            else if (item.StartsWith("tr") || (item.StartsWith("ti")))
            {
                PlaceOne = "112";
            }
            else if (item.StartsWith("sk"))
            {
                PlaceOne = "96";
            }
            else if (item.StartsWith("sk"))
            {
                PlaceOne = "96";
            }
            else if (item.StartsWith("ey") || (item.StartsWith("un")))
            {
                PlaceOne = "128";
            }
            else if (item.StartsWith("re") || (item.StartsWith("bx") ) || (item.StartsWith("rd")))
            {
                PlaceOne = "80";
            }
            else if (item.StartsWith("fi"))
            {
                PlaceOne = "144";
            }
            else if (item.StartsWith("lk"))
            {
                PlaceOne = "240";
            }
            else if (item.StartsWith("cu"))
            {
                PlaceOne = "251";
            }
            else
            {
                PlaceOne = "192";
            }
            ////now to the other digits
            string placeholder = item.Substring(2);
            string lasttwo = item.Substring(5);
            char[] HexWord = new char[255];
            char[] Abjad = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] cData = item.ToCharArray();
            int zzz = 0;

            string one = "";
            string two = "";
            string three = "";
            string four = "";
            string five = "";


            for (int i = 0; i < (placeholder.Length); i++)
            {
                for (int k = 0; k < Abjad.Length; k++)
                {
                    if (Abjad[k] == cData[i])
                    {
                        if (i == 0)
                        {
                            if (cData[0] == 0)
                            {
                                if ((cData[3] == 1) && (cData[4] == 0))
                                {
                                    one = String.Format("{0}",  16 + Int32.Parse(PlaceOne));
                                }
                                else
                                {
                                    one = String.Format("{0}",  + cData[4] + Int32.Parse(PlaceOne));
                                }
                            }
                            else
                            {
                                one = String.Format("{0}",  k + Int32.Parse(PlaceOne));
                            }
                            zzz++;
                        }
                        else
                        {
                            if (i == 1)
                            {
                                two = String.Format("{0}", + k);
                            }
                            if (i == 2)
                            {
                                three = String.Format("{0}",  + k);
                            }
                            if (i == 3)
                            {
                                four = String.Format("{0}", + k);
                            }
                            if (i == 4)
                            {
                                five = String.Format("{0}", + k);
                            }
                            zzz++;
                        }
                    }
                }
            }
            int dec0 = Convert.ToInt32(PlaceOne);
            int dec1 = Convert.ToInt32(one, 10);
            int dec2 = Convert.ToInt32(two, 10);
            int dec3 = Convert.ToInt32(three, 10);
            int dec4 = Convert.ToInt32(four, 10);
            int dec5 = Convert.ToInt32(five, 10);

            int truelast = dec3 + dec0;
            string outputHex = Convert.ToString(int.Parse(four), 16);
           
            
            string testview1 = String.Format("{0:X02}{1:X02}{2:X02}{3:X02}", lasttwo, dec5, dec4, truelast);

           var testsomething = Convert.ToInt32(testview1, 16);
           
            return (int)ReverseBytes((uint)testsomething); 

        }

        public int m_sCondVal_ClassType(byte[] Bytes)
        {
            string ID = Encoding.UTF8.GetString(Bytes, 0, Bytes.Length);

            string purge0 = ID.Replace("\0", string.Empty);
            if(purge0.Length == 1)
            {
                return Convert.ToInt32(purge0, 16);
            }
            string one_0 = "";
            string one_1 = "";
            //todo expand to handle all classes
            if (purge0.StartsWith("BW"))
            {              
                one_0 = "10";
                one_1 = "60";
            }
            string two = ID.Substring(2,1);
            string three = ID.Substring(3,1);
            var two2 = Convert.ToInt32(two.ToLower(), 16);
            var three2 = Convert.ToInt32(three.ToLower(), 16);
            string testview1 = String.Format("{0:X02}{1:X02}{2:D02}{3:D02}", one_0, one_1, two2, three2);

           var testsomething = Convert.ToInt32(testview1, 16);
           var tester =  (int)ReverseBytes((uint)testsomething);
            int value = 0;
            return tester;

        }
        public int m_sCondVal_ItemType(byte[] Bytes)
        {
            string ID = Encoding.UTF8.GetString(Bytes, 0, Bytes.Length);

            string purge0 = ID.Replace("\0", string.Empty);
            
            if (purge0 == "-1")
            {
                int value = 0;
                return value;
            }
            else if(purge0.Length == 7)
            {
                string start = purge0.Substring(0, 2);
                switch(start)
                {
                    case"if": return 0; 
                    case"iu": return 1;
                    case"il": return 2;
                    case"ig": return 3;
                    case"is": return 4;
                    case"ih": return 5;
                    case"iw": return 6;
                    case"id": return 7;
                    case"ik": return 8;
                    case"ii": return 9;
                    case"ia": return 10;
                    case"ib": return 11;
                    case"im": return 12;
                    case"ip": return 13;
                    case"ie": return 14;
                    case"it": return 15;
                    case"io": return 16;
                    case"ir": return 17;
                    case"ic": return 18;
                    case"in": return 19;
                    case"iy": return 20;
                    case"iz": return 21;
                    case"iq": return 22;
                    case"ix": return 23;
                    case"ij": return 24;
                    case"gt": return 25;
                    case"tr": return 26;
                    case"sk": return 27;
                    case"ti": return 28;
                    case"ey": return 29;
                    case"re": return 30;
                    case"bx": return 31;
                    case"fi": return 32;
                    case"un": return 33;
                    case"rd": return 34;
                    case"lk": return 35;
                    case"cu": return 36;
                    default:  return 0 ;
                }
            }
            else
            {
                return 0;
            }

        }
        public int m_sCondVal_Item_Int(byte[] Bytes)
        {
            string ID = Encoding.UTF8.GetString(Bytes, 0, Bytes.Length);

            string purge0 = ID.Replace("\0", string.Empty);

            if (purge0 == "-1")
            {
                int value = -1;
                return value;
            }
           
            return Client_Hex(purge0);
             

        }

        public int m_sCondVal_Hex_Int(byte[] Bytes)
        {
            string ID = Encoding.UTF8.GetString(Bytes, 0, Bytes.Length);

            string purge0 = ID.Replace("\0", string.Empty);
          
            if (purge0 == "-1")
            {
                int value = -1;
                return value;
            }

            int hex = Convert.ToInt32(purge0, 16); //npcevent uses base 10
            return hex;
        }

        public int m_sCondVal_Dec_Int(byte[] Bytes)
        {
            string ID = Encoding.UTF8.GetString(Bytes, 0, Bytes.Length);

            string purge0 = ID.Replace("\0", string.Empty);

            if(purge0 == "-1")
            {
                int value = -1;
                return value;
            }
            
            int dec = Convert.ToInt32(purge0, 10); //npcevent uses base 10
            return dec;
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
            else if(Bytes.Length == 5)
            {
                string result = System.Text.Encoding.UTF8.GetString(Bytes, 0, 5);
                int hex = Convert.ToInt32(result, 16);
                return hex;                            

            }
            int hex1 = -1;
            return hex1;
           

            
        }



    }
}