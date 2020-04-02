using Xunit;
using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Users.Service.Managment.Application.Users.Commands.Create;

namespace Application.UnitTests.Users.Commands.Create
{
    public class CreateUserCommandValidatorTests
    {
        private readonly CreateUserCommandValidator _validator;

        public CreateUserCommandValidatorTests()
        {
            _validator = new CreateUserCommandValidator();
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
        public void GivenWhenValidatorConstructing_ThenRulesForUserNameAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.UserName, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<RegularExpressionValidator>(@"\A\S+\z")
                .Create());
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForEmailAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Email, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .Create());
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenRulesForPhoneNumberAreConfiguredCorrectly()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.PhoneNumber, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .Create());
        }

       
    }
}