using RabbitMQ.Client;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672
};

using var connection = connectionFactory.CreateConnection();
using var chanel = connection.CreateModel(); // use for multi Thread

var queueName = "HelloWorld";
chanel.QueueDeclare(queueName,false,false,false,null);

Console.Write("Type your message and press [Enter]: ");
var message = Console.ReadLine() ?? "Default message";
var messageBytes = System.Text.Encoding.UTF8.GetBytes(message).ToArray();

chanel.BasicPublish(string.Empty, queueName, null, messageBytes);

Console.WriteLine($"[*] Your message sent: {message}");
Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();

connection.Close();
    


