using Application.UnitTests.Common;
using AutoFixture;
using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Users.Commands.Update;
using Users.Service.Managment.Domain.Entities;
using Xunit;

namespace Application.UnitTests.Users.Commands.Update
{
    public class UpdateUserCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;
        public UpdateUserCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Handle_UserObjectSimplePropertiesUpdated_UpdatesAreReflectedInDb()
        {
            // Arrange
            var user = await CreateUserUsingAutoFixture(0);

            // update properties
            user.CreationDate = _fixture.Create<DateTime>();
            user.UserName = _fixture.Create<string>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdateUserCommand>(), It.IsAny<User>())).Returns(user);

            // creating System Under Test
            var sut = new UpdateUserCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdateUserCommand(), CancellationToken.None);

            // Assert
            var dbUser = _context.Users.First();

            dbUser.CreationDate.ShouldBe(user.CreationDate);
            dbUser.UserName.ShouldBe(user.UserName);
        }


        [Fact]
        public async Task Handle_UserCreditCardObjectUpdated_UpdatesAreReflectedInDb()
        {
            // Arrange
            var user = await CreateUserUsingAutoFixture(1);

            // update properties
            var userCreditCard = user.UserCreditCards.First();
            userCreditCard.CardDisplayNumber = _fixture.Create<string>();
            userCreditCard.CardNumber = _fixture.Create<string>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdateUserCommand>(), It.IsAny<User>())).Returns(user);

            // creating System Under Test
            var sut = new UpdateUserCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdateUserCommand(), CancellationToken.None);

            // Assert
            var dbUserCreditCards = _context.UserCreditCards.First();
            dbUserCreditCards.CardDisplayNumber.ShouldBe(userCreditCard.CardDisplayNumber);
            dbUserCreditCards.CardNumber.ShouldBe(userCreditCard.CardNumber);
        }



        private async Task<User> CreateUserUsingAutoFixture(int repeatCount)
        {
            _fixture.RepeatCount = repeatCount; // modify inner-collection objects count

            var user = _fixture.Create<User>();

            // insert initial user
            _context.Users.Add(user);
            await _context.SaveChangesAsync(CancellationToken.None);
            return user;
        }


    }
}