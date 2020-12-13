function solve() {
    class Employee {
        constructor(name, age) {
            if (new.target === Employee) {
                throw new Error("Cannot construct Employee instances directly.");
            }
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work(){
            let x = this.tasks.shift();
            console.log(`${this.name} ${x}`);
            this.tasks.push(x);
        }

        collectSalary(){
            console.log(`${this.name} received ${this.getSalary()} this month.`);
        }

        getSalary(){
            return this.salary;
        }
    }

    class Junior extends Employee{
        constructor(name, age){
            super(name, age);
            this.tasks.push('is working on a simple task.');
        }
    }

    class Senior extends Employee{
        constructor(name, age){
            super(name, age);
            this.tasks.push('is working on a complicated task.');
            this.tasks.push('is taking time off work.');
            this.tasks.push('is supervising junior workers.');
        }
    }

    class Manager extends Employee{
        constructor(name, age){
            super(name, age);
            this.dividend = 0;
            this.tasks.push('scheduled a meeting.');
            this.tasks.push('is preparing a quarterly report.');
        }

        getSalary(){
            return this.salary + this.dividend;
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    };
}

let create = solve();

let guy1 = new create.Junior('Mark Zuckerberg', 35);
let guy3 = new create.Senior('Eray Erol', 24);
let guy2 = new create.Manager('Bill Gates', 197);

guy1.work();
guy1.salary = 580;
console.log(guy1.getSalary());

guy2.work();
guy2.salary = 175450000;
guy2.dividend = 0.75;
console.log(guy2.getSalary());

guy3.work();
guy3.salary = 8688;
console.log(guy3.getSalary());