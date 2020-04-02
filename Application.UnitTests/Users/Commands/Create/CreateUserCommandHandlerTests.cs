using Application.UnitTests.Common;
using AutoFixture;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Users.Commands.Create;
using Users.Service.Managment.Domain.Entities;
using Xunit;

namespace Application.UnitTests.Users.Commands.Create
{
    public class DeleteUserCommandHandlerTests : CommandTestBase
    {
        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(User user)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<User>(It.IsAny<CreateUserCommand>()))
               .Returns(user); // AutoMapper setup


            var creditCardsCount = user.UserCreditCards.Count();
            var markupPlansCount = user.UserMarkupPlans.Count();
            var pointsRedeemPlansCount = user.UserPointsRedeemPlans.Count();

            var sut = new CreateUserCommandHandler(_context, _mapperMock.Object); // creating system under test

            var fixture = new Fixture();

            // Act
            await sut.Handle(new CreateUserCommand { Password = fixture.Create<string>()}, CancellationToken.None);

            // Assert
            _context.Users.Count().ShouldBe(1);
            _context.UserCreditCards.Count().ShouldBe(creditCardsCount);
            _context.UserMarkupPlans.Count().ShouldBe(markupPlansCount);
            _context.UserPointsRedeemPlans.Count().ShouldBe(pointsRedeemPlansCount);

        }
    }
}