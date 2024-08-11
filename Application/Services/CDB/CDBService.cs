using Domain.Interfaces;
using Domain.Models.CDB.Dto;

namespace Application.Services.CDB
{
    public class CDBService : ICDBService
    {
        private const decimal CDI = 0.009M; 
        private const decimal TB = 1.08M;
        private const decimal TAXA6MESES = 0.225M;
        private const decimal TAXA12MESES = 0.20M;
        private const decimal TAXA24MESES = 0.175M;
        private const decimal TAXAACIMA24MESES = 0.15M;

        public Task<CDBResponseDto> ObterCalculoCDB(CDBRequestDto cDBRequest)
        {
            CDBResponseDto cDBResponse = new CDBResponseDto();

            cDBResponse.ValorBruto = CalculoCDB(cDBRequest);
            cDBResponse.ValorLiquido = CalculoImposto(cDBRequest, cDBResponse.ValorBruto);
            return Task.FromResult(cDBResponse);
        }

        private decimal CalculoCDBMensal(decimal valorInicial)
        {
            //VF = VI x [1 + (CDI x TB)] 
            return decimal.Round(valorInicial * (1 + (CDI * TB)), 2);
        }

        private decimal CalculoCDB(CDBRequestDto cDBRequest)
        {
            decimal retornoBruto = cDBRequest.ValorInicial;

            for (int i = 0; i < cDBRequest.Prazo; i++)
            {
               retornoBruto = CalculoCDBMensal(retornoBruto);
            }

            return retornoBruto;
        }

        private decimal CalculoImposto(CDBRequestDto cDBRequest, decimal valorBruto)
        {
            var taxas = new Dictionary<int, decimal>
            {
                { 6, TAXA6MESES }, 
                { 12, TAXA12MESES }, 
                { 24, TAXA24MESES }, 
                { int.MaxValue, TAXAACIMA24MESES } 
            };

            //var retornoLiquinho = cDBRequest.ValorInicial;
            var prazo = cDBRequest.Prazo;

            decimal taxa = taxas.First(key => prazo <= key.Key).Value;

            decimal imposto = valorBruto - cDBRequest.ValorInicial;

            return decimal.Round(valorBruto - (imposto * taxa), 2);
        }

    }
}
