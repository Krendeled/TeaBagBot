﻿using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot.Core
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient client;
        private readonly CommandService service;

        public CommandHandler(DiscordSocketClient client, CommandService service)
        {
            this.client = client;
            this.service = service;
        }

        public async Task InitializeAsync()
        {
            await service.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            client.MessageReceived += HandleMessage;
        }

        private async Task HandleMessage(SocketMessage socketMsg)
        {
            var msg = socketMsg as SocketUserMessage;
            if (msg == null)
                return;
            var context = new SocketCommandContext(client, msg);

            int argPos = 0;
        }
    }
}