using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonNest.ResourceInspection.dnt;
using System.Data;
namespace DragonNest.SkillSimulator.Types
{
    using Dnt = DragonNestDataTable;

    public class Job
    {
        const string RowIdColumnId = "_JobName";
        const string ServiceColumnId = "_Service";
        public String Name
        {
            get;
            set;
        }

        public int JobId
        {
            get;
            set;
        }

        public Job ()
        {
            Name = String.Empty;
            JobId = new int();
        }

        public Job(int ClassId, Dnt JobTable, Dnt ClassTable)
        {
            //Check to make sure nothing is null
            if (JobTable == null)
                throw new ArgumentNullException("JobTable");
            if (ClassTable == null)
                throw new ArgumentNullException("ClassTable");

            //Get Information pertaining to the Job.
            var JobRow = JobTable.Rows.Cast<DataRow>().FirstOrDefault(p => p[RowIdColumnId].Equals(ClassId));

            //If we cannot find that information throw exception
            if (JobRow == null)
                throw new Exception("Not Such Class Id");

            //If we find the information but its not active, most likely the information pertaining to the skill tree is incomplete.
            //Throw an error to prevent unexpected behaviour.
            if (JobRow[ServiceColumnId].Equals(false))
                throw new Exception("The Class you specified is not in Service");
        }
    }
}
