using Azure.Messaging.WebPubSub.Clients;

public static class WebPubSubConnectionsHelper
{
    public static async Task ConnectAsync(string groupName)
    {
        for (var i = 0; i < 5; i++)
        {
            var clientAccessUri = "Get a client access uri from Azure Portal";
            var client = new WebPubSubClient(new Uri(clientAccessUri));
            await client.StartAsync();
            await client.JoinGroupAsync(groupName);
        }
    }
}