import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bug',
  templateUrl: './bug.component.html',
  styleUrls: ['./bug.component.sass'],
})
export class BugComponent implements OnInit {

  constructor() {
    console.log('hallo?');
  }

  ngOnInit() {
    
  }
}
