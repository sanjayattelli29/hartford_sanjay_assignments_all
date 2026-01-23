import { Routes } from '@angular/router';
import { CurdDemo } from './components/curd-demo/curd-demo';
import { ToDoComponent } from './components/to-do/to-do';
import { PipeDemo } from './components/pipe-demo/pipe-demo';
import {EmpDemo} from './components/emp-demo/emp-demo';
export const routes: Routes = [
    { path: 'user-crud', component: CurdDemo },
    { path: '', redirectTo: 'user-crud', pathMatch: 'full' },
    { path: 'todo', component: ToDoComponent },
    { path: 'pipes', component: PipeDemo },    
    {path: 'orders', component: EmpDemo}
];
