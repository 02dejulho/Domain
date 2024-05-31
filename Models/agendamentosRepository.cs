using MySqlConnector;
using System;
using System.Collections.Generic;

namespace PI_lucianasilva_Atv4.Models
{
    public class agendamentosRepository
    {
       private const string conexaoDados = "Database = domain; Data Source = localhost; User Id=root; Convert Zero Datetime=True";

        public MySqlConnection conexao = new MySqlConnection(conexaoDados);

        public void testeConexao()
        {
            conexao.Open();

            Console.WriteLine ("Conectado com Sucesso");

            conexao.Close();
        }

        //CRUD

        //CADASTRAR AGENDAMENTO

        public void Cadastrar (agendamentos ag)

        {
            conexao.Open();

            string query = "INSERT INTO agendamentos (nome, tel, data, email, procedimento, clienteag, area, observacoes) VALUES (@nome, @tel, @data, @email, @procedimento, @clienteag, @area, @observacoes)";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue ("@nome", ag.nome);
            comando.Parameters.AddWithValue ("@tel", ag.tel);
            comando.Parameters.AddWithValue ("@data", ag.data);
            comando.Parameters.AddWithValue ("@email", ag.email);
            comando.Parameters.AddWithValue ("@procedimento", ag.procedimento);
            comando.Parameters.AddWithValue ("@clienteag", ag.clienteag);
            comando.Parameters.AddWithValue ("@area", ag.area);
            comando.Parameters.AddWithValue ("@observacoes", ag.observacoes);
           
            

            comando.ExecuteNonQuery ();

            conexao.Close();
        }


        // LISTAR PACOTES CADASTRADOS

        public List<agendamentos> Listar()
        {
            List<agendamentos> listaAgendamentos = new List<agendamentos>();

            conexao.Open();

            string query = "SELECT * FROM agendamentos";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                agendamentos novoAg = new agendamentos();
                
                novoAg.idAg = reader.GetInt32("idAg");

                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                novoAg.nome = reader.GetString("nome");

                if(!reader.IsDBNull(reader.GetOrdinal("tel")))
                novoAg.tel = reader.GetString("tel");

                if(!reader.IsDBNull(reader.GetOrdinal("data")))
                novoAg.data = reader.GetDateTime("data");

                if(!reader.IsDBNull(reader.GetOrdinal("email")))
                novoAg.email = reader.GetString("email");

                if(!reader.IsDBNull(reader.GetOrdinal("procedimento")))
                novoAg.procedimento = reader.GetString("procedimento");

                if(!reader.IsDBNull(reader.GetOrdinal("clienteag")))
                novoAg.clienteag = reader.GetString("clienteag");

                if(!reader.IsDBNull(reader.GetOrdinal("area")))
                novoAg.area = reader.GetString("area");

                if(!reader.IsDBNull(reader.GetOrdinal("observacoes")))
                novoAg.observacoes = reader.GetString("observacoes");

                listaAgendamentos.Add(novoAg);
                
            }

            conexao.Close();

            return listaAgendamentos;
        }


        // EDITAR OS AGENDAMENTOS CADASTRADOS

        public void Editar (agendamentos ag)
        {
            conexao.Open();

            string query = "UPDATE agendamentos SET nome = @nome, tel = @tel, data = @data, email = @email, procedimento = @procedimento, clienteag = @clienteag, area = @area WHERE idAg = @idAg";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue ("@nome", ag.nome);
            comando.Parameters.AddWithValue ("@tel", ag.tel);
            comando.Parameters.AddWithValue ("@data", ag.data);
            comando.Parameters.AddWithValue ("@email", ag.email);
            comando.Parameters.AddWithValue ("@procedimento", ag.procedimento);
            comando.Parameters.AddWithValue ("@clienteag", ag.clienteag);
            comando.Parameters.AddWithValue ("@area", ag.area);
            comando.Parameters.AddWithValue ("@observacoes", ag.observacoes);
            comando.Parameters.AddWithValue ("@idAg", ag.idAg);


            comando.ExecuteNonQuery ();

            conexao.Close();

        }


        // DELETAR REGISTROS DE agendamentos

        public void Deletar (int idAg)
        {
            conexao.Open();

            string query = "DELETE FROM agendamentos WHERE idAg = @idAg";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue ("@idAg", idAg);

            comando.ExecuteNonQuery ();

            conexao.Close();

        }

        public agendamentos buscaId(int idBusca)
        {
            agendamentos agendamentoBuscado = new agendamentos();

            conexao.Open();

            string query = "SELECT * FROM agendamentos WHERE idAg = @idAg";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue ("@idAg", idBusca);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {             
                agendamentoBuscado.idAg = reader.GetInt32("idAg");

                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                agendamentoBuscado.nome = reader.GetString("nome");

                if(!reader.IsDBNull(reader.GetOrdinal("tel")))
                agendamentoBuscado.tel = reader.GetString("tel");

                if(!reader.IsDBNull(reader.GetOrdinal("data")))
                agendamentoBuscado.data = reader.GetDateTime("data");

                if(!reader.IsDBNull(reader.GetOrdinal("email")))
                agendamentoBuscado.email = reader.GetString("email");

                if(!reader.IsDBNull(reader.GetOrdinal("procedimento")))
                agendamentoBuscado.procedimento = reader.GetString("procedimento");

                if(!reader.IsDBNull(reader.GetOrdinal("clienteag")))
                agendamentoBuscado.clienteag = reader.GetString("clienteag");

                if(!reader.IsDBNull(reader.GetOrdinal("area")))
                agendamentoBuscado.area = reader.GetString("area");

                if(!reader.IsDBNull(reader.GetOrdinal("observacoes")))
                agendamentoBuscado.observacoes = reader.GetString("observacoes");    
            }

            conexao.Close();         

            return agendamentoBuscado;
        } 
    }
}