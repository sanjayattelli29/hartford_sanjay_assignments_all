// let message: string = "Hello world!";
// console.log(message);

// let heading = document.createElement("h1");
// heading.textContent = message;
// document.body.appendChild(heading);


let myskills: string[] = ["JavaScript", "TypeScript", "Angular", "React"];
console.log("My skills are:", myskills.join(", "));

interface StudentDetails{
    studentnmame: string;
    studentage: number;
    studentgrade: string;
}

let a:string="sanjay";
console.log(`student name is ${a}`);


interface ProjectDetailsInterface{
    projectname:string,
    projectDescription:string,
    projectStack:string[],
    projectFeatures:string[]
}

function addTwoNumbers(a:number, b:number):number{
    return a+b;
}
console.log("Addition of two numbers is :", addTwoNumbers(5,8))