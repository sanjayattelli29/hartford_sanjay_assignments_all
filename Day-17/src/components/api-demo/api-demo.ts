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

    deletePost(id: number) {
        if (confirm('Are you sure you want to delete this post?')) {
            this.todoService.deletePost(id).subscribe({
                next: () => {
                    this.posts.update(currentPosts => currentPosts.filter(p => p.id !== id));
                    alert('Post deleted successfully (simulated)');
                },
                error: (err) => {
                    console.error('Error deleting post', err);
                    alert('Failed to delete post');
                }
            });
        }
    }

    editPost(post: Post) {
        const newTitle = prompt('Edit Title:', post.title);
        if (newTitle !== null && newTitle !== post.title) {
            const updatedPost = { ...post, title: newTitle };
            this.todoService.updatePost(updatedPost).subscribe({
                next: (result) => {
                    this.posts.update(currentPosts =>
                        currentPosts.map(p => p.id === post.id ? result : p)
                    );
                    // Since the API is mocked and might not return the updated object exactly as we sent it for PUT,
                    // specifically jsonplaceholder often just returns the ID 101 or similar for updates if creating,
                    // but for PUT it usually mocks correctly.
                    // However, to ensure the UI updates for this demo even if the mock doesn't persist:
                    this.posts.update(currentPosts =>
                        currentPosts.map(p => p.id === post.id ? updatedPost : p)
                    );
                },
                error: (err) => {
                    console.error('Error updating post', err);
                    alert('Failed to update post');
                }
            });
        }
    }
}
