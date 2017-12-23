using Newtonsoft.Json;
using System;
using System.IO;

namespace BruzeBotV2.Config
{
    class BotConfig
    {
        [JsonIgnore]
        public static readonly string appdir = AppContext.BaseDirectory;

        public string Prefix { get; set; }
        public string Token { get; set; }
        public string NewMemberRank { get; set; }
        public string UserRank { get; set; }
        public string MusicRank { get; set; }
        public string ProgrammingRank { get; set; }
        public string GraphicsRank { get; set; }
        public BotConfig()
        {
            Prefix = "!";
            Token = "";
            NewMemberRank = "";
            UserRank = "";
            MusicRank = "";
            ProgrammingRank = "";
            GraphicsRank = "";
        }

        public void Save(string dir = "configuration/config.json")
        {
            string file = Path.Combine(appdir, dir);
            File.WriteAllText(file, ToJson());
        }
        public static BotConfig Load(string dir = "configuration/config.json")
        {
            string file = Path.Combine(appdir, dir);
            return JsonConvert.DeserializeObject<BotConfig>(File.ReadAllText(file));
        }
        public string ToJson()
            => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
