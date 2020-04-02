using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update;
using Xunit;

namespace Application.UnitTests.PointsRedeemPlans.Commands.Update
{
    public class UpdatePointsRedeemPlanCommandValidatorTests
    {
        private readonly UpdatePointsRedeemPlanCommandValidator _validator;

        public UpdatePointsRedeemPlanCommandValidatorTests()
        {
            _validator = new UpdatePointsRedeemPlanCommandValidator();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(5);
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForIdAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Id, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
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