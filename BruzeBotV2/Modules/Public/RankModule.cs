﻿using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System.Threading.Tasks;
using BruzeBotV2.Config;
using System.Linq;
using BruzeBotV2.util;

namespace BruzeBotV2.Modules.Public
{
    public class RankModule : ModuleBase
    {
        Errors errors = new Errors();

        [Command("rank add")]
        [Remarks("Assigns the rank to the user.")]
        public async Task Rank(string rank)
        {
            var chan = Context.Channel;
            var userName = Context.User as SocketGuildUser;
            var newMemberRole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);

            if (rank.ToLower().Equals("user"))
            {
                var user = Context.User;

                var config = new BotConfig();
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().UserRank);
                await (user as IGuildUser).AddRoleAsync(role);

                var ranks = new RankSaves();
                
                ranks.userCount = RankSaves.Load().userCount + 1;
                ranks.musicCount = RankSaves.Load().musicCount;
                ranks.programmingCount = RankSaves.Load().programmingCount;
                ranks.graphicsCount = RankSaves.Load().graphicsCount;

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                    ranks.newMembersCount = RankSaves.Load().newMembersCount - 1;
                }
                else ranks.newMembersCount = RankSaves.Load().newMembersCount;

                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you were given the user rank successfully!");
                //await Delete.DelayDeleteMessage(message, 10);

                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("music"))
            {
                var user = Context.User;
                var config = new BotConfig();
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().MusicRank);
                await (user as IGuildUser).AddRoleAsync(role);

                var ranks = new RankSaves();
                ranks.userCount = RankSaves.Load().userCount;
                ranks.musicCount = RankSaves.Load().musicCount + 1;
                ranks.programmingCount = RankSaves.Load().programmingCount;
                ranks.graphicsCount = RankSaves.Load().graphicsCount;

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                    ranks.newMembersCount = RankSaves.Load().newMembersCount - 1;
                }
                else ranks.newMembersCount = RankSaves.Load().newMembersCount;

                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you were given the music rank successfully!");

                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("programming"))
            {
                var user = Context.User;

                var config = new BotConfig();
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().ProgrammingRank);
                await (user as IGuildUser).AddRoleAsync(role);

                var ranks = new RankSaves();
                ranks.userCount = RankSaves.Load().userCount;
                ranks.musicCount = RankSaves.Load().musicCount;
                ranks.programmingCount = RankSaves.Load().programmingCount + 1;
                ranks.graphicsCount = RankSaves.Load().graphicsCount;

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                    ranks.newMembersCount = RankSaves.Load().newMembersCount - 1;
                }
                else ranks.newMembersCount = RankSaves.Load().newMembersCount;

                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you were given the programming rank successfully!");

                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("graphics"))
            {
                var user = Context.User;

                var config = new BotConfig();
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().GraphicsRank);
                await (user as IGuildUser).AddRoleAsync(role);

                var ranks = new RankSaves();
                ranks.userCount = RankSaves.Load().userCount;
                ranks.musicCount = RankSaves.Load().musicCount;
                ranks.programmingCount = RankSaves.Load().programmingCount;
                ranks.graphicsCount = RankSaves.Load().graphicsCount + 1;

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                    ranks.newMembersCount = RankSaves.Load().newMembersCount - 1;
                }
                else ranks.newMembersCount = RankSaves.Load().newMembersCount;

                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you were given the graphics rank successfully!");

                await Context.Message.DeleteAsync();
            }
            else
            {
                await Context.Message.DeleteAsync();
                await errors.sendErrorTemp(chan, "You need to choose one of the listed roles!", Colours.errorCol);
            }
        }

        [Command("rank remove")]
        [Remarks("Removes the rank to the user.")]
        public async Task RankRemove(string rank)
        {
            var chan = Context.Channel;
            var user = Context.User;
            var userName = user as SocketGuildUser;

            if (rank.ToLower().Equals("user"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().UserRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var ranks = new RankSaves();
                ranks.userCount = RankSaves.Load().userCount - 1;
                ranks.musicCount = RankSaves.Load().musicCount;
                ranks.programmingCount = RankSaves.Load().programmingCount;
                ranks.graphicsCount = RankSaves.Load().graphicsCount;
                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("music"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().MusicRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var ranks = new RankSaves();
                ranks.userCount = RankSaves.Load().userCount;
                ranks.musicCount = RankSaves.Load().musicCount - 1;
                ranks.programmingCount = RankSaves.Load().programmingCount;
                ranks.graphicsCount = RankSaves.Load().graphicsCount;
                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("programming"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().ProgrammingRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var ranks = new RankSaves();
                ranks.userCount = RankSaves.Load().userCount;
                ranks.musicCount = RankSaves.Load().musicCount;
                ranks.programmingCount = RankSaves.Load().programmingCount - 1;
                ranks.graphicsCount = RankSaves.Load().graphicsCount;
                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("graphics"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().GraphicsRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var ranks = new RankSaves();
                ranks.userCount = RankSaves.Load().userCount;
                ranks.musicCount = RankSaves.Load().musicCount;
                ranks.programmingCount = RankSaves.Load().programmingCount;
                ranks.graphicsCount = RankSaves.Load().graphicsCount - 1;
                ranks.Save();

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else await errors.sendErrorTemp(chan, "Parameter not recognised. Parameters are as follows user, music, programming or graphics", Colours.errorCol);
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
            var usersField = new EmbedFieldBuilder() { Name = BotConfig.Load().UserRank.ToString() + ":", Value = users };
            var musicField = new EmbedFieldBuilder() { Name = BotConfig.Load().MusicRank.ToString() + ":", Value = music };
            var programmingField = new EmbedFieldBuilder() { Name = BotConfig.Load().ProgrammingRank.ToString() + ":", Value = programming };
            var graphicsField = new EmbedFieldBuilder() { Name = BotConfig.Load().GraphicsRank.ToString() + ":", Value = graphics };
            var newbsField = new EmbedFieldBuilder() { Name = "New", Value = "That leaves " + newbs.ToString() + " not in any rank yet!" };

            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };

            embed.Title = ("Members Count");
            embed.Description = ("There are a total of " + members + " members in the discord, how many in each rank?");
            embed.AddField(usersField);
            embed.AddField(musicField);
            embed.AddField(programmingField);
            embed.AddField(graphicsField);
            embed.AddField(newbsField);
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
