import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LifeDemo } from '../components/life-demo/life-demo'
import { PipeDemo } from '../components/pipe-demo/pipe-demo'
import { CommonModule } from '@angular/common';
import { FormDemo } from '../components/form-demo/form-demo'
import { ApiDemo } from '../components/api-demo/api-demo'

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LifeDemo, PipeDemo, CommonModule, FormDemo, ApiDemo],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Day-17');
  title2 = 'custom pipe';
}
