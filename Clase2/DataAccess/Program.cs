using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseDao baseDao = new ProductDao();
            baseDao.Execute();
        }
    }

    abstract class BaseDao
    {
        public void OpenConnection()
        {
            Console.WriteLine("Open connection...");
        }

        public void CloseConnection()
        {
            Console.WriteLine("Connection closed...");
        }

        public abstract void Query();

        public  void Execute()
        {
            OpenConnection();
            Query();
            CloseConnection();
        }
    }

    class ProductDao : BaseDao
    {
        public override void Query()
        {
            Console.WriteLine("SELECT * FROM Products");
        }
    }

    class CustomerDao : BaseDao
    {
        public override void Query()
        {
            Console.WriteLine("SELECT * FROM Customers");
        }
    }
}
