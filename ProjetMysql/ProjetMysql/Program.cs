namespace ProjetMysql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MysqlConnection mysqlConnection = new MysqlConnection();

            mysqlConnection.InitialiserConnexion();
            mysqlConnection.AppelerProcedureStockee1();
        }


    }
}
