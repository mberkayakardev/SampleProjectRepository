namespace DataAccess
{
    public class GenericReposiory<T> : IGenericRepository<T>  
    {
        private readonly MyDbContext myDbContext;
        public GenericReposiory(MyDbContext dbContext)
        {
            this.myDbContext = dbContext;
        }
        public void Add(T entity)
        {

        }

        public void Delete(T entity)
        {

        }

        public void List(T entity)
        {

        }
    }
}
