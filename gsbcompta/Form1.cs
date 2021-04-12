using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsbcompta
{
    public partial class Form1 : Form
    {
        Bdd bdd;
        ListeFiches form;
        public Form1()
        {
            InitializeComponent();
            bdd = new Bdd();
         
           
            this.dataGridView1.DataSource = bdd.getBindingSource();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            form = new ListeFiches();
            form.Show();
        }
    }
}
