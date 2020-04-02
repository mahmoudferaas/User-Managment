using Xunit;
using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create;

namespace Application.UnitTests.PointsRedeemPlans.Commands.Create
{
    public class CreatePointsRedeemPlanCommandValidatorTests
    {
        private readonly CreatePointsRedeemPlanCommandValidator _validator;

        public CreatePointsRedeemPlanCommandValidatorTests()
        {
            _validator = new CreatePointsRedeemPlanCommandValidator();
        }


        [Fact]
        public void GivenWhenValidatorConstructing_Then4PropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(4);
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForClientReferenceAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.ClientReference, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .Create());
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForPointsAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Points, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForBalanceAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Balance, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForPlanDateAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.PlanDate, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }

       
    }
}