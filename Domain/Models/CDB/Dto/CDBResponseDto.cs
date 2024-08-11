using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.CDB.Dto;

[ExcludeFromCodeCoverage]
public  class CDBResponseDto
{
    public decimal ValorBruto { get; set; } //Resultado Bruto
    public decimal ValorLiquido { get; set; } //Resultado Líquido
}
