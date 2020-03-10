import { Employee } from "./employee.model";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

const employeeUrl = "/api/employees";

@Injectable()
export class Repository {
  employee: Employee;
  employees: Employee[];

  constructor(private http: HttpClient) {
    this.getEmployees();
  }

  getEmployee(id: number) {
    this.http.get<Employee>(`${employeeUrl}/${id}`).subscribe(e => {
      this.employee = e;
    });
  }

  getEmployees() {
    this.http
      .get<Employee[]>(employeeUrl)
      .subscribe(emps => (this.employees = emps));
  }

  createEmployee(e: Employee) {
    console.log("Create Employee: ", e);
    let data = {
      firstname: e.firstName,
      lastName: e.lastName,
      title: e.title,
      titleOfCourtesy: e.titleOfCourtesy,
      birthDate: e.birthDate,
      hireDate: e.hireDate,
      address: e.address,
      city: e.city,
      region: e.region,
      postalCode: e.postalCode,
      country: e.country,
      homePhone: e.homePhone,
      extension: e.extension,
      notes: e.notes,
      reportsTo: e.reportsTo
    };
    this.http.post<number>(employeeUrl, data).subscribe(id => {
      e.employeeID = id;
      this.employees.push(e);
    });
  }

  updateEmployee(e: Employee) {
    console.log("Update Employee:", e);
    let data = {
      firstname: e.firstName,
      lastName: e.lastName,
      title: e.title,
      titleOfCourtesy: e.titleOfCourtesy,
      birthDate: e.birthDate,
      hireDate: e.hireDate,
      address: e.address,
      city: e.city,
      region: e.region,
      postalCode: e.postalCode,
      country: e.country,
      homePhone: e.homePhone,
      extension: e.extension,
      notes: e.notes,
      reportsTo: e.reportsTo
    };
    this.http
      .put(`${employeeUrl}/${e.employeeID}`, data)
      .subscribe(() => this.getEmployees());
  }

  // Method to delete employee from database
  deleteEmployee(id: number) {
    this.http
      .delete(`${employeeUrl}/${id}`)
      .subscribe(() => this.getEmployees());
    console.log("Delete employee with ID ", id);
  }

}