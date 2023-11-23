import { Pipe, PipeTransform } from '@angular/core';
import { BugStatus } from '../models';

@Pipe({ name: 'bugStatus' })
export class BugStatusPipe implements PipeTransform {
  transform(bugStatus: number): string {
    switch (bugStatus) {
      case BugStatus.Todo:
        return 'Todo';
      case BugStatus.InProgress:
        return 'Under arbeid';
      case BugStatus.Completed:
        return 'Fullført';
      default:
        return 'Ukjent';
    }
  }
}