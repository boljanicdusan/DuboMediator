using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Application.Features.Identity
{
    public class JwtSettings
    {
        private static string _key;
        public static string Key 
        {
            get => _key;
            set => _key = string.IsNullOrEmpty(_key) ? value : _key;
        }

        private static string _issuer;
        public static string Issuer 
        {
            get => _issuer;
            set => _issuer = string.IsNullOrEmpty(_issuer) ? value : _issuer;
        }

        private static string _audience;
        public static string Audience 
        {
            get => _audience;
            set => _audience = string.IsNullOrEmpty(_audience) ? value : _audience;
        }

        private static double _durationInMinutes;
        public static double DurationInMinutes 
        {
            get => _durationInMinutes;
            set => _durationInMinutes = _durationInMinutes == default(double) ? value : _durationInMinutes;
        }
    }
}