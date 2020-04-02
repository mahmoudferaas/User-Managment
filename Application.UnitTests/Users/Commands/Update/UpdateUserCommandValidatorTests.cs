using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Users.Service.Managment.Application.Users.Commands.Update;
using Xunit;

namespace Application.UnitTests.Users.Commands.Update
{
    public class UpdateUserCommandValidatorTests
    {
        private readonly UpdateUserCommandValidator _validator;

        public UpdateUserCommandValidatorTests()
        {
            _validator = new UpdateUserCommandValidator();
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