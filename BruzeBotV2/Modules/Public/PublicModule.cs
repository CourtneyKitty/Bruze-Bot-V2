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

        [Command("ranks")]
        public async Task ranks()
        {
            var members = BotConfig.Load().Members;
            var users = RankSaves.Load().userCount;
            var music = RankSaves.Load().musicCount;
            var programming = RankSaves.Load().programmingCount;
            var graphics = RankSaves.Load().graphicsCount;
            var newbs = RankSaves.Load().newMembersCount;

            var embed = new EmbedBuilder() { Color = Colours.generalCol };
            var usersField = new EmbedFieldBuilder() { Name = BotConfig.Load().UserRank + ":", Value = users };
            var musicField = new EmbedFieldBuilder() { Name = BotConfig.Load().MusicRank + ":", Value = music };
            var programmingField = new EmbedFieldBuilder() { Name = BotConfig.Load().ProgrammingRank + ":", Value = programming };
            var graphicsField = new EmbedFieldBuilder() { Name = BotConfig.Load().GraphicsRank + ":", Value = graphics };
            var newbsField = new EmbedFieldBuilder() { Value = "That leaves " +  newbs + " not in any rank yet!"};

            embed.Title = ("Members Count");
            embed.Description = ("There are a total of " + members + " members in the discord, how many in each rank?");

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
