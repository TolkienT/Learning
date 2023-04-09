using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Model.Db
{
    //class:T必须是一个类(class)类型，不是结构(structure)类型
    //new(): T必须要有一个无参构造函数
    public class MyDbContext<T> where T : class, new()
    {
        //用来处理事务多表查询和复杂的操作
        public SqlSugarClient Db;
        string connectString = "server=localhost;Database=web-server;Uid=root;Pwd=root;Port=3306;Allow User Variables=True;";
        //用来操作当前表的数据
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }

        public MyDbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,//开启自动释放模式
            });
            //调式代码 用来打印SQL
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
               Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }


    }
}
