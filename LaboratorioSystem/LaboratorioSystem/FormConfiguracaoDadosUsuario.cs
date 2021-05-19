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
    public partial class FormConfiguracaoDadosUsuario : Form
    {
        Thread nt;
        public FormConfiguracaoDadosUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* 
           column = new DataColumn();
           column.DataType = System.Type.GetType("System.String");
           column.ColumnName = "ParentItem";
           column.AutoIncrement = false;
           column.Caption = "ParentItem";
           column.ReadOnly = false;
           column.Unique = false;
           table.Columns.Add(column);
           */

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("nome");
            dt.Columns.Add("email");
            dt.Columns.Add("celular");
            dt.Columns.Add("rua");
            dt.Columns.Add("numero");
            dt.Columns.Add("bairro");
            dt.Columns.Add("cpf");
            dt.Columns.Add("unidades");
            dt.Columns.Add("exames");
            dt.Columns.Add("data");
            dt.Columns.Add("horario");
            dt.Columns.Add("valor");
            dt.Columns.Add("pagamento");



            DataRow row;
            /*
            row = dt.NewRow();
            row["matricula"] = 1;
            row["nome"] = "Leandro";
            row["cargo"] = "professor";
            row["status"] = "ativo";
            row["email"] = "leandrodam@gmail.com";
            dt.Rows.Add(row);
            */

            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd='';database='dbPaciente'");
                string sql = "select * from tbpaciente";
                MySqlCommand comm = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    row = dt.NewRow();
                    row["id"] = dr["id"];
                    row["nome"] = dr["nome"];
                    row["email"] = dr["email"];
                    row["celular"] = dr["celular"];
                    row["rua"] = dr["rua"];
                    row["numero"] = dr["numero"];
                    row["bairro"] = dr["bairro"];
                    row["cpf"] = dr["cpf"];
                    row["unidades"] = dr["unidades"];
                    row["exames"] = dr["exames"];
                    row["data"] = dr["data"];
                    row["horario"] = dr["horario"];
                    row["valor"] = dr["valor"];
                    row["pagamento"] = dr["pagamento"];



                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;

                comm.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
            }

            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
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

