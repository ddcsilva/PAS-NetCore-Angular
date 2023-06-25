import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EstudantesComponent } from './estudantes/estudantes.component';
import { DetalheEstudanteComponent } from './estudantes/detalhe-estudante/detalhe-estudante.component';

const routes: Routes = [
  {
    path: '',
    component: EstudantesComponent
  },
  {
    path: 'estudantes',
    component: EstudantesComponent
  },
  {
    path: 'estudantes/:id',
    component: DetalheEstudanteComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
