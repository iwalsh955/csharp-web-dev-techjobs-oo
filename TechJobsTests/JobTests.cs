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
            Job j1 = new Job();
            Job j2 = new Job();
            Assert.IsTrue(j1.Id != j2.Id);
            Assert.IsTrue(j2.Id - j1.Id == 1);
        }
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job j1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));
            Assert.IsTrue(j1.Name == "Product tester");
            Assert.IsTrue(j1.EmployerName.Value== "ACME");
            Assert.IsTrue(j1.EmployerLocation.Value == "Desert");
            Assert.IsTrue(j1.JobType.Value == "Quality control");
            Assert.IsTrue(j1.JobCoreCompetency.Value == "Persistence");
        }
        [TestMethod]
        public void TestJobsForEquality()
        {
            Job j1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));
            Job j2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));
            Assert.IsTrue(j1.Equals(j2)==false);
        }
        [TestMethod]
        public void TestJobToStringNewLines()
        {
            Job j1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));
            string text = j1.ToString();
            Assert.IsTrue(text.StartsWith("\n"));
            Assert.IsTrue(text.EndsWith("\n"));
        }
        [TestMethod]
        public void TestJobToStringHasLabelAndData()
        {
            Job j1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));
            string text = j1.ToString();
            Assert.IsTrue(text.Contains("ID: "+ j1.Id + "\n"));
            Assert.IsTrue(text.Contains("Name: " + j1.Name + "\n"));
            Assert.IsTrue(text.Contains("Employer: " + j1.EmployerName.Value + "\n"));
            Assert.IsTrue(text.Contains("Location: " + j1.EmployerLocation.Value + "\n"));
            Assert.IsTrue(text.Contains("Position Type: " + j1.JobType.Value + "\n"));
            Assert.IsTrue(text.Contains("Core Competency: " + j1.JobCoreCompetency.Value + "\n"));
        }
        [TestMethod]
        public void TestJobToStringHasDataNotAvailable()
        {
            Job j1 = new Job("Product tester", new Employer(), new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));
            string text = j1.ToString();
            Assert.IsTrue(text.Contains("Employer: Data not available"));
        }
        [TestMethod]
        public void TestJobToStringOopsJobDosntExist()
        {
            Job j1 = new Job();
            string text = j1.ToString();
            Assert.IsTrue(text == "\nOOPS! This job does not seem to exist.\n");
            Job j2 = new Job("", new Employer(), new Location(), new PositionType()
                , new CoreCompetency());
            text = j2.ToString();
            Assert.IsTrue(text == "\nOOPS! This job does not seem to exist.\n");
        }
    }
}
