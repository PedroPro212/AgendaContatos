using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgendaContato.Contato
{
    public partial class UpdateContato : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                var id = Request.QueryString["id"].ToString();
                var contato = new Negocio.Contato().Read(id);

                connection.Open();
                ddlParentesco.Items.Clear();
                var reader = new MySqlCommand($"SELECT parentesco, id FROM familia WHERE id!=0", connection).ExecuteReader();
                while (reader.Read())
                {
                    var familia = new ListItem(reader.GetString("parentesco"), reader.GetInt32("id").ToString());
                    ddlParentesco.Items.Add(familia);
                }
                connection.Close();

                if (contato == null)
                {
                    SiteMaster.AlertPersonalizado(this, "Deu B.O", "ExibirContato.aspx");
                }

                txtNome.Text = contato.Nome;
                txtTel.Text = contato.Tel;
                ddlParentesco.Text = id;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"].ToString();
            try
            {
                if((txtNome.Text == "")||(txtTel.Text == ""))
                {
                    SiteMaster.AlertPersonalizado(this, "É necessário os campos estarem preenchidos");
                }
                else
                {
                    connection.Open();
                    var comando = new MySqlCommand($"UPDATE adicionar SET nome = @nome, tel = @tel, id_parentesco = {ddlParentesco.SelectedValue} WHERE id={id}", connection);
                    comando.Parameters.Add(new MySqlParameter("nome", txtNome.Text));
                    comando.Parameters.Add(new MySqlParameter("tel", txtTel.Text));
                    comando.ExecuteNonQuery();
                    connection.Close();

                    SiteMaster.AlertPersonalizado(this, "Cadastrado com sucesso");

                    txtNome.Text = "";
                    txtTel.Text = "";
                }

            }
            catch
            {
                SiteMaster.AlertPersonalizado(this, "Algo saiu errado");
            }
        }
    }
}