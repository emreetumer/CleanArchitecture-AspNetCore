using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı ya da email bilgisi boş olamaz!");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı ya da email bilgisi boş olamaz!");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı adı ya da email bilgisi 3 karakterden kısa olamaz!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre bilgisi boş olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre bilgisi boş olamaz!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 büyük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir!");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1 adet özel karakter içermelidir!");
    }
}
