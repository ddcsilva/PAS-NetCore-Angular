import { Component, OnInit, ViewChild } from '@angular/core';
import { EstudanteService } from '../estudante.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Estudante } from 'src/app/models/estudante.model';
import { GeneroService } from 'src/app/services/genero.service';
import { Genero } from 'src/app/models/genero.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NgForm } from '@angular/forms';

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
  };
  novoEstudante: boolean = false;
  titulo: string = '';
  imagemPerfilUrl: string = '';

  listaGeneros: Genero[] = [];

  @ViewChild('formularioDetalhesEstudante') formularioDetalhesEstudante?: NgForm;

  constructor(
    private readonly estudanteService: EstudanteService,
    private readonly generoService: GeneroService,
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.estudanteId = params.get('id');

        if (this.estudanteId) {
          if (this.estudanteId.toLocaleLowerCase() === 'Novo'.toLocaleLowerCase()) {
            this.novoEstudante = true;
            this.titulo = 'Novo Estudante';
            this.definirImagem();
          } else {
            this.novoEstudante = false;
            this.titulo = 'Editar Estudante';

            this.estudanteService.obterEstudante(this.estudanteId).subscribe({
              next: (response) => {
                this.estudante = response;
                this.definirImagem();
              },
              error: (error) => {
                this.definirImagem();
              }
            })
          }

          this.generoService.obterGeneros().subscribe({
            next: (response) => {
              this.listaGeneros = response;
            }
          })
        }
      }
    )
  }

  adicionar(): void {
    if (this.formularioDetalhesEstudante?.form.valid) {
      this.estudanteService.adicionarEstudante(this.estudante).subscribe({
        next: (response) => {
          this.snackbar.open('Estudante adicionado com sucesso!', 'Fechar', {
            duration: 2000
          });

          setTimeout(() => {
            this.router.navigateByUrl('estudantes');
          }, 2000);
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
  }

  atualizar(): void {
    if (this.formularioDetalhesEstudante?.form.valid) {
      this.estudanteService.atualizarEstudante(this.estudante.id, this.estudante).subscribe({
        next: (response) => {
          this.snackbar.open('Estudante atualizado com sucesso!', 'Fechar', {
            duration: 2000
          });
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
  }

  excluir(): void {
    this.estudanteService.excluirEstudante(this.estudante.id).subscribe({
      next: (response) => {
        this.snackbar.open('Estudante excluído com sucesso!', 'Fechar', {
          duration: 2000
        });

        setTimeout(() => {
          this.router.navigateByUrl('estudantes');
        }, 2000);
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  uploadImagem(event: any): void {
    if (this.estudanteId) {
      const arquivo: File = event.target.files[0];
      this.estudanteService.uploadImagem(this.estudanteId, arquivo).subscribe({
        next: (response) => {
          this.estudante.imagemPerfilUrl = response;
          this.definirImagem();

          this.snackbar.open('Imagem atualizada com sucesso!', 'Fechar', {
            duration: 2000
          });
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
  }

  private definirImagem(): void {
    if (this.estudante.imagemPerfilUrl) {
      this.imagemPerfilUrl = this.estudanteService.obterCaminhoImagem(this.estudante.imagemPerfilUrl);
    }
    else {
      this.imagemPerfilUrl = '/assets/images/sem-imagem.png';
    }
  }
}

function ViewChield(arg0: string): (target: DetalheEstudanteComponent, propertyKey: "formularioDetalhesEstudante") => void {
  throw new Error('Function not implemented.');
}
