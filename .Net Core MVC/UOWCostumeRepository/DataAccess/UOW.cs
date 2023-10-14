using Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace DataAccess
{
    public class UOW : IUOW
    {
        private readonly MyDbContext _db;
        private readonly IServiceProvider _service;
        public UOW(MyDbContext context, IServiceProvider collection)
        {
            _db = context;
            _service = collection;
        }
        public void SaveChanges(IServiceProvider service)
        {

        }

        public TRepository GetRepository<T, TRepository>() where T : IEntity where TRepository : IGenericRepository<T>
        {
            return _service.GetService<TRepository>();
        }

        IGenericRepository<T> IUOW.GetGenericRepository<T>()
        {
            return new GenericReposiory<T>(_db);
        }

        public void SaveChanges()
        {

        }
    }
}
