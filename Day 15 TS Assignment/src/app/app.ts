import { Component } from '@angular/core';

import { FooterComponent } from '../components/footer/footer';
import { NavbarComponent } from '../components/navbar/navbar';
import { DescriptionComponent } from '../components/description/description';
import { WelcomeBannerComponent } from '../components/welcome-banner/welcome-banner';
import { InsuranceProfilesComponent } from '../components/insurance-profiles/insurance-profiles';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    FooterComponent,
    NavbarComponent,
    DescriptionComponent,
    WelcomeBannerComponent,
    InsuranceProfilesComponent
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {
}
