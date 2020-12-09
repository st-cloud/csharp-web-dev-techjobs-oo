using System;
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

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

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
            if (String.IsNullOrEmpty(Name))
            {
                return "\n\n";
            }

            //Is this a bad idea, to put them in an array? What if a new field is added later? Is there a way to account for this?
            //Is it incorrect to assign "Data not available" as the value? This changes the object rather than just changing how it prints.

            //CURRENTLY test 3 is not passing. instead of assigning "data not available" to empty fields, fields remain empty.
            string[] fields = { Name, EmployerName.Value, EmployerLocation.Value, JobType.Value, JobCoreCompetency.Value };

            for (int i = 0; i < fields.Length; i++)
            {
                if (String.IsNullOrEmpty(fields[i]))
                {
                    fields[i] = "Data not available";
                }
            }

            return $"\nID: {Id}\nName: {Name}\nEmployer: {EmployerName.Value}\nLocation: {EmployerLocation.Value}\nPosition Type: {JobType.Value}\nCore Competency: {JobCoreCompetency.Value}\n";
        }
    }
}
