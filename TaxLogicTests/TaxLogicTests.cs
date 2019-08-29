using NUnit.Framework;
using Asp.Net.Core.Razor.Api.Data;
using Asp.Net.Core.Razor.Models;
using System;

namespace TaxLogicTests
{
    public class TaxLogicTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void FlatRateTaxTest()
        {
            //Arrange
            TaxLogic taxLogic = new TaxLogic();
            //Act
            var result = taxLogic.calculateFlatRate(1000000);
            //Assert
            Assert.AreEqual(result, 175000);            
        }

        [Test]
        public void FlatValueTaxTest()
        {
            //Assert
            TaxLogic taxLogic = new TaxLogic();
            //Act
            var result = taxLogic.calculateFlatValue(1000000);
            //Assert
            Assert.AreEqual(result, 10000);
        }

        [Test]
        public void ProgressiveTaxTest()
        {
            //Arrange
            TaxLogic taxLogic = new TaxLogic();
            //Act
            var result = taxLogic.calculateProgressive(1000000);
            result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
            //Assert
            Assert.AreEqual(result, 327682.49m);
        }

        [Test]
        public void CodeFlatRateTaxTest700()
        {
            //Arrange
            TaxLogic taxLogic = new TaxLogic();
            //Act
            var result = taxLogic.calculateTax(TaxCodeTypes.FlatRate ,1000000);
            //Assert
            Assert.AreEqual(result, 175000);
        }

        [Test]
        public void CodeFlatValueTaxTestA100()
        {
            //Assert
            TaxLogic taxLogic = new TaxLogic();
            //Act
            var result = taxLogic.calculateTax(TaxCodeTypes.FlatValue, 1000000);
            //Assert
            Assert.AreEqual(result, 10000);
        }

        [Test]
        public void CodeProgressiveTaxTest7441()
        {
            //Arrange
            TaxLogic taxLogic = new TaxLogic();
            //Act
            var result = taxLogic.calculateTax(TaxCodeTypes.ProgressiveA, 1000000);
            result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
            //Assert
            Assert.AreEqual(result, 327682.49m);
        }

        [Test]
        public void CodeProgressiveTaxTest1000()
        {
            //Arrange
            TaxLogic taxLogic = new TaxLogic();
            //Act
            var result = taxLogic.calculateTax(TaxCodeTypes.PorgressiveB, 1000000);
            result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
            //Assert
            Assert.AreEqual(result, 327682.49m);
        }


    }
}