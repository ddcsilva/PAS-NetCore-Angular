import { Component, OnInit } from '@angular/core';
import { EstudanteService } from '../estudante.service';
import { ActivatedRoute } from '@angular/router';
import { Estudante } from 'src/app/models/estudante.model';
import { GeneroService } from 'src/app/services/genero.service';
import { Genero } from 'src/app/models/genero.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-detalhe-estudante',
  templateUrl: './detalhe-estudante.component.html',
  styleUrls: ['./detalhe-estudante.component.scss']
})
export class DetalheEstudanteComponent implements OnInit {
  estudanteId: string | null | undefined;
  estudante: Estudante = {
    id: '',
    nome: '',
    sobrenome: '',
    dataNascimento: '',
    email: '',
    telefone: 0,
    imagemPerfilUrl: '',
    generoId: '',
    genero: {
      id: '',
      descricao: ''
    },
    endereco: {
      id: '',
      enderecoFisico: '',
      enderecoPostal: ''
    }
  }

  listaGeneros: Genero[] = [];

  constructor(
    private readonly estudanteService: EstudanteService, 
    private readonly generoService: GeneroService,
    private readonly route: ActivatedRoute,
    private snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.estudanteId = params.get('id');

        if (this.estudanteId) {
          this.estudanteService.obterEstudante(this.estudanteId).subscribe({
            next: (response) => {
              this.estudante = response;
            }
          })

          this.generoService.obterGeneros().subscribe({
            next: (response) => {
              this.listaGeneros = response;
            }
          })
        }
      }
    )
  }

  atualizar(): void {
    this.estudanteService.atualizarEstudante(this.estudante.id, this.estudante).subscribe({
      next: (response) => {
        this.snackbar.open('Estudante atualizado com sucesso!', 'Fechar', {
          duration: 3000
        });
      },
      error: (error) => {
        console.log(error);
      }
    })
  }
}