using Microsoft.AspNetCore.SignalR;

namespace Server_SingalR.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessage(string message, string userName, string receiverConnectionId)
        {
            return Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", message, userName);
        }
        public string GetConnectionID() => Context.ConnectionId;
    }
}
