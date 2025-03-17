# WebPubSub Presence Api Sample

This sample shows how to invoke Web PubSub "List Connections In Group" API.

To run the sample, please update necessary information about your resource:
1. Update Web PubSub resource name and access key in the class `PresenceClient`.
2. Update the `clientAccessUri` in file `Program`. The URI must have permission to join group named `group1`. You may want to get the URI from Azure Portal: https://learn.microsoft.com/en-us/azure/azure-web-pubsub/howto-generate-client-access-url?tabs=javascript#copy-from-the-azure-portal