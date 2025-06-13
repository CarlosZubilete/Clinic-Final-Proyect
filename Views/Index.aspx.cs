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
    private void Load_ProvinciasDropDown()
    {
      ProvinciaService provinciaService = new ProvinciaService();
      DataTable dataTable = provinciaService.GetAllProvincies();

      ddlProvincies.DataSource = dataTable;
      ddlProvincies.DataTextField = "Nombre";
      ddlProvincies.DataValueField = "Id_Provincia";
      ddlProvincies.DataBind();

      ddlProvincies.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
    }
  }
}