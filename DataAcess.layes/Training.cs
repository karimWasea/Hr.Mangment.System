using SystemEnums;

namespace DataAcess.layes
{


    public class Training : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string? TrainingName { get; set; }

        // Navigation property
        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
    }
}