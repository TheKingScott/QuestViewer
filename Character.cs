using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEditor_V2
{
    internal class Character
    {
        public NameValueCollection ClassType_KV_List = new NameValueCollection();

        public Character()
        {
            ClassType_KV_List.Add("BWB0", "10601100");
            ClassType_KV_List.Add("BWF1", "51601100");
            ClassType_KV_List.Add("BWF2", "52601100");
            ClassType_KV_List.Add("BWS1", "21611100");
            ClassType_KV_List.Add("BWS2", "22611100");
            ClassType_KV_List.Add("BWS3", "23611100");
            ClassType_KV_List.Add("BWS4", "24611100");
            ClassType_KV_List.Add("BWT1", "31611100");
            ClassType_KV_List.Add("BWT2", "32611100");
            ClassType_KV_List.Add("BWT3", "33611100");
            ClassType_KV_List.Add("BWT4", "34611100");
            ClassType_KV_List.Add("BWT5", "35611100");
            ClassType_KV_List.Add("BWT6", "36611100");
            ClassType_KV_List.Add("BWT7", "37611100");
            ClassType_KV_List.Add("BWT8", "38611100");

            ClassType_KV_List.Add("BRB0", "10101100");
            ClassType_KV_List.Add("BRF1", "51101100");
            ClassType_KV_List.Add("BRF2", "52101100");
            ClassType_KV_List.Add("BRS1", "21111100");
            ClassType_KV_List.Add("BRS2", "22111100");
            ClassType_KV_List.Add("BRS3", "23111100");
            ClassType_KV_List.Add("BRS4", "24111100");
            ClassType_KV_List.Add("BRT1", "31111100");
            ClassType_KV_List.Add("BRT2", "32111100");
            ClassType_KV_List.Add("BRT3", "33111100");
            ClassType_KV_List.Add("BRT4", "34111100");
            ClassType_KV_List.Add("BRT5", "35111100");
            ClassType_KV_List.Add("BRT6", "36111100");
            ClassType_KV_List.Add("BRT7", "37111100");
            ClassType_KV_List.Add("BRT8", "38111100");

            ClassType_KV_List.Add("BFB0", "10501000");
            ClassType_KV_List.Add("BFF1", "51501000");
            ClassType_KV_List.Add("BFF2", "52501000");
            ClassType_KV_List.Add("BFS1", "21511000");
            ClassType_KV_List.Add("BFS2", "22511000");
            ClassType_KV_List.Add("BFS3", "23511000");
            ClassType_KV_List.Add("BFS4", "24511000");
            ClassType_KV_List.Add("BFT1", "31511000");
            ClassType_KV_List.Add("BFT2", "32511000");
            ClassType_KV_List.Add("BFT3", "33511000");
            ClassType_KV_List.Add("BFT4", "34511000");
            ClassType_KV_List.Add("BFT5", "35511000");
            ClassType_KV_List.Add("BFT6", "36511000");
            ClassType_KV_List.Add("BFT7", "37511000");
            ClassType_KV_List.Add("BFT8", "38511000");

            ClassType_KV_List.Add("BSB0", "10201100");
            ClassType_KV_List.Add("BSF1", "51201100");
            ClassType_KV_List.Add("BSF2", "52201100");
            ClassType_KV_List.Add("BSS1", "21211100");
            ClassType_KV_List.Add("BSS2", "22211100");
            ClassType_KV_List.Add("BSS3", "23211100");
            ClassType_KV_List.Add("BSS4", "24211100");
            ClassType_KV_List.Add("BST1", "31211100");
            ClassType_KV_List.Add("BST2", "32211100");
            ClassType_KV_List.Add("BST3", "33211100");
            ClassType_KV_List.Add("BST4", "34211100");
            ClassType_KV_List.Add("BST5", "35211100");
            ClassType_KV_List.Add("BST6", "36211100");
            ClassType_KV_List.Add("BST7", "37211100");
            ClassType_KV_List.Add("BST8", "38211100");


            ClassType_KV_List.Add("CWB0", "10602100");
            ClassType_KV_List.Add("CWF1", "51602100");
            ClassType_KV_List.Add("CWF2", "52602100");
            ClassType_KV_List.Add("CWS1", "21612100");
            ClassType_KV_List.Add("CWS2", "22612100");
            ClassType_KV_List.Add("CWS3", "23612100");
            ClassType_KV_List.Add("CWS4", "24612100");
            ClassType_KV_List.Add("CWT1", "31612100");
            ClassType_KV_List.Add("CWT2", "32612100");
            ClassType_KV_List.Add("CWT3", "33612100");
            ClassType_KV_List.Add("CWT4", "34612100");
            ClassType_KV_List.Add("CWT5", "35612100");
            ClassType_KV_List.Add("CWT6", "36612100");
            ClassType_KV_List.Add("CWT7", "37612100");
            ClassType_KV_List.Add("CWT8", "38612100");

            ClassType_KV_List.Add("CRB0", "10102100");
            ClassType_KV_List.Add("CRF1", "51102100");
            ClassType_KV_List.Add("CRF2", "52102100");
            ClassType_KV_List.Add("CRS1", "21112100");
            ClassType_KV_List.Add("CRS2", "22112100");
            ClassType_KV_List.Add("CRS3", "23112100");
            ClassType_KV_List.Add("CRS4", "24112100");
            ClassType_KV_List.Add("CRT1", "31112100");
            ClassType_KV_List.Add("CRT2", "32112100");
            ClassType_KV_List.Add("CRT3", "33112100");
            ClassType_KV_List.Add("CRT4", "34112100");
            ClassType_KV_List.Add("CRT5", "35112100");
            ClassType_KV_List.Add("CRT6", "36112100");
            ClassType_KV_List.Add("CRT7", "37112100");
            ClassType_KV_List.Add("CRT8", "38112100");

            ClassType_KV_List.Add("CFB0", "10502000");
            ClassType_KV_List.Add("CFF1", "51502000");
            ClassType_KV_List.Add("CFF2", "52502000");
            ClassType_KV_List.Add("CFS1", "21512000");
            ClassType_KV_List.Add("CFS2", "22512000");
            ClassType_KV_List.Add("CFS3", "23512000");
            ClassType_KV_List.Add("CFS4", "24512000");
            ClassType_KV_List.Add("CFT1", "31512000");
            ClassType_KV_List.Add("CFT2", "32512000");
            ClassType_KV_List.Add("CFT3", "33512000");
            ClassType_KV_List.Add("CFT4", "34512000");
            ClassType_KV_List.Add("CFT5", "35512000");
            ClassType_KV_List.Add("CFT6", "36512000");
            ClassType_KV_List.Add("CFT7", "37512000");
            ClassType_KV_List.Add("CFT8", "38512000");

            ClassType_KV_List.Add("CSB0", "10202100");
            ClassType_KV_List.Add("CSF1", "51202100");
            ClassType_KV_List.Add("CSF2", "52202100");
            ClassType_KV_List.Add("CSS1", "21212100");
            ClassType_KV_List.Add("CSS2", "22212100");
            ClassType_KV_List.Add("CSS3", "23212100");
            ClassType_KV_List.Add("CSS4", "24212100");
            ClassType_KV_List.Add("CST1", "31212100");
            ClassType_KV_List.Add("CST2", "32212100");
            ClassType_KV_List.Add("CST3", "33212100");
            ClassType_KV_List.Add("CST4", "34212100");
            ClassType_KV_List.Add("CST5", "35212100");
            ClassType_KV_List.Add("CST6", "36212100");
            ClassType_KV_List.Add("CST7", "37212100");
            ClassType_KV_List.Add("CST8", "38212100");

            ClassType_KV_List.Add("AWB0", "10600100");
            ClassType_KV_List.Add("AWF1", "51600100");
            ClassType_KV_List.Add("AWF2", "52600100");
            ClassType_KV_List.Add("AWS1", "21610100");
            ClassType_KV_List.Add("AWS2", "22610100");
            ClassType_KV_List.Add("AWS3", "23610100");
            ClassType_KV_List.Add("AWS4", "24610100");
            ClassType_KV_List.Add("AWT1", "31610100");
            ClassType_KV_List.Add("AWT2", "32610100");
            ClassType_KV_List.Add("AWT3", "33610100");
            ClassType_KV_List.Add("AWT4", "34610100");
            ClassType_KV_List.Add("AWT5", "35610100");
            ClassType_KV_List.Add("AWT6", "36610100");
            ClassType_KV_List.Add("AWT7", "37610100");
            ClassType_KV_List.Add("AWT8", "38610100");

            ClassType_KV_List.Add("ARB0", "10100100");
            ClassType_KV_List.Add("ARF1", "51100100");
            ClassType_KV_List.Add("ARF2", "52100100");
            ClassType_KV_List.Add("ARS1", "21110100");
            ClassType_KV_List.Add("ARS2", "22110100");
            ClassType_KV_List.Add("ARS3", "23110100");
            ClassType_KV_List.Add("ARS4", "24110100");
            ClassType_KV_List.Add("ART1", "31110100");
            ClassType_KV_List.Add("ART2", "32110100");
            ClassType_KV_List.Add("ART3", "33110100");
            ClassType_KV_List.Add("ART4", "34110100");
            ClassType_KV_List.Add("ART5", "35110100");
            ClassType_KV_List.Add("ART6", "36110100");
            ClassType_KV_List.Add("ART7", "37110100");
            ClassType_KV_List.Add("ART8", "38110100");

            ClassType_KV_List.Add("ASB0", "10200100");
            ClassType_KV_List.Add("ASF1", "51200100");
            ClassType_KV_List.Add("ASF2", "52200100");
            ClassType_KV_List.Add("ASS1", "21210100");
            ClassType_KV_List.Add("ASS2", "22210100");
            ClassType_KV_List.Add("ASS3", "23210100");
            ClassType_KV_List.Add("ASS4", "24210100");
            ClassType_KV_List.Add("AST1", "31210100");
            ClassType_KV_List.Add("AST2", "32210100");
            ClassType_KV_List.Add("AST3", "33210100");
            ClassType_KV_List.Add("AST4", "34210100");
            ClassType_KV_List.Add("AST5", "35210100");
            ClassType_KV_List.Add("AST6", "36210100");
            ClassType_KV_List.Add("AST7", "37210100");
            ClassType_KV_List.Add("AST8", "38210100");

        }
    }
}
