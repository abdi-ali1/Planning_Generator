using System.Reflection.Metadata;
using Logic.Companys;
using Logic.Employee;
using NUnit.Framework;

namespace UnitTest_Pl
{
    public class CompanyTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Mosadex")]
        [TestCase("Vista")]
        [TestCase("GorrilaGames")]
        public void CompanyNameTest(string name)
        {
            //arrange

            // act
            Company company = new Company(name);

            //assert
            Assert.AreEqual(name, company.Name);
        }


        [Test]
        public void CompanyAddWeeklyNeed()
        {




        }


    }
}