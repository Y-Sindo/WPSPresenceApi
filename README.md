# WebPubSub Presence Api Sample

This sample shows how to invoke Web PubSub "List Connections In Group" API.

To run the sample, please update necessary information about your resource:
1. Update Web PubSub resource name and access key in the class `PresenceClient`. **Authentication via access key is not recommended in production. Please [Authenticate via Microsoft Entra token](https://learn.microsoft.com/azure/azure-web-pubsub/reference-rest-api-data-plane#authenticate-via-microsoft-entra-token) in production.**
2. Update the `clientAccessUri` in file `WebPubSubClientHelper`. The URI must have a permission to join group named `group1`. You may want to get the URI from Azure Portal: https://learn.microsoft.com/en-us/azure/azure-web-pubsub/howto-generate-client-access-url?tabs=javascript#copy-from-the-azure-portal