using System;

namespace CH3.DesignForChange
{
    public class MongoDbConnection : IConnection
    {
        public void Close()
        {
            Console.WriteLine("Połączenie z MongoDB zamknięte.");
        }

        public void Open()
        {
            Console.WriteLine("Połączenie z MongoDB otwarte.");
        }
    }
}
