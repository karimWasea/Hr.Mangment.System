using PagedList;

namespace HR_Api.Irepreatory
{
    public interface IPaginationHelper<T>
    {
        IPagedList<T> GetPagedData<T>(IEnumerable<T> data, int pagenumber);
    }

    

}
