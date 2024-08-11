using Application.Services.CDB;
using Domain.Models.CDB.Dto;

namespace Test.Feature.CDB.Services
{
    public class CDBTest
    {
        [Fact]
        public async Task ObterCalculoCDB_RetornoValorLiquido_12Meses()
        {
            decimal valorInicial = 1000M;
            int meses = 12;

            CDBService service = new CDBService();
            CDBRequestDto request = new CDBRequestDto();
            request.ValorInicial = valorInicial;
            request.Prazo = meses;

            var resultado = await service.ObterCalculoCDB(request);

            Assert.Equal(1098.46M, resultado.ValorLiquido);
        }

        [Fact]
        public async Task ObterCalculoCDB_RetornoValorBruto_12Meses()
        {
            decimal valorInicial = 1000M;
            int meses = 12;

            CDBService service = new CDBService();
            CDBRequestDto request = new CDBRequestDto();
            request.ValorInicial = valorInicial;
            request.Prazo = meses;

            var resultado = await service.ObterCalculoCDB(request);

            Assert.Equal(1123.07M, resultado.ValorBruto);
        }

        [Fact]
        public async Task ObterCalculoCDB_RetornoValorLiquido_6Meses()
        {
            decimal valorInicial = 1000M;
            int meses = 6;

            CDBService service = new CDBService();
            CDBRequestDto request = new CDBRequestDto();
            request.ValorInicial = valorInicial;
            request.Prazo = meses;

            var resultado = await service.ObterCalculoCDB(request);

            Assert.Equal(1046.31M, resultado.ValorLiquido);
        }

        [Fact]
        public async Task ObterCalculoCDB_RetornoValorBruto_6Meses()
        {
            decimal valorInicial = 1000M;
            int meses = 6;

            CDBService service = new CDBService();
            CDBRequestDto request = new CDBRequestDto();
            request.ValorInicial = valorInicial;
            request.Prazo = meses;

            var resultado = await service.ObterCalculoCDB(request);

            Assert.Equal(1059.75M, resultado.ValorBruto);
        }
    }
}
