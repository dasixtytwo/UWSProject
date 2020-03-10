export class Employee {
  constructor(
    public employeeID?: number,
    public lastName?: string,
    public firstName?: string,
    public title?: string,
    public titleOfCourtesy?: string,
    public birthDate?: Date,
    public hireDate?: Date,
    public address?: string,
    public city?: string,
    public region?: string,
    public postalCode?: string,
    public country?: string,
    public homePhone?: string,
    public extension?: string,
    public notes?: string,
    public reportsTo?: number
  ) { }
}