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
            await Context.Message.DeleteAsync();

            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("PING");
            embed.Description = ("PONG");

            var message = await Context.Channel.SendMessageAsync("", false, embed);
            await Delete.DelayDeleteEmbed(message, 30);
        }

        [Command("bot info")]
        public async Task botInfo()
        {
            await Context.Message.DeleteAsync();

            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("Bot Info");
            embed.Description = ("Name: " + References.TITLE + "\n" +
                                    "Version: " + References.ID + "\n" +
                                    "Developer: " + References.DEV + "\n" +
                                    "Developer Website: " + References.DEVWEB);

            var message = await Context.Channel.SendMessageAsync("", false, embed);
            await Delete.DelayDeleteEmbed(message, 30);
        }

        [Command("messages count")]
        public async Task messagesCount()
        {
            await Context.Message.DeleteAsync();
            var messages = BotConfig.Load().Messages;

            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("Message Count");
            embed.Description = ("There has been " + messages + " messages since this feature was added!");

            var message = await Context.Channel.SendMessageAsync("", false, embed);
            await Delete.DelayDeleteEmbed(message, 30);
        }

        [Command("members count")]
        public async Task membersCount()
        {
            await Context.Message.DeleteAsync();
            var members = BotConfig.Load().Members;

            var embed = new EmbedBuilder() { Color = Colours.generalCol };

            embed.Title = ("Members Count");
            embed.Description = ("There are " + members + " members in the discord!");

            var message = await Context.Channel.SendMessageAsync("", false, embed);
            await Delete.DelayDeleteEmbed(message, 30);
        }
    }
}
