using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Views
{
  public partial class AddMedico : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if(Session["DataPersona"] != null)
        {
          DataTable dataPerson = (DataTable)Session["DataPersona"];

          lblDNI.Text = dataPerson.Rows[0]["DNI"].ToString();
          lblFullName.Text = dataPerson.Rows[0]["Nombre"].ToString() + " " + dataPerson.Rows[0]["Apellido"].ToString();
          lblBirthdate.Text = dataPerson.Rows[0]["FechaNacimiento"].ToString(); 
        }
      }
    }
  }
}