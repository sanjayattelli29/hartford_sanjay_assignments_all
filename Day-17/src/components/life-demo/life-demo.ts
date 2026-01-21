import {
  Component,
  OnInit,
  OnChanges,
  DoCheck,
  AfterViewInit,
  AfterViewChecked,
  SimpleChanges,
  OnDestroy
} from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-life-demo',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './life-demo.html',
  styleUrls: ['./life-demo.css'],
})
export class LifeDemo
  implements OnInit, OnChanges, DoCheck, AfterViewInit, AfterViewChecked, OnDestroy {
  count: number = 0;
  arr: number[] = [];
  total: number = 0;

  logs: string[] = [];
  status: string = 'Component created';

  ngOnInit() {
    this.status = 'ngOnInit: Component loaded';
    this.logs.push(this.status);

    this.count = 1;
    this.arr = [1];
    this.calculateTotal();
  }

  ngOnChanges(changes: SimpleChanges) {
    this.status = 'ngOnChanges: Data changed';
    this.logs.push(this.status);
  }

  ngDoCheck() {
    this.logs.push('ngDoCheck: Change detection running');
  }

  ngAfterViewInit() {
    this.logs.push('ngAfterViewInit: View ready (DOM loaded)');
  }

  ngAfterViewChecked() {
    this.logs.push('ngAfterViewChecked: View checked');
  }

  ngOnDestroy() {
    console.log('ngOnDestroy: Component destroyed');
    alert('ngOnDestroy: LifeDemo Component is being destroyed!');
  }

  increment() {
    this.count++;
    this.arr.push(this.count);
    this.calculateTotal();

    this.status = 'Manual change happened';
    this.logs.push('Manual data change triggered');
  }

  calculateTotal() {
    this.total = this.arr.reduce((a, b) => a + b, 0);
  }

  clearLogs() {
    this.logs = [];
  }
}
