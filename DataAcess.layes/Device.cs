using SystemEnums;

namespace DataAcess.layes
{


    public class Device : BaseEntity
    {
        public string? DeviceName { get; set; }

        // Navigation property
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public ICollection<EmployeeDevice> EmployeeDevices { get; set; }
    }
}