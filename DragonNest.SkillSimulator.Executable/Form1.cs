using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DragonNest.ResourceInspection.dnt;
using DragonNest.SkillSimulator.Executable;
namespace DragonNest.SkillSimulator.Executable
{
    public partial class Form1 : Form
    {

        DataTable SkillTableCharacter;
        DataTable SkillTableCleric;
        public Form1() 
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            using(var stream = new MemoryStream(DNTResources.skilltable_character))
                SkillTableCharacter = new DragonNestDataTable(stream);

            using (var stream = new MemoryStream(DNTResources.skillleveltable_charactercleric))
                SkillTableCleric = new DragonNestDataTable(stream);

            var viewable = SkillTableCharacter.Clone();
            viewable.Rows.Clear();
            
            var rows = SkillTableCharacter.Rows.Cast<DataRow>();
            foreach (var row in rows.Where(r => r["_NeedJob"].Equals(4)))
                viewable.ImportRow(row);

            dataGridView1.DataSource = viewable;
        }

    }
}
