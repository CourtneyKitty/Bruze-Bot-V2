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
namespace BruzeBotV2.Modules.Admin
{
    public class AdminModule : ModuleBase
    {
        Errors errors = new Errors();

        [Command("settings")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Settings()
        {
            string serverName = "Bruze MPG Community";
            string token = BotConfig.Load().Token;
            string prefix = BotConfig.Load().Prefix;
            string newUserRank = BotConfig.Load().NewMemberRank;
            string userRank = BotConfig.Load().UserRank;
            string musicRank = BotConfig.Load().MusicRank;
            string programmingRank = BotConfig.Load().ProgrammingRank;
            string graphicsRank = BotConfig.Load().GraphicsRank;

            var embed = new EmbedBuilder() { Color = Colours.adminCol };
            var serverNameField = new EmbedFieldBuilder() { Name = "Server Name", Value = serverName };
            var tokenField = new EmbedFieldBuilder() { Name = "Bot Token", Value = token, IsInline = true };
            var prefixField = new EmbedFieldBuilder() { Name = "Bot Prefix", Value = prefix, IsInline = true };
            var newUserField = new EmbedFieldBuilder() { Name = "New User Rank", Value = newUserRank, IsInline = true };
            var userField = new EmbedFieldBuilder() { Name = "User Rank", Value = userRank, IsInline = true };
            var musicField = new EmbedFieldBuilder() { Name = "Music Rank", Value = musicRank, IsInline = true };
            var programmingField = new EmbedFieldBuilder() { Name = "Programming Rank", Value = programmingRank, IsInline = true };
            var graphicsField = new EmbedFieldBuilder() { Name = "Graphics Rank", Value = graphicsRank, IsInline = true };

            string lol = "---------------------------------------------------------------------------------------------------";
            string lol1 = "-------------------------------------------------------------------------------------------------";
            var title1 = new EmbedFieldBuilder() { Name = lol, Value = lol1 };
            var title2 = new EmbedFieldBuilder() { Name = lol, Value = lol1 };
            var title3 = new EmbedFieldBuilder() { Name = lol, Value = lol1 };

            embed.Title = ("Current Server Settings");
            embed.Description = ("Here are all the current server settings.");
            embed.AddField(serverNameField);
            embed.AddField(title1);
            embed.AddField(tokenField);
            embed.AddField(prefixField);
            embed.AddField(title2);
            embed.AddField(newUserField);
            embed.AddField(userField);
            embed.AddField(title3);
            embed.AddField(musicField);
            embed.AddField(programmingField);
            embed.AddField(graphicsField);

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("settings token")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsToken(String token = null)
        {
            if (token != null)
            {
                BotConfig config = new BotConfig();

                config.Prefix = BotConfig.Load().Prefix;
                config.Token = token;
                config.NewMemberRank = BotConfig.Load().NewMemberRank;
                config.UserRank = BotConfig.Load().UserRank;
                config.MusicRank = BotConfig.Load().MusicRank;
                config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
                config.GraphicsRank = BotConfig.Load().GraphicsRank;
                config.Messages = BotConfig.Load().Messages;
                config.Members = BotConfig.Load().Members;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Token");
                embed.Description = ("Token has been set to " + token + " successfully!");
                await ReplyAsync("", false, embed.Build());
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a token!", Colours.errorCol);
        }

        [Command("settings newmember")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsNewMember(String newmember = null)
        {
            if (newmember != null)
            {
                BotConfig config = new BotConfig();

                config.Prefix = BotConfig.Load().Prefix;
                config.Token = BotConfig.Load().Token;
                config.NewMemberRank = newmember;
                config.UserRank = BotConfig.Load().UserRank;
                config.MusicRank = BotConfig.Load().MusicRank;
                config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
                config.GraphicsRank = BotConfig.Load().GraphicsRank;
                config.Messages = BotConfig.Load().Messages;
                config.Members = BotConfig.Load().Members;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings New Member Rank");
                embed.Description = ("New member rank has been set to " + newmember + " successfully!");
                await ReplyAsync("", false, embed.Build());
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings userrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsUserRank(String userrank = null)
        {
            if (userrank != null)
            {
                BotConfig config = new BotConfig();

                config.Prefix = BotConfig.Load().Prefix;
                config.Token = BotConfig.Load().Token;
                config.NewMemberRank = BotConfig.Load().NewMemberRank;
                config.UserRank = userrank;
                config.MusicRank = BotConfig.Load().MusicRank;
                config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
                config.GraphicsRank = BotConfig.Load().GraphicsRank;
                config.Messages = BotConfig.Load().Messages;
                config.Members = BotConfig.Load().Members;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings User Rank");
                embed.Description = ("User rank has been set to " + userrank + " successfully!");
                await ReplyAsync("", false, embed.Build());
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings musicrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsMusicRank(String rank = null)
        {
            if (rank != null)
            {
                BotConfig config = new BotConfig();

                config.Prefix = BotConfig.Load().Prefix;
                config.Token = BotConfig.Load().Token;
                config.NewMemberRank = BotConfig.Load().NewMemberRank;
                config.UserRank = BotConfig.Load().UserRank;
                config.MusicRank = rank;
                config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
                config.GraphicsRank = BotConfig.Load().GraphicsRank;
                config.Messages = BotConfig.Load().Messages;
                config.Members = BotConfig.Load().Members;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Music Rank");
                embed.Description = ("Music rank has been set to " + rank + " successfully!");
                await ReplyAsync("", false, embed.Build());
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings programmingrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsProgrammingRank(String rank = null)
        {
            if (rank != null)
            {
                BotConfig config = new BotConfig();

                config.Prefix = BotConfig.Load().Prefix;
                config.Token = BotConfig.Load().Token;
                config.NewMemberRank = BotConfig.Load().NewMemberRank;
                config.UserRank = BotConfig.Load().UserRank;
                config.MusicRank = BotConfig.Load().MusicRank;
                config.ProgrammingRank = rank;
                config.GraphicsRank = BotConfig.Load().GraphicsRank;
                config.Messages = BotConfig.Load().Messages;
                config.Members = BotConfig.Load().Members;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Programming Rank");
                embed.Description = ("Programming rank has been set to " + rank + " successfully!");
                await ReplyAsync("", false, embed.Build());
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings graphicsrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsGraphicsRank(String rank = null)
        {
            if (rank != null)
            {
                BotConfig config = new BotConfig();

                config.Prefix = BotConfig.Load().Prefix;
                config.Token = BotConfig.Load().Token;
                config.NewMemberRank = BotConfig.Load().NewMemberRank;
                config.UserRank = BotConfig.Load().UserRank;
                config.MusicRank = BotConfig.Load().MusicRank;
                config.ProgrammingRank = BotConfig.Load().ProgrammingRank;
                config.GraphicsRank = rank;
                config.Messages = BotConfig.Load().Messages;
                config.Members = BotConfig.Load().Members;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Graphics Rank");
                embed.Description = ("Graphics rank has been set to " + rank + " successfully!");
                await ReplyAsync("", false, embed.Build());
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }
    }
}
