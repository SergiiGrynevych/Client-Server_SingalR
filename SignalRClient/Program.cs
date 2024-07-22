using Microsoft.AspNetCore.SignalR.Client;

HubConnection HubConnection = 
    new HubConnectionBuilder()
    .WithUrl("https://localhost:7024/notification")
    .Build();

HubConnection.On<string, string>("ReceiveMessage", (message, userName) => Console.WriteLine($"Message from {userName}: {message}"));


await HubConnection.StartAsync();
bool isExit = false;

string connectionID = HubConnection.ConnectionId;

Console.WriteLine($"Your connID: {connectionID} Enter your Name");
string userName = Console.ReadLine();

Console.WriteLine("Chat with User:");
string userNameToChat = Console.ReadLine();

while (!isExit)
{
    var message = Console.ReadLine();

    if (message != "exit" && message != "new")
        await HubConnection.SendAsync("SendMessage", message, userName, userNameToChat);
    else if(message == "new")
    {
        Console.WriteLine("Enter id to send message:");
        userNameToChat = Console.ReadLine();
        Console.WriteLine("Enter message:");
        message = Console.ReadLine();
        await HubConnection.SendAsync("SendMessage", message, userName, userNameToChat);
    }
    else
        isExit = true;
}

Console.ReadLine();