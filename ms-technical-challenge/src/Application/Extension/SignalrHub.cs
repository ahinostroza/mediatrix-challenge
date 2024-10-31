namespace SB.TechnicalChallenge.Application;
using Microsoft.AspNetCore.SignalR;

public class SignalrHub : Hub
{
    public async Task NewMessage(string user, string message)
    {
        await Clients.All.SendAsync("messageReceived", user, message);
    }

    public async Task SendMessageToClient(string connectionId, string user, string message)
    {
        await Clients.Client(connectionId).SendAsync("messageReceived", user, message);
    }

    public override async Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        // Puedes guardar el connectionId en una base de datos o en una lista para su uso posterior
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        // Eliminar el connectionId de la base de datos o lista si es necesario
        await base.OnDisconnectedAsync(exception);
    }
}
