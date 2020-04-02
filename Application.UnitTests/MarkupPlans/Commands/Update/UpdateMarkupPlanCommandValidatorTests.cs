using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Users.Service.Managment.Application.MarkupPlans.Commands.Update;
using Xunit;

namespace Application.UnitTests.MarkupPlans.Commands.Update
{
    public class UpdateMarkupPlanCommandValidatorTests
    {
        private readonly UpdateMarkupPlanCommandValidator _validator;

        public UpdateMarkupPlanCommandValidatorTests()
        {
            _validator = new UpdateMarkupPlanCommandValidator();
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
        public void GivenWhenValidatorConstructing_ThenRulesForNameAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Name, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .Create());
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForMarkupAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Markup, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForCanUseCouponAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.CanUseCoupon, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }
    }
}