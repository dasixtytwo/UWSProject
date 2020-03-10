using System;
using System.ComponentModel.DataAnnotations;
using dasixtytwo.lib;

namespace WebApp2.Models.Binding
{
  /* I will use this class as the parameter for the action methods the will receive POST requests, 
   * this allow me to receive JSON data from the client
   * I using this class on EmployeeController on action method create and update.
   */
  public class EmployeeData
  {

    public int EmployeeID { get; set; }

    [Required]
    [StringLength(25, MinimumLength = 3)]
    public string LastName
    {
      get => Employee.LastName; set => Employee.LastName = value;
    }
    [Required]
    [StringLength(25, MinimumLength = 3)]
    public string FirstName
    {
      get => Employee.FirstName; set => Employee.FirstName = value;
    }
    [Required]
    public string Title
    {
      get => Employee.Title; set => Employee.Title = value;
    }
    [Required]
    [StringLength(5, MinimumLength = 2)]
    public string TitleOfCourtesy
    {
      get => Employee.TitleOfCourtesy; set => Employee.TitleOfCourtesy = value;
    }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? BirthDate
    {
      get => Employee.BirthDate; set => Employee.BirthDate = value;
    }
    [Required]
    public DateTime? HireDate
    {
      get => Employee.HireDate; set => Employee.HireDate = value;
    }
    [Required]
    public string Address
    {
      get => Employee.Address; set => Employee.Address = value;
    }
    [Required]
    public string City
    {
      get => Employee.City; set => Employee.City = value;
    }
    public string Region
    {
      get => Employee.Region; set => Employee.Region = value;
    }
    public string PostalCode // ?
    {
      get => Employee.PostalCode; set => Employee.PostalCode = value;
    }
    [Required]
    public string Country // ?
    {
      get => Employee.Country; set => Employee.Country = value;
    }
    [Required]
    public string HomePhone
    {
      get => Employee.HomePhone; set => Employee.HomePhone = value;
    }
    public string Extension // ?
    {
      get => Employee.Extension; set => Employee.Extension = value;
    }
    public string Notes // ?
    {
      get => Employee.Notes; set => Employee.Notes = value;
    }
    public int? ReportsTo // ?
    {
      get => Employee.ReportsTo; set => Employee.ReportsTo = value;
    }

    public Employee Employee { get; set; } = new Employee();
  }
}