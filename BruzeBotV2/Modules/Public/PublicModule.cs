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

        [Command("message count")]
        public async Task messageCount()
        {
            var messages = BotConfig.Load().Messages;

            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("Message Count");
            embed.Description = ("There has been " + messages + " messages since this feature was added!");

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
