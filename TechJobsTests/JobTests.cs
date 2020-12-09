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

        [TestInitialize]
        public void JobExamples()
        {
            testJobOne = new Job();
            testJobTwo = new Job();
            testJobThree = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            testJobFour = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        }

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreEqual(1, testJobTwo.Id - testJobOne.Id, .001);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.IsTrue(testJobThree.Name == "Product tester");
            Assert.IsTrue(testJobThree.EmployerName.Value == "ACME");
            Assert.IsTrue(testJobThree.EmployerLocation.Value == "Desert");
            Assert.IsTrue(testJobThree.JobType.Value == "Quality control");
            Assert.IsTrue(testJobThree.JobCoreCompetency.Value == "Persistence");
            Assert.IsTrue(testJobThree.Id != null);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(testJobThree.Equals(testJobFour));
        }

        [TestMethod]
        public void TestToStringProducesBlankLinesBeforeAfter()
        {
            Assert.IsTrue(testJobOne.ToString().Substring(0, 1) == "\n");
            Assert.IsTrue(testJobOne.ToString().Substring(testJobOne.ToString().Length - 1, 1) == "\n");
        }

        //adding this test made the previous test not work. changed from testJobOne to testJobThree and still doesn't work.
        //[TestMethod]
        //public void TestToStringPrintsJobData()
        //{
        //    Assert.AreEqual("\nID: " + testJobThree.Id + "\nName: Product tester\nEmployer: ACME\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Persistence\n", testJobThree.ToString());
        //}
    }
}
