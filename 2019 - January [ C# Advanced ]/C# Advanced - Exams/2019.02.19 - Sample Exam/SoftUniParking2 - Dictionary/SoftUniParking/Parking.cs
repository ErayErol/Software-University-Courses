using System.Linq;

namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Parking
    {
        // 1.0 Правим текущият клас да е => public
        // 1.1 Write a C# class Parking that has cars (a collection which stores the entity Car). All entities inside the class have the same properties.
        // Напишете клас Parking, който има коли (колекцията която съдържа обекти от тип Car). Всичките entitiеs(Cars-Коли) в класа(Parking) трябва да имат еднакви propertie-та

        // 1.2 The class constructor should initialize the cars with a new instance of the collection and accept capacity as parameter. 
        // Конструктура трябва да инициализира cars(колите - тоест колекцията която имаме) с нова инстанцията на колекцията и да приема capacity като parameter. 
        // Тоест ще имаме 2 field-a
        // 1 - Колекция с колите => инициализираме cars с нова инстанция на колекцията(колекцията ние си я избираме, може да е List<Car> cars , Dictionary<string, Car> и т.н)
        // 2 - Integer capacity => от условието се подразбира, че е цяло число (int) и това ще е => параметъра

        // 2.0 Implement the following features:

        // 3.0 •	Field cars – collection that holds added cars
        private Dictionary<string, Car> cars;
        // защо използваме речник вместо списък, защото в условието по-надолу навсякъде се иска регистрационен номер на колата и е по-лесно с речник
        // key => registrationNumber , value => car

        // 4.0  •	Field capacity – accessed only by the base class (responsible for the parking capacity)
        private int capacity;
        // хващаме field-a capacity => ALT + ENTER => Generate constructor

        // 4.1 защо правим само capacity (без cars) => защото ако правим и на cars, ще иска като параметър да вкараме и колекцията(List, Dictionary... каквото сме направили) а в условието пише
        // => The class constructor should initialize the cars with a new instance of the collection and accept capacity as parameter. 
        public Parking(int capacity) // вътре в скобите се нарича => параметър
        {
            this.capacity = capacity;
            // 4.2 accept capacity as parameter
            this.cars = new Dictionary<string, Car>();
            // 4.3 initialize the cars with a new instance of the collection(
        }

        // 9.0 •	Getter Count – returns the number of stored cars.

        public int Count
        {
            get => this.cars.Count;
        }

        // 5.0 •	Method AddCar(Car car)
        // 5.1 гледаме метода какво връща, ако е само съобщения както в случая => string

        public string AddCar(Car car)
        {
            // first checks if there is already a car with tha provided car registration number and if there is the method returns the following message:
            // "Car with that registration number, already exist!"
            if (this.cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            // Next checks if the count of the cars in the parking is more than the capacity and if it is returns the following message:
            // "Parking is full!"
            if (this.cars.Count == this.capacity) // може да се използва и else if
            {
                return "Parking is full!";
            }

            // Finally if nothing from the previous conditions is true it just adds the current car to the cars in the parking and returns the message:
            // "Successfully added new car {Make} {RegistrationNumber}"
            this.cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        // 6.0 •	Method RemoveCar(string registrationNumber) – removes a car with the given registration number.
        // 6.1 гледаме метода какво връща, ако е само съобщения както в случая => string

        public string RemoveCar(string registrationNumber)
        {
            // If the provided registration number does not exist returns the message: 
            //"Car with that registration number, doesn't exist!"
            if (this.cars.ContainsKey(registrationNumber) == false)
            {
                return "Car with that registration number, doesn't exist!";
            }

            //Otherwise, removes the car and returns the message:
            //"Successfully removed {registrationNumber}"
            this.cars.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }

        // 7.0 •	Method GetCar(string registrationNumber) – returns the Car with the provided registration number
        // 7.1      гледаме метода какво връща, ако е самата кола както в случая => клас Car
        // 7.2      не е казано да хвърляме някакви съобщения, ако не съществува колата, явно всички тестове ще бъдат с коли, които ги има

        public Car GetCar(string registrationNumber)
        {
            // returns the Car with the provided registration number
            return this.cars[registrationNumber];
        }

        // 8.0 •	Method RemoveSetOfRegistrationNumber(List<string> registrationNumbers) – void method, which removes all cars having the provided registration numbers.Each car is removed only if the registration number exists
        // 8.1      гледаме метода какво връща => този път си пише (void)

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                if (this.cars.ContainsKey(registrationNumber))
                {
                    this.cars.Remove(registrationNumber);
                }
            }
        }
    }
}