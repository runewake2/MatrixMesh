// See https://aka.ms/new-console-template for more information

// The Service Bus client types are safe to cache and use as a singleton for the lifetime
// of the application, which is best practice when messages are being published or read
// regularly.
//
// Create the clients that we'll use for sending and processing messages.
using Azure.Messaging.ServiceBus;

var connectionString = Environment.GetEnvironmentVariable("SERVICE_BUS_QUEUE_PUBLISHER");
var queueName = "matrix-transformation-requests";

var client = new ServiceBusClient(connectionString);
var sender = client.CreateSender(queueName);

// create a batch 
using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

var message = File.ReadAllText("message.txt");

// try adding a message to the batch
if (!messageBatch.TryAddMessage(new ServiceBusMessage(message)))
{
    // if it is too large for the batch
    throw new Exception($"The message is too large to fit in the batch.");
}

try
{
    // Use the producer client to send the batch of messages to the Service Bus topic
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"A batch of messages has been published to the topic.");
}
finally
{
    // Calling DisposeAsync on client types is required to ensure that network
    // resources and other unmanaged objects are properly cleaned up.
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("Press any key to end the application");
Console.ReadKey();