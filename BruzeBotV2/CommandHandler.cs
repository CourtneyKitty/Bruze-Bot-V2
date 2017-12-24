using System.Threading.Tasks;
using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using BruzeBotV2.Config;
using BruzeBotV2.util;

namespace BruzeBotV2
{
    public class CommandHandler : ModuleBase
    {
        private CommandService commands;
        private DiscordSocketClient bot;
        private IServiceProvider map;

        public CommandHandler(IServiceProvider provider)
        {
            map = provider;
            bot = map.GetService<DiscordSocketClient>();
            bot.UserJoined += AnnounceUserJoined;
            bot.UserLeft += AnnounceLeftUser;
            bot.Ready += SetGame;
            //Send user message to get handled
            bot.MessageReceived += HandleCommand;
            commands = map.GetService<CommandService>();
            bot.MessageReceived += messageCount;
        }

        public async Task AnnounceLeftUser(SocketGuildUser user) {
            BotConfig config = new BotConfig();
            config.Prefix = BotConfig.Load().Prefix;
            config.Token = BotConfig.Load().Token;
            config.NewMemberRank = BotConfig.Load().NewMemberRank;
            config.UserRank = BotConfig.Load().UserRank;
            config.MusicRank = BotConfig.Load().MusicRank;
            config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
            config.GraphicsRank = BotConfig.Load().GraphicsRank;
            config.welcomeChannelId = BotConfig.Load().welcomeChannelId;
            config.Messages = BotConfig.Load().Messages;
            config.Members = BotConfig.Load().Members - 1;
            config.Save();

            var ranks = new RankSaves();
            ranks.newMembersCount = RankSaves.Load().newMembersCount - 1;
            ranks.userCount = RankSaves.Load().userCount;
            ranks.musicCount = RankSaves.Load().musicCount;
            ranks.programmingCount = RankSaves.Load().programmingCount;
            ranks.graphicsCount = RankSaves.Load().graphicsCount;
            ranks.Save();
        }

        public async Task AnnounceUserJoined(SocketGuildUser user)
        {
            BotConfig config = new BotConfig();
            config.Prefix = BotConfig.Load().Prefix;
            config.Token = BotConfig.Load().Token;
            config.NewMemberRank = BotConfig.Load().NewMemberRank;
            config.UserRank = BotConfig.Load().UserRank;
            config.MusicRank = BotConfig.Load().MusicRank;
            config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
            config.GraphicsRank = BotConfig.Load().GraphicsRank;
            config.welcomeChannelId = BotConfig.Load().welcomeChannelId;
            config.Messages = BotConfig.Load().Messages;
            config.Members = BotConfig.Load().Members + 1;
            config.Save();

            var ranks = new RankSaves();
            ranks.newMembersCount = RankSaves.Load().newMembersCount + 1;
            ranks.userCount = RankSaves.Load().userCount;
            ranks.musicCount = RankSaves.Load().musicCount;
            ranks.programmingCount = RankSaves.Load().programmingCount;
            ranks.graphicsCount = RankSaves.Load().graphicsCount;
            ranks.Save();

            var newMemberRank = BotConfig.Load().NewMemberRank;
            var role = user.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == newMemberRank);
            await (user as IGuildUser).AddRoleAsync(role);

            var welcomeChannel = Context.Guild.GetChannelAsync(BotConfig.Load().welcomeChannelId);
            if (welcomeChannel != null)
            {
                var message = await Context.Channel.SendMessageAsync("Hey " + Context.User.Mention + ", read the above post, read the rules and then head into #bot-commands and get your roles to enter the full discord!");
                await Delete.DelayDeleteMessage(message, 60);
            }
            else await errors.sendErrorTemp(Context.Channel, "Welcome channel not found, make sure the config.json is set up correctly!", Colours.errorCol);
        }


        public async Task SetGame()
        {
            await bot.SetGameAsync(BotConfig.Load().Prefix + "help");
        }

        Errors errors = new Errors();
        [Command("settings prefix")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsPrefix(String prefix = null)
        {
            if (prefix != null)
            {
                BotConfig config = new BotConfig();

                config.Prefix = prefix;
                config.Token = BotConfig.Load().Token;
                config.NewMemberRank = BotConfig.Load().NewMemberRank;
                config.UserRank = BotConfig.Load().UserRank;
                config.MusicRank = BotConfig.Load().MusicRank;
                config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
                config.GraphicsRank = BotConfig.Load().GraphicsRank;
                config.welcomeChannelId = BotConfig.Load().welcomeChannelId;
                config.Messages = BotConfig.Load().Messages;
                config.Members = BotConfig.Load().Members;
                config.Save();

                await bot.SetGameAsync(BotConfig.Load().Prefix + "help");

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Prefix");
                embed.Description = ("Prefix has been set to " + prefix + " successfully!");
                await ReplyAsync("", false, embed.Build());
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a prefix!", Colours.errorCol);
        }

        public async Task ConfigureAsync()
        {
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        public async Task messageCount(SocketMessage msg)
        {
            BotConfig config = new BotConfig();
            config.Prefix = BotConfig.Load().Prefix;
            config.Token = BotConfig.Load().Token;
            config.NewMemberRank = BotConfig.Load().NewMemberRank;
            config.UserRank = BotConfig.Load().UserRank;
            config.MusicRank = BotConfig.Load().MusicRank;
            config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
            config.GraphicsRank = BotConfig.Load().GraphicsRank;
            config.welcomeChannelId = BotConfig.Load().welcomeChannelId;
            config.Messages = BotConfig.Load().Messages + 1;
            config.Members = BotConfig.Load().Members;
            config.Save();
        }

        public async Task HandleCommand(SocketMessage pMsg)
        {
            //Don't handle the command if it is a system message
            var message = pMsg as SocketUserMessage;
            if (message == null)
                return;
            var context = new SocketCommandContext(bot, message);

            //Mark where the prefix ends and the command begins
            int argPos = 0;
            //Determine if the message has a valid prefix, adjust argPos
            if (message.HasStringPrefix(BotConfig.Load().Prefix, ref argPos))
            {
                if (message.Author.IsBot)
                    return;
                //Execute the command, store the result
                var result = await commands.ExecuteAsync(context, argPos, map);

                //If the command failed, notify the user
                if (!result.IsSuccess && result.ErrorReason != "Unknown command.")
                    await errors.sendErrorTemp(pMsg.Channel, result.ErrorReason, Colours.errorCol);
            }
        }
    }
}