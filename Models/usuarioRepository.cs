using MySqlConnector;
using System;
using System.Collections.Generic;

namespace PI_lucianasilva_Atv4.Models
{
    public class usuarioRepository
    {
        private const string conexaoDados = "Database = domain; Data Source = localhost; User Id=root";

        public MySqlConnection conexao = new MySqlConnection(conexaoDados);

        public void testeConexao()
        {
            conexao.Open();

            Console.WriteLine ("Conectado com Sucesso");

            conexao.Close();
        }

        //CRUD

        public void inserir (usuario user)

        {
            conexao.Open();

            string query = "INSERT INTO usuario (nome, login, senha, dataNascimento) VALUES (@nome, @login, @senha, @dataNascimento)";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue ("@nome", user.nome);
            comando.Parameters.AddWithValue ("@login", user.login);
            comando.Parameters.AddWithValue ("@senha", user.senha);
            comando.Parameters.AddWithValue ("@dataNascimento", user.dataNascimento);

            comando.ExecuteNonQuery ();


            conexao.Close();
        }



        public List<usuario> ListarUsuario()
        {
            List<usuario> listaUsuarios = new List<usuario>();

            conexao.Open();

            string query = "SELECT * FROM usuario";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                usuario novoUsuario = new usuario();
                
                novoUsuario.idUser = reader.GetInt32("idUser");

                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                novoUsuario.nome = reader.GetString("nome");

                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                novoUsuario.login = reader.GetString("login");

                if(!reader.IsDBNull(reader.GetOrdinal("senha")))
                novoUsuario.senha = reader.GetString("senha");

                if(!reader.IsDBNull(reader.GetOrdinal("dataNascimento")))
                novoUsuario.dataNascimento = reader.GetDateTime("dataNascimento");

                listaUsuarios.Add(novoUsuario);
                
            }

            conexao.Close();
            return listaUsuarios;
        }



        public usuario validarLogin(usuario user)
        {
            conexao.Open();

            string query = "SELECT * FROM usuario WHERE login = @login AND senha = @senha";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue ("@login", user.login);
            comando.Parameters.AddWithValue ("@senha", user.senha);

            MySqlDataReader reader = comando.ExecuteReader();

            usuario usuarioLogado = null;
            

            while (reader.Read())
            {   
                usuarioLogado = new usuario();        


                usuarioLogado.idUser = reader.GetInt32("idUser");

                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                usuarioLogado.nome = reader.GetString("nome");

                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                usuarioLogado.login = reader.GetString("login");

                if(!reader.IsDBNull(reader.GetOrdinal("senha")))
                usuarioLogado.senha = reader.GetString("senha");

                     
            }
            conexao.Close();
            return usuarioLogado;

        }
    }
}