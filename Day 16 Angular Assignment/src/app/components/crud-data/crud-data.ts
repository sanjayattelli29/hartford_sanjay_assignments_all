import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { User } from '../../services/user';

@Component({
  selector: 'app-usercomp',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './crud-data.html',
  styleUrl: './crud-data.css'
})
export class UsercompComponent {

  users: User[] = [];

  user: User = {
    id: 0,
    name: '',
    email: ''
  };

  isEditMode = false;

  saveUser() {
    if (this.isEditMode) {
      const index = this.users.findIndex(u => u.id === this.user.id);
      this.users[index] = { ...this.user };
      this.isEditMode = false;
    } 
    else {
      this.user.id = Date.now(); 
      this.users.push({ ...this.user });
    }
    this.resetForm();
  }

  editUser(selectedUser: User) {
    this.user = { ...selectedUser };
    this.isEditMode = true;
  }

  deleteUser(id: number) {
    this.users = this.users.filter(u => u.id !== id);
  }

  resetForm() {
    this.user = { id: 0, name: '', email: '' };
  }
}
