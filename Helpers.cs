using System;
using System.Collections;
using System.Collections.Specialized;
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

        public byte[] ByteExpand40(byte[] Bytes)
        {
            byte[] holder = new byte[40];
            for (int i = 0; i < 40; i++)
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
            if(item.Length == 2)
            {
                return -1;
            }           
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
            string five = "0";


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
            Character help = new Character();
            string ID = Encoding.UTF8.GetString(Bytes, 0, Bytes.Length);

            string purge0 = ID.Replace("\0", string.Empty);

            if (purge0 == "-1")
            {
                int value = -1;
                return value;
            }

            if (purge0.Length == 1 || purge0.Length == 2)
            {
                return Convert.ToInt32(purge0, 16);
            }

            

            string[] key = help.ClassType_KV_List.GetValues(purge0);

            var testview1= "0";
            if (key.Length > 0)
            {
                testview1 = key[0];
            }
            
            var testsomething = Convert.ToInt32(testview1, 16);
            var tester =  (int)ReverseBytes((uint)testsomething);
            
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
        
        //zero based index lookup
        public int Hex_LinqQuestItem(byte[] Bytes)
        {
            if (Bytes.Length == 2)
            {
                return -1;
            }
            if (Bytes.Length == 7)
            {
                string result = System.Text.Encoding.UTF8.GetString(Bytes, 0, 7);
                string Last = System.Text.Encoding.UTF8.GetString(Bytes, 0, 1);
                string Last2 = System.Text.Encoding.UTF8.GetString(Bytes, 1, 1);
                string secondToLast = System.Text.Encoding.UTF8.GetString(Bytes, 1, 2);

                string thirdToLast = System.Text.Encoding.UTF8.GetString(Bytes, 3, 2);
                string FourthToLast = System.Text.Encoding.UTF8.GetString(Bytes, 5, 2);

               string happy = Last + secondToLast + thirdToLast + FourthToLast;
                int hex = Convert.ToInt32(happy, 16);
                return hex;
            }

                return -1;

        }

        public int Hex_ServerCodeToClient(byte[] Bytes)
        {
            if(Bytes.Length == 2)
            {
                return -1;
            }
            if (Bytes.Length == 7)
            {           
                string result = System.Text.Encoding.UTF8.GetString(Bytes, 0, 7);
                string Last = System.Text.Encoding.UTF8.GetString(Bytes, 0, 1);
                string Last2 = System.Text.Encoding.UTF8.GetString(Bytes, 1, 1);
                string secondToLast = System.Text.Encoding.UTF8.GetString(Bytes, 1, 2);
                
                string thirdToLast = System.Text.Encoding.UTF8.GetString(Bytes, 3, 2);
                string FourthToLast = System.Text.Encoding.UTF8.GetString(Bytes, 5, 2);

                string happy;
               
                if (Last == "Q")
                {
                    Last = "10";
                    
                    if(result.StartsWith("QI"))//error on I  not event in parser files so 0 for now
                    {

                        return 0;
                    }
                    else
                    {
                        happy = Last + secondToLast + thirdToLast + FourthToLast;
                    }
                   int hex = Convert.ToInt32(happy, 16);
                    return hex;
                }
                if (Last == "e")
                {
                    //Last = "64";
                    if(Last2 == "d")
                    {
                        Last2 = "64";
                    }
                    else if (Last2 == "i")
                    {
                        Last2 = "69";
                    }
                    secondToLast = "65";
                    happy = Last2 + secondToLast + thirdToLast + FourthToLast;
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
           
            int hex2 = -1;
            return hex2;
                       
        }

        int Bin_fix(string data)
        {
            if (data == "00010")
            {
                return 5;
            }
            if (data == "10010")
            {
                return 3;
            }
            return 0;
        }
        public int Quest_Hex(string Bytes)
        {
            int hex = 0;
            if (Bytes.Length == 7)
            {
               
                string results_6 = Bytes.Substring(6, 1);
                string results_5 = Bytes.Substring(5, 1);
                string results_4 = Bytes.Substring(4, 1);
                string results_3 = Bytes.Substring(3, 1);
                string results_2 = Bytes.Substring(2, 1);
                string results_1 = Bytes.Substring(1, 1);
                string capture = Bytes.Substring(2, 5);
                string result =Bytes.Substring(0,7);
                string Last = Bytes.Substring(0, 1);
                string Last2 = Bytes.Substring( 1, 1);
                string test2 = Bytes.Substring(0, 2);
                string secondToLast =Bytes.Substring( 1, 2);

                string thirdToLast = Bytes.Substring(3, 2);
                string FourthToLast = Bytes.Substring(5, 2);
                
                string happy;
                int mathfunction = Convert.ToInt32(result, 16);
                int test = Convert.ToInt32(test2, 16);
                int mathsolve = 0;

                if (Bytes.StartsWith("B0"))
                {
                    happy =  results_6 + results_5 + results_4 + results_3 + results_2;
                    
                    hex = Convert.ToInt32(happy, 10) ;
                    hex -= Bin_fix(capture);
                     mathsolve = (mathfunction - 184548397);

                }
                else if(Bytes.StartsWith("B1"))
                {
                    string test1 = Bytes.Substring(2, 4);
                    hex = Convert.ToInt32(test1, 16);
                    mathsolve = (mathfunction - 185613327);
                }
               


                var tester = (int)ReverseBytes((uint)hex);
                return mathsolve;
            }
           
            return hex;
        }

    }
}