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
}