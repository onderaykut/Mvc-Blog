using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Kullanıcı Mail Alanı Boş Geçilemez");
          //  RuleFor(x => x.UserMail).MaximumLength(50).WithMessage("Maximum 50 karakter girebilirsiniz");
         //   RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj Konusu Boş Geçilemez");
           // RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
           // RuleFor(x => x.Message).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");

        }

    }
}
