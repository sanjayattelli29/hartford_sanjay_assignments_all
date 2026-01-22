import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-curd-demo',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './curd-demo.html',
  styleUrl: './curd-demo.css'
})
export class CurdDemo implements OnInit {
  users: any[] = [];
  userForm: any = {
    name: '',
    email: '',
    username: ''
  };
  isEditing = false;
  currentUserId: number | null = null;

  constructor(private userService: UserService, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
  }

  fetchUsers() {
    this.userService.getUsers().subscribe(data => {
      this.users = data;
      this.cdr.detectChanges();
    });
  }

  onSubmit() {
    if (this.isEditing) {
      this.updateUser();
    } else {
      this.addUser();
    }
  }

  addUser() {
    this.userService.createUser(this.userForm).subscribe(newUser => {
      newUser.id = this.users.length + 1; 
      this.users.push({ ...this.userForm, id: newUser.id });
      this.resetForm();
    });
  }

  editUser(user: any) {
    this.isEditing = true;
    this.currentUserId = user.id;
    this.userForm = { ...user };
  }

  updateUser() {
    const updatedUser = { ...this.userForm, id: this.currentUserId };
    this.userService.updateUser(updatedUser).subscribe(() => {
      const index = this.users.findIndex(u => u.id === this.currentUserId);
      if (index !== -1) {
        this.users[index] = updatedUser;
      }
      this.resetForm();
    });
  }

  deleteUser(id: number) {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(id).subscribe(() => {
        this.users = this.users.filter(u => u.id !== id);
      });
    }
  }

  resetForm() {
    this.userForm = { name: '', email: '', username: '' };
    this.isEditing = false;
    this.currentUserId = null;
  }
}
