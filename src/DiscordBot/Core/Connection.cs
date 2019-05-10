﻿using Discord;
using Discord.WebSocket;
using DiscordBot.Core.Logging;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Core
{
    public class Connection
    {
        private readonly DiscordLogger logger;
        private readonly DiscordSocketClient client;

        public Connection(DiscordLogger logger, DiscordSocketClient client)
        {
            this.logger = logger;
            this.client = client;
        }

        public async Task ConnectAsync(string token)
        {
            client.Log += logger.LogAsync;

            try
            {
                await client.LoginAsync(TokenType.Bot, token);
                await client.StartAsync();
            }
            catch (Exception ex)
            {
                throw new ConnectionException("Something went wrong while trying to connect.", ex);
            }
        }

        public async Task DisconnectAsync()
        {
            client.Log -= logger.LogAsync;

            await client.LogoutAsync();
            await client.StopAsync();
        }
    }
}
