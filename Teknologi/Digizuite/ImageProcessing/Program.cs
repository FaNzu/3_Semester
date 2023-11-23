﻿using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("ImageProcessing unit");
var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "JobsImages",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received image {message}");
};
channel.BasicConsume(queue: "JobsImages",
                     autoAck: true,
                     consumer: consumer);
Console.ReadLine();