using SystemEnums;

namespace DataAcess.layes
{
    public class EmployeeTraining : BaseEntity
    {
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string? EmployeeId { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }
        public Applicaionuser Employee { get; set; }

    }
}