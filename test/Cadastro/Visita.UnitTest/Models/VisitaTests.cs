using System;
using Xunit;

namespace Visita.UnitTest.Models
{
    public class VisitaTests
    {
        [Fact(DisplayName = nameof(Visita_CriarNovo_DeveCriar))]
        [Trait("UNIT", "Cadastros")]
        public void Visita_CriarNovo_DeveCriar()
        {
            // Arrange & Act
            var visita = new Domain.Visita(0, 1, 0, 1, 1, 1, "", DateTime.Now, DateTime.Now, 0, 1, Guid.NewGuid().ToString("n"), "", "", "", 0);
            // Assert 
            Assert.NotNull(visita);
        }
    }
}
