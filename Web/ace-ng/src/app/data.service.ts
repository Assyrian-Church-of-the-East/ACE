import { Injectable, OnInit } from '@angular/core';
import { AppConfigService } from './AppConfigService';
import { IMember } from './model/IMember';
import { Observable, BehaviorSubject, throwError } from 'rxjs';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataService implements OnInit {

  private membersObserver: BehaviorSubject<IMember[]>;

  constructor(private configService: AppConfigService,private _http: HttpClient) {
    this.membersObserver = new BehaviorSubject<IMember[]>([]);
  }

  ngOnInit() {
 
  }

  downLoadMembers() {
    let url = this.configService.settings.api + "/members";
    this.post(url).subscribe((memebers: IMember[])=>{
      console.log("get mebmers!");
      this.membersObserver.next(memebers);
    });
    return this.membersObserver;
  }
  


  private post<T>(url: string, body?: any): Observable<T> {
    if (url == undefined || url == null) {
      console.error("post received url " + url);
      throw new URIError();
    }
    return this._http.post<T>(url, body, { withCredentials: true }).pipe(catchError(err => this.handleError(url, err)));
  }

  private handleError(url: string, error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(`Error: Backend returned code ${error.status}, name ${error.name}, body was: ${error.error} when calling url ${url} message: ${error.message}`);
    }
    return throwError(`Error for call ${url}`);
  }
}
};

