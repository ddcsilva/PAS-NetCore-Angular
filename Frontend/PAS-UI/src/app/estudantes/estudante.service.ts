import { AtualizarEstudanteRequest } from './../models/atualizar-estudante-request.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estudante } from '../models/estudante.model';

@Injectable({
  providedIn: 'root'
})
export class EstudanteService {

  private urlBaseApi = 'https://localhost:7132';

  constructor(private httpClient: HttpClient) { }

  obterEstudantes(): Observable<Estudante[]> {
    return this.httpClient.get<Estudante[]>(this.urlBaseApi + '/estudantes');
  }

  obterEstudante(estudanteId: string): Observable<Estudante> {
    return this.httpClient.get<Estudante>(this.urlBaseApi + '/estudantes/' + estudanteId);
  }

  atualizarEstudante(estudanteId: string, estudanteRequest: Estudante): Observable<Estudante> {
    const atualizarEstudanteRequest: AtualizarEstudanteRequest = {
      nome: estudanteRequest.nome,
      sobrenome: estudanteRequest.sobrenome,
      dataNascimento: estudanteRequest.dataNascimento,
      email: estudanteRequest.email,
      telefone: estudanteRequest.telefone,
      generoId: estudanteRequest.generoId,
      enderecoFisico: estudanteRequest.endereco.enderecoFisico,
      enderecoPostal: estudanteRequest.endereco.enderecoPostal
    }

    return this.httpClient.put<Estudante>(this.urlBaseApi + '/estudantes/' + estudanteId, atualizarEstudanteRequest);
  }

  excluirEstudante(estudanteId: string): Observable<Estudante> {
    return this.httpClient.delete<Estudante>(this.urlBaseApi + '/estudantes/' + estudanteId);
  }
}
