using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_Google.Control;

namespace Projeto_Google.Model
{
    class UnidadesDAO : Bd
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

            MySqlCommand cmd = new MySqlCommand("INSERT INTO unidade (unidadeNome) VALUES ('" + nome + "')", conn2);

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

            string sql = "SELECT * FROM unidade";
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader.GetString(1);
                Unidades unidade = new Unidades(nome,"","","");
                ListernerUnidades.sinstance.unidades.Add(unidade);
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

            MySqlCommand cmd = new MySqlCommand("DELETE FROM unidade WHERE unidadeNome = '" + nome + "'", conn);

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

            MySqlCommand cmd = new MySqlCommand("UPDATE unidade SET unidadeNome='" + nome + "' WHERE unidadeNome = '" + nomeAntigo + "'", conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }
    }
}
