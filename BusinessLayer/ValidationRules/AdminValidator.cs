using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUsername).NotEmpty().WithMessage("Admin Maili Boş Geçilemez");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");

            RuleFor(x => x.AdminUsername).MinimumLength(10).WithMessage("Lütfen en az 10 karakter giriniz");
            RuleFor(x => x.AdminPassword).MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz");

            RuleFor(x => x.AdminUsername).MaximumLength(50).WithMessage("Maximum 50 karakter girebilirsiniz");
            RuleFor(x => x.AdminPassword).MaximumLength(50).WithMessage("Maximum 50 karakter girebilirsiniz");

        }



    }
}
