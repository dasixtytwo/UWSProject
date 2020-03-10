import { Component, OnInit, Input } from '@angular/core';
import { Repository } from '../../models/repository';
import { Employee } from '../../models/employee.model';

@Component({
  selector: "employee-detail",
  templateUrl: "./employee-detail.component.html",
  styleUrls: ["./employee-detail.component.css"]
})
export class EmployeeDetailComponent implements OnInit {

  constructor(private repo: Repository) { }

  get employee(): Employee {
    return this.repo.employee;
  }

  get employees(): Employee[] {
    console.log("Employees:", this.repo.employees);
    return this.repo.employees;
  }

  ngOnInit() { }
}