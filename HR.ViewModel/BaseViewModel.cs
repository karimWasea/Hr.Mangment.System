using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR.ViewModel
{
    public class BaseViewModel
    {
        [Required]
        public int Id { get; set; }
        public IsDeleted isDeleted { get; set; }
        [Required]
public string Name { get; set; }

    }
}