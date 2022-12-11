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
        public void CompanyNameTest()
        {
            //arrange
            string name = "Mosadex";

            // act
            Company company = new Company(name);

            //assert
            Assert.AreEqual("Mosadex", company.Name);
        }


        [Test]
        public void CompanyAddWeeklyNeed()
        {




        }


    }
}