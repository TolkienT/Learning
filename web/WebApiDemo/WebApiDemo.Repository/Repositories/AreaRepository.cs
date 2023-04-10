using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Model.Models;
using WebApiDemo.Repository.IRepositories;
using WebApiDemo.Repository.Repositories.Base;

namespace WebApiDemo.Repository.Repositories
{
    public class AreaRepository : BaseRepository<AreaModel>, IAreaRepository
    {

    }
}
