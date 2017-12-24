using Newtonsoft.Json;
using System;
using System.IO;

namespace BruzeBotV2.Config
{
    class RankSaves
    {
        [JsonIgnore]
        public static readonly string appdir = AppContext.BaseDirectory;
        
        public int userCount { get; set; }
        public int musicCount { get; set; }
        public int programmingCount { get; set; }
        public int graphicsCount { get; set; }

        public RankSaves()
        {
            userCount = 0;
            musicCount = 0;
            programmingCount = 0;
            graphicsCount = 0;
        }

        public void Save(string dir = "configuration/ranks.json")
        {
            Console.WriteLine("Attempting to save " + dir);
            string file = Path.Combine(appdir, dir);
            File.WriteAllText(file, ToJson());
            Console.WriteLine("Successfully saved " + dir);
        }
        public static RankSaves Load(string dir = "configuration/ranks.json")
        {
            Console.WriteLine("Attempting to load " + dir);
            string file = Path.Combine(appdir, dir);
            return JsonConvert.DeserializeObject<RankSaves>(File.ReadAllText(file));
            Console.WriteLine("Successfully loaded " + dir);
        }
        public string ToJson()
            => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
