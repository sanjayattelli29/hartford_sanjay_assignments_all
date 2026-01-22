import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

interface Todo {
  id: number;
  task: string;
  completed: boolean;
}

@Component({
  selector: 'app-to-do',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './to-do.html',
  styleUrl: './to-do.css'
})
export class ToDoComponent implements OnInit {

  taskControl = new FormControl('');
  todoList: Todo[] = [];

  ngOnInit(): void {
    const saved = localStorage.getItem('todos');
    if (saved) {
      this.todoList = JSON.parse(saved);
    }
  }

  addTask(): void {
    const task = this.taskControl.value?.trim();
    if (!task) return;

    const newTodo: Todo = {
      id: Date.now(),
      task,
      completed: false
    };

    this.todoList.push(newTodo);
    this.taskControl.setValue('');
    this.saveToLocal();
  }

  toggleDone(todo: Todo): void {
    todo.completed = !todo.completed;
    this.saveToLocal();
  }

  deleteTask(id: number): void {
    this.todoList = this.todoList.filter(t => t.id !== id);
    this.saveToLocal();
  }

  private saveToLocal(): void {
    localStorage.setItem('todos', JSON.stringify(this.todoList));
  }
}
