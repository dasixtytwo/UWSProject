using dasixtytwo.lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WinApp
{
  public class EmployeeViewModel
  {
    public class EmployeeJson
    {
      public int employeeID;
      public string lastName;
      public string firstName;
      public string title;
      public string titleOfCourtesy;
      //public DateTime? birthDate;
      //public DateTime? hireDate;
      public string address;
      public string city;
      public string region;
      public string postalCode;
      public string country;
      public string homePhone;
      public string extension;
      public string notes;
      public int? reportsTo;
    }

    public ObservableCollection<Employee> Employees { get; set; }

    public EmployeeViewModel()
    {
      using (var http = new HttpClient())
      {
        http.BaseAddress = new Uri("http://localhost:5000/");

        var serializer = new DataContractJsonSerializer(typeof(List<EmployeeJson>));

        var stream = http.GetStreamAsync("api/employees").Result;

        var emps = serializer.ReadObject(stream) as List<EmployeeJson>;

        var employees = emps.Select(e => new Employee
        {
          EmployeeID = e.employeeID,
          FirstName = e.firstName,
          LastName = e.lastName,
          Title = e.title,
          TitleOfCourtesy = e.titleOfCourtesy,
          //BirthDate = e.birthDate,
          //HireDate = e.hireDate,
          Address = e.address,
          City = e.city,
          Region = e.region,
          PostalCode = e.postalCode,
          Country = e.country,
          HomePhone = e.homePhone,
          Extension = e.extension,
          Notes = e.notes,
          ReportsTo = e.reportsTo
        });

        Employees = new ObservableCollection<Employee>(employees);
      }
    }
  }
}
