﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using BruzeBotV2.Config;
using System.IO;
using System.Collections.Generic;

namespace BruzeBotV2
{
    public class Program
    {
        public static List<ulong> modRoleID = new List<ulong>();
        public static ulong[] modRoleIDs;
        public static void Main(string[] args) => new Program().Start().GetAwaiter().GetResult();
        private DiscordSocketClient client;
        private CommandHandler handler;

        public async Task Start()
        {
            EnsureBotConfigExists(); // Ensure that the bot configuration json file has been created.

            client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose,
            });

            client.Log += Logger;
            await client.LoginAsync(TokenType.Bot, BotConfig.Load().Token);
            await client.StartAsync();

            var serviceProvider = ConfigureServices();
            handler = new CommandHandler(serviceProvider);
            await handler.ConfigureAsync();

            //Block this program untill it is closed
            await Task.Delay(-1);
        }
        private static Task Logger(LogMessage lmsg)
        {
            var cc = Console.ForegroundColor;
            switch (lmsg.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine($"{DateTime.Now} [{lmsg.Severity,8}] {lmsg.Source}: {lmsg.Message}");
            Console.ForegroundColor = cc;
            return Task.CompletedTask;
        }

        public static void EnsureBotConfigExists()
        {
            if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, "configuration")))
                Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "configuration"));

            string loc = Path.Combine(AppContext.BaseDirectory, "configuration/config.json");

            if (!File.Exists(loc))                              // Check if the configuration file exists.
            {
                var config = new BotConfig();               // Create a new configuration object.

                Console.WriteLine("Please enter the following information to save into your configuration/config.json file");
                Console.Write("Bot Token: ");
                config.Token = Console.ReadLine();
                Console.Write("Bot Prefix: ");
                config.Prefix = Console.ReadLine();
                Console.WriteLine("New Member Rank: ");
                config.NewMemberRank = Console.ReadLine();
                Console.WriteLine("User Rank: ");
                config.UserRank = Console.ReadLine();
                Console.WriteLine("Music Rank: ");
                config.MusicRank = Console.ReadLine();
                Console.WriteLine("Programming Rank: ");
                config.ProgrammingRank = Console.ReadLine();
                Console.WriteLine("Graphics Rank: ");
                config.GraphicsRank = Console.ReadLine();
                config.Messages = 0;
                config.Save();                                 
            }
            Console.WriteLine("Configuration has been loaded");
        }
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddSingleton(client)
                 .AddSingleton(new CommandService(new CommandServiceConfig { CaseSensitiveCommands = false }));
            var provider = new DefaultServiceProviderFactory().CreateServiceProvider(services);

            return provider;
        }
    }
}
