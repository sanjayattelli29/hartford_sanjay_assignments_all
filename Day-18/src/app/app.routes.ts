import { Routes } from '@angular/router';
import { CurdDemo } from './components/curd-demo/curd-demo';
import { ToDoComponent } from './components/to-do/to-do';

export const routes: Routes = [
    { path: 'user-crud', component: CurdDemo },
    { path: '', redirectTo: 'user-crud', pathMatch: 'full' },
    { path: 'todo', component: ToDoComponent }
    
];
