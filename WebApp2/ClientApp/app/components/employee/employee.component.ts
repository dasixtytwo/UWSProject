import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { Repository } from "../../models/repository";
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html',
  styleUrls: ['/employee.component.css'],
})

export class EmployeeComponent implements OnInit {
  employeeForm: FormGroup;

  constructor(private repo: Repository) { }

  tableMode: boolean = true;
  isDisabled: boolean = true;

  get employee(): Employee {
    //console.log("Employee:", this.repo.employee);
    return this.repo.employee;
  }

  get employees(): Employee[] {
    //console.log("Employees:", this.repo.employees);
    return this.repo.employees;
  }

  enable() {
    this.isDisabled = false;
  }

  selectEmployee(id: number) {
    //console.log("Employee:", id);
    this.isDisabled = true;
    return this.repo.getEmployee(id);
  }

  saveEmployee() {
    if (this.repo.employee.employeeID == null) {
      this.repo.createEmployee(this.repo.employee);
    } else {
      this.repo.updateEmployee(this.repo.employee);
    }
    this.isDisabled = true;
    this.clearEmployee();
    this.tableMode = true;
  }

  deleteEmployee(id: number) {
    this.repo.deleteEmployee(id);
  }

  clearEmployee() {
    this.repo.employee = new Employee();
    this.tableMode = true;
  }

  ngOnInit() {
    // Check if the Form is validate, if validate the save button disable turn true
    this.employeeForm = new FormGroup({
      titleOfCourtesy: new FormControl('', [Validators.required, Validators.minLength(2)]),
      firstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      lastName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      title: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      postalCode: new FormControl('', Validators.required),
      region: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      phone: new FormControl('', Validators.required),
      extension: new FormControl('', Validators.required),
    });

    //this.employeeForm.valueChanges.subscribe(newVal => console.log("Form", newVal))
  }
}
