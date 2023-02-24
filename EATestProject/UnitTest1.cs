using AutoFixture.Xunit2;
using EATestProject.Model;
using EATestProject.Pages;
using FluentAssertions;

namespace EATestProject
{
    public class UnitTest1
    {
        private readonly IHomePage homePage;
        private readonly IProductPage productPage;

        public UnitTest1(IHomePage homePage, IProductPage productPage)
        {
            this.homePage = homePage;
            this.productPage = productPage;
        }

        [Theory, AutoData]
        public void Test1(Product product)
        {
            product.ProductyType = ProductType.PERIPHARALS; //Not randomly generating product type as expected so overloading product type

            //Seperation of concern
            homePage.CreateProduct();
            productPage.EnterProductDetails(product);
            homePage.PerformClickOnSpecialValue(product.Name, "Details");

            //assertion
            Product actualProduct = productPage.GetProductDetails();
            actualProduct.Should().BeEquivalentTo(product,
                options => options.Excluding(x => x.Id));
        }

        [Theory, AutoData]
        public void Test2(Product product)
        {
            //Seperation of concern
            homePage.CreateProduct();
            productPage.EnterProductDetails(product);
            homePage.PerformClickOnSpecialValue(product.Name, "Details");
        }

        [Theory, AutoData]
        public void Test3(Product product)
        {
            //Seperation of concern
            homePage.CreateProduct();
            productPage.EnterProductDetails(product);
            homePage.PerformClickOnSpecialValue(product.Name, "Details");
        }

        [Theory, AutoData]
        public void Test4(Product product)
        {
            //Seperation of concern
            homePage.CreateProduct();
            productPage.EnterProductDetails(product);
            homePage.PerformClickOnSpecialValue(product.Name, "Details");
        }
    }
}