import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface Policy {
  id?: number;
  policyName: string;
  provider: string;
  premium: number;
  coverageAmount: number;
}

@Injectable({ providedIn: 'root' })
export class PolicyService {
  private http = inject(HttpClient);
  private api = 'https://localhost:7124/api/Policies';

  getAll() {
    return this.http.get<Policy[]>(this.api);
  }

  add(policy: Policy) {
    return this.http.post(this.api, policy);
  }

  delete(id: number) {
    return this.http.delete(`${this.api}/${id}`);
  }
}
