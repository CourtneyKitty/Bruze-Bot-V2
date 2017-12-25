using Discord.Commands;
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
        Success success = new Success();

        [Command("rank add")]
        [Remarks("Assigns the rank to the user.")]
        public async Task Rank(string rank)
        {
            var chan = Context.Channel;
            var userName = Context.User as SocketGuildUser;
            var newMemberRole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
            await Context.Message.DeleteAsync();
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

                await success.sendSuccessTemp(Context.Channel, "Add Rank", "@" + Context.User.Id + " you was added to the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
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

                await success.sendSuccessTemp(Context.Channel, "Add Rank", "@" + Context.User.Id + " you was added to the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
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

                await success.sendSuccessTemp(Context.Channel, "Add Rank", "@" + Context.User.Id + " you was added to the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
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

                await success.sendSuccessTemp(Context.Channel, "Add Rank", "@" + Context.User.Id + " you was added to the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
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
            await Context.Message.DeleteAsync();

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

                await success.sendSuccessTemp(Context.Channel, "Remove Rank", "@" + Context.User.Id + " you was removed from the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
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

                await success.sendSuccessTemp(Context.Channel, "Remove Rank", "@" + Context.User.Id + " you was removed from the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
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

                await success.sendSuccessTemp(Context.Channel, "Remove Rank", "@" + Context.User.Id + " you was removed from the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
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
                
                await success.sendSuccessTemp(Context.Channel, "Remove Rank", "@" + Context.User.Id + " you was removed from the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
            }
            else await errors.sendErrorTemp(chan, "Parameter not recognised. Parameters are as follows user, music, programming or graphics", Colours.errorCol);
        }

        [Command("ranks")]
        public async Task ranks()
        {
            await Context.Message.DeleteAsync();
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

        /** Sub Ranks **/

        [Command("subrank add")]
        public async Task AddSubRank([Remainder] string rank = null)
        {
            await Context.Message.DeleteAsync();
            if (rank != null)
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == rank);

                if (role != null)
                {
                    await (Context.User as IGuildUser).AddRoleAsync(role);
                    await success.sendSuccessTemp(Context.Channel, "Add Sub Rank", "@" + Context.User.Id + " you was added to the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
                }
                else await errors.sendErrorTemp(Context.Channel, "You must enter a valid rank! I am case sensitive!", Colours.errorCol);
            }
            else await errors.sendErrorTemp(Context.Channel, "Please enter a sub rank.", Colours.errorCol);
        }

        [Command("subrank remove")]
        public async Task RemoveSubRank([Remainder] string rank = null)
        {
            await Context.Message.DeleteAsync();
            if (rank != null)
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == rank);

                if (role != null)
                {
                    await (Context.User as IGuildUser).RemoveRoleAsync(role);
                    await success.sendSuccessTemp(Context.Channel, "Remove Sub Rank", "@" + Context.User.Id + " you was removed from the '" + rank.ToLower() + "' sub rank successfully!", Colours.generalCol);
                }
                else await errors.sendErrorTemp(Context.Channel, "You must enter a valid rank! I am case sensitive!", Colours.errorCol);
            }
            else await errors.sendErrorTemp(Context.Channel, "Please enter a sub rank.", Colours.errorCol);
        }

        [Command("subranks")]
        public async Task SubRanks()
        {
            await Context.Message.DeleteAsync();
            var embed = new EmbedBuilder() { Color = Colours.helpCol };

            embed.Title = ("Sub Ranks");
            string desc = "Type " + BotConfig.Load().Prefix + "subrank add <rank> to be added to the sub ranks!";

            if (SubRanksSaves.Load().SubRanks > 1)
            {
                for (int i = 0; i < SubRanksSaves.Load().SubRanks; i++)
                {
                    desc = desc + "\n";
                    desc = desc + SubRanksSaves.Load().Ranks[i];
                }
            }
            else desc = desc + "\n- Sub Ranks are to be added soon!";

            embed.Description = (desc);

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
