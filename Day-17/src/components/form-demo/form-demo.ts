import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-form-demo',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './form-demo.html',
  styleUrl: './form-demo.css',
})
export class FormDemo {
    loginForm = new FormGroup({
    name : new FormControl('',[Validators.required,Validators.minLength(3),Validators.maxLength(20)]),
    email : new FormControl('',[Validators.required,Validators.email,Validators.maxLength(40)]),
    password : new FormControl('',[Validators.required,Validators.minLength(8),Validators.maxLength(16)]),
  });
  get name(){
    return this.loginForm.get('name');
  }
  get email(){
    return this.loginForm.get('email');
  }
  get password(){
    return this.loginForm.get('password');
  }
  handleProfile(){
    console.log(this.loginForm.value);
  }
  reset(){
    this.loginForm.setValue({name: '', email: '', password: ''});
  }
  }