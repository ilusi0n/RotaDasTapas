using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Validators;

namespace RotaDasTapas.Unit.Tests.Validators
{
    [TestClass]
    public class JourneyParametersValidatorTests
    {
        private readonly JourneyParametersValidator _validator;
        public JourneyParametersValidatorTests()
        {
            _validator = new JourneyParametersValidator();
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
        
        [TestMethod]
        public void Should_have_error_when_City_is_null() {
            _validator.ShouldHaveValidationErrorFor(param => param.City, null as string); 
        }
        
        [TestMethod]
        public void Should_have_error_when_City_is_Invalid() {
            _validator.ShouldHaveValidationErrorFor(param => param.City, "fakecity"); 
        }
        
        [TestMethod]
        public void Should_not_have_error_when_City_is_valid() {
            _validator.ShouldNotHaveValidationErrorFor(person => person.City, "Lisbon");
        }
        
        [TestMethod]
        public void Should_have_error_when_ListSelectedTapas_is_null() {
            _validator.ShouldHaveValidationErrorFor(param => param.ListSelectedTapas, null as string); 
        }
        
        [TestMethod]
        public void Should_have_error_when_ListSelectedTapas_is_invalid() {
            _validator.ShouldHaveValidationErrorFor(param => param.ListSelectedTapas, "fakelist"); 
        }
        
        [TestMethod]
        public void Should_have_error_when_ListSelectedTapas_is_less_than_3() {
            _validator.ShouldHaveValidationErrorFor(param => param.ListSelectedTapas, "Lisbon_1|Lisbon_2"); 
        }
        
        [TestMethod]
        public void Should_not_have_error_when_ListSelectedTapas_is_valid() {
            _validator.ShouldNotHaveValidationErrorFor(person => person.ListSelectedTapas, "Lisbon_1|Lisbon_2|Lisbon_3|Lisbon_4");
        }
    }
}