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
    public partial class form_excluir : Form
    {
        public form_excluir()
        {
            InitializeComponent();
        }

        private void btn_delcancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
