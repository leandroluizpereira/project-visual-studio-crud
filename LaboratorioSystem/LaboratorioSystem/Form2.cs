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
            String sql = "insert into tbpaciente(nome,senha,email,celular,rua,numero,bairro,cpf,unidades,exames,data,horario,pagamento) " +
                "values(@nome,@senha,@email,@celular,@rua,@numero,@bairro,@cpf,@unidades,@exames,@data,@horario,@pagamento)";
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
   }



    }

