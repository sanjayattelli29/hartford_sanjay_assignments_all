import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrimTextPipe } from '../../app/custom-pipe/trim-text-pipe';

@Component({
  selector: 'app-pipe-demo',
  imports: [CommonModule, TrimTextPipe],
  templateUrl: './pipe-demo.html',
  styleUrl: './pipe-demo.css',
})
export class PipeDemo {
  title = "Angular Pipes Demo";
  name = signal("angular framework");

  amount = 12345.6789;
  today = new Date();
  mobile = "samsung galaxy s24 ultra";
  percentVal = 0.8543;
  longText = "This is a very long text that needs to be trimmed or sliced for better display.";

  user = signal({
    name: 'sanjay',
    age: 20,
    dob: new Date('2000-01-01'),
    role: 'Admin'
  });
}
