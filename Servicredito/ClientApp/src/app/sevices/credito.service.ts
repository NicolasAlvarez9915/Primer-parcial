import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { Credito } from '../servicredito/model/credito';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CreditoService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
      private handleErrorService: HandleHttpErrorService

  ) { this.baseUrl = baseUrl;
  }

  get(): Observable<Credito[]> {
    return this.http.get<Credito[]>(this.baseUrl + 'api/Creditos')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Credito[]>('Consulta Creditos', null))
        );
  }

  post(creditos: Credito): Observable<Credito> {
    return this.http.post<Credito>(this.baseUrl + 'api/Creditos', Credito)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Credito>('Registrar Creditos', null))
        );
}
}
