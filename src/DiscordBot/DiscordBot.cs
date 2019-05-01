﻿using DiscordBot.Core;
using DiscordBot.Storage.Exceptions;
using System;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class DiscordBot
    {
        private readonly ILogger logger;
        private readonly Connection connection;
        private readonly CommandHandler commandHandler;

        public DiscordBot(ILogger logger, Connection connection, CommandHandler commandHandler)
        {
            this.logger = logger;
            this.connection = connection;
            this.commandHandler = commandHandler;
        }

        public async Task StartAsync()
        {
            try
            {
                string token = TokenManager.GetToken();
                await connection.ConnectAsync(token);
                await commandHandler.InitializeAsync();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
    }
}
