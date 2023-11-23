using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "IncommingJobs",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
channel.QueueDeclare(queue: "JobsImages",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
channel.QueueDeclare(queue: "JobsVideo",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();

    var types = (int)ea.BasicProperties.Headers["type"];
    string routingkey = types switch
    {
        0 => "JobsImages",
        1 => "JobsVideo"
    };
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}, which is a {routingkey}");
    //var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: string.Empty,
                         routingKey: routingkey,
                         basicProperties: null,
                         body: body);
};
channel.BasicConsume(queue: "IncommingJobs",
                     autoAck: true,
                     consumer: consumer);


Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();