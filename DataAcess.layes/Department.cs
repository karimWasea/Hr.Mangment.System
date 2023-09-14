using SystemEnums;

namespace DataAcess.layes
{

    public class Department : BaseEntity
    {
        public string? DepartmentName { get; set; } = string.Empty;
        public string? ManagerId { get; set; }
        public  IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        //public Employee Manager { get; set; }
        // Navigation property
        //[NotMapped]
        public ICollection<Applicaionuser> Employees { get; set; }
    }

}