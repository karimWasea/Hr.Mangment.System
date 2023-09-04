using SystemEnums;

namespace DataAcess.layes
{

    public class EmployeeDevice : BaseEntity
    {
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string? EmployeeId { get; set; }
        public Applicaionuser Employee { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}