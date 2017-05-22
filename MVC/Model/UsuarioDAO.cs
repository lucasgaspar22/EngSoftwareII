using MySql.Data.MySqlClient;
using Projeto_Google.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Google.Model
{
    class UsuarioDAO:Bd
    {
        public void Cadastrar(string nome,string email,string idade, string senha, string celular)
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

            MySqlCommand cmd = new MySqlCommand("INSERT INTO usuario (usuarioNome,usuarioEmail,usuarioIdade,usuarioSenha,usuarioCelular) VALUES ('" + nome + "','"+email+"','"+idade+"','"+senha+"','"+celular+"')", conn2);

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

            string sql = "SELECT * FROM usuario";
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader.GetString(1);
                string email = reader.GetString(2);
                string idade = reader.GetInt32(3).ToString();
                string senha = reader.GetString(4);
                string celular = reader.GetString(5);
                Usuario user  = new Usuario(nome,email,senha,idade,celular);
                ListernerUsuarios.sinstance.usuarios.Add(user);
            }
        }

        public void Excluir(string nome,string email)
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

            MySqlCommand cmd = new MySqlCommand("DELETE FROM usuario WHERE usuarioNome = '" + nome + "'AND usuarioEmail ='"+email+"'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Editar(string nomeAntigo, string nome,string emailAntigo,string email,string idade,string senha,string celular)
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

            MySqlCommand cmd = new MySqlCommand("UPDATE usuario SET usuarioNome='" + nome +"',usuarioEmail= '"+email+"',usuarioIdade='"+idade+"',usuarioSenha ='"+senha+"',usuarioCelular='"+celular+ "' WHERE usuarioNome = '" + nomeAntigo + "'AND usuarioEmail ='" + emailAntigo + "'", conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }

    }
}
