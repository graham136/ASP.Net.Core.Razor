using NUnit.Framework;
using Asp.Net.Core.Razor.Api.Data;
using Asp.Net.Core.Razor.Models;
using System;
using Asp.Net.Core.Razor.Api.Interfaces;
using Moq;
using Asp.Net.Core.Razor.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ControllerTests
{
    class ControllerTests
    {

        [Test]
        public void TestPersonalTaxGetAllItems()
        {
            //Arrange
            var PersonalTaxesDataMock = new Mock<IDataRepository<PersonalTax>>();
            var TaxLogicMock = new Mock<ICalculate>();
            var PersonalTaxController = new PersonalTaxController(PersonalTaxesDataMock.Object,TaxLogicMock.Object);

            //Act
            var result = PersonalTaxController.Get();

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            
        }

        [Test]
        public void TestPersonalTaxGetById()
        {
            //Arrange
            var PersonalTaxesDataMock = new Mock<IDataRepository<PersonalTax>>();
            var TaxLogicMock = new Mock<ICalculate>();
            var PersonalTaxController = new PersonalTaxController(PersonalTaxesDataMock.Object, TaxLogicMock.Object);

            //Act
            var result = PersonalTaxController.Get(0);

            //Assert
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);

        }

        [Test]
        public void TestPersonalTaxAddItem()
        {
            //Arrange
            var PersonalTaxesDataMock = new Mock<IDataRepository<PersonalTax>>();
            var TaxLogicMock = new Mock<ICalculate>();
            var PersonalTaxController = new PersonalTaxController(PersonalTaxesDataMock.Object, TaxLogicMock.Object);

            //Act
            var result = PersonalTaxController.Post(new PersonalTax());

            //Assert
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);

        }

        [Test]
        public void TestPersonalTaxDeleteItem()
        {
            //Arrange
            var PersonalTaxesDataMock = new Mock<IDataRepository<PersonalTax>>();
            var TaxLogicMock = new Mock<ICalculate>();
            var PersonalTaxController = new PersonalTaxController(PersonalTaxesDataMock.Object, TaxLogicMock.Object);

            //Act
            var result = PersonalTaxController.Delete(0);

            //Assert
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Test]
        public void TestPersonalTaxUpdateItem()
        {
            //Arrange
            var PersonalTaxesDataMock = new Mock<IDataRepository<PersonalTax>>();
            var TaxLogicMock = new Mock<ICalculate>();
            var PersonalTaxController = new PersonalTaxController(PersonalTaxesDataMock.Object, TaxLogicMock.Object);

            //Act
            var result = PersonalTaxController.Put(1,new PersonalTax());

            //Assert
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

    }
}
