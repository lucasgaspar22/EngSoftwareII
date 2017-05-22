using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_Google.Control;

namespace Projeto_Google.Model
{
    class AppsDAO:Bd
    {

        public void Cadastrar(string nome,string tamanho,string numDownload, string avaliacao)
        {
            MySqlConnection conn2 = new MySqlConnection(connString);
            try
            {
                conn2.Open();
                System.Console.WriteLine("Conectado no banco");
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine("ERRO!");

            }

            MySqlCommand cmd = new MySqlCommand("INSERT INTO app (appNome, appTamanho,appNumDowload,appAvaliacao) VALUES ('" + nome + "','" + tamanho + "','" + numDownload + "','" + avaliacao + "')", conn2);

            cmd.ExecuteNonQuery();

            conn2.Close();
        }

        public void Listar()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                System.Console.WriteLine("Conectado no banco");
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine("ERRO!");

            }

            string sql = "SELECT * FROM app";
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader.GetString(1);
                string tamanho = reader.GetString(2);
                string downloads = reader.GetInt32(3).ToString();
                string avaliacao = reader.GetString(4);
                Apps app = new Apps(nome,tamanho,downloads,avaliacao);
                ListernerApps.sinstance.apps.Add(app); 
            }
        }
        public void Editar(string nomeAntigo, string nome,string tamanhoAntigo,string tamanho,string numAntigo, string numDownload,string avaliacaoAntigo, string avaliacao)
        {
            MySqlConnection conn2 = new MySqlConnection(connString);
            try
            {
                conn2.Open();

                System.Console.WriteLine("Conectado no banco");
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine("ERRO!");

            }

            MySqlCommand cmd = new MySqlCommand("UPDATE app SET appNome='" + nome +"', appTamanho = '" +tamanho+ "',appNumDowload = '"+numDownload+"',appAvaliacao = '"+avaliacao+   "' WHERE appNome = '" + nomeAntigo +"'AND appTamanho = '"+tamanhoAntigo+ "'AND appNumDowload = '"+numAntigo+ "'AND appAvaliacao = '"+avaliacaoAntigo+ "'", conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }

        public void Excluir(string nome)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                System.Console.WriteLine("Conectado no banco");
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine("ERRO!");

            }

            MySqlCommand cmd = new MySqlCommand("DELETE FROM app WHERE appNome = '" + nome + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
