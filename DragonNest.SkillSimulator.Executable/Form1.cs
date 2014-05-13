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
        public Form1()
        {
            InitializeComponent();
        }

        void init()
        {
            using(var stream = new MemoryStream(DNTResources.skilltable_character))
                SkillTableCharacter = new DragonNestDataTable();
        }

    }
}
