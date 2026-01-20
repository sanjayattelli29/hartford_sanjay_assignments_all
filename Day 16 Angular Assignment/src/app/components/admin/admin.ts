import { Component, OnInit, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';

interface LifecycleLog {
  method: string;
  timestamp: string;
  description: string;
}

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './admin.html',
  styleUrl: './admin.css',
})
export class Admin implements OnInit, OnChanges, OnDestroy {

  counter: number = 0;
  lifecycleLogs: LifecycleLog[] = [];
  componentInitialized: boolean = false;

  ngOnInit(): void {
  console.log("ngOnInit");
  this.componentInitialized = true;
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("ngOnChanges", changes);
  }

  ngOnDestroy(): void {
    console.log("ngOnDestroy");
  }

  incrementCounter(): void {
    this.counter++;
  }

  resetCounter(): void {
    this.counter = 0;
  }

  clearLogs(): void {
    this.lifecycleLogs = [];
  }
}
