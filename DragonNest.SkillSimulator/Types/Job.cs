using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonNest.ResourceInspection.dnt;
using System.Data;
using System.Xml;
namespace DragonNest.SkillSimulator.Types
{
    using Dnt = DragonNestDataTable;

    public class Job
    {
        //Job Table Column Names { jobtable.dnt }
        const string RowIdColumnId = "_JobName";
        const string ServiceColumnId = "_Service";
        const string ParentColumnId = "_ParentJob";
        const string RowColumnId = "Row Id";
        //SKill Table Column Names { skilltable_character.dnt}
        const string NeedJobId = "_NeedJob";
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

        public Job(int jobId, Dnt jobTable, Dnt classTable, Dnt skilltable, XmlDocument uiString) : this()
        {
            //Check to make sure nothing is null
            if (jobTable == null)
                throw new ArgumentNullException("JobTable");
            if (jobTable.Rows == null)
                throw new ArgumentNullException("JobTable.Rows");
            if (classTable == null)
                throw new ArgumentNullException("ClassTable");

            //Initilization
            List<DataRow> Jobs = new List<DataRow>();

            //Get Information pertaining to the Job.
            var JobTableRows = jobTable.Rows.Cast<DataRow>();
            for (int i = jobId; i != 0; i = Convert.ToInt32(Jobs.Last()[ParentColumnId])) 
                Jobs.Add( JobTableRows.First(p => p[RowIdColumnId].Equals(jobId)));




            


        }
    }
}
