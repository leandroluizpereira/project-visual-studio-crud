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
    }
}
