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
    public partial class Form1 : Form
    {
        Thread nt;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void lblRua_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblAdministrador_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(novoForm2);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoForm2()
        {
            Application.Run(new Form2());
        }

        private void lblAgendar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            /* primeiro exemplo :
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbpaciente");
            Selecionando a tabela fucionario
            String sql = "select * from tbfuncionario ";
            MySqlCommand cmm = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader dr = cmm.ExecuteReader();
            if (dr.Read())
            {
                if (txtEmail.Text == dr["email"].ToString() && txtSenha.Text == dr["senha"].ToString())
                {
              
                    this.Close();
                    nt = new Thread(novoForm);
                    nt.SetApartmentState(ApartmentState.STA);
                    nt.Start();
                }
                else
                {
                    MessageBox.Show("Senha invalido!");
                }
            }
          
            cmm.Dispose();
            conn.Close();
            */

            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database='dbpaciente'");
                string sql = "select * from tbfuncionario where email='" + txtEmail.Text + "' and senha='" + txtSenha.Text + "'";
                MySqlCommand comm = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = comm.ExecuteReader();
                Funcionario.matricula = 0;
                Funcionario.nome = "";
                Funcionario.cargo = "";
                Funcionario.status = "";
                Funcionario.email = "";
                if (dr.Read())
                {
                    Funcionario.matricula = (int)dr["matricula"];
                    Funcionario.nome = (String)dr["nome"];
                    Funcionario.cargo = (String)dr["cargo"];
                    Funcionario.status = (String)dr["status"];
                    Funcionario.email = (String)dr["email"];
                }
                comm.Dispose();
                conn.Close();
                if (Funcionario.matricula == 0)
                {
                    MessageBox.Show("Usuário ou senha inválidos!");
                }
                else if (Funcionario.status.Equals("bloqueado"))
                {
                    MessageBox.Show("Usuário bloqueado pelo administrador!");
                }
                else
                {
                    this.Close();
                    nt = new Thread(novoForm3);
                    nt.SetApartmentState(ApartmentState.STA);
                    nt.Start();
                    this.Dispose(false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        private void novoForm3()
        {
            Application.Run(new Form3());
        }

    }
}







    
