using PagedList;

namespace IREprestory
{
    public interface IRepository<T> : IPaginationHelper<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(T entity);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
     
        
    }
    public interface IPaginationHelper<T>
    {
        IPagedList<T> GetPagedData<T>(IQueryable<T> data , int pagenumber );
    }

}