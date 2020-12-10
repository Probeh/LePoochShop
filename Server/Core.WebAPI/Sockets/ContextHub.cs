using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Core.Shared.Context;

namespace Core.WebAPI.Sockets
{
    public class ContextHub : Hub
    {
        public static Dictionary<string, KeyValuePair<string, List<string>>> Messages =
            // ======================================= //
            /* Dictionary<scope, List<entries>> */
            // ======================================= //
            new Dictionary<string, KeyValuePair<string, List<string>>>();
        public static Dictionary<string, List<string>> Members =
            // ======================================= //
            /* Dictionary<username, List<connectionId>> */
            // ======================================= //
            new Dictionary<string, List<string>>();
        // ======================================= //
        public ContextHub()
        {
            ApplicationData.ContextListener += (target, items, text) =>
            {
                /* TODO: Continue from here... */
            };
        }
        // ======================================= //
        public Task<bool> UserConnection(string username, string connectionId)
        {
            bool isConnected = false;
            // ======================================= //
            if (Members.ContainsKey(username))
                Members[username].Add(connectionId);
            else
            {
                Members.Add(username, new List<string> { connectionId });
                isConnected = true;
            }
            return Task.FromResult(isConnected);
        }
        public Task<bool> UserDisconnection(string username, string connectionId)
        {
            bool isConnected = true;
            // ======================================= //
            if (!Members.ContainsKey(username))
                return Task.FromResult(isConnected);

            Members[username].Remove(connectionId);
            if (Members[username].Count == 0)
            {
                Members.Remove(username);
                isConnected = false;
            }
            Members.Add(username, new List<string> { connectionId });
            isConnected = true;

            return Task.FromResult(isConnected);
        }

    }
}