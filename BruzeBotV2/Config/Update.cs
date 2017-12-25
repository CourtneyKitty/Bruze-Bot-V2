using System;
using System.Collections.Generic;
using System.Text;

namespace BruzeBotV2.Config
{
    class Update
    {
        public static BotConfig UpdateConfig(BotConfig config)
        {
            config.Prefix = BotConfig.Load().Prefix;
            config.Token = BotConfig.Load().Token;
            config.NewMemberRank = BotConfig.Load().NewMemberRank;
            config.UserRank = BotConfig.Load().UserRank;
            config.MusicRank = BotConfig.Load().MusicRank;
            config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
            config.GraphicsRank = BotConfig.Load().GraphicsRank;
            config.welcomeChannelId = BotConfig.Load().welcomeChannelId;
            config.Messages = BotConfig.Load().Messages;
            config.Members = BotConfig.Load().Members;
            return config;
        }
    }
}
