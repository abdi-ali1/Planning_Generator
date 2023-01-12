using Logic;
using Logic.Companys;
using Logic.Employee;
using Logic.Employee.Degrees;
using Logic.Enum;
using Logic.Interface;
using Logic.Schedules.Staff;
using Logic.Shifts.Availibiltiy;
using Logic.System.ModelManager;
using UnitTest_Pl.Mocking;

namespace UnitTest_Pl
{
    public class StaffMemeberTest
    {
        private StaffMember staff;
        private Company company;
        private IStaffMemberModelManager modelManager;
        private IBinaryFileManager binaryFileManager;

        [SetUp]
        public void SetUp()
        {
            //company
            string companyName = "GorrilaGames";
            company = new Company(companyName);

            //staff
            string username = "hokage";
            string staffName = "naruto uzumaki";
            Gender gender = Gender.Male;
            CompanyRole companyRole = CompanyRole.Manager;
            Occupation occupation = Occupation.Picker;
            DateTime birthdate = new DateTime(1990, 1, 1);
            Degree degree = new Degree("Hbo Ict", 7);
            staff = new StaffMember(username, staffName, gender, companyRole, occupation, birthdate, degree);

            binaryFileManager = new BinaryFileMock();
            modelManager = new StaffMemberModelManager(binaryFileManager);


        }

        [Test]
        public void GivenStaff_WhenCreatingStaff_ThenPropertiesShouldBeSetCorrectly()
        {
            // Assert
            Assert.AreEqual("hokage", staff.Username, "Username should be set correctly");
            Assert.AreEqual("naruto uzumaki", staff.Name, "Name should be set correctly");
            Assert.AreEqual(Gender.Male, staff.Gender, "Gender should be set correctly");
            Assert.AreEqual(CompanyRole.Manager, staff.Role, "Role should be set correctly");
            Assert.AreEqual(Occupation.Picker, staff.Occaption, "Occupation should be set correctly");

        }

        [Test]
        public void GivenNewSchedule_WhenAddingSchedule_ThenReturnOk()
        {
            Company company = new Company("GorrilaGames");
            // Arrange
            StaffSchedule schedule = new StaffSchedule(3, company);

            // Act
            Result<string> result = staff.AddSchedule(schedule);

            // Assert
            Assert.IsTrue(result.Success, "Adding new schedule should have returned OK, but got " + result.Exception);
        }

        [Test]
        public void GivenExistingSchedule_WhenAddingSchedule_ThenReturnFail()
        {
            // Arrange
            StaffSchedule schedule = new StaffSchedule(3, company);
            staff.AddSchedule(schedule);

            // Act
            Result<string> result = staff.AddSchedule(schedule);

            // Assert
            Assert.IsFalse(result.Success, "Adding existing schedule should have returned fail, but got " + result.Exception);
        }

        [Test]
        public void GivenNewAvailability_WhenAddingAvailability_ThenReturnOk()
        {
            // Arrange
            AvailabilityStaff availability = new AvailabilityStaff(3, company);

            // Act
            Result<string> result = staff.AddAvailibilty(availability);

            // Assert
            Assert.IsTrue(result.Success, "Adding new availability should have returned OK, but got " + result.Exception);
        }

        [Test]
        public void GivenExistingAvailability_WhenAddingAvailability_ThenReturnFail()
        {
            // Arrange
            AvailabilityStaff availability = new AvailabilityStaff(3, company);
            staff.AddAvailibilty(availability);

            // Act
            Result<string> result = staff.AddAvailibilty(availability);

            // Assert
            Assert.IsFalse(result.Success, "Adding new availability should have returned Fail, but got " + result.Exception);
        }

        [Test]
        public void GivenNewStaffMember_WhenAddingToList_ThenReturnTrue()
        {
            // Act
            Result<string> result = modelManager.AddNewStaff(staff);

            // Assert
            Assert.IsTrue(result.Success, $"Adding new staff member should have returned true, but got {result.Success}");
        }

        [Test]
        public void GivenDuplicateStaffMember_WhenAddingToList_ThenReturnFalse()
        {
            // Arrange
            modelManager.AddNewStaff(staff);
            StaffMember duplicateStaff = new StaffMember("hokage", "Naruto Uzumaki", Gender.Male, CompanyRole.Manager, Occupation.Driver, new DateTime(1990, 1, 1), new Degree("Hbo Ict", 7));

            // Act
            Result<string> result = modelManager.AddNewStaff(duplicateStaff);

            // Assert
            Assert.IsFalse(result.Success, $"Adding duplicate staff member should have returned false, but got {result.Success}");
        }

    }
}

