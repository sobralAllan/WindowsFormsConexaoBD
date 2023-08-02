using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DAO conectar;
        Consultar consul;
        Abas ab;
        public Form1()
        {
            InitializeComponent();
            conectar = new DAO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }//fim do método

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conectar.Inserir(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,"CadastroPessoa"));
        }//botão Inserir

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            consul = new Consultar();
            consul.ShowDialog();
        }//botão consultar

        private void button3_Click(object sender, EventArgs e)
        {
            ab = new Abas();
            ab.ShowDialog();
        }//botão atualizar
    }//fim da classe
}//fim do projeto
