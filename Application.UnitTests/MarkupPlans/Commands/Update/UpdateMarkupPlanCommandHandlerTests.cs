using Application.UnitTests.Common;
using AutoFixture;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.MarkupPlans.Commands.Update;
using Users.Service.Managment.Domain.Entities;
using Users.Service.Managment.Domain.Enums;
using Xunit;

namespace Application.UnitTests.MarkupPlans.Commands.Update
{
    public class UpdateMarkupPlanCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public UpdateMarkupPlanCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Handle_MarkupPlanObjectSimplePropertiesUpdated_UpdatesAreReflectedInDb()
        {
            // Arrange
            var markupPlan = await CreateMarkupPlanUsingAutoFixture(0);

            // update properties
            markupPlan.CanUseCoupon = _fixture.Create<bool>();
            markupPlan.Name = _fixture.Create<string>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdateMarkupPlanCommand>(), It.IsAny<MarkupPlan>())).Returns(markupPlan);

            // creating System Under Test
            var sut = new UpdateMarkupPlanCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdateMarkupPlanCommand(), CancellationToken.None);

            // Assert
            var dbMarkupPlan = _context.MarkupPlans.First();

            dbMarkupPlan.CanUseCoupon.ShouldBe(markupPlan.CanUseCoupon);
            dbMarkupPlan.Name.ShouldBe(markupPlan.Name);
        }

        [Fact]
        public async Task Handle_DefaultMarkupPlansObjectUpdated_UpdatesAreReflectedInDb()
        {
            // Arrange
            var markupPlan = await CreateMarkupPlanUsingAutoFixture(1);

            // update properties
            var defaultMarkupPlans = markupPlan.DefaultMarkupPlans.First();
            defaultMarkupPlans.MarkupPlanId = _fixture.Create<int>();
            defaultMarkupPlans.Module = _fixture.Create<ModuleTypes>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdateMarkupPlanCommand>(), It.IsAny<MarkupPlan>())).Returns(markupPlan);

            // creating System Under Test
            var sut = new UpdateMarkupPlanCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdateMarkupPlanCommand(), CancellationToken.None);

            // Assert
            var dbDefaultMarkupPlans = _context.DefaultMarkupPlans.First();
            dbDefaultMarkupPlans.MarkupPlanId.ShouldBe(defaultMarkupPlans.MarkupPlanId);
            dbDefaultMarkupPlans.Module.ShouldBe(defaultMarkupPlans.Module);
        }

        private async Task<MarkupPlan> CreateMarkupPlanUsingAutoFixture(int repeatCount)
        {
            _fixture.RepeatCount = repeatCount; // modify inner-collection objects count

            var MarkupPlan = _fixture.Create<MarkupPlan>();

            // insert initial MarkupPlan
            _context.MarkupPlans.Add(MarkupPlan);
            await _context.SaveChangesAsync(CancellationToken.None);
            return MarkupPlan;
        }
    }
}