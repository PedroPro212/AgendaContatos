using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgendaContato
{
    public partial class CadastrarContato : System.Web.UI.Page
    {

        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connection.Open();
                ddlParentesco.Items.Clear();
                var reader = new MySqlCommand("SELECT parentesco, id FROM familia WHERE id!=0", connection).ExecuteReader();
                while (reader.Read())
                {
                    var familia = new ListItem(reader.GetString("parentesco"), reader.GetInt32("id").ToString());
                    ddlParentesco.Items.Add(familia);
                }
                connection.Close();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"INSERT INTO adicionar(nome, tel, id_parentesco) VALUES (@nome, @tel, {ddlParentesco.SelectedValue})", connection);
                comando.Parameters.Add(new MySqlParameter("nome", txtNome.Text));
                comando.Parameters.Add(new MySqlParameter("tel", txtTel.Text));
                comando.ExecuteNonQuery();
                connection.Close();

                SiteMaster.AlertPersonalizado(this, "Cadastrado com sucesso");

                txtNome.Text = "";
                txtTel.Text = "";
            }
            catch
            {
                SiteMaster.AlertPersonalizado(this, "Algo saiu errado");
            }

        }

    }
}