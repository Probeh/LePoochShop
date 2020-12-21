using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Core.WebAPI.Sockets
{
    public class ContextHub : Hub
    {
        // ======================================= //
        public ContextHub() { }
        // ======================================= //
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        // ======================================= //
    }
}