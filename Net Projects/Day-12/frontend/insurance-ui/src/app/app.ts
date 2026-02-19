import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';   // ✅ ADD THIS
import { PolicyService, Policy } from './policy.service';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css',
  imports: [FormsModule]   // ✅ ADD THIS
})
export class App {

  private service = inject(PolicyService);

  active = 'list';

  policies = signal<Policy[]>([]);

  form: Policy = {
    policyName: '',
    provider: '',
    premium: 0,
    coverageAmount: 0
  };

  ngOnInit() {
    this.loadPolicies();
  }

  loadPolicies() {
    this.service.getAll().subscribe(data => this.policies.set(data));
  }

  add() {
    this.service.add(this.form).subscribe(() => {
      this.loadPolicies();

      this.form = {
        policyName: '',
        provider: '',
        premium: 0,
        coverageAmount: 0
      };

      this.active = 'list';
    });
  }

  delete(id: number) {
    this.service.delete(id).subscribe(() => this.loadPolicies());
  }
}
