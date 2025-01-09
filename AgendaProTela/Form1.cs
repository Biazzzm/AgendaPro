
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Windows.Forms;

namespace AgendaProTela
{
    public partial class Form1 : Form
    {
        private readonly AgendaProApiClient agendaProApiClient;

        public Form1()
        {
            InitializeComponent();

            agendaProApiClient = new AgendaProApiClient();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

        }

        private async void btnSalvarPost_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                var contato = agendaProApiClient.PostContactAsync(NameTextBox.Text, emailtextbox.Text, teltextBox3.Text).Result;

                if (contato != null)
                {
                    MessageBox.Show("Contato salvo com sucesso!");

                    CarregarDatagrid();
                  
                }
                else
                {
                    MessageBox.Show("Erro ao salvar contato.");
                }
            }

            else
            {
                var contatoExistente = await agendaProApiClient.GetContactsByIdAsync(idTextBox.Text);

                if (contatoExistente != null)
                {
                    string nomeAtualizado = string.IsNullOrEmpty(NameTextBox.Text) ? contatoExistente.Name : NameTextBox.Text;

                    string emailAtualizado = string.IsNullOrEmpty(emailtextbox.Text) ? contatoExistente.Email : NameTextBox.Text;

                    string phoneAtualizado = string.IsNullOrEmpty(teltextBox3.Text) ? contatoExistente.Phone : NameTextBox.Text;

                    var message = $"Deseja atualizar contato com matrícula {idTextBox.Text}?";

                    const string caption = "Form Closing";

                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var sucesso = await agendaProApiClient.UpdateAsync(idTextBox.Text, NameTextBox.Text, emailtextbox.Text, teltextBox3.Text);

                        if (sucesso)
                        {
                            MessageBox.Show("Contato atualizado com sucesso");
                            CarregarDatagrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contato não encontrado! ");
                    }


                }

               


            }
            LimparTexto();
        }


        private async void btnDeletar_Click(object sender, EventArgs e)
        {
            var contatoExistente = await agendaProApiClient.GetContactsByIdAsync(idTextBox.Text);

            if (contatoExistente != null)
            {
                var message = $"Deseja deletar contato com matrícula {idTextBox.Text}?";

                const string caption = "Form Closing";

                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    bool sucesso = await agendaProApiClient.DeleteAsync(idTextBox.Text);
                    CarregarDatagrid();

                    if (sucesso)
                    {
                        MessageBox.Show($"Contato {idTextBox.Text} Deletado com sucesso");
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao excluir contato");
                    }
                }
             }
            else
            {
                MessageBox.Show("Contato não encontrado");
            }


        }

        public void LimparTexto()
        {
            NameTextBox.Text = "";
            emailtextbox.Text = "";
            teltextBox3.Text = "";
        }



        private void CarregarDatagrid()
        {
            var contatoListado = agendaProApiClient.GetContactsAsync().Result;

            if (contatoListado != null)
            {
                dataGridView1.DataSource = contatoListado;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 8);
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter; // Permite editar ao clicar na célula
                dataGridView1.Columns["Id"].ReadOnly = true;

                if (!dataGridView1.Columns.Contains("Ação"))
                {
                    DataGridViewButtonColumn botaoColuna = new DataGridViewButtonColumn();
                    botaoColuna.Name = "Ação";
                    botaoColuna.HeaderText = "Ação";
                    botaoColuna.Text = "Atualizar";
                    botaoColuna.UseColumnTextForButtonValue = true;

                    dataGridView1.Columns.Add(botaoColuna);
                }


            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                AtualizarContato(e.RowIndex);

            }
        }

        private void AtualizarContato(int rowIndex)
        {
            var linhaSelecionada = dataGridView1.Rows[rowIndex];

            dataGridView1.Columns["Id"].ReadOnly = true;

            var id = linhaSelecionada.Cells["Id"].Value?.ToString();
            var name = linhaSelecionada.Cells["Name"].Value?.ToString();
            var email = linhaSelecionada.Cells["Email"].Value?.ToString();
            var phone = linhaSelecionada.Cells["Phone"].Value?.ToString();

            var message = $"Deseja atualizar contato com matrícula {idTextBox.Text}?";

            const string caption = "Form Closing";

            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var success = agendaProApiClient.UpdateAsync(id, name, email, phone).Result;

                    if (success)
                    {
                        MessageBox.Show("Contato atualizado com sucesso!");
                        CarregarDatagrid();
                    }
                    else
                        MessageBox.Show("Erro ao atualizar contato.");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancelarPost_Click(object sender, EventArgs e)
        {
            LimparTexto();
        }
    }
} 