using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMq.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            //factory.Uri = "amqp://gut:1qaz@WSX@hostName:port/vhost";
            factory.HostName = "192.168.1.102";
            factory.UserName = "gut";
            factory.Password = "1qaz@WSX";
            factory.VirtualHost = "gut_mq";
            factory.Port = 5672;
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                   // bool durable = true;

                    channel.ExchangeDeclare("X1", ExchangeType.Direct);

                    //channel.QueueDeclare("task_queue", durable, false, false, null);
                    //channel.QueueDeclare("task_queue2", durable, false, false, null);
                    //channel.QueueBind("task_queue", "X1", "K1");
                    //channel.QueueBind("task_queue2", "X1", "K1");

                    string message = GetMessage(args);
                    var properties = channel.CreateBasicProperties();
                    properties.SetPersistent(true);
                    properties.DeliveryMode = 2;


                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("X1", "K1", properties, body);


                    Console.WriteLine(" set {0}", message);
                }
            }

            Console.ReadKey();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
