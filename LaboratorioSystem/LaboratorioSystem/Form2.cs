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
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database=dbPaciente");
            String sql = "insert into tbpaciente(nome) values('" + txtNome.Text + "')";
            MySqlCommand cmm = new MySqlCommand(sql, conn);
            conn.Open();
            cmm.ExecuteNonQuery();
            cmm.Dispose();
            conn.Close();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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


    }



    }

