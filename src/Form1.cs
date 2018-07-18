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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public SQLiteConnection sql = Program.sql;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Cadastrar cad = new Cadastrar();
            cad.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string nome = txt_login.Text;
            string senha = txt_senha.Text;
            var verify = Program.sql.Query($"SELECT * FROM usuarios WHERE `login`='{nome}' and `senha`='{senha}'").FirstOrDefault() ;
            if (verify == null)
            {
                MessageBox.Show("Usuario ou Senha incorreto.");
            }
            else
            {
                Logado log = new Logado(nome);
                this.Visible = false;
                log.Show();
                MessageBox.Show($"{nome} está Conectado.");
            }
        }
    }
}
