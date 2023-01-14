using Logic;
using Logic.Companys;
using Logic.Companys.Request;
using Logic.Interface;
using Logic.System.ModelManager;
using UnitTest_Pl.Mocking;
using UnitTest_Pl.Mocking.Companys;

namespace UnitTest_Pl
{
    public class CompanyTest
    {
        private Company company;
        private ICompanyModelManager _companyModelManager;

        [SetUp]
        public void Setup()
        {

            _companyModelManager = new CompanyModelManager(new BinaryFileMock());
        }

        [Test]
        public void CompanyNameTest()
        {
            // Arrange
            string companyName = "Mosadex";

            // Act
            company = new Company(companyName);

            // Assert
            Assert.AreEqual(companyName, company.Name, "Company name should be set correctly");
        }

        [Test]
        public void CompanyAddWeeklyNeed_AddingExistingWeeklyNeed_ReturnsFalse()
        {
            // Arrange
            company = new Company("Mosadex");
            IWeeklyNeed weeklyNeed = new WeeklyNeedMock(3);
            IWeeklyNeed sameWeek = new WeeklyNeedMock(3);
            company.AddWeeklyNeed(weeklyNeed);

            // Act
            Result<string> result = company.AddWeeklyNeed(sameWeek);

            // Assert
            Assert.IsFalse(result.Success, $"Adding existing weekly need should have returned false, but got {result.Success}");
        }

        [Test]
        public void CompanyAddWeeklyNeed_AddingNewWeeklyNeed_ReturnsTrue()
        {
            // Arrange
            company = new Company("Mosadex");
            IWeeklyNeed weeklyNeed = new WeeklyNeedMock(3);
            IWeeklyNeed differentWeek = new WeeklyNeedMock(5);
            company.AddWeeklyNeed(differentWeek);


            Console.WriteLine();

            // Act
            Result<string> result = company.AddWeeklyNeed(weeklyNeed);

            Assert.IsTrue(result.Success, $"Adding non-existing weekly need should have returned true, but got {result.Success}");
        }

        [Test]
        public void CompanyModelManager_AddingNewCompany_ReturnsTrue()
        {
            // Arrange
            Company company = new Company("GorrilaGames");

            // Act
            Result<string> result = _companyModelManager.AddNewCompany(company);

            // Assert
            Assert.IsTrue(result.Success, $"Adding new company should have returned true, but got {result.Success}");
        }

        [Test]
        public void CompanyModelManager_AddingDuplicateCompany_ReturnsFalse()
        {
            // Arrange
            Company company1 = new Company("Tesla");

            // Act
            // Company Tesla already exist in the companymodelManager
            Result<string> result = _companyModelManager.AddNewCompany(company1);

            // Assert
            Assert.IsFalse(result.Success, $"Adding duplicate company should have returned false, but got {result.Success}");
        }
    }
}
