import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Genero } from '../models/genero.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GeneroService {

  private urlBaseApi = environment.urlBaseApi;

  constructor(private httpClient: HttpClient) { }

  obterGeneros(): Observable<Genero[]> {
    return this.httpClient.get<Genero[]>(this.urlBaseApi + '/generos');
  }
}
