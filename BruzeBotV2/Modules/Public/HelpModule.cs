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
                                    BotConfig.Load().Prefix + "bot info - Displays information about me!" + "\n" +
                                    BotConfig.Load().Prefix + "messages count - Shows how many messages have been sent in this discord!" + "\n" +
                                    BotConfig.Load().Prefix + "members count - Shows how many members are in this discord!" + "\n" +
                                    BotConfig.Load().Prefix + "ranks - Shows how many members are in each rank" + "\n" +
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
            embed.Description = (BotConfig.Load().Prefix + "settings - View the current server config settings" + "\n" +
                                 BotConfig.Load().Prefix + "settings prefix <prefix> - Change the bot prefix" + "\n" +
                                 BotConfig.Load().Prefix + "settings token <token> - Change the bot token (IMPORTANT! DO NOT DO THIS UNLESS REQUIRED)" + "\n" +
                                 BotConfig.Load().Prefix + "settings newmember <rank> - Change the new user rank" + "\n" +
                                 BotConfig.Load().Prefix + "settings userrank <rank> - Change the user rank" + "\n" +
                                 BotConfig.Load().Prefix + "settings musicrank <rank> - Change the music rank" + "\n" +
                                 BotConfig.Load().Prefix + "settings programmingrank <rank> - Change the programming rank" + "\n" +
                                 BotConfig.Load().Prefix + "settings graphicsrank <rank> - Change the graphics rank" + "\n");


            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
