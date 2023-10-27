﻿using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using static HR_Api.Dtos.VacarionDTOAdd;

namespace HR_Api.IrepreatoryServess
{
    public interface IVaction_Api : IRepository<VacarionDTO>
    {
        Vacation Add(VacarionDTOAdd entity);
        Vacation Update(VacarionDTO entity);
    }
}
