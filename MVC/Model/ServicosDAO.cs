using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using Projeto_Google.Control;

namespace Projeto_Google.Model
{
    class ServicosDAO:Bd
    {
        public void Cadastrar(string nome)
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

            MySqlCommand cmd = new MySqlCommand("INSERT INTO servicos (servicoNome) VALUES ('"+nome+"')", conn2);

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

            string sql = "SELECT * FROM servicos";
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader.GetString(1);
                Servicos servico = new Servicos(nome);
                ListernerServicos.sinstance.servicos.Add(servico);
            }
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

            MySqlCommand cmd = new MySqlCommand("DELETE FROM servicos WHERE servicoNome = '" + nome + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Editar(string nomeAntigo, string nome)
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

            MySqlCommand cmd = new MySqlCommand("UPDATE servicos SET servicoNome='" + nome + "' WHERE servicoNome = '" + nomeAntigo + "'", conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }
    }
}
