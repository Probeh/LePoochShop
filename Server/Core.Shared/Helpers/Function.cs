using System.Collections.Generic;

namespace Core.Shared.Helpers
{
    // ======================================= //
    public delegate T_Value Function<T_Key, T_Value>(T_Key key);
    public delegate T_Value Function<T_Value>(string key, string value);
    // ======================================= //
}