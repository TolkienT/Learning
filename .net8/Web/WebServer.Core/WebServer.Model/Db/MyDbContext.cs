using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Common.Helpers;

namespace WebServer.Model.Db
{
    public class MyDbContext<TEntity> where TEntity : class, new()
    {
        public SqlSugarClient _db;

        public MyDbContext()
        {
            var dbConnections = AppSettingHelper.GetApp<DbConnectionModel>("DbConnections");
            if (dbConnections is not null)
            {
                var myDb = dbConnections.FirstOrDefault(x => x.ConnectionId == "Mysql");
                if (myDb is not null)
                {
                    _db = new SqlSugarClient(new ConnectionConfig()
                    {
                        ConnectionString = myDb.Connection,
                        DbType = DbType.MySql,
                        IsAutoCloseConnection = true,//开启自动释放模式
                    });
                    //调式代码 用来打印SQL
                    _db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        Console.WriteLine(sql + "\r\n" +
                       _db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                        Console.WriteLine();
                    };
                }

            }
            else
            {
                Console.WriteLine("未配置数据库连接");
            }

        }

    }
}
