using Moq;
using NUnit.Framework;
using SXPDLK_HFT_2021221.Logic;
using SXPDLK_HFT_2021221.Models;
using SXPDLK_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SXPDLK_HFT_2021221.Test
{
    [TestFixture]
    public class Tests
    {
        Mock<IGuitarRepository> mockGuitarRepository;
        Mock<IBrandRepository> mockBrandRepository;
        Mock<IPurchaseRepository> mockPurchaseRepository;
        GuitarLogic gl;
        PurchaseLogic pl;
        BrandLogic bl;
        [SetUp]
        public void Init()
        {
            #region GuitarRepoSetup
            mockGuitarRepository = new Mock<IGuitarRepository>();
            mockBrandRepository = new Mock<IBrandRepository>();
            mockPurchaseRepository = new Mock<IPurchaseRepository>();
            Brand fakeBrand = new Brand()
            {
                Name = "Epiphone"
            };
            mockGuitarRepository.Setup(r => r.ReadAll()).Returns(
                new List<Guitar>()
                {
                    new Guitar()
                    {
                        Id=1,
                        Model="LP3",
                        Brand=fakeBrand,
                        Price=10000,
                        Type=GuitarTypes.Electric
                    },
                    new Guitar()
                    {
                        Id=2,
                        Model="BC9",
                        Brand=fakeBrand,
                        Price=20000,
                        Type=GuitarTypes.Acoustic
                    },
                    new Guitar()
                    {
                        Id=3,
                        Model="GH1",
                        Brand=fakeBrand,
                        Price=15000,
                        Type=GuitarTypes.Electric
                    }
                }.AsQueryable()
                );
            mockGuitarRepository.Setup(r => r.Create(It.IsAny<Guitar>()));
            mockGuitarRepository.Setup(r => r.Delete(It.IsInRange(1,3,Moq.Range.Inclusive)));
            gl = new GuitarLogic(mockGuitarRepository.Object, mockBrandRepository.Object);
            #endregion
            #region MockPurchaseSetup
            mockPurchaseRepository.Setup(r => r.ReadAll()).Returns(
                new List<Purchase>()
                {
                    new Purchase()
                    {
                        BuyerName="Buyer1",
                        BuyerCity="Budapest",
                        Guitar=mockGuitarRepository.Object.ReadAll().ToArray()[0]
                    },
                    new Purchase()
                    {
                        BuyerName="Buyer2",
                        BuyerCity="Budapest",
                        Guitar=mockGuitarRepository.Object.ReadAll().ToArray()[1]
                    },
                    new Purchase()
                    {
                        BuyerName="Buyer3",
                        BuyerCity="Chicago",
                        Guitar=mockGuitarRepository.Object.ReadAll().ToArray()[2]
                    }
                }.AsQueryable()
                );
            mockPurchaseRepository.Setup(r => r.Create(It.IsAny<Purchase>()));
            pl = new PurchaseLogic(mockGuitarRepository.Object, mockBrandRepository.Object, mockPurchaseRepository.Object);
            #endregion
            mockBrandRepository.Setup(r => r.Create(It.IsAny<Brand>()));
            bl = new BrandLogic(mockBrandRepository.Object);
            
        }
        [Test]
        public void AVGPriceByBrandsTest()
        {
            var result = gl.AVGPriceByBrands();
            var expected = new List
               <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("Epiphone", 15000)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void AVGPriceByTypesTest()
        {
            var result = gl.AVGPriceByTypes();
            var expect = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Electric",12500),
                new KeyValuePair<string, double>("Acoustic",20000)
            };
            Assert.That(result, Is.EqualTo(expect));
        }
        [Test]
        public void BuyerNamesByBrandsTest()
        {
            var result = pl.BuyerNamesByBrands();
            var expected = new List<KeyValuePair<string, List<string>>>()
            {
                new KeyValuePair<string, List<string>>("Epiphone",new List<string>(){"Buyer1","Buyer2","Buyer3" })
            };
        }
        [Test]
        public void AVGPricebyCitiesTest()
        {
            var result = pl.AVGPriceByCities();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Budapest",15000),
                new KeyValuePair<string, double>("Chicago",15000)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void ModelsByBrandsTest()
        {
            var result = gl.GuitarModelsByBrands();
            var expected = new List<KeyValuePair<string, List<string>>>()
            {
                new KeyValuePair<string, List<string>>("Epiphone",new List<string>(){"LP3", "BC9", "GH1" })
            };
        }
        [TestCase(3000, false)]
        [TestCase(-1000, true)]
        public void CreateGuitarThrowsException(int price, bool shouldthrow)
        {
            Guitar c = new Guitar()
            {
                Model = "Telecaster",
                Price = price
            };
            if (shouldthrow)
            {
                Assert.That(() => gl.Create(c), Throws.Exception);
                mockGuitarRepository.Verify(m => m.Create(c), Times.Never);
            }
            else
            {
                Assert.That(() => gl.Create(c), Throws.Nothing);
                mockGuitarRepository.Verify(m => m.Create(c), Times.Once);
            }
        }
        [TestCase("Soundstation", false)]
        [TestCase(null, true)]
        public void CreateBrandThrowsException(string name, bool shouldthrow)
        {
            Brand c = new Brand()
            {
                Name=name
            };
            if (shouldthrow)
            {
                Assert.That(() => bl.Create(c), Throws.Exception);
                mockBrandRepository.Verify(m => m.Create(c), Times.Never);
            }
            else
            {
                Assert.That(() => bl.Create(c), Throws.Nothing);
                mockBrandRepository.Verify(m => m.Create(c), Times.Once);
            }
        }
        [TestCase("Buyer", false)]
        [TestCase(null, true)]
        public void CreatePurchaseThrowsException(string name, bool shouldthrow)
        {
            Purchase c = new Purchase()
            {
                BuyerName = name
            };
            if (shouldthrow)
            {
                Assert.That(() => pl.Create(c), Throws.Exception);
                mockPurchaseRepository.Verify(m => m.Create(c), Times.Never);
            }
            else
            {
                Assert.That(() => pl.Create(c), Throws.Nothing);
                mockPurchaseRepository.Verify(m => m.Create(c), Times.Once);
            }
        }
        [TestCase(0, false)]
        [TestCase(9999, true)]
        public void DeleteGuitarThrowsException(int id, bool shouldthrow)
        {
            if (shouldthrow)
            {
                Assert.That(() => gl.Delete(id), Throws.Exception);
                mockGuitarRepository.Verify(m => m.Delete(id), Times.Never);
            }
            else
            {
                Assert.That(() => gl.Delete(id), Throws.Nothing);
                mockGuitarRepository.Verify(m => m.Delete(id), Times.Once);
            }
        }
        [TestCase("Something",false)]
        [TestCase(null,true)]
        public void UpdateGuitarThrowsException(string name, bool shouldthrow)
        {
            Guitar c = new Guitar()
            {
                Model=name
            };
            if (shouldthrow)
            {
                Assert.That(() => gl.Update(c), Throws.Exception);
                mockGuitarRepository.Verify(m => m.Update(c), Times.Never);
            }
            else
            {
                Assert.That(() => gl.Update(c), Throws.Nothing);
                mockGuitarRepository.Verify(m => m.Update(c), Times.Once);
            }
        }
    }
}

