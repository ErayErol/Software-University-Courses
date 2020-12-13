function solve() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            let className = this.constructor.name;
            return `${className} (name: ${this.name}, email: ${this.email})`;
        }
    }
    
    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return `${super.toString().slice(0, -1)}, subject: ${this.subject})`;
        }
    }
    
    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return `${super.toString().slice(0, -1)}, course: ${this.course})`;
        }
    }

    return {
        Person,
        Teacher,
        Student
    };
}

let create = solve();

let Person = create.Person;
let person = new Person('Eray', 'errayerrol@gmail.com');
console.log(person.toString());

let Teacher = create.Teacher;
let teacher = new Teacher(person.name, person.email, 'Coding');
console.log(teacher.toString());

let Student = create.Student;
let student = new Student(person.name, person.email, 'JavaScript Applications');
console.log(student.toString());