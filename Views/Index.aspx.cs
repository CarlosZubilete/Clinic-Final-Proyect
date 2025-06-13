using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business;
using Entities;

namespace Views
{
  public partial class Index : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        this.Load_ProvinciasDropDown();
      }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {

      lblShowMessage.Text = $"Provincie: {ddlProvincies.SelectedItem} ";
      lblShowMessage.Text += $"Localidad: {ddlLocalities.SelectedItem} "; 
    }

    protected void ddlProvincies_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedId = Convert.ToInt32(ddlProvincies.SelectedValue);

      if (selectedId != 0)
      {
        Load_LocatitiesDropDown(selectedId);
        lblShowMessage.Text = $"Provincia seleccionada: {ddlProvincies.SelectedItem.Text}";
      }
      else
      {
        ddlLocalities.Items.Clear();
        ddlLocalities.Items.Insert(0, new ListItem(" -- Select --", "0"));
        lblShowMessage.Text = string.Empty;
      }
    }
    private void Load_ProvinciasDropDown()
    {
      ProvinciaService provinciaService = new ProvinciaService();
      DataTable dataTable = provinciaService.GetAllProvincies();

      ddlProvincies.DataSource = dataTable;
      ddlProvincies.DataTextField = "Nombre";
      ddlProvincies.DataValueField = "Id_Provincia";
      ddlProvincies.DataBind();

      ddlProvincies.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }
    private void Load_LocatitiesDropDown(int idProvincie)
    {
      LocalidadService localidadService = new LocalidadService();
      DataTable dataTable = localidadService.GetLocalidades(idProvincie);

      ddlLocalities.DataSource = dataTable;
      ddlLocalities.DataTextField = "Nombre";
      ddlLocalities.DataValueField = "Id_Localidad";
      ddlLocalities.DataBind();

      ddlLocalities.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }
  }
}