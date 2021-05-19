using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;


namespace LaboratorioSystem
{
    public partial class Form2 : Form
    {
        Thread nt;

        public Form2()
        {
            InitializeComponent();


        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            String pagamento = radioCartao.Text;
            if (radioCartao.Checked == true)
            {
                pagamento = radioCartao.Text;
            }
            else
            {
                pagamento = radioDinheiro.Text;
            }


            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbPaciente");
            String sql = "insert into tbpaciente(nome,senha,email,celular,rua,numero,bairro,cpf,unidades,exames,data,horario,valor,pagamento) " +
                "values(@nome,@senha,@email,@celular,@rua,@numero,@bairro,@cpf,@unidades,@exames,@data,@horario,@valor,@pagamento)";
            MySqlCommand cmm = new MySqlCommand(sql, conn);

            if (txtNome.Text != "" && txtSenha.Text != "" && txtEmail.Text != ""
                && txtCelular.Text != "" && txtRua.Text != "" && txtNumero.Text != ""
                && txtBairro.Text != "" && txtCpf.Text != "" && comboUnidades.Text != "" && checkedListBoxExame.Text != "" && comboHorario.Text != "")
            {
                cmm.Parameters.AddWithValue("@nome", txtNome.Text);
                cmm.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmm.Parameters.AddWithValue("@email", txtEmail.Text);
                cmm.Parameters.AddWithValue("@celular", txtCelular.Text);
                cmm.Parameters.AddWithValue("@rua", txtRua.Text);
                cmm.Parameters.AddWithValue("@numero", txtNumero.Text);
                cmm.Parameters.AddWithValue("@bairro", txtBairro.Text);
                cmm.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmm.Parameters.AddWithValue("@unidades", comboUnidades.Text);
                cmm.Parameters.AddWithValue("@exames", checkedListBoxExame.Text);
                cmm.Parameters.AddWithValue("@data", comboData.Text);
                cmm.Parameters.AddWithValue("@horario", comboHorario.Text);
                cmm.Parameters.AddWithValue("@valor", lblValor.Text);
                cmm.Parameters.AddWithValue("@pagamento", pagamento);

                conn.Open();
                cmm.ExecuteNonQuery();
                cmm.Dispose();
                conn.Close();

                MessageBox.Show("Agendando com sucesso!");

                this.Close();
                nt = new Thread(novoForm1);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
            else
            {
                MessageBox.Show("Os dados devem ser preenchido!");
                this.Close();
                nt = new Thread(novoForm2);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();

            }


        }
        private void novoForm2()
        {
            Application.Run(new Form2());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /// MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbPaciente");
            // String sql = "insert into tbpaciente(nome) values('" + txtNome.Text + ")";
            // MySqlCommand cmm = new MySqlCommand(sql, conn);
            // conn.Open();
            // cmm.ExecuteNonQuery();
            // cmm.Dispose();
            // conn.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {

            this.Close();
            nt = new Thread(novoForm1);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoForm1()
        {
            Application.Run(new Form1());
        }

        private void checkedListBoxExame_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void lblValor_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (checkedListBoxExame.SelectedItem.Equals("Ultrassonografia"))
            {
                lblValor.Text = "R$:100,00";
                MessageBox.Show("A ultrassonografia," +
                    " também conhecida por ecografia e ultrassom," +
                    " é um exame de imagem diagnóstico que serve " +
                    "para visualizar em tempo real qualquer órgão" +
                    " ou tecido do corpo. Quando o exame é realizado" +
                    " com Doppler, o médico consegue observar o fluxo" +
                    " sanguíneo dessa região.");
            }
            else if (checkedListBoxExame.SelectedItem.Equals("Analises clinicas"))
            {
                lblValor.Text = "R$:148,00";
                MessageBox.Show("As análises clínicas são um" +
                    " conjunto de exames com a finalidade" +
                    " de verificar o estado de saúde de um " +
                    "paciente ou investigar doenças, " +
                    "como os chamados exames de rotina, " +
                    "check-ups, dentre outros.");
            }
            else if (checkedListBoxExame.SelectedItem.Equals("Teste do covid - 19"))
            {
                lblValor.Text = "R$:248,00";
                MessageBox.Show("Os testes rápidos para COVID-19 " +
                    "são similares aos testes de farmácia para gravidez." +
                    " No caso do teste para COVID-19, " +
                    "faz-se uso de uma lâmina de nitrocelulose " +
                    "(uma espécie de papel) que reage com a amostra " +
                    "e apresenta uma indicação visual em caso positivo.");
            }
           else  if (checkedListBoxExame.SelectedItem.Equals("Mamografia"))
            {
                lblValor.Text = "R$:200,00";
                MessageBox.Show("O exame de mamografia é a principal tecnologia" +
                    " a serviço das mulheres para o diagnóstico precoce do câncer" +
                    " de mama – que implica em maiores chances de vencer a doença.");
            }
            else if (checkedListBoxExame.SelectedItem.Equals("Espermograma"))
            {
                lblValor.Text = "R$68,00";
                MessageBox.Show("Espermograma é um exame" +
                    " laboratorial que analisa a qualidade " +
                    "do sêmen e é considerado a forma mais" +
                    " importante para averiguar a capacidade" +
                    " reprodutiva dos homens.");
            }
            else if (checkedListBoxExame.SelectedItem.Equals("Colonoscopia"))
            {
                lblValor.Text = "R$:600,00";
                MessageBox.Show("A colonoscopia é um exame que permite " +
                    "ao médico analisar o revestimento interno do intestino" +
                    " grosso e parte do intestino delgado, em uma área que" +
                    " corresponde ao reto, ao cólon e ao íleo terminal.");
            }
            else if (checkedListBoxExame.SelectedItem.Equals("Eletrocardiograma"))
            {
                lblValor.Text = "R$:200,00";
                MessageBox.Show("Para que serve esse teste" +
                    " (também chamado de ECG ou eletro) " +
                    "que mede a atividade elétrica do coração" +
                    " e quando você deve fazê-lo. O eletrocardiograma" +
                    " (ECG) é feito com um aparelhinho ligado " +
                    "a eletrodos que avalia o ritmo dos batimentos" +
                    " cardíacos em repouso");
            }
        }
    }
}



    

