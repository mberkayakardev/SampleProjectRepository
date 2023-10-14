using Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace DataAccess
{
    public static class Extentions
    {
        public static TReposiyory GetRepositoryInstance<T, TReposiyory>(this IServiceProvider collecion) where TReposiyory: class, IGenericRepository<IEntity> where T : class , IEntity, new()
        {
            
            return collecion.GetService<TReposiyory>();

        }
    }
}
