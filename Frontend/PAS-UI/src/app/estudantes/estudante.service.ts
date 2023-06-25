import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estudante } from '../models/estudante.model';

@Injectable({
  providedIn: 'root'
})
export class EstudanteService {

  private urlBaseApi  = 'https://localhost:7132';

  constructor(private httpClient: HttpClient) { }

  obterEstudantes(): Observable<Estudante[]> {
    return this.httpClient.get<Estudante[]>(this.urlBaseApi + '/estudantes');
  }

  obterEstudante(estudanteId: string): Observable<Estudante> {
    return this.httpClient.get<Estudante>(this.urlBaseApi + '/estudantes/' + estudanteId);
  }
}
