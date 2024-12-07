using CustomerOrderViewer2._0.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CustomerOrderViewer2._0.Repository
{
    internal class ItemCommand
    {
        private string _connectionString;
        public ItemCommand(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IList<ItemModel> GetList()
        {
            List<ItemModel> items = new List<ItemModel>();

            //GetList SPROC (stored procedure)
            var sql = "Item_GetList";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //using dapper to take care of commands and mapping - Query() is a method from dapper
                items = connection.Query<ItemModel>(sql).ToList();
            }

            return items;
        }
    }
}
