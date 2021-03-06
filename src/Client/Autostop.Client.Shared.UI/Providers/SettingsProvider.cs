﻿using Autostop.Client.Abstraction.Providers;
using Autostop.Common.Shared.Constants;
using Autostop.Common.Shared.Models;
using Conditions;
using Plugin.Settings.Abstractions;

namespace Autostop.Client.Shared.UI.Providers
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly ISettings _settings;

        public SettingsProvider(ISettings settings)
        {
            settings.Requires(nameof(settings)).IsNotNull();

            _settings = settings;
        }

        public Address HomeAddress
        {
            get
            {
                var address = _settings.GetValueOrDefault(Settings.HomeAddress, string.Empty);
                return Deserialize(address);
            }
            set
            {
                var formattedAddress = Serialize(value);
                _settings.AddOrUpdateValue(Settings.HomeAddress, formattedAddress);
            }
        }

        public Address WorkAddress
        {
            get
            {
                var address = _settings.GetValueOrDefault(Settings.WorkAddress, string.Empty);
                return Deserialize(address);
            }
            set
            {
                var formattedAddress = Serialize(value);
                _settings.AddOrUpdateValue(Settings.WorkAddress, formattedAddress);
            }
        }

        private string Serialize(Address value)
        {
            return $"{value.FormattedAddress}|{value.Location.Latitude}|{value.Location.Longitude}";
        }

        private Address Deserialize(string address)
        {
            if (string.IsNullOrEmpty(address))
                return null;

            var splittedAddress = address.Split('|');
            if (splittedAddress.Length != 3)
                return null;

            var formattedAddress = splittedAddress[0];
            var latitude = double.Parse(splittedAddress[1]);
            var longitude = double.Parse(splittedAddress[2]);

            return new Address
            {
                FormattedAddress = formattedAddress,
                Location = new Location(latitude, longitude)
            };
        }
    }
}