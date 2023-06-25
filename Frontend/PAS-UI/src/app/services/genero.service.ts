import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Genero } from '../models/genero.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeneroService {

  private urlBaseApi = 'https://localhost:7132';

  constructor(private httpClient: HttpClient) { }

  obterGeneros(): Observable<Genero[]> {
    return this.httpClient.get<Genero[]>(this.urlBaseApi + '/generos');
  }
}
