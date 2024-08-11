import { Injectable } from "@angular/core";
import { BaseService } from "../../core/services/base.service";
import { HttpClient } from "@angular/common/http";
import { CDB } from "../models/cdb.models";
import { catchError, Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable({
    providedIn: 'root',
})
export class CDBService extends BaseService {

    private pathAPI = environment.API_URL;
    
    constructor(private http: HttpClient) {
        super();
    }

    CalculoCDB(cdb: CDB): Observable<CDB | any> {
        return this.http
            .post<CDB>(this.pathAPI + 'CDB', cdb, super.header())
            .pipe(catchError(super.handleError));
    }
}