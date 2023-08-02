using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DAO
    {
        public MySqlConnection conexao;
        public int i;
        public int contador;
        public string resultado;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] cidade;
        public string[] uf;
        public string[] tudo;

        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;Database=pessoa;Uid=root;Password=");
            try
            {
                conexao.Open();
            }catch(Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro.Message);
            }
        }//fim da DAO

        public string Inserir(string nome, string telefone, string cidade, string uf, string nomeDoBanco)
        {
            string inserir = $"Insert into {nomeDoBanco}(codigo, nome, telefone, cidade, uf) values('','{nome}','{telefone}','{cidade}','{uf}')";
            MySqlCommand sql = new MySqlCommand(inserir, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            return resultado;
        }//fim do método

        public int ConsultarTamanhoDoBD()
        {
            return contador;
        }//fim do método
        public void PreencherVetor()
        {
            
            string query = "select * from cadastroPessoa";//Coletar os dados do BD

            //Instanciar
            this.codigo = new int[100];
            this.nome = new string[100];
            this.telefone = new string[100];
            this.cidade = new string[100];
            this.uf = new string[100];

            //Preencher com valores iniciais
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                cidade[i] = "";
                uf[i] = "";
            }//fim do for

            //Criando o comando para consultar no BD
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura dos dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                cidade[i] = leitura["cidade"] + "";
                uf[i] = leitura["uf"] + "";
                i++;
                contador++;
                
            }//Fim do while

            //Fechar a leitura de dados no banco
            leitura.Close();
        }//fim do método de preenchimento do vetor

        public int[] ConsultarCodigo()
        {
            PreencherVetor();
            return codigo;
        }//fim do método
        public string[] ConsultarNome()
        {
            PreencherVetor();
            return nome;
        }//fim do método

        public string[] ConsultarTelefone()
        {
            PreencherVetor();
            return telefone;
        }//fim do método

        public string[] ConsultarCidade()
        {
            PreencherVetor();
            return cidade;
        }//fim do método

        public string[] ConsultarUF()
        {
            PreencherVetor();
            return uf;
        }//fim do método

        //Método que consulta TODOS OS DADOS no banco de dados
        /*
        public string ConsultarTudo()
        {
            //Preencher os vetores
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += "Código: " + codigo[i] +
                       ", Nome: " + nome[i] +
                       ", Telefone: " + telefone[i] +
                       ", Endereço: " + endereco[i] +
                       ", Data de Nascimento: " + data[i] +
                       "\n\n";
            }//fim do for

            return msg;
        }//fim do método consultarTudo
        


        public string ConsultarTudo(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigo[i] == cod)
                {
                    msg = "Código: " + codigo[i] +
                       ", Nome: " + nome[i] +
                       ", Telefone: " + telefone[i] +
                       ", Endereço: " + endereco[i] +
                       ", Data de Nascimento: " + data[i] +
                       "\n\n";
                    return msg;
                }
            }//fim do for
            return "Código informado não encontrado!";
        }//fim do consultar
        */

    }//fim da classe de conexão
}//fim do projeto
