import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface Employee {
  id: number;
  name: string;
  role: string;
  salary: number;
}

@Component({
  selector: 'app-emp-demo',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './emp-demo.html',
  styleUrl: './emp-demo.css',
})
export class EmpDemo {
  name: string = '';
  role: string = '';
  salary: number | null = null;

  employees: Employee[] = [
    { id: 1, name: 'Ravi Kumar', role: 'Developer', salary: 50000 },
    { id: 2, name: 'Neha Sharma', role: 'Designer', salary: 45000 }
  ];

  isEditMode: boolean = false;
  editId: number | null = null;

  saveEmployee() {
    if (!this.name || !this.role || this.salary === null) {
      alert('All fields are required');
      return;
    }

    if (this.isEditMode && this.editId !== null) {
      const index = this.employees.findIndex(e => e.id === this.editId);
      if (index !== -1) {
        this.employees[index] = {
          id: this.editId,
          name: this.name,
          role: this.role,
          salary: this.salary
        };
      }
    } else {
      const newEmployee: Employee = {
        id: Date.now(),
        name: this.name,
        role: this.role,
        salary: this.salary
      };
      this.employees.push(newEmployee);
    }

    this.clearForm();
  }

  editEmployee(emp: Employee) {
    this.name = emp.name;
    this.role = emp.role;
    this.salary = emp.salary;
    this.isEditMode = true;
    this.editId = emp.id;
  }

  deleteEmployee(id: number) {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.employees = this.employees.filter(e => e.id !== id);
    }
  }

  clearForm() {
    this.name = '';
    this.role = '';
    this.salary = null;
    this.isEditMode = false;
    this.editId = null;
  }
}
