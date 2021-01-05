class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department) {
            throw new Error('Invalid input!');
        }
        if (salary < 0) {
            throw new Error('Invalid input!');
        }
        let currentDepartment = this.departments.find(x => x.name === department);

        if (currentDepartment) {
            currentDepartment.employee.push({
                username,
                salary,
                position,
            });
        } else {
            currentDepartment = {
                name: department,
                employee: [{
                    username,
                    salary,
                    position,
                }],
                averageSalary: function () {
                    return this.employee.reduce((acc, curr) => acc + curr.salary, 0) / this.employee.length;
                },
            };
            this.departments.push(currentDepartment);
        }

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        const [best] = [...this.departments].sort((a, b) => b.averageSalary() - a.averageSalary());
        const outputEmployee = best.employee
            .sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username))
            .map(x => `${x.username} ${x.salary} ${x.position}`)
            .join('\n');

        return `Best Department is: ${best.name}\nAverage salary: ${best.averageSalary().toFixed(2)}\n${outputEmployee}`;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());