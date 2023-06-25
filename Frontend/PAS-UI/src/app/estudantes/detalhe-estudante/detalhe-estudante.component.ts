import { Component, OnInit } from '@angular/core';
import { EstudanteService } from '../estudante.service';
import { ActivatedRoute } from '@angular/router';
import { Estudante } from 'src/app/models/estudante.model';

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

  constructor(private readonly estudanteService: EstudanteService, private readonly route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.estudanteId = params.get('id');

        if (this.estudanteId) {
          this.estudanteService.obterEstudante(this.estudanteId).subscribe({
            next: (response) => {
              this.estudante = response;
            },
            error: (error) => {
              console.log(error);
            }
          })
        }
      }
    )
  }
}