import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {Admin} from './components/admin/admin'
import { User } from './components/user/user';
import {DataBinding} from './components/data-binding/data-binding'
import {ListEmployees} from './components/employee/employee'
import {UsercompComponent} from './components/crud-data/crud-data'
import {CalcOperations} from './components/calc-operations/calc-operations'
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ListEmployees,UsercompComponent,CalcOperations,Admin,User,DataBinding,],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('first-ng-app');
}
