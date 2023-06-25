import { Endereco } from "./endereco.model";
import { Genero } from "./genero.model";

export interface Estudante {
    id: string;
    nome: string;
    sobrenome: string;
    dataNascimento: Date;
    email: string;
    telefone: number;
    imagemPerfilUrl: string;
    generoId: string;
    genero: Genero;
    endereco: Endereco;
}