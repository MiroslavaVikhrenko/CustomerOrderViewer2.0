using CustomerOrderViewer2._0.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer2._0.Repository
{
    internal class CustomerCommand
    {
        private string _connectionString;
        public CustomerCommand(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IList<CustomerModel> GetList()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            //GetList SPROC (stored procedure)
            var sql = "Customer_GetList";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //using dapper to take care of commands and mapping - Query() is a method from dapper
                customers = connection.Query<CustomerModel>(sql).ToList();
            }

            return customers;
        }
    }
}
