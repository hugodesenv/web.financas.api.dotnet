﻿using api.aspnetcore.webfinancas.Application.DTO.Purpose;
using api.aspnetcore.webfinancas.Domain.Model;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IPurposeRepository
    {
        Task<List<PurposeFindAllDTO>> FindAll();
        Task<Purpose?> FindByID(int id);
        Task<bool> Insert(Purpose purpose);
        bool Update(PurposeUpdateDTO purpose); 
        bool DeleteById(int id);
    }
}
