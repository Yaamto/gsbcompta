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
    public partial class ListeFiches : Form
    {

        Bdd bdd;
        ListeFiches form;
        public ListeFiches()
        {
            InitializeComponent();
            bdd = new Bdd();
           
            
            this.dataGridView1.DataSource = bdd.getBindingSource1();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                MessageBox.Show(dgv.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}
