export interface AdicionarEstudanteRequest {
    nome: string;
    sobrenome: string;
    dataNascimento: string;
    email: string;
    telefone: number;
    generoId: string;
    enderecoFisico: string;
    enderecoPostal: string;
}