import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { Repository } from "../../models/repository";

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html',
  styleUrls: ['/employee.component.css']
})

export class EmployeeComponent implements OnInit {

  constructor(private repo: Repository) {
  }

  get employee(): Employee {
    return this.repo.employee;
  }

  get employees(): Employee[] {
    console.log("Employees:", this.repo.employees);
    return this.repo.employees;
  }

  selectEmployee(id: number) {
    return this.repo.getEmployee(id);
  }

  clearEmployee() {
    this.repo.employee = new Employee();
  }

  ngOnInit() { }
}
