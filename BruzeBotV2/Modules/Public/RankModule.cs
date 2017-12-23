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

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                }

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

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                }

                var message = await ReplyAsync("@" + Context.User.Id + " you were given the music rank successfully!");

                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("programming"))
            {
                var user = Context.User;

                var config = new BotConfig();
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().ProgrammingRank);
                await (user as IGuildUser).AddRoleAsync(role);

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                }

                var message = await ReplyAsync("@" + Context.User.Id + " you were given the programming rank successfully!");

                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("graphics"))
            {
                var user = Context.User;

                var config = new BotConfig();
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().GraphicsRank);
                await (user as IGuildUser).AddRoleAsync(role);

                if (userName.Roles.Contains(newMemberRole))
                {
                    var remrole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NewMemberRank);
                    await (user as IGuildUser).RemoveRoleAsync(remrole);
                }

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
        [Remarks("Wipes the rank to the user.")]
        public async Task RankWipe(string rank)
        {
            var chan = Context.Channel;
            var user = Context.User;
            var userName = user as SocketGuildUser;

            if (rank.ToLower().Equals("user"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().UserRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("music"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().MusicRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("programming"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().ProgrammingRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else if (rank.ToLower().Equals("graphics"))
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().GraphicsRank);
                await (user as IGuildUser).RemoveRoleAsync(role);

                var message = await ReplyAsync("@" + Context.User.Id + " you was removed from the " + rank.ToLower() + " rank successfully!");
                await Context.Message.DeleteAsync();
            }
            else await errors.sendErrorTemp(chan, "", Colours.errorCol);
        }
    }
}
