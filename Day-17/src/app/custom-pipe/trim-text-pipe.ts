import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'trimText',
})
export class TrimTextPipe implements PipeTransform {
  

  transform(value: string, ...args: unknown[]): string {
    return value.substring(0,5);
  }

}
