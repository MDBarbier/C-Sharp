export default class Person {
    constructor(name, age, hometown) {
        this.name = name;
        this.age = age;
        this.hometown = hometown;
    }

    speak() {
        console.log(`Hi I'm ${this.name} and ${this.age} years old and from ${this.hometown}`);
    }
}