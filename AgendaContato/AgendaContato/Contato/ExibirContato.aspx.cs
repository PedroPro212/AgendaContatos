using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgendaContato.Contato
{
    public partial class ExibirContato : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var contato = new Negocio.Contato().Read("", txtNome.Text, "", "");
            Session["dados"] = contato;
            grdContatos.DataSource = contato;
            grdContatos.DataBind();


            var reader = new MySqlCommand("SELECT COUNT(nome) AS qts FROM adicionar", connection);
            
            try
            {
                connection.Open();
                lblQts.Text = "";
                MySqlDataReader dataReader;
                dataReader = reader.ExecuteReader();
                while (dataReader.Read())
                {
                    lblQts.Text += dataReader.GetInt32("qts");
                }
            }
            catch(Exception ex)
            {
                SiteMaster.AlertPersonalizado(this, ex.Message);
            }
            connection.Close();
            

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarContato.aspx");
        }

        protected void grdContatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var contato = (List<Classes.Contato>)Session["dados"];

            if(e.CommandName == "excluir")
            {
                if(new Negocio.Contato().Delete(contato[index].Id))
                {
                    SiteMaster.AlertPersonalizado(this, "Excluido com sucesso");
                }
                else
                {
                    SiteMaster.AlertPersonalizado(this, "Deu merda");
                }
                btnPesquisar_Click(null, null);
            }
            if(e.CommandName == "editar")
            {
                Response.Redirect("UpdateContato.aspx?id=" + contato[index].Id);
            }
        }

        protected void grdContatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#171f25'; this.style.cursor='hand';");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='#212529'");
            }
        }
    }
}