﻿using System;
using System.Collections.Generic;

namespace Bit.Core.Models
{
    public class TokenRequest
    {
        public string Email { get; set; }
        public string MasterPasswordHash { get; set; }
        public string Token { get; set; }
        public int? Provider { get; set; }

        public IDictionary<string, string> ToIdentityTokenRequest()
        {
            var dict = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", Email },
                { "password", MasterPasswordHash },
                { "scope", "api offline_access" },
                { "client_id", "mobile" }
            };

            if(Token != null && Provider.HasValue)
            {
                dict.Add("TwoFactorToken", Token);
                dict.Add("TwoFactorProvider", Provider.Value.ToString());
            }

            return dict;
        }
    }
}