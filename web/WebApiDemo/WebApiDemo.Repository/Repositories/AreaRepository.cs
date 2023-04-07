using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Repository.IRepositories;

namespace WebApiDemo.Repository.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        public string Test()
        {
            return "Test";
        }
    }
}
