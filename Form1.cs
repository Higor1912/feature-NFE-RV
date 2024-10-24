using Order_Flow.database;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Order_Flow
{
    public partial class Form1 : Form
    {
        private static readonly string apiKey = "http://router.project-osrm.org/route/v1/driving/-122.42,37.78;-122.45,37.91?overview=false\r\n";

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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        // Botão NFE (button1) - Gerar NFE
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dadosNFE = ObterDadosNFE(); // Método para obter dados da NFE
                string caminhoArquivo = @"C:\Users\User\Documents\Orderflow\Main\database\XMLFile1.xml"; // Caminho completo do arquivo XML
                GerarXML(dadosNFE, caminhoArquivo); // Gera o XML e salva no arquivo
                MessageBox.Show("NFE gerada e salva em: " + caminhoArquivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar NFE: " + ex.Message);
            }
        }

        // Método para obter os dados da NFE
        private dynamic ObterDadosNFE() 
        {
 
            return new
            {
                Emitente = new
                {
                    CNPJ = "12345678901234",
                    IE = "123456789",
                    Nome = "Empresa Exemplo",
                    Endereco = new
                    {
                        Logradouro = "Rua Exemplo",
                        Numero = "123",
                        Bairro = "Centro",
                        Cidade = "Cidade",
                        UF = "SP",
                        CEP = "12345678"
                    }
                },
                // Outros dados da NFE podem ser adicionados aqui...
            };
        }

        // Método para gerar e salvar o XML
        private void GerarXML(dynamic dadosNFE, string caminhoArquivo) // Usar dynamic aqui também
        {
            // Exemplo de construção do XML usando XElement
            XElement xmlNFE = new XElement("NFe",
                new XElement("Emitente",
                    new XElement("CNPJ", dadosNFE.Emitente.CNPJ),
                    new XElement("IE", dadosNFE.Emitente.IE),
                    new XElement("Nome", dadosNFE.Emitente.Nome),
                    new XElement("Endereco",
                        new XElement("Logradouro", dadosNFE.Emitente.Endereco.Logradouro),
                        new XElement("Numero", dadosNFE.Emitente.Endereco.Numero),
                        new XElement("Bairro", dadosNFE.Emitente.Endereco.Bairro),
                        new XElement("Cidade", dadosNFE.Emitente.Endereco.Cidade),
                        new XElement("UF", dadosNFE.Emitente.Endereco.UF),
                        new XElement("CEP", dadosNFE.Emitente.Endereco.CEP)
                    )
                )
            // Adicione outros elementos conforme necessário
            );

            // Salva o XML em um arquivo
            xmlNFE.Save(caminhoArquivo);
        }

        // Botão para roteirização de veículos (button2)
        private async void button2_Click(object sender, EventArgs e) // Botão de roteirização de veículos
        {
            try
            {
                string origem = "Rua Exemplo, Cidade"; // Pode ser substituído por valores dinâmicos
                string destino = "Avenida Exemplo, Cidade"; // Pode ser substituído por valores dinâmicos

                // Chamar a API de roteirização
                var rota = await RoteirizarVeiculosAsync(origem, destino);

                if (rota != null)
                {
                    // Exibir a rota no MessageBox (ou você pode exibir em outro controle, como um painel ou mapa)
                    MessageBox.Show("Roteirização realizada com sucesso!\n" + rota);
                }
                else
                {
                    MessageBox.Show("Erro ao calcular a rota.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular a rota: " + ex.Message);
            }
        }

        // Método para fazer a requisição à API de roteirização
        private async Task<string> RoteirizarVeiculosAsync(string origem, string destino)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={origem}&destination={destino}&key={apiKey}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(jsonResponse);

                        // Aqui você pode acessar as informações de rota
                        var rota = data["routes"]?[0]?["overview_polyline"]?["points"]?.ToString();

                        return rota ?? "Nenhuma rota encontrada.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer a solicitação da rota: " + ex.Message);
            }

            return null;
        }
    }
}
