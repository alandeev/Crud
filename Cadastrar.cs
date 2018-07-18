using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using Dapper;

namespace CRUD_TI
{
    public partial class Cadastrar : MetroFramework.Forms.MetroForm
    {
        public SQLiteConnection sql = Program.sql;
        Metodos met = new Metodos();


        public Cadastrar()
        {
            InitializeComponent();
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            MessageBox.Show("   AVISO CADASTRAMENTO\n\nNome acima de 8 caracteres\nLogin acima de 8 caracteres\nSenha acima de 8 caracteres\nIdade acima de 18");
        }

        private void retornar_tela()
        {
            this.Close();
            Form1 form = new Form1();
            form.Visible = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            retornar_tela();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            int c = met.verify(txt_nome.Text,txt_login.Text,txt_senha.Text, int.Parse(txt_idade.Text));
            if (c == 4)
            {

                try {
                    Program.sql.Query($"INSERT INTO usuarios(`nome`,`login`,`senha`,`idade`)VALUES('{txt_nome.Text}','{txt_login.Text}','{txt_senha.Text}','{txt_idade.Text}')");
                    Program.sql.Close();
                    MessageBox.Show("Cadastrado.");
                    retornar_tela();
                }
                catch
                {
                    txt_login.Clear();
                    MessageBox.Show("Usuario já existe.");
                }
            }
            else
            {
                MessageBox.Show("Verifique os campos acima\nAlgo está incorreto.");
            }
        }

        private void txt_nome_Click(object sender, EventArgs e)
        {

        }
    }
}
