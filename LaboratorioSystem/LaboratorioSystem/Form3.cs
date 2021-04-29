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
    public partial class Form3 : Form
    {
        Thread nt;
        public Form3()
        {
            InitializeComponent();
     


        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(novoForm3);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoForm3()
        {
            Application.Run(new Form1());
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbPaciente");
            //Selecionando a tabela fucionario
            String sql = "select * from tbpaciente where id=" + txtPesquisar.Text;
            MySqlCommand cmm = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader dr = cmm.ExecuteReader();
            if (dr.Read())
            {
                lblNome.Text = dr["nome"].ToString();
                lblCelular.Text = dr["celular"].ToString();
                lblBairro.Text = dr["bairro"].ToString();
                lblUnidades.Text = dr["unidades"].ToString();
                lblExame.Text= dr["exames"].ToString();
                lblEmailuser.Text = dr["email"].ToString();
                lblRua.Text = dr["rua"].ToString();
                lblNum.Text = dr["numero"].ToString();
                lblCpf.Text = dr["cpf"].ToString();
                lblPagamento.Text = dr["pagamento"].ToString();
              //  lblExame.Text = dr["exame"].ToString();
            }
            else
            {
                MessageBox.Show("Nenhum registro foi encontrado");
            }
            cmm.Dispose();
            conn.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbpaciente");
            String sql = "update tbfuncionario set email='" + txtEmailAdministrador.Text + "', senha='" + txtPassword.Text + "'";
            MySqlCommand cmm = new MySqlCommand(sql, conn);
            conn.Open();
            cmm.ExecuteNonQuery();
            cmm.Dispose();
            conn.Close();

            lblInformacao.Text = "Alterado com sucesso!!!";
            txtEmailAdministrador.Text = "";
            txtPassword.Text = "";

        }

        }
    }
    

