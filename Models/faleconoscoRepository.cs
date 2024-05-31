using MySqlConnector;
using System;
using System.Collections.Generic;

namespace PI_lucianasilva_Atv4.Models
{
    public class faleconoscoRepository
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

        public void inserir (faleconosco fc)

        {
            conexao.Open();

            string query = "INSERT INTO faleconosco (nomefc, telfc, emailfc, cliente, msg) VALUES (@nomefc, @telfc, @emailfc, @cliente, @msg)";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue ("@nomefc", fc.nomefc);
            comando.Parameters.AddWithValue ("@telfc", fc.telfc);
            comando.Parameters.AddWithValue ("@emailfc", fc.emailfc);
            comando.Parameters.AddWithValue ("@cliente", fc.cliente);
            comando.Parameters.AddWithValue ("@msg", fc.msg);

            comando.ExecuteNonQuery ();


            conexao.Close();
        }



        public List<faleconosco> ListarMensagem()
        {
            List<faleconosco> listaMensagens = new List<faleconosco>();

            conexao.Open();

            string query = "SELECT * FROM faleconosco";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                faleconosco novoFc = new faleconosco();
                
                novoFc.idFc = reader.GetInt32("idFc");

                if(!reader.IsDBNull(reader.GetOrdinal("nomefc")))
                novoFc.nomefc = reader.GetString("nomefc");

                if(!reader.IsDBNull(reader.GetOrdinal("telfc")))
                novoFc.telfc = reader.GetString("telfc");

                if(!reader.IsDBNull(reader.GetOrdinal("emailfc")))
                novoFc.emailfc = reader.GetString("emailfc");

                if(!reader.IsDBNull(reader.GetOrdinal("cliente")))
                novoFc.cliente = reader.GetString("cliente");

                if(!reader.IsDBNull(reader.GetOrdinal("msg")))
                novoFc.msg = reader.GetString("msg");

                listaMensagens.Add(novoFc);
                
            }

            conexao.Close();
            return listaMensagens;
        }
    }
}