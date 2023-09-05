using PagedList;

namespace IREprestory
{
    public interface IRepository<T> : IPaginationHelper<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Save(T entity);
        void Delete(int id );

        bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase);
    }
    public interface IPaginationHelper<T>
    {
        IPagedList<T> GetPagedData<T>(IQueryable<T> data , int pagenumber );
    }

}