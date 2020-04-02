using Application.UnitTests.Common;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.MarkupPlans.Commands.Create;
using Users.Service.Managment.Domain.Entities;
using Xunit;

namespace Application.UnitTests.MarkupPlans.Commands.Create
{
    public class CreateMarkupPlanCommandHandlerTests : CommandTestBase
    {
        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(MarkupPlan markupPlan)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<MarkupPlan>(It.IsAny<CreateMarkupPlanCommand>()))
               .Returns(markupPlan); // AutoMapper setup

            var sut = new CreateMarkupPlanCommandHandler(_context, _mapperMock.Object); // creating system under test

            // Act
            await sut.Handle(new CreateMarkupPlanCommand(), CancellationToken.None);

            // Assert
            _context.MarkupPlans.Count().ShouldBe(1);
        }
    }
}