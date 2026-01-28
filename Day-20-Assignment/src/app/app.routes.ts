import { Routes } from '@angular/router';
import { CurdDemo } from './components/curd-demo/curd-demo';
import { ToDoComponent } from './components/to-do/to-do';
import { PipeDemo } from './components/pipe-demo/pipe-demo';
import { EmpDemo } from './components/emp-demo/emp-demo';
import { LoginComponent } from './components/login/login';
import { RegisterComponent } from './components/register/register';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'user-crud', component: CurdDemo, canActivate: [authGuard] },
    { path: 'todo', component: ToDoComponent, canActivate: [authGuard] },
    { path: 'pipes', component: PipeDemo, canActivate: [authGuard] },    
    { path: 'orders', component: EmpDemo, canActivate: [authGuard] },
    { path: '', redirectTo: 'login', pathMatch: 'full' }
];
