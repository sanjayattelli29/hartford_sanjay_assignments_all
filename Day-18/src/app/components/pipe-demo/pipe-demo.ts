import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { OrderStatusPipe } from './order-status.pipe';

@Component({
  selector: 'app-pipe-demo',
  imports: [CommonModule, FormsModule, OrderStatusPipe],
  templateUrl: './pipe-demo.html',
  styleUrl: './pipe-demo.css',
})
export class PipeDemo {
  orders = [
    { id: 1, status: 'pending', username: 'John' },
    { id: 2, status: 'shipped', username: 'Sarah' },
    { id: 3, status: 'delivered', username: 'Mike' },
    { id: 4, status: 'cancelled', username: 'Emily' },
    { id: 5, status: 'unknown', username: 'David' }
  ];

  newOrder = {
    id: 6,
    status: 'pending',
    username: ''
  };

  statusOptions = ['pending', 'shipped', 'delivered', 'cancelled', 'unknown'];

  addOrder() {
    if (this.newOrder.username.trim()) {
      this.orders.push({
        id: this.newOrder.id,
        status: this.newOrder.status,
        username: this.newOrder.username
      });
      
      this.newOrder = {
        id: this.newOrder.id + 1,
        status: 'pending',
        username: ''
      };
    }
  }
}
