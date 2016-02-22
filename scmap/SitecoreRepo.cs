using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using scmap.Extensions;
using scmap.Helpers;

namespace scmap
{
    public class SitecoreRepo
    {
        readonly SqlConnection _connection;

        public SitecoreRepo(string database = "master")
        {
            _connection = new SqlConnection(ConfigHelper.Read().GetStringProperty($"{database}-db"));
        }

        public dynamic GetItemById(string id)
        {
            var item = _connection.Query("select * from items where items.id = @Id", new
            {
                Id = id
            }).FirstOrDefault();

            return item;
        }

        public List<dynamic> GetFieldsForItemById(string id)
        {

            var fields = _connection.Query<dynamic>(@"select i3.* 
                               from items i
                               inner
                               join items i2 on i2.ParentId = i.Id
                               inner
                               join items i3 on i3.ParentID = i2.Id
                               where i.id = @Id
            ", new
            {
                Id = id
            }).ToList();

            return fields;
        }
    }
}
