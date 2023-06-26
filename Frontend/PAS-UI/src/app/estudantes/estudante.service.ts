import { AtualizarEstudanteRequest } from './../models/atualizar-estudante-request.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estudante } from '../models/estudante.model';
import { AdicionarEstudanteRequest } from '../models/adicionar-estudante-request.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstudanteService {

  private urlBaseApi = environment.urlBaseApi;

  constructor(private httpClient: HttpClient) { }

  obterEstudantes(): Observable<Estudante[]> {
    return this.httpClient.get<Estudante[]>(this.urlBaseApi + '/estudantes');
  }

  obterEstudante(estudanteId: string): Observable<Estudante> {
    return this.httpClient.get<Estudante>(this.urlBaseApi + '/estudantes/' + estudanteId);
  }

  adicionarEstudante(estudanteRequest: Estudante): Observable<Estudante> {
    const adicionarEstudanteRequest: AdicionarEstudanteRequest = {
      nome: estudanteRequest.nome,
      sobrenome: estudanteRequest.sobrenome,
      dataNascimento: estudanteRequest.dataNascimento,
      email: estudanteRequest.email,
      telefone: estudanteRequest.telefone,
      generoId: estudanteRequest.generoId,
      enderecoFisico: estudanteRequest.endereco.enderecoFisico,
      enderecoPostal: estudanteRequest.endereco.enderecoPostal
    }

    return this.httpClient.post<Estudante>(this.urlBaseApi + '/estudantes/adicionar', adicionarEstudanteRequest);
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

  uploadImagem(estudanteId: string, arquivo: File): Observable<string> {
    const formData = new FormData();
    formData.append('imagemPerfil', arquivo);

    return this.httpClient.post(this.urlBaseApi + '/estudantes/' + estudanteId + '/upload-imagem', formData, {
      responseType: 'text'
    });
  }

  obterCaminhoImagem(caminhoRelativo: string): string {
    return `${this.urlBaseApi}/${caminhoRelativo}`
  }
}
