using System;

namespace CH3.DesignForChange
{
    public class SqlServerConnection : IConnection
    {
        public void Close()
        {
            Console.WriteLine("Połączenie z SQL Server zamknięte.");
        }

        public void Open()
        {
            Console.WriteLine("Połączenie z SQL Server otwarte.");
        }
    }
}
