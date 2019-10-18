﻿using Discord;
using Discord.Commands;

namespace TeaBagBot.Core.Factories
{
    public static class CommandServiceConfigFactory
    {
        public static CommandServiceConfig GetDefault()
        {
            return new CommandServiceConfig()
            {
                CaseSensitiveCommands = false,
                LogLevel = LogSeverity.Verbose
            };
        }

        public static CommandServiceConfig GetNew()
        {
            return new CommandServiceConfig();
        }
    }
}