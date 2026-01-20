import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-data-binding',
  imports: [FormsModule],
  templateUrl: './data-binding.html',
  styleUrl: './data-binding.css',
})
export class DataBinding {
  courseName: string = " Angular 20";

  rollNo: number = 101;

  spanClassName = 'secondary'
  currentDate: Date = new Date(); 
  constructor() {
    console.log(this.courseName)

    this.courseName = "Data Binding Concept";
    console.log(this.courseName)
  }

}
