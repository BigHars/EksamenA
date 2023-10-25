using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        #region test initialize
        private WoodPellet? instance;

        [TestInitialize]
        public void TestInitialize()
        {
            //arrange
            instance = new WoodPellet();
        }
        #endregion

        #region brand property tests
        [TestMethod()]
        [DataRow("Bi")]
        [DataRow("Bio")]
        [DataRow("BioWood")]
        public void BrandPropertyTestOk(string validBrand)
        {
            //act
            instance.Brand = validBrand;

            //assert
            Assert.AreEqual(validBrand, instance.Brand);
        }

        [TestMethod()]
        [DataRow("")]
        [DataRow("B")]
        [DataRow(null)]
        public void BrandPropertyTestFail(string invalidBrand)
        {
            //act & assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => instance.Brand = invalidBrand);
        }
        #endregion

        #region quality property test
        [TestMethod()]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        public void QualityPropertyTestOk(int validQuality)
        {
            //act
            instance.Quality = validQuality;

            //assert
            Assert.AreEqual(validQuality, instance.Quality);
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(6)]
        public void QualityPropertyTestFail(int invalidQuality)
        {
            //act & assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>  instance.Quality = invalidQuality);
        }
        #endregion
    }
}