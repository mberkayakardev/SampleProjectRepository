namespace AkarDataAccess.Abstract
{
    public interface IUnitOfWork
    {
        void Save();
        void SaveAsync();
    }
}
