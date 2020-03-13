using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo.IndicesAndRanges
{
    public class SystembolagetFile
    {
        public static async Task<Systembolaget[]> ReadAll()
        {
            using FileStream stream = File.OpenRead(GetPath());
            SystembolagetFile fileContent = await JsonSerializer.DeserializeAsync<SystembolagetFile>(stream);
            return fileContent.ButikOmbud;
            
            static string GetPath()
            {
                return @"D:\dev\PracticeProjects\CSharp8\CSharp8.Swenug\systembolaget.json";
            }
        }

        public Info Info { get; set; }
        public Systembolaget[] ButikOmbud { get; set; }
    }

    public class Info
    {
        public string Meddelande { get; set; }
    }

    public class Systembolaget
    {
        public string Typ { get; set; }
        public string Nr { get; set; }
        public object Namn { get; set; }
        public string Address1 { get; set; }
        public object[] Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Telefon { get; set; }
        public object[] ButiksTyp { get; set; }
        public object Tjanster { get; set; }
        public string SokOrd { get; set; }
        public object Oppettider { get; set; }
        public object RT90x { get; set; }
        public object RT90y { get; set; }

        public override string ToString()
        {
            return Namn.ToString();
        }
    }
}