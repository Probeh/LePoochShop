using System;
using System.Collections.Generic;
using Core.Shared.Models.Enums;

namespace Core.WebAPI.Extensions
{
    public static partial class Environment
    {
        private static Dictionary<string, Scopes> environments = new Dictionary<string, Scopes>()
            .Append("Development", Scopes.Development)
            .Append("Staging"    , Scopes.Staging    )
            .Append("Production" , Scopes.Production );

        public static Scopes GetScope() =>
            environments[System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")];

    }
}