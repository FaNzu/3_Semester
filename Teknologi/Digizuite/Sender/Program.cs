// See https://aka.ms/new-console-template for more information
using System.Text;
using RabbitMQ.Client;
Random random = new Random();

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "IncommingJobs",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
while (true)
{
    IBasicProperties props = channel.CreateBasicProperties();
    props.Headers = new Dictionary<string, object>
    {
        { "type", random.Next(0,2) }
    };
    string message = Console.ReadLine();
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: string.Empty,
                         routingKey: "IncommingJobs",
                         basicProperties: props,
                         body: body);
    Console.WriteLine($" [x] Sent {message}");
} 