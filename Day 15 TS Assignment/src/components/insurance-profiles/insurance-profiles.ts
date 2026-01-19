import { Component } from '@angular/core';
import { NgIconComponent } from '@ng-icons/core';

@Component({
  selector: 'app-insurance-profiles',
  standalone: true,
  imports: [NgIconComponent],
  templateUrl: './insurance-profiles.html',
  styleUrl: './insurance-profiles.css',
})
export class InsuranceProfilesComponent {
  activeCard: string = 'auto'; 

  selectCard(card: string) {
    this.activeCard = card;
  }
}
