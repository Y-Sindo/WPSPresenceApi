using Azure.Messaging.WebPubSub.Clients;

var hub = "hub1";
var groupName = "group1";
for (var i = 0; i < 5; i++)
{
    var clientAccessUri = "Get a client access uri from Azure Portal";
    var client = new WebPubSubClient(new Uri(clientAccessUri));
    await client.StartAsync();
    await client.JoinGroupAsync(groupName);
}
var connections = PresenceClient.ListConnectionsInGroupAsync(hub, groupName);
await foreach (var connection in connections)
{
    Console.WriteLine($"Connection {connection.ConnectionId} with user name {connection.UserId} in group.");
}
