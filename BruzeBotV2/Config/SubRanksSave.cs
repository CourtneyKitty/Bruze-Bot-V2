using BruzeBotV2.util;
using Newtonsoft.Json;
using System;
using System.IO;

namespace BruzeBotV2.Config
{
    class SubRanksSaves
    {
        [JsonIgnore]
        public static readonly string appdir = AppContext.BaseDirectory;

        public int SubRanks { get; set; } // Count of sub ranks
        public SubRank[] Ranks { get; set; } // Array of ranks

        public SubRanksSaves()
        {
            SubRanks = 0;
            Ranks = new SubRank[SubRanks];
        }

        public void Save(string dir = "configuration/sub_ranks.json")
        {
            Console.WriteLine("Attempting to save " + dir);
            string file = Path.Combine(appdir, dir);
            File.WriteAllText(file, ToJson());
            Console.WriteLine("Successfully saved " + dir);
        }
        public static SubRanksSaves Load(string dir = "configuration/sub_ranks.json")
        {
            Console.WriteLine("Attempting to load " + dir);
            string file = Path.Combine(appdir, dir);
            Console.WriteLine("Successfully loaded " + dir);
            return JsonConvert.DeserializeObject<SubRanksSaves>(File.ReadAllText(file));
        }
        public string ToJson()
            => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
