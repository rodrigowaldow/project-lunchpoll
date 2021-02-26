import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { map, filter, switchMap, catchError } from 'rxjs/operators';
import { LunchLocal } from './lunch-local.model';

@Injectable({
  providedIn: 'root'
})
export class LunchLocalService {
  localData: LunchLocal= new LunchLocal();
  readonly baseURL = 'http://localhost:62128/api/LunchLocal';
  list : LunchLocal[];

  constructor(private _http: HttpClient) { }

  async getLocals() {
    return this._http.get(this.baseURL)
      .toPromise()
      .then(res =>this.list = res as LunchLocal[]);
    // return this._http.get(this.baseURL).pipe(
    //   map((response: any) => {
    //     console.log("Data got: ");
    //     console.log(response);
    //     return response as LunchLocal[]
    //   }),
    //   catchError(this.errorHandler)
    // );
  }

  getTotalVotes() {
    return this._http.get(this.baseURL + '/TotalVotes');
  }

  saveVote() {
    this.localData.voteCount++;
    return this._http.put(`${this.baseURL}/${this.localData.localId}`, this.localData);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}
