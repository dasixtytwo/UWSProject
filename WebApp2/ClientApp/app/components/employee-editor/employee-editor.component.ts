import { Employee } from "../../models/employee.model";
import { Repository } from "../../models/repository";
import { Component, OnInit, Input } from "@angular/core";
import { FormGroup } from "@angular/forms";

@Component({
  selector: "employee-editor",
  templateUrl: "./employee-editor.component.html",
  styleUrls: ["./employee-editor.component.css"],
})
export class EmployeeEditorComponent implements OnInit {
  @Input() isDisabled: boolean = true;
  @Input() employeeForm: FormGroup;

  constructor(private repo: Repository) { }

  get employee(): Employee {
    return this.repo.employee;
  }

  get employees(): Employee[] {
    //console.log("Employees:", this.repo.employees);
    return this.repo.employees;
  }

  ngOnInit() {}
}
