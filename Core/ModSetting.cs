﻿using BepInEx.Configuration;
using System;
using System.Collections.Generic;



namespace ModPack
{
    public class ModSetting<T> : ModSettingBase
    {
        // Publics
        public T Value
        {
            get => _configEntry.Value;
            set => _configEntry.Value = value;
        }
        public void SetSilently(T value)
        {
            _configEntry.SetField("_typedValue", value);
            _configEntry.ConfigFile.Save();
        }

        // Privates
        private ConfigEntry<T> _configEntry;

        // Constructors
        public ModSetting(string section, string name, T defaultValue = default, AcceptableValueBase acceptableValues = null) : base()
        {
            ConfigDescription description = new ConfigDescription("", acceptableValues, new ConfigurationManagerAttributes());
            _configEntryBase = _configEntry = Tools.ConfigFile.Bind(section, name, defaultValue, description);
            IsVisible = true;
        }

        // Operators
        public static implicit operator T(ModSetting<T> setting)
        => setting.Value;
    }
}