using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Common;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create;
using Users.Service.Managment.Domain.Entities;
using Xunit;

namespace Application.UnitTests.PointsRedeemPlans.Commands.Create
{
    public class CreatePointsRedeemPlanCommandHandlerTests : CommandTestBase
    {
        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(PointsRedeemPlan pointsRedeemPlan)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<PointsRedeemPlan>(It.IsAny<CreatePointsRedeemPlanCommand>()))
               .Returns(pointsRedeemPlan); // AutoMapper setup

            var sut = new CreatePointsRedeemPlanCommandHandler(_context, _mapperMock.Object); // creating system under test

            // Act
            await sut.Handle(new CreatePointsRedeemPlanCommand(), CancellationToken.None);

            // Assert
            _context.PointsRedeemPlans.Count().ShouldBe(1);
        }
    }
}