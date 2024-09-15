using Visita.Application.Commands;
using System;
using Xunit;

namespace Visita.UnitTest.Application.Commands
{
    public class AdicionarVisitaCommandTests
    {
        [Fact(DisplayName = nameof(Visita_AdicionarComCodigoEspecificoValido_ComandoDeveEstarValido))]
        [Trait("UNIT", "Cadastros")]
        public void Visita_AdicionarComCodigoEspecificoValido_ComandoDeveEstarValido()
        {
            // Arrange
            var SUT = new AdicionarVisitaCommand(0, 1, 0, 1, 1, 1, "", DateTime.Now, DateTime.Now, 0, 1, Guid.NewGuid().ToString("n"), "", "", "", 0);
            // Act
            bool comandoEhValido = SUT.EhValido();
            // Assert 
            Assert.True(comandoEhValido);
        }
    }
}
