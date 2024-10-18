using Order_Flow.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Order_Flow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Get_Load); // Registrando o evento de carregamento do formulário
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ShowForm(new form_adicionar());
        }

        private void btn_historico_Click(object sender, EventArgs e)
        {
            ShowForm(new form_historico());
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ShowForm(new forms_editar());
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            ShowForm(new form_excluir());
        }

        private void Get_Load(object sender, EventArgs e)
        {
            LoadWorkers(); // Carregar os dados do banco
        }

        private void LoadWorkers()
        {
            Controller controller = new Controller();
            var res = controller.Get();

            grid.Rows.Clear();

            if (grid.Columns.Count == 0)
            {
                grid.Columns.Add("ID", "ID");
                grid.Columns.Add("productKey", "Chave do Produto");
                grid.Columns.Add("client", "Cliente");
                grid.Columns.Add("locate", "Local de Coleta");
                grid.Columns.Add("dateproductpost", "Data de Solicitação");
                grid.Columns.Add("status", "Status");
            }

            if (res != null && res.Any())
            {
                foreach (var order in res)
                {
                    grid.Rows.Add(order.id, order.productkey, order.client, order.locate, order.dateproductpost, order.status);
                }
            }
            else
            {
                MessageBox.Show("No Workers Found! Add Workers to view!");
                
            }
        }


        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            form.Parent = this;
            form.Location = new Point(0, 0);
            form.Show();
            form.BringToFront();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implementar ações quando a célula é clicada, se necessário
        }

    }
}
