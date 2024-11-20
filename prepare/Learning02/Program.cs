using System;

class Program
{
    static void Main(string[] args)
    {
        // Create job instances
        Job job1 = new Job();
        job1._jobTitle = "Data Analyst";
        job1._company = "Amazon";
        job1._startYear = 2018;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Project Manager";
        job2._company = "Tesla";
        job2._startYear = 2021;
        job2._endYear = 2024;

        // Create a resume instance
        Resume resume = new Resume();
        resume._name = "Jane Smith";

        // Add jobs to the resume
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        // Display the resume
        resume.DisplayResume();
    }
}
