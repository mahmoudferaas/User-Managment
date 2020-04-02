using Application.UnitTests.Common;
using AutoFixture;
using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update;
using Users.Service.Managment.Domain.Entities;
using Users.Service.Managment.Domain.Enums;
using Xunit;

namespace Application.UnitTests.PointsRedeemPlans.Commands.Update
{
    public class UpdatePointsRedeemPlanCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public UpdatePointsRedeemPlanCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Handle_PointsRedeemPlanObjectSimplePropertiesUpdated_UpdatesAreReflectedInDb()
        {
            // Arrange
            var pointsRedeemPlan = await CreatePointsRedeemPlanUsingAutoFixture(0);

            // update properties
            pointsRedeemPlan.PlanDate = _fixture.Create<DateTime>();
            pointsRedeemPlan.Points = _fixture.Create<int>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdatePointsRedeemPlanCommand>(), It.IsAny<PointsRedeemPlan>())).Returns(pointsRedeemPlan);

            // creating System Under Test
            var sut = new UpdatePointsRedeemPlanCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdatePointsRedeemPlanCommand(), CancellationToken.None);

            // Assert
            var dbPointsRedeemPlan = _context.PointsRedeemPlans.First();

            dbPointsRedeemPlan.PlanDate.ShouldBe(pointsRedeemPlan.PlanDate);
            dbPointsRedeemPlan.Points.ShouldBe(pointsRedeemPlan.Points);
        }

        [Fact]
        public async Task Handle_DefaultPointsRedeemPlansObjectUpdated_UpdatesAreReflectedInDb()
        {
            // Arrange
            var pointsRedeemPlan = await CreatePointsRedeemPlanUsingAutoFixture(1);

            // update properties
            var defaultPointsRedeemPlans = pointsRedeemPlan.DefaultPointsRedeemPlans.First();
            defaultPointsRedeemPlans.PointsRedeemPlanId = _fixture.Create<int>();
            defaultPointsRedeemPlans.Module = _fixture.Create<ModuleTypes>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdatePointsRedeemPlanCommand>(), It.IsAny<PointsRedeemPlan>())).Returns(pointsRedeemPlan);

            // creating System Under Test
            var sut = new UpdatePointsRedeemPlanCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdatePointsRedeemPlanCommand(), CancellationToken.None);

            // Assert
            var dbDefaultPointsRedeemPlans = _context.DefaultPointsRedeemPlans.First();
            dbDefaultPointsRedeemPlans.PointsRedeemPlanId.ShouldBe(defaultPointsRedeemPlans.PointsRedeemPlanId);
            dbDefaultPointsRedeemPlans.Module.ShouldBe(defaultPointsRedeemPlans.Module);
        }

        private async Task<PointsRedeemPlan> CreatePointsRedeemPlanUsingAutoFixture(int repeatCount)
        {
            _fixture.RepeatCount = repeatCount; // modify inner-collection objects count

            var PointsRedeemPlan = _fixture.Create<PointsRedeemPlan>();

            // insert initial PointsRedeemPlan
            _context.PointsRedeemPlans.Add(PointsRedeemPlan);
            await _context.SaveChangesAsync(CancellationToken.None);
            return PointsRedeemPlan;
        }
    }
}