using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        //generic repository,design pattern araştır


        //entity ıqueryable döndürür bize bizde ıenumarable'a dönüştürmek için tolist() kullanıyoruz.
        //tolist:sorgu sonucunu döndürür.
        //ıqueryable :sorguyu döndürür.Dönen sonuc tekrar sorgulanabilir

        IList<T> GetAll();

        IList<T> GetAll(Expression<Func<T, bool>> predicate= null,Func < IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);




    }
}
