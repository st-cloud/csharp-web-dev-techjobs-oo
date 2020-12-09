using System;
namespace TechJobsOO
{
    public class Employer : JobField
    { 
        //having only this constructor (as directed in textbook) gives me an error in my JobTests class because it says I am not allowed to have an Employer object with no value when creating testJobFive. I added an empty string ("") but is this an issue? (same with Core Competency)
        //book says "The empty constructor is shared, but not the second." it doesn't seem to be shared here?
        public Employer(string value) : base(value)
        {
        }
    }
}
