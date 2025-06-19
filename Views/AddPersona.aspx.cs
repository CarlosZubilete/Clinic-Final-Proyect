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

    protected void btnSend_Click(object sender, EventArgs e)
    {
      string year;
      string day;
      string month;

      day = txtDate.Text.ToString().Split('/')[0];
      month = txtDate.Text.ToString().Split('/')[1];
      year = txtDate.Text.ToString().Split('/')[2];

      Fecha fechaNacimiento = new Fecha(Convert.ToInt32(day), Convert.ToInt32(month), Convert.ToInt32(year));

      if (!fechaNacimiento.FechaValida())
      {
        lblDateError.Text = "Date is invalided";
        return;
      }
      else
      {
        if (Page.IsValid)
        {
          string dni = txtDNI.Text.ToString().Trim();
          // TODO: validate if dni is repeat 
          string name = txtName.Text.ToString().Trim();
          string lastName = txtLastName.Text.ToString().Trim();
          char sexo = radioListSexo.SelectedValue[0];
          string nacionality = ddlNacionalities.SelectedValue.ToString();
          string province = ddlProvincies.SelectedValue.ToString();
          string locality = ddlNacionalities.SelectedValue.ToString();
          string address = txtAddress.Text.ToString().Trim();
          string email = txtEmail.Text.ToString().Trim();
          string phone = txtPhone.Text.ToString().Trim();

          bool added= AddPerson(fechaNacimiento, dni, name, lastName, sexo, nacionality, province, locality, address, email, phone);

          if (added)
          {

            PersonaService personaService = new PersonaService();
            DataTable dataPersona =  personaService.GetPersonByDNI(dni);

            if(dataPersona != null && dataPersona.Rows.Count > 0)
            {
              Session["DataPersona"] = dataPersona;
              Response.Redirect("AddMedico.aspx");
            
            }
          }
        }
      }
    }
    protected void btnShowData_Click(object sender, EventArgs e)
    {
      /*
      PersonaService personaService = new PersonaService();
      DataTable dataPersona = personaService.GetPersonByDNI("12345678");

      if (dataPersona != null && dataPersona.Rows.Count > 0)
      {
        Session["DataPersona"] = dataPersona;
        Response.Redirect("AddMedico.aspx");

      }
      */
    }
    private bool AddPerson(Fecha fechaNacimiento, string dni, string name, string lastName, char sexo, string nacionality, string province, string locality, string address, string email, string phone)
    {

      Persona persona = new Persona { DNI = dni, Name = name, LastName = lastName, Sexo = sexo, IdNacionalidad = Convert.ToInt32(nacionality), IdProvincia = Convert.ToInt32(province), IdLocalidad = Convert.ToInt32(locality), Addres = address, Email = email, Phone = phone, FechaNacimiento = fechaNacimiento };

      PersonaService personaService = new PersonaService();

      if (!personaService.AddPersona(ref persona))
      {
        lblShowMessage.Text = $"Can't add the register";
        return false;
      }
      else
      {
        lblShowMessage.Text = $"Can add the register successfully";
        return true;
      }
    }

   
  }
}

// TODO: Maybe we can a fuction for IsDuplicatePerson. 
// TODO: Create addd as a medico or a paciente. 