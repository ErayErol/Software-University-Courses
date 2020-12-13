function personAndTeacher() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    }

    return {
        Person,
        Teacher
    };
}

let create = personAndTeacher();

let Person = create.Person;
let person = new Person('Eray', 'errayerrol@gmail.com');
console.log(person);

let Teacher = create.Teacher;
let teacher = new Teacher(person.name, person.email, 'Coding');
console.log(teacher);