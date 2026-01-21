import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoService, Post } from '../../app/services/todo-service';

@Component({
    selector: 'app-api-demo',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './api-demo.html',
    styleUrls: ['./api-demo.css']
})
export class ApiDemo implements OnInit {
    posts = signal<Post[]>([]);
    loading = signal<boolean>(true);
    error = signal<string | null>(null);

    private todoService = inject(TodoService);

    ngOnInit() {
        this.todoService.getPosts().subscribe({
            next: (data) => {
                this.posts.set(data);
                this.loading.set(false);
            },
            error: (err) => {
                this.error.set('Failed to fetch posts');
                this.loading.set(false);
                console.error(err);
            }
        });
    }
}
