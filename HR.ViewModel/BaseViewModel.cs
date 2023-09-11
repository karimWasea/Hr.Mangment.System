using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR.ViewModel
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public IsDeleted isDeleted { get; set; }
public string Name { get; set; }

    }
}