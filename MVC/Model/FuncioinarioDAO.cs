using MySql.Data.MySqlClient;
using Projeto_Google.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class FuncioinarioDAO:Bd

    {
        public void Cadastrar(string nome, string email, string idade, string cargo, string unidade)
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

            MySqlCommand cmd = new MySqlCommand("INSERT INTO funcionario (funcionarioNome,funcionarioEmail,fucnionarioIdade,funcionarioCargo,funcionarioUnidade) VALUES ('" + nome + "','" + email + "','" + idade + "','" + cargo + "','" + unidade + "')", conn2);

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

            string sql = "SELECT * FROM funcionario";
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader.GetString(1);
                string email = reader.GetString(2);
                string idade = reader.GetInt32(3).ToString();
                string cargo = reader.GetString(4);
                string unidade = reader.GetString(5);
                Funcionario funcionario = new Funcionario(nome, email,idade,cargo,unidade);
                ListernerFuncionarios.sinstance.funcionarios.Add(funcionario);
            }
        }

        public void Excluir(string nome, string email)
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

            MySqlCommand cmd = new MySqlCommand("DELETE FROM funcionario WHERE funcionarioNome = '" + nome + "'AND funcionarioEmail ='" + email + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Editar(string nomeAntigo, string nome, string emailAntigo, string email, string idade, string cargo, string unidade)
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

            MySqlCommand cmd = new MySqlCommand("UPDATE funcionario SET funcionarioNome='" + nome + "',funcionarioEmail= '" + email + "',fucnionarioIdade='" + idade + "',funcionarioCargo ='" + cargo + "',funcionarioUnidade='" + unidade + "' WHERE funcionarioNome = '" + nomeAntigo + "'AND funcionarioEmail ='" + emailAntigo + "'", conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }
    }
}
