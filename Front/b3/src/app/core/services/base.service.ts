import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export abstract class BaseService {
  constructor() {}

  public extractData(res: Response):  Promise<any> {
    const body = res.json();
    return body || {};
  }

  public handleError(error: Response | any) {
    // In a real-world app, we might use a remote logging infrastructure
    let errMsg: string;

    if (error && error.error.auth === false) {
        return Observable;
    }

    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }

    return error;
  }

  public header() {
    let header = new HttpHeaders({ 'Content-Type': 'application/json' });
    const token = sessionStorage.getItem('kas.token');
    if (!token) {
      return;
    }
    header = header.append('Authorization', 'Bearer ' + token);
    return { headers: header };
  }
}
