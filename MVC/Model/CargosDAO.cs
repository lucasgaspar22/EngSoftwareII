using MySql.Data.MySqlClient;
using Projeto_Google.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class CargosDAO:Bd
    {
        public void Cadastrar(string nome,string salario, string hierarquia)
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

            MySqlCommand cmd = new MySqlCommand("INSERT INTO cargos (cargoNome,cargoSalario,cargoHierarquia) VALUES ('" + nome +"','"+salario+"','"+hierarquia+"')", conn2);

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

            string sql = "SELECT * FROM cargos";
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader.GetString(1);
                string salario = reader.GetFloat(2).ToString();
                string hierarquia = reader.GetString(3);
                Cargos cargo = new Cargos(nome,salario,hierarquia);
                ListernerCargos.sinstance.cargos.Add(cargo);
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

            MySqlCommand cmd = new MySqlCommand("DELETE FROM cargos WHERE cargoNome = '" + nome + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Editar(string nomeAntigo, string nome, string salario, string hierarquia)
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

            MySqlCommand cmd = new MySqlCommand("UPDATE cargos SET cargoNome='" + nome + "',cargoSalario = '"+salario+"', cargoHierarquia = '"+hierarquia+ "' WHERE cargoNome = '" + nomeAntigo + "'", conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }
    }
}
