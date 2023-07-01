using AkarDataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AkarDataAccess.Concrete.DataAccess.UOW
{
    public class MyUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _MyDbContext;
        public MyUnitOfWork(DbContext myDbContext)
        {
            _MyDbContext = myDbContext;
        }
        public void Save()
        {
            _MyDbContext.SaveChanges();
        }

        [Obsolete("Asenkron kullanmak istersen bunu kullanabilirsin. Şimdilik Tanımlamıyorum")]
        public void SaveAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
