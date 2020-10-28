using System;
using System.Linq;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employeeName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employeeName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            string returnValue = "\n";
            int count = 0;
            int index = 0;
            returnValue += "ID: " + Id + "\n";
            returnValue += "Name: " + returnValToString<string>(Name);
            returnValue += "Employer: " + returnValToString<Employer>(EmployerName);
            returnValue += "Location: " + returnValToString<Location>(EmployerLocation);
            returnValue += "Position Type: " + returnValToString<PositionType>(JobType);
            returnValue += "Core Competency: " + returnValToString<CoreCompetency>(JobCoreCompetency) + "\n";
            while (index != -1)
            {
                index = returnValue.IndexOf("Data not available", index);
                if (index != -1)
                {
                    count++;
                    index++;
                }
            }
            if (count == 5) returnValue = "\nOOPS! This job does not seem to exist.\n";
            return returnValue;
        }
        public string returnValToString<T>(T obj)
        {
            string returnVal = "";
            try
            {
                string temp = obj.ToString();
                if (temp == "" || temp == null)
                    returnVal = "Data not available";
                else
                    returnVal = temp;
            }
            catch(NullReferenceException)
            {
                returnVal = "Data not available";
            }
            return returnVal + "\n";
        }
    }
}
