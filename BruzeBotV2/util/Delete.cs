using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BruzeBotV2.util
{
    class Delete
    {
        public static async Task DelayDeleteMessage(IUserMessage message, int time = 0)
        {
            var delete = Task.Run(async () =>
            {
                if (time == 0) await Task.Delay(2500);
                else await Task.Delay(time * 1000);

                await message.DeleteAsync();
            });
        }

        public static async Task DelayDeleteError(IMessage error, int time = 0)
        {
            var delete = Task.Run(async () =>
            {
                if (time == 0) await Task.Delay(2500);
                else await Task.Delay(time * 1000);

                await error.DeleteAsync();
            });
        }
    }
}
