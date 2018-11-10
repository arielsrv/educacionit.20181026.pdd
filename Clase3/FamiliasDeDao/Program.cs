using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliasDeDao
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractDaoProvider abstractDao = new OracleDaoProvider();
            ProductDao productDao = abstractDao.CreateProductDao();
        }
    }

    abstract class AbstractDaoProvider
    {
        public abstract ProductDao CreateProductDao();
        public abstract CustomerDao CreateCustomerDao();
    }


    class OracleDaoProvider : AbstractDaoProvider
    {
        public override CustomerDao CreateCustomerDao()
        {
            return new OracleCustomerDao();
        }

        public override ProductDao CreateProductDao()
        {
            return new OracleProductDao();
        }
    }

    class SqlServerDaoProvider : AbstractDaoProvider
    {
        public override CustomerDao CreateCustomerDao()
        {
            return new SqlServerCustomerDao();
        }

        public override ProductDao CreateProductDao()
        {
            return new SqlServerProductDao();
        }
    }
    
    abstract class ProductDao
    {

    }

    abstract class CustomerDao
    {

    }

    class SqlServerProductDao : ProductDao
    {

    }

    class OracleProductDao : ProductDao
    {

    }

    class SqlServerCustomerDao : CustomerDao
    {

    }

    class OracleCustomerDao : CustomerDao
    {

    }

}
