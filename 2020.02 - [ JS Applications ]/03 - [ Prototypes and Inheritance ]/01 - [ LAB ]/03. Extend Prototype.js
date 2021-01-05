function extendPrototype(Class) {
    Class.prototype.species = "Human";
    Class.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    };
}

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

extendPrototype(Person, Teacher, Student);

let person = new Person('Eray', 'errayerrol@gmail.com');
console.log(person.toSpeciesString());

let teacher = new Teacher('Eray', 'errayerrol@gmail.com', 'Coding');
console.log(teacher.toSpeciesString());

let student = new Student('Eray', 'errayerrol@gmail.com', 'JavaScript Applications');
console.log(student.toSpeciesString());