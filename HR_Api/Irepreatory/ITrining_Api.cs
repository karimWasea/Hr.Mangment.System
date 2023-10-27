using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;




namespace HR_Api.IrepreatoryServess
{
    public interface ITrining_Api : IRepository<TrainingDTOUppdate>
    {
        Training Add(TrainingDTOAdd entity);
        Training Update(TrainingDTOUppdate entity);
    }
}
