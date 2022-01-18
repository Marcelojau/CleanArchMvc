using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domains.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateProdcut_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. too short, minimum 3 characters");
        }


        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, "product kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk imagedasklldkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");

            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainExcpetion()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, null);

            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();
                
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, null);

            action.Should()
                .NotThrow<NullReferenceException>();

        }

        [Fact]
        public void CreateProduct_WithEmptymageName_NoDomainExcpetion()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, "");

            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();

        }


        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, value, "");

            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

    }
}
