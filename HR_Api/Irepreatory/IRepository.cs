using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HR_Api.Irepreatory
{
    public interface IRepository<T> : IPaginationHelper<T>
    {
        bool Delete(int id);

        T GetById(int id);
        //IEnumerable<T> GetAll();
     
    IEnumerable<T> Search( string str = default);
    }
}
