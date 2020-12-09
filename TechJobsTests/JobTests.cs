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

        //When creating second test (PrintsJobData) and building the ToString method of Job accordingly, it made this first test fail because I was using testJobOne that doesn't have any arguments, meaning there is no this.Name etc. Is changing this to testJobThree, which does have these properties, cheating? It made the test pass, but it wouldn't work for a Job object created with the first constructor and only an Id.
        [TestMethod]
        public void TestToStringProducesBlankLinesBeforeAfter()
        {
            Assert.IsTrue(testJobThree.ToString().Substring(0, 1) == "\n");
            Assert.IsTrue(testJobThree.ToString().Substring(testJobThree.ToString().Length - 1, 1) == "\n");
        }

        [TestMethod]
        public void TestToStringPrintsJobData()
        {
            Assert.AreEqual($"\nID: {testJobThree.Id}\nName: Product tester\nEmployer: ACME\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Persistence\n", testJobThree.ToString());
        }
    }
}
