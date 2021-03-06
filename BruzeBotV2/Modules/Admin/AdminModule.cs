﻿using System;
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
            await Context.Message.DeleteAsync();

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

            var message = await Context.Channel.SendMessageAsync("", false, embed);
            await Delete.DelayDeleteEmbed(message, 30);
        }

        [Command("settings token")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsToken(String token = null)
        {
            await Context.Message.DeleteAsync();

            if (token != null)
            {
                BotConfig config = new BotConfig();
                config = Update.UpdateConfig(config);
                config.Token = token;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Token");
                embed.Description = ("Token has been set to " + token + " successfully!");

                var message = await ReplyAsync("", false, embed.Build());
                await Delete.DelayDeleteEmbed(message, 30);
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a token!", Colours.errorCol);
        }

        [Command("settings newmember")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsNewMember(String newmember = null)
        {
            await Context.Message.DeleteAsync();

            if (newmember != null)
            {
                BotConfig config = new BotConfig();
                config = Update.UpdateConfig(config);
                config.NewMemberRank = newmember;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings New Member Rank");
                embed.Description = ("New member rank has been set to " + newmember + " successfully!");
                var message = await ReplyAsync("", false, embed.Build());
                await Delete.DelayDeleteEmbed(message, 30);
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings userrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsUserRank(String userrank = null)
        {
            await Context.Message.DeleteAsync();

            if (userrank != null)
            {
                BotConfig config = new BotConfig();
                config = Update.UpdateConfig(config);
                config.UserRank = userrank;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings User Rank");
                embed.Description = ("User rank has been set to " + userrank + " successfully!");
                var message = await ReplyAsync("", false, embed.Build());
                await Delete.DelayDeleteEmbed(message, 30);
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings musicrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsMusicRank(String rank = null)
        {
            await Context.Message.DeleteAsync();

            if (rank != null)
            {
                BotConfig config = new BotConfig();
                config = Update.UpdateConfig(config);;
                config.MusicRank = rank;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Music Rank");
                embed.Description = ("Music rank has been set to " + rank + " successfully!");
                var message = await ReplyAsync("", false, embed.Build());
                await Delete.DelayDeleteEmbed(message, 30);
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings programmingrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsProgrammingRank(String rank = null)
        {
            await Context.Message.DeleteAsync();

            if (rank != null)
            {
                BotConfig config = new BotConfig();
                config = Update.UpdateConfig(config);
                config.ProgrammingRank = rank;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Programming Rank");
                embed.Description = ("Programming rank has been set to " + rank + " successfully!");
                var message = await ReplyAsync("", false, embed.Build());
                await Delete.DelayDeleteEmbed(message, 30);
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        [Command("settings graphicsrank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SettingsGraphicsRank(String rank = null)
        {
            await Context.Message.DeleteAsync();

            if (rank != null)
            {
                BotConfig config = new BotConfig();
                config = Update.UpdateConfig(config);
                config.GraphicsRank = rank;
                config.Save();

                var embed = new EmbedBuilder() { Color = Colours.adminCol };
                embed.Title = ("Settings Graphics Rank");
                embed.Description = ("Graphics rank has been set to " + rank + " successfully!");
                var message = await ReplyAsync("", false, embed.Build());
                await Delete.DelayDeleteEmbed(message, 30);
            }
            else await errors.sendErrorTemp(Context.Channel, "You must specify a rank!", Colours.errorCol);
        }

        /** Sub Rank Stuff **/
        [Command("subrank create")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task CreateSubRank([Remainder] string title = null)
        {
            await Context.Message.DeleteAsync();

            if (title != null)
            { 
                if (SubRanksSaves.Load().MaxRanks > SubRanksSaves.Load().SubRanks)
                {
                    // Creating object and pushing to file
                    SubRanksSaves SubRanks = new SubRanksSaves();
                    SubRanks.MaxRanks = SubRanksSaves.Load().MaxRanks;
                    for (int i = 0; i < SubRanksSaves.Load().MaxRanks; i++)
                    {
                        SubRanks.Ranks[i] = SubRanksSaves.Load().Ranks[i];
                    }
                    SubRanks.Ranks[SubRanksSaves.Load().SubRanks - 1] = title;
                    SubRanks.SubRanks = SubRanksSaves.Load().SubRanks + 1;
                    SubRanks.Save();

                    // Create Role
                    var perms = new GuildPermissions(false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
                    await Context.Guild.CreateRoleAsync(title, perms, null, false, null);

                    // Success Message
                    var embed = new EmbedBuilder() { Color = Colours.adminCol };
                    embed.Title = "Create Sub Rank";
                    embed.Description = "The sub rank '" + title + "' was created successfully!";
                    var message = await Context.Channel.SendMessageAsync("", false, embed);
                    await Delete.DelayDeleteMessage(message, 30);
                }
                else await errors.sendErrorTemp(Context.Channel, "You have used up all sub ranks!", Colours.errorCol);
            }
            else await errors.sendErrorTemp(Context.Channel, "You need to specify the rank title.", Colours.errorCol);
        }


    }
}
