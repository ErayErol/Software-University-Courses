class Organization {
    constructor(name, budget) {
        this.name = name;
        this.budget = Number(budget);
        this.employees = [];
        this.departments = {
            marketing: this.budget * 0.4,
            finance: this.budget * 0.25,
            production: this.budget * 0.35
        };
    }

    get departmentsBudget() {
        return {
            marketing: this.departments['marketing'],
            finance: this.departments['finance'],
            production: this.departments['production']
        };
    }

    add(employeeName, department, salary) {
        if (this.departmentsBudget[department] >= salary) {
            const employee = {
                employeeName,
                department,
                salary
            };

            this.employees.push(employee);
            this.departments[department] -= salary;

            return `Welcome to the ${department} team Mr./Mrs. ${employeeName}.`;
        }

        return `The salary that ${department} department can offer to you Mr./Mrs. ${employeeName} is $${this.departmentsBudget[department]}.`;
    }

    employeeExists(employeeName) {
        let employeeIndex = this.employees.findIndex(e => e.employeeName === employeeName);

        if (employeeIndex === -1) {
            return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;
        }

        return `Mr./Mrs. ${employeeName} is part of the ${this.employees[employeeIndex].department} department.`;
    }

    leaveOrganization(employeeName) {
        let employeeIndex = this.employees.findIndex(e => e.employeeName === employeeName);

        if (employeeIndex === -1) {
            return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;
        }

        this.departments[this.employees[employeeIndex].department] += this.employees[employeeIndex].salary;
        this.employees.splice(employeeIndex, 1);

        return `It was pleasure for ${this.name} to work with Mr./Mrs. ${employeeName}.`;
    }

    status() {
        let result = `${this.name.toUpperCase()} DEPARTMENTS:`;
        result += `\n${output('marketing', this.employees, this.departments)}`;
        result += `\n${output('finance', this.employees, this.departments)}`;
        result += `\n${output('production', this.employees, this.departments)}`;

        return result;

        function output(department, employees, departments) {
            return `${department.charAt(0).toUpperCase() + department.slice(1)} | Employees: ${employees
                .filter(x => x.department === `${department}`).length}: ${employees
                .filter(x => x.department === `${department}`)
                .sort((a, b) => b.salary - a.salary)
                .map(e => e.employeeName)
                .join(', ')} | Remaining Budget: ${departments[`${department}`]}`;
        }
    }
}

let organization = new Organization('SoftUni', 20000);

console.log(organization.add('Pesho1', 'marketing', 1200));
console.log(organization.add('Gosho3', 'production', 200));
console.log(organization.add('Tosho3', 'marketing', 120));
console.log(organization.add('Bosho1', 'production', 2220));
console.log(organization.add('Shosho2', 'marketing', 210));
console.log(organization.add('Yosho4', 'production', 20));
console.log(organization.add('Rosho2', 'production', 250));

console.log(organization.status());