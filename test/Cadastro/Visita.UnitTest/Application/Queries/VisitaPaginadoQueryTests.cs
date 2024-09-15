using Visita.Application.Queries;
using Xunit;

namespace Visita.UnitTest.Application.Queries
{
    public class VisitaPaginadoQueryTests
    {
        [Fact(DisplayName = nameof(Visita_ObterListaSemParametros_DeveGerarQuery))]
        [Trait("UNIT", "Consultas")]
        public void Visita_ObterListaSemParametros_DeveGerarQuery()
        {
            // Act
            var SUT = new VisitaPaginadoQuery();
            // Assert 
            Assert.NotNull(SUT);
        }
    }
}
