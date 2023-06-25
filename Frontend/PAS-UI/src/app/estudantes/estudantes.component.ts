import { Component, OnInit, ViewChild } from '@angular/core';
import { EstudanteService } from './estudante.service';
import { Estudante } from '../models/estudante.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-estudantes',
  templateUrl: './estudantes.component.html',
  styleUrls: ['./estudantes.component.scss']
})
export class EstudantesComponent implements OnInit {
  estudantes: Estudante[] = [];
  colunas: string[] = ['nome', 'sobrenome', 'dataNascimento', 'email', 'telefone', 'genero'];
  dataSource: MatTableDataSource<Estudante> = new MatTableDataSource<Estudante>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  filtroEstudante = '';

  constructor(private estudanteService: EstudanteService) { }

  ngOnInit(): void {
    this.estudanteService.obterEstudantes().subscribe({
      next: (response) => {
        this.estudantes = response;
        this.dataSource = new MatTableDataSource<Estudante>(this.estudantes);

        if (this.paginator) {
          this.dataSource.paginator = this.paginator;
        }

        if (this.sort) {
          this.dataSource.sort = this.sort;
        }
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  filtrarEstudantes(): void {
    this.dataSource.filter = this.filtroEstudante.trim().toLowerCase();
  }
}
