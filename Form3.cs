using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Flow
{
    public partial class form_historico : Form
    {
        public form_historico()
        {
            InitializeComponent();
        }

        private void btn_histocancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
