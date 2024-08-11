using Domain.Models.CDB.Dto;

namespace Domain.Interfaces;

public interface ICDBService
{
    Task<CDBResponseDto> ObterCalculoCDB(CDBRequestDto cDBRequest);
}
