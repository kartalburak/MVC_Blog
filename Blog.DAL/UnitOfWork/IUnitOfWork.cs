using Blog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {

        IRepository<T> Repository<T>() where T : class;


        int SaveChanges();





    }
}
