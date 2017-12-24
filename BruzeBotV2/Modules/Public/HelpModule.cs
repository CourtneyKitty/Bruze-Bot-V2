using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System.Threading.Tasks;
using BruzeBotV2.Config;
using System.Linq;
using BruzeBotV2.util;

namespace BruzeBotV2.Modules.Public
{
    public class HelpModule : ModuleBase
    {
        Errors errors = new Errors();

        [Command("help")]
        [Alias("?")]
        [Remarks("Server Help.")]
        public async Task Help()
        {
            var embed = new EmbedBuilder() { Color = Colours.helpCol };
            
            embed.Title = ("Bruze MPG Help");
            embed.Description = (BotConfig.Load().Prefix + "help new - New Member Help" + "\n" +
                                    BotConfig.Load().Prefix + "help general - General Commands Help" + "\n" +
                                    BotConfig.Load().Prefix + "help admin - Admin Commands Help");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("help new")]
        [Alias("? new")]
        [Remarks("Help for new members.")]
        public async Task HelpNew()
        {
            var embed = new EmbedBuilder() { Color = Colours.helpCol };

            embed.Title = ("Bruze MPG New Member Help");
            embed.Description = (BotConfig.Load().Prefix + "rank add <user|music|programming|graphics> - Used to set your rank to enter the full discord");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("help general")]
        [Alias("? general")]
        [Remarks("Help for general commands.")]
        public async Task HelpGen()
        {
            var embed = new EmbedBuilder() { Color = Colours.helpCol };

            embed.Title = ("Bruze MPG General Help");
            embed.Description = (BotConfig.Load().Prefix + "ping - I like ping pong" + "\n" +
                                    BotConfig.Load().Prefix + "message count - Shows how many messages have been sent in this discord!" + "\n" +
                                    BotConfig.Load().Prefix + "members count - Shows how many members are in this discord!" + "\n" +
                                    BotConfig.Load().Prefix + "help - I think you know this command" + "\n" +
                                    BotConfig.Load().Prefix + "rank add <user|music|programming|graphics> - Used to set your rank" + "\n" +
                                    BotConfig.Load().Prefix + "rank remove <user|music|programming|graphics> - Used to remove the rank");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("help admin")]
        [Alias("? admin")]
        [Remarks("Help for admins.")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task HelpAdmin()
        {
            var embed = new EmbedBuilder() { Color = Colours.helpCol };

            embed.Title = ("Bruze MPG New Member Help");
            embed.Description = (BotConfig.Load().Prefix + "settings - View the current server config settings");

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
