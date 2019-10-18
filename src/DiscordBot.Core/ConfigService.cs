﻿using TeaBagBot.Core.Entities;
using TeaBagBot.Core.Storage;
using System;

namespace TeaBagBot.Core
{
    public class ConfigService
    {
        private readonly IDataStorage _storage;

        public ConfigService(IDataStorage storage)
        {
            _storage = storage;
        }

        public BotConfig LoadConfig()
        {
            try
            {
                return _storage.RestoreObject<BotConfig>("Config");
            }
            catch (Exception ex)
            {
                throw new ConfigException($"Couldn't load config.", ex);
            }
        }

        public void SaveConfig(BotConfig config)
        {
            try
            {
                _storage.StoreObject(config, "Config");
            }
            catch (Exception ex)
            {
                throw new ConfigException($"Couldn't save config.", ex);
            }
        }
    }
}