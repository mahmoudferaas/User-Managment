using Xunit;
using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Users.Service.Managment.Application.MarkupPlans.Commands.Create;

namespace Application.UnitTests.MarkupPlans.Commands.Create
{
    public class CreateMarkupPlanCommandValidatorTests
    {
        private readonly CreateMarkupPlanCommandValidator _validator;

        public CreateMarkupPlanCommandValidatorTests()
        {
            _validator = new CreateMarkupPlanCommandValidator();
        }


        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
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