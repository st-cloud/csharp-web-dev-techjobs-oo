using System;
using System.Collections.Generic;

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
            //accounts for Job object created with first constructor (only Id)
            if (String.IsNullOrEmpty(Name))
            {
                return "\n\n";
            }
        
            List<string> fields = new List<string> { Name, EmployerName.Value, EmployerLocation.Value, JobType.Value, JobCoreCompetency.Value };

            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i] == null || fields[i] == "")
                {
                    fields[i] = "Data not available";
                }
            }

            return $"\nID: {Id}\nName: {fields[0]}\nEmployer: {fields[1]}\nLocation: {fields[2]}\nPosition Type: {fields[3]}\nCore Competency: {fields[4]}\n";
        }
    }
}
