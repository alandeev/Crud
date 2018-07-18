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
    public partial class Logado : MetroFramework.Forms.MetroForm
    {
        Metodos met = new Metodos();
        int count = 0;
        string login;
        string user_connect;
        public Logado(string nome)
        {
            user_connect = nome;
            InitializeComponent();
        }

        private void Logado_Load(object sender, EventArgs e)
        {

        }
        private void info_update()
        {
            Program.sql.Query($"UPDATE usuarios SET `nome`='{txt_nome.Text}' WHERE `login`='{login}'");
            Program.sql.Query($"UPDATE usuarios SET `login`='{txt_login.Text}' WHERE `login`='{login}'");
            Program.sql.Query($"UPDATE usuarios SET `senha`='{txt_senha.Text}' WHERE `login`='{login}'");
        }

        private void update()
        {
            if (txt_nome.Text.Length < 8 || txt_login.Text.Length < 8 || txt_senha.Text.Length < 8)
            {
                MessageBox.Show("Cada campo deve ter no minimo 8 Caracteres.");
            }
            else
            {
                if (user_connect == login)
                {
                    info_update();
                    this.Close();
                    Form1 jan = new Form1();
                    jan.Visible = true;
                    MessageBox.Show("Sua conta foi Alterada.");
                }
                else
                {
                    info_update();
                    lb_res.Text = "Usuario Alterado.";
                    visible_false();
                }
            }
        }

        private void visible_false()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            bt_alterar.Visible = false;
            bt_deletar.Visible = false;
            bt_clear.Visible = false;
            txt_nome.Visible = false;
            txt_login.Visible = false;
            txt_senha.Visible = false;
            cbox.Visible = false;
        }

        private void bt_pesq_Click(object sender, EventArgs e)
        {
            string user = txt_pesq.Text;
            var pesq = Program.sql.Query($"SELECT * FROM usuarios WHERE `login`='{user}'").FirstOrDefault();
            if (pesq == null)
            {
                lb_res.Text = $"Usuario {user} não encontrado";
                visible_false();
            }
            else
            {
                lb_res.Text = $"Usuario {user} encontrado.";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                bt_alterar.Visible = true;
                bt_deletar.Visible = true;
                bt_clear.Visible = true;
                txt_nome.Visible = true;
                txt_login.Visible = true;
                txt_senha.Visible = true;
                cbox.Visible = true;
                txt_nome.Text = pesq.nome;
                txt_login.Text = pesq.login;
                txt_senha.Text = pesq.senha;
                login = txt_pesq.Text;
            }
        }

        private void bt_alterar_Click(object sender, EventArgs e)
        {
            update();
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            txt_nome.Text = "";
            txt_login.Text = "";
            txt_senha.Text = "";
        }

        private void cbox_CheckedChanged(object sender, EventArgs e)
        {
            if (count % 2 == 0)
            {
                txt_senha.UseSystemPasswordChar = false;
            }
            else
            {
                txt_senha.UseSystemPasswordChar = true;
            }
            count += 1;
        }

        private void bt_deletar_Click(object sender, EventArgs e)
        {
            if (user_connect == login)
            {
                if (MessageBox.Show("Quer deletar sua conta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.sql.Query($"DELETE FROM usuarios WHERE `login`='{login}'");
                    this.Close();
                    Form1 jan = new Form1();
                    jan.Visible = true;
                    MessageBox.Show("Sua conta foi deletada.");
                }
                else
                {
                    // Quando o usuario clica em não -> Alan <-
                }
            }
            else
            {
                if (MessageBox.Show($"Quer deletar {login}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.sql.Query($"DELETE FROM usuarios WHERE `login`='{login}'");
                    MessageBox.Show($"Usuario {login} Deletado.");
                }
                else
                {
                    // Quando o usuario clica em não -> Alan <-

                }
            }
        }
    }
}
