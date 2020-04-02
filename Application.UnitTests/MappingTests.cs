using AutoMapper;
using Shouldly;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Domain.Entities;
using Xunit;

namespace Application.UnitTests
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldMapUserToUserDto()
        {
            var entity = new User();

            var result = _mapper.Map<UserDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<UserDto>();
        }

        [Fact]
        public void ShouldMapMarkupPlanToMarkupPlanDto()
        {
            var entity = new MarkupPlan();

            var result = _mapper.Map<MarkupPlanDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<MarkupPlanDto>();
        }

        [Fact]
        public void ShouldMapPointsRedeemPlanToPointsRedeemPlanDto()
        {
            var entity = new PointsRedeemPlan();

            var result = _mapper.Map<PointsRedeemPlanDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<PointsRedeemPlanDto>();
        }

    }
}