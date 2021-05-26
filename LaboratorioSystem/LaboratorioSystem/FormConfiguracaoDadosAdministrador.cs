using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace LaboratorioSystem
{
    public partial class FormConfiguracaoDadosAdministrador : Form
    {
        Thread nt;
        public FormConfiguracaoDadosAdministrador()
        {
            InitializeComponent();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbpaciente");
            String sql = "update  tbfuncionario set email='" + txtEmailAdministrador.Text + "', senha='" + txtPassword.Text + "',cargo='" + comboBoxCargo.Text + "',nome='" + lblNome.Text + "'";
            MySqlCommand cmm = new MySqlCommand(sql, conn);
            conn.Open();
            cmm.ExecuteNonQuery();
            cmm.Dispose();
            conn.Close();

        
            txtEmailAdministrador.Text = "";
            txtPassword.Text = "";
            comboBoxCargo.Text = "";
            lblNome.Text = "";

        }

        private void txtEmailAdministrador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(novovoltarForm3);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novovoltarForm3()
        {
            Application.Run(new Form3());
        }

        private void lblInformacao_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbPaciente");
            String sql = "insert into tbfuncionario(nome,senha,email,cargo) " +
                "values(@nome,@senha,@email,@cargo)";
            MySqlCommand cmm = new MySqlCommand(sql, conn);

            if (txtNome.Text != "" && txtSenha.Text != "" && txtEmail.Text != ""
                && cargoCombo.Text != "")
            {
                cmm.Parameters.AddWithValue("@nome", txtNome.Text);
                cmm.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmm.Parameters.AddWithValue("@email", txtEmail.Text);
                cmm.Parameters.AddWithValue("@cargo", cargoCombo.Text);
      

                conn.Open();
                cmm.ExecuteNonQuery();
                cmm.Dispose();
                conn.Close();

                MessageBox.Show("Funcionario cadastrado com sucesso!");

                this.Close();
           
            }
            else
            {
                MessageBox.Show("Os dados devem ser preenchido!");
                this.Close();
         
            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
