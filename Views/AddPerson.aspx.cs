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
  public partial class AddPerson : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Load_ProvinciasDropDown();
        Load_NacionalitiesDropDown();
      }
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
    private void Load_NacionalitiesDropDown()
    {
      NacionalidadService nacionalidadService = new NacionalidadService();
      DataTable dataTable = nacionalidadService.GetNacionalidades();
      ddlNacionalities.DataSource = dataTable;
      ddlNacionalities.DataTextField = "Nombre";
      ddlNacionalities.DataValueField = "Id_Nacionalidad";
      ddlNacionalities.DataBind();
      ddlNacionalities.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }
    protected void btnSendMedico_Click(object sender, EventArgs e)
    {
      //if (Page.IsValid)
      //{
      //  TryAddPersonaYRedirigir("AddMedico.aspx");
      //} 
    }
    protected void btnSendPacient_Click(object sender, EventArgs e)
    {
      /*
      if (Page.IsValid)
      {
        TryAddPersonaYRedirigir("AddPaciente.aspx");
      }
      */
    }
    private void TryAddPersonaYRedirigir(string destino)
    {
      Fecha fecha = this.BuiltDate();

      if (!fecha.FechaValida())
      {
        lblDateError.Text = "Date is invalided";
        return;
      }

      Persona persona = this.BuiltPersona(fecha);
      PersonaService personaService = new PersonaService();

      if (personaService.ExistsDNI(persona.DNI))
      {
        lblShowMessage.Text = "DNI already exists.";
        return;
      }

      if (personaService.AddPersona(ref persona))
      {
        lblShowMessage.Text = $"Can add the register successfully";

        DataTable dataPersona = personaService.GetPersonByDNI(persona.DNI);

        if (dataPersona != null && dataPersona.Rows.Count > 0)
        {
          Session["DataPersona"] = dataPersona;
          Response.Redirect(destino);
        }
      }
      else
      {
        lblShowMessage.Text = $"Can't add the register";
      }
    }
    private Fecha BuiltDate()
    {
      string year, day, month;
      day = txtDate.Text.ToString().Split('/')[0];
      month = txtDate.Text.ToString().Split('/')[1];
      year = txtDate.Text.ToString().Split('/')[2];
      return new Fecha(Convert.ToInt32(day), Convert.ToInt32(month), Convert.ToInt32(year));
    }
    private Persona BuiltPersona(Fecha fechaNacimiento)
    {
      string dni = txtDNI.Text.ToString().Trim();
      // TODO: validate if dni is repeat 
      string name = txtName.Text.ToString().Trim();
      string lastName = txtLastName.Text.ToString().Trim();
      char sexo = radioListSexo.SelectedValue[0];
      string nacionality = ddlNacionalities.SelectedValue.ToString();
      string province = ddlProvincies.SelectedValue.ToString();
      string locality = ddlLocalities.SelectedValue.ToString();
      string address = txtAddress.Text.ToString().Trim();
      string email = txtEmail.Text.ToString().Trim();
      string phone = txtPhone.Text.ToString().Trim();

      Persona persona = new Persona { DNI = dni, Name = name, LastName = lastName, Sexo = sexo, IdNacionalidad = Convert.ToInt32(nacionality), IdProvincia = Convert.ToInt32(province), IdLocalidad = Convert.ToInt32(locality), Addres = address, Email = email, Phone = phone, FechaNacimiento = fechaNacimiento };

      return persona;
    }
    protected void btnSendTest_Click(object sender, EventArgs e)
    {
      //Response.Redirect("AddTurno.aspx");
      Response.Redirect("AddMedico.aspx");
      //Response.Redirect("AddMedico.aspx");
    }
  }
}