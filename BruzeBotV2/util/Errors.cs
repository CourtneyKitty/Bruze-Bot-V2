using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace BruzeBotV2.util
{
    class Errors : ModuleBase<SocketCommandContext>
    {
        public async Task sendError(ISocketMessageChannel channel, string error, Color color)
        {
            //Console.WriteLine("ERROR: " + error);

            var embed = new EmbedBuilder() { Color = color };
            embed.Title = ("ERROR");
            embed.Description = (error);
            await channel.SendMessageAsync("", false, embed);

            Console.WriteLine("Error message was sent to the user.");

        }

        public async Task sendError(IMessageChannel channel, string error, Color color)
        {
            //Console.WriteLine("ERROR: " + error);

            var embed = new EmbedBuilder() { Color = color };
            embed.Title = ("ERROR");
            embed.Description = (error);
            await channel.SendMessageAsync("", false, embed);

            Console.WriteLine("Error message was sent to the user.");

        }

        public async Task sendErrorTemp(ISocketMessageChannel channel, string error, Color color)
        {
            //Console.WriteLine("ERROR: " + error);

            var embed = new EmbedBuilder() { Color = color };
            embed.Title = ("ERROR");
            embed.Description = (error);
            var errorMessage = await channel.SendMessageAsync("", false, embed);
            Console.WriteLine("Error message was sent to the user.");

            await Delete.DelayDeleteEmbed(errorMessage, 30);
            Console.WriteLine("The error message that was sent to the user is now deleted.");
        }

        public async Task sendErrorTemp(IMessageChannel channel, string error, Color color)
        {
            //Console.WriteLine("ERROR: " + error);

            var embed = new EmbedBuilder() { Color = color };
            embed.Title = ("ERROR");
            embed.Description = (error);
            var errorMessage = await channel.SendMessageAsync("", false, embed);
            Console.WriteLine("Error message was sent to the user.");

            await Delete.DelayDeleteEmbed(errorMessage, 30);
            Console.WriteLine("The error message that was sent to the user is now deleted.");
        }
    }
}
