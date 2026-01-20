import { Component } from '@angular/core';
import { Employee } from '../../models/employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee',
  imports: [CommonModule],
  templateUrl: './employee.html',
  styleUrl: './employee.css',
})

export class ListEmployees {
  employees: Employee[] = [
    {
      id: 1,
      name: 'Mark',
      gender: 'Male',
      contactPreference: 'Email',
      phoneNumber: 6303526523,
      email: 'mark@gmail.com',
      dateOfBirth: new Date('10/25/1990'),
      department: 'IT',
      isActive: true,
      photoPath: 'emp1.webp'
    },
      {
      id: 2,
      name: 'John',
      gender: 'Male',
      contactPreference: 'Phone',
      phoneNumber: 9123456780,
      email:'john1@gmail.com',
      dateOfBirth: new Date('06/12/1988'),
      department: 'Finance',
      isActive: false,
      photoPath: 'emp3.webp'
    },
    {
      id: 3,
      name: 'sans',
      gender: 'Female',
      contactPreference: 'Phone',
      phoneNumber: 8919200200,
      email:'sans@gmail.com',
      dateOfBirth: new Date('08/15/1992'),
      department: 'HR',
      isActive: true,
      photoPath: 'emp2.webp'
    },
    {
      id: 4,
      name: 'John',
      gender: 'Male',
      contactPreference: 'Phone',
      phoneNumber: 9030130001,
      email:'john@gmail.com',
      dateOfBirth: new Date('06/12/1988'),
      department: 'Finance',
      isActive: false,
      photoPath: 'emp3.webp'
    },
     {
      id: 5,
      name: 'Mark',
      gender: 'Male',
      contactPreference: 'Email',
      phoneNumber: 6303526523,
      email: 'mark@gmail.com',
      dateOfBirth: new Date('10/25/1990'),
      department: 'IT',
      isActive: true,
      photoPath: 'emp1.webp'
    }
  ];

}



