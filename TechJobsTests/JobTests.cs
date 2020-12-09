using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job testJobOne = new Job();
            Job testJobTwo = new Job();

            Assert.AreEqual(1, testJobTwo.Id - testJobOne.Id, .001);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testJob = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.IsTrue(testJob.Name == "Product tester");
            Assert.IsTrue(testJob.EmployerName.Value == "ACME");
            Assert.IsTrue(testJob.EmployerLocation.Value == "Desert");
            Assert.IsTrue(testJob.JobType.Value == "Quality control");
            Assert.IsTrue(testJob.JobCoreCompetency.Value == "Persistence");
            Assert.IsTrue(testJob.Id != null);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job testJobOne = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job testJobTwo = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.IsFalse(testJobOne.Equals(testJobTwo));
        }
    }
}
