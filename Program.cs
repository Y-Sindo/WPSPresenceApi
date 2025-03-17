
var hub = "hub1";
var groupName = "group1";

// Create some Web PubSub connections and join the group.
await WebPubSubConnectionsHelper.ConnectAsync(groupName);

// List connections in the group.
var connections = RestApiClient.ListConnectionsInGroupAsync(hub, groupName);
await foreach (var connection in connections)
{
    Console.WriteLine($"Connection {connection.ConnectionId} with user name {connection.UserId} in group.");
}
