import { Component, OnInit } from '@angular/core';
import { IMember } from '../model/IMember';
import { DataService } from '../data.service';
import { Subscription, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  members: IMember[];
  anyMemebers:boolean;

  constructor(private dataService: DataService) {
  }

  ngOnInit() {

    this.dataService.getMembers.subscribe((param_Memeber: IMember[]) => {
      this.members = param_Memeber;
    });

    if(this.members){
      this.anyMemebers = true;
    }

  }

}
