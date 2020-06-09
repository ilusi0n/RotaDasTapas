using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Validators;

namespace RotaDasTapas.Unit.Tests.Validators
{
    [TestClass]
    public class RotaDasTapasParametersValidatorTests
    {
        private readonly RotaDasTapasParametersValidator _validator;

        public RotaDasTapasParametersValidatorTests()
        {
            _validator = new RotaDasTapasParametersValidator();
        }
        
        [TestMethod]
        public void Should_have_error_when_Name_is_null() {
            _validator.ShouldHaveValidationErrorFor(param => param.Localtime, null as string); 
        }
        
        [TestMethod]
        public void Should_not_have_error_when_localtime_is_valid() {
            _validator.ShouldNotHaveValidationErrorFor(person => person.Localtime, "2020-06-09 15:54:59.851553");
        }
        
        [TestMethod]
        public void Should_have_error_when_localtime_is_invalid() {
            _validator.ShouldHaveValidationErrorFor(person => person.Localtime, "fakedate");
        }
    }
}