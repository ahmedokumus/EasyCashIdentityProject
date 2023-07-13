using System.Runtime.CompilerServices;
using DtoLayer.Dtos.AppUserDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppUser;

public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez!");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez!");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez!");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre doğrulama boş geçilemez!");
        RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girin.");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 2 karakter girin.");
        RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin.");
    }
}