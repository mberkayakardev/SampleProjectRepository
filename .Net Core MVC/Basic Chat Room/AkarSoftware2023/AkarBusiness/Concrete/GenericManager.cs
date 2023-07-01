using AkarBusiness.Abstract;
using AkarDataAccess.Abstract;
using AkarEntities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AkarBusiness.Concrete
{
    public class GenericManager<T> : IGenericService<T>
    {
        private readonly IGenericRepository<T> _genericService;
        private readonly IUnitOfWork _UnitOfWork;
        public readonly IMapper _mapper;
      
        public GenericManager(IGenericRepository<T> genericService, IUnitOfWork unitOfWork , IMapper mapper)
        {
            _genericService = genericService;
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public void Add(T item)
        { 
            _genericService.Add(item);
            _UnitOfWork.Save();
        }

        public bool ForceDelete(T item)
        {
            var result = _genericService.ForceDelete(item);
            _UnitOfWork.Save();
            return result;

        }

        public T Get(Expression<Func<T, bool>> where = null, Expression<Func<T, object>>[] include = null)
        {
            return _genericService.Get(where, include);
        }

        public List<T> GetEnum(Expression<Func<T, bool>> where = null, Expression<Func<T, object>>[] include = null)
        {
            return _genericService.GetEnum(where, include);
        }

        public bool SafeDelete(T item)
        {
            var result = _genericService.SafeDelete(item);
            _UnitOfWork.Save();
            return result;
        }

        public void Update(T item)
        {
            _genericService.Update(item);
            _UnitOfWork.Save();
        }

    }
}
