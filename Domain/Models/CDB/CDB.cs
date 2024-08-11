using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.CDB;

[ExcludeFromCodeCoverage]
public class CDB
{
    public decimal ValorInicial { get; set; } //Valor inicial
    public decimal CDI { get; set; } //Valor dessa taxa no último mês
    public decimal TB { get; set; } //Quanto o banco paga sobre o CDI
    public int Prazo { get; set; } //Prazo em meses para o cálculo
    public decimal ValorBruto { get; set; } //Resultado Bruto
    public decimal ValorLiquido { get; set; } //Resultado Líquido
}
