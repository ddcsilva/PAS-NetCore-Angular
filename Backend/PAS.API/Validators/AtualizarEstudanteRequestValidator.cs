using FluentValidation;
using PAS.API.Repositories;
using PAS.API.ViewModels;

namespace PAS.API.Validators;

public class AtualizarEstudanteRequestValidator : AbstractValidator<AtualizarEstudanteViewModel>
{
    public AtualizarEstudanteRequestValidator(IEstudanteRepository estudanteRepository)
    {
        RuleFor(estudante => estudante.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(50).WithMessage("O nome não pode ter mais de 50 caracteres.");

        RuleFor(estudante => estudante.Sobrenome)
            .NotEmpty().WithMessage("O sobrenome é obrigatório.")
            .MaximumLength(50).WithMessage("O sobrenome não pode ter mais de 50 caracteres.");

        RuleFor(estudante => estudante.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
            .LessThan(DateTime.Now).WithMessage("A data de nascimento não pode ser maior que a data atual.");

        RuleFor(estudante => estudante.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email não é válido.");

        RuleFor(estudante => estudante.Telefone)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .GreaterThan(0).WithMessage("O telefone não é válido.");

        RuleFor(estudante => estudante.GeneroId)
            .NotEmpty().Must(id =>
            {
                var genero = estudanteRepository.ObterGenerosAsync().Result.ToList()
                    .FirstOrDefault(genero => genero.Id == id);

                if (genero != null)
                {
                    return true;
                }

                return false;
            }).WithMessage("O gênero não é válido.");

        RuleFor(estudante => estudante.EnderecoFisico)
            .NotEmpty().WithMessage("O endereço físico é obrigatório.")
            .MaximumLength(100).WithMessage("O endereço físico não pode ter mais de 100 caracteres.");

        RuleFor(estudante => estudante.EnderecoPostal)
            .NotEmpty().WithMessage("O endereço postal é obrigatório.")
            .MaximumLength(100).WithMessage("O endereço postal não pode ter mais de 100 caracteres.");
    }
}