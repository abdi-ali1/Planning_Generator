using System.Reflection.Metadata;
using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using NUnit.Framework;
using UnitTest_Pl.Mocking.Companys;

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

            // act
            Company company = new Company(name);

            //assert
            Assert.AreEqual(name, company.Name);
        }


        [Test]
        public void CompanyAddWeeklyNeedTestExist()
        {

            // arrange 
            Company company = new Company("Mosadex");
            IWeeklyNeed weekly = new WeeklyNeedMock(new DateTime(2023, 1, 2));


            //act
            bool isAdded = company.AddWeeklyNeed(weekly).Success;

            //assert
            Assert.IsTrue(isAdded);

        }

        [Test]
        public void CompanyAddWeeklyNeedTestDoesntExist()
        {

            // arrange 
            Company company = new Company("Mosadex");
            IWeeklyNeed weekly = new WeeklyNeedMock(new DateTime(2023, 1, 2));
            company.AddWeeklyNeed(weekly);


            //act
            bool isAdded = company.AddWeeklyNeed(weekly).Success;


            //assert
            Assert.IsFalse(isAdded);

        }

  




    }
}