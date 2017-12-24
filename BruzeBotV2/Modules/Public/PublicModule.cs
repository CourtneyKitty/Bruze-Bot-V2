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
    public class PublicModule : ModuleBase
    {
        Errors errors = new Errors();

        [Command("ping")]
        public async Task ping()
        {
            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("PING");
            embed.Description = ("PONG");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("bot info")]
        public async Task botInfo()
        {
            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("Bot Info");
            embed.Description = ("Name: " + References.TITLE + "\n" +
                                    "Version: " + References.ID + "\n" +
                                    "Developer: " + References.DEV + "\n" +
                                    "Developer Website: " + References.DEVWEB);

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("messages count")]
        public async Task messagesCount()
        {
            var messages = BotConfig.Load().Messages;

            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("Message Count");
            embed.Description = ("There has been " + messages + " messages since this feature was added!");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("members count")]
        public async Task membersCount()
        {
            var members = BotConfig.Load().Members;

            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("Members Count");
            embed.Description = ("There are " + members + " members in the discord!");

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
