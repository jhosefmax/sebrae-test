using Moq;
using Sebrae.Persistence;
using Sebrae.Repository;
using Sebrae.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Test
{
    public class ContaServiceTests
    {
        [Fact]
        public async Task shouldReturnContasList()
        {
            // Arrange
            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(repo => repo.GetContasAsync())
                               .ReturnsAsync(new List<Conta> { new Conta { Id = 1, Nome = "Conta1" } });

            var contaService = new ContaService(contaRepositoryMock.Object);

            // Act
            var result = await contaService.GetContas();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Garante que há exatamente uma conta na lista
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Conta1", result[0].Nome);
        }

        [Fact]
        public async Task shouldCreateConta()
        {
            // Arrange
            var contaRepositoryMock = new Mock<IContaRepository>();
            var contaService = new ContaService(contaRepositoryMock.Object);

            var novaConta = new Conta { Nome = "NovaConta" };

            // Act
            await contaService.CreateConta(novaConta);

            // Assert
            contaRepositoryMock.Verify(repo => repo.CreateContaAsync(It.IsAny<Conta>()), Times.Once);
        }

        [Fact]
        public async Task shouldGetContaById()
        {
            // Arrange
            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(repo => repo.GetContaByIdAsync(1))
                               .ReturnsAsync(new Conta { Id = 1, Nome = "Conta1" });

            var contaService = new ContaService(contaRepositoryMock.Object);

            // Act
            var result = await contaService.GetContaById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Conta1", result.Nome);
        }

        [Fact]
        public async Task shouldUpdateConta()
        {
            // Arrange
            var contaRepositoryMock = new Mock<IContaRepository>();
            var contaService = new ContaService(contaRepositoryMock.Object);

            var contaExistente = new Conta { Id = 1, Nome = "Conta1" };

            // Act
            await contaService.UpdateConta(contaExistente);

            // Assert
            contaRepositoryMock.Verify(repo => repo.UpdateContaAsync(It.IsAny<Conta>()), Times.Once);
        }

        [Fact]
        public async Task shouldDeleteConta()
        {
            // Arrange
            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(repo => repo.DeleteContaAsync(1)).Returns(Task.CompletedTask);

            var contaService = new ContaService(contaRepositoryMock.Object);

            // Act
            await contaService.DeleteConta(1);

            // Assert
            contaRepositoryMock.Verify(repo => repo.DeleteContaAsync(1), Times.Once);
        }
    }
}
