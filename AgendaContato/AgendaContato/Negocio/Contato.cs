using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaContato.Negocio
{
    public class Contato
    {
        private MySqlConnection connection;

        public Contato()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public Classes.Contato Read(string id)
        {
            return this.Read(id, "", "", "").FirstOrDefault();
        }

        public List<Classes.Contato> Read(string id, string nome, string tel, string id_parentesco)
        {
            var contato = new List<Classes.Contato>();

            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"SELECT nome, tel, id_parentesco, id FROM adicionar WHERE (1=1)", connection);
                if (nome.Equals("") == false)
                {
                    comando.CommandText += $" AND nome like @nome";
                    comando.Parameters.Add(new MySqlParameter("nome", $"%{nome}%"));
                }
                if (tel.Equals("") == false)
                {
                    comando.CommandText += $" AND tel = @tel";
                    comando.Parameters.Add(new MySqlParameter("tel", tel));
                }
                //if (id_parentesco.Equals("") == false)
                //{
                //    comando.CommandText += $" AND id_parentesco = @id_parentesco";
                //    comando.Parameters.Add(new MySqlParameter("id_parentesco", id_parentesco));
                //}
                if (id.Equals("") == false)
                {
                    comando.CommandText += $" AND id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    contato.Add(new Classes.Contato
                    {
                        Nome = reader.GetString("nome"),
                        Id = reader.GetInt32("id"),
                        Tel = reader.GetString("tel")
                        //Id_parentesco = reader.GetString("id_parentesco")
                    });
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return contato;
        }

        public bool Delete(int id)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand("DELETE FROM adicionar WHERE id = " + id, connection);
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}