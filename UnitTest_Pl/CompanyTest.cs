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
            //arrange

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
            IWeeklyNeed weekly = new WeeklyNeedMock();


            //act
           bool isAdded = company.AddWeeklyNeed(weekly);

            //assert
            Assert.IsTrue(isAdded);

        }

        [Test]
        public void CompanyAddWeeklyNeedTestDoesntExist()
        {

            // arrange 
            Company company = new Company("Mosadex");
            IWeeklyNeed weekly = new WeeklyNeedMock();


            //act
              company.AddWeeklyNeed(weekly);
            bool isAdded = company.AddWeeklyNeed(weekly);

            //assert
            Assert.IsFalse(isAdded);

        }

        [Test]
        public void CompanyAddWeeklyNeedTestExistInList()
        {
            // arrange 
            Company company = new Company("Mosadex");
            IWeeklyNeed weekly = new WeeklyNeedMock();


            //act
            company.AddWeeklyNeed(weekly);
            bool isAdded = company.AddWeeklyNeed(weekly);

            //assert
            Assert.AreEqual(weekly, company.WeeklyNeed[0]);

        }




    }
}