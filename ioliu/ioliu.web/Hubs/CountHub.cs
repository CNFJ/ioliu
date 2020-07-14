using ioliu.web.Sercers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ioliu.web.Hubs
{
    [Authorize]
    public class CountHub : Hub

    {
        private readonly CountService countService;

        public CountHub(CountService countService)
        {
            this.countService = countService;
        }
        public async Task GetLatestCount( string random)
        {
            int count;
            do{
                count = countService.GetLatestCounbt();
                Thread.Sleep(1000);
                await Clients.All.SendAsync("ReceiveUpdate",count);
            } while (count<10);
            await Clients.All.SendAsync("Finished");
        }
        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var client = Clients.Client(connectionId);
            await client.SendAsync("someFunc", new { });
            await Clients.AllExcept(connectionId).SendAsync("someFunc");
            await Groups.AddToGroupAsync(connectionId, "MyGroup");
            await Groups.RemoveFromGroupAsync(connectionId, "MyGroup");
            await Clients.Groups("MyGroup").SendAsync("someFunc");
        }
    }
}
