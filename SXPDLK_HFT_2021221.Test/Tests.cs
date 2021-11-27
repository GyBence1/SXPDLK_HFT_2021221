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
                ,Id=1
            };
            List<Guitar> guitars = new List<Guitar>()
            {
                new Guitar()
                    {
                        Id=1,
                        Model="LP3",
                        Brand=fakeBrand,
                        BrandId=fakeBrand.Id,
                        Price=10000,
                        Type=GuitarTypes.Electric
                    },
                    new Guitar()
                    {
                        Id=2,
                        Model="BC9",
                        Brand=fakeBrand,
                        BrandId=fakeBrand.Id,
                        Price=20000,
                        Type=GuitarTypes.Acoustic
                    },
                    new Guitar()
                    {
                        Id=3,
                        Model="GH1",
                        Brand=fakeBrand,
                        BrandId=fakeBrand.Id,
                        Price=15000,
                        Type=GuitarTypes.Electric
                    }
            };
            mockGuitarRepository.Setup(r => r.ReadAll()).Returns(guitars.AsQueryable()
                );
            mockGuitarRepository.Setup(r => r.Create(It.IsAny<Guitar>()));
            mockGuitarRepository.Setup(r => r.Delete(It.IsInRange(1,3,Moq.Range.Inclusive)));
            gl = new GuitarLogic(mockGuitarRepository.Object, mockBrandRepository.Object);
            #endregion
            #region MockPurchaseSetup
            var purchases = new List<Purchase>()
            {

                    new Purchase()
                    {
                        BuyerName="Buyer1",
                        BuyerCity="Budapest",
                        Guitar=guitars[0],
                        GuitarId=guitars[0].Id,
                        Id=1
                        ,BrandName=guitars[0].Brand.Name

                    },
                    new Purchase()
                    {
                        BuyerName="Buyer2",
                        BuyerCity="Budapest",
                        Guitar=guitars[1],
                        GuitarId=guitars[1].Id,
                        Id=2,
                        BrandName=guitars[1].Brand.Name
                    },
                    new Purchase()
                    {
                        BuyerName="Buyer3",
                        BuyerCity="Chicago",
                        Guitar=guitars[2],
                        GuitarId=guitars[2].Id,
                        Id=3,
                        BrandName=guitars[2].Brand.Name
                    }
            };
            mockPurchaseRepository.Setup(r => r.ReadAll()).Returns(purchases.AsQueryable());
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
        public void BuyerNamesByModelsTest()
        {
            var result = pl.BuyerNamesByGuitarModels();
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("LP3","Buyer1"),
                new KeyValuePair<string, string>("BC9","Buyer2"),
                new KeyValuePair<string, string>("GH1","Buyer3")
            };
            Assert.That(result, Is.EqualTo(expected));
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
        public void AVGModelsByBrandsTest()
        {
            var result = gl.AVGModelsByBrands();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Epiphone",3)
            };
            Assert.That(result, Is.EqualTo(expected));
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
        public void CreatePurchaseThrowsException(string name,bool shouldthrow)
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

