using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Utils
{
    public static class EventLogger
    { // Método para logar eventos genéricos no sistema
        public static void LogEvent(string evento)
        {
            // Aqui você pode implementar o que deseja, por exemplo, logar no console, em um arquivo, em uma base de dados, etc.
            // Para simplicidade, estamos logando no console:
            Console.WriteLine($"Evento: {evento} registrado em {DateTime.Now}");

            // Caso você queira logar em um banco de dados ou serviço de mensagens, você pode implementar aqui
            // Por exemplo:
            // LogInDatabase(evento);
            // LogInMessageQueue(evento);
        }

        // Exemplo de método para logar no banco (caso queira)
        private static void LogInDatabase(string evento)
        {
            // Lógica para gravar no banco de dados
            // Exemplo: Inserir o evento em uma tabela de log no banco
        }

        // Exemplo de método para logar em uma fila de mensagens (caso queira)
        private static void LogInMessageQueue(string evento)
        {
            // Lógica para enviar o evento para um serviço de filas (exemplo: RabbitMQ, Kafka, etc)
        }
    }
}