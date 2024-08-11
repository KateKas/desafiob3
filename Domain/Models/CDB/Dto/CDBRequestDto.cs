using System.Diagnostics.CodeAnalysis;
namespace Domain.Models.CDB.Dto;
[ExcludeFromCodeCoverage]
public class CDBRequestDto
{
    public decimal ValorInicial { get; set; } //Valor inicial
    public int Prazo { get; set; } //Prazo em meses para o cálculo
}
