namespace HR_Api.Irepreatory
{
    public interface IRepository<T> : IPaginationHelper<T>
    {
        T GetById(int id);
        //IEnumerable<T> GetAll();
        T Save(T entity);
        bool Delete(int id);

        IEnumerable<T> Search( string str = default);
    }
}
