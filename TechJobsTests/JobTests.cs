using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job testJobOne;
        Job testJobTwo;
        Job testJobThree;
        Job testJobFour;
        Job testJobFive;

        [TestInitialize]
        public void JobExamples()
        {
            testJobOne = new Job();
            testJobTwo = new Job();
            testJobThree = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            testJobFour = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            testJobFive = new Job("Product tester", new Employer(""), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency(""));
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreEqual(1, testJobTwo.Id - testJobOne.Id, .001);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.IsTrue(testJobThree.Id != null);
            Assert.IsTrue(testJobThree.Name == "Product tester");
            Assert.IsTrue(testJobThree.EmployerName.Value == "ACME");
            Assert.IsTrue(testJobThree.EmployerLocation.Value == "Desert");
            Assert.IsTrue(testJobThree.JobType.Value == "Quality control");
            Assert.IsTrue(testJobThree.JobCoreCompetency.Value == "Persistence");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(testJobThree.Equals(testJobFour));
        }

        [TestMethod]
        public void TestToStringProducesBlankLinesBeforeAfter()
        {
            //empty Job object
            Assert.IsTrue(testJobOne.ToString().Substring(0, 1) == "\n");
            Assert.IsTrue(testJobOne.ToString().Substring(testJobOne.ToString().Length - 1, 1) == "\n");

            //Job object with properties
            Assert.IsTrue(testJobThree.ToString().Substring(0, 1) == "\n");
            Assert.IsTrue(testJobThree.ToString().Substring(testJobThree.ToString().Length - 1, 1) == "\n");
        }

        [TestMethod]
        public void TestToStringPrintsJobData()
        {
            Assert.AreEqual($"\nID: {testJobThree.Id}\nName: Product tester\nEmployer: ACME\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Persistence\n", testJobThree.ToString());
        }

        [TestMethod]
        public void TestToStringEmptyField()
        {
            Assert.AreEqual($"\nID: {testJobFive.Id}\nName: Product tester\nEmployer: Data not available\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Data not available\n", testJobFive.ToString());
        }
    }
}
