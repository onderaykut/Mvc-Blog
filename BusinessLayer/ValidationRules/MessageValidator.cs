using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
           RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez");
           RuleFor(x => x.MessageContent).MinimumLength(30).WithMessage("Lütfen en az 30 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Maximum 100 karakter girebilirsiniz");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Mail Adresi Boş Geçilemez");
            //  RuleFor(x => x.ReceiverMail).Must(@ => @.ToString().Contains("@")).WithMessage("Mail adresi içinde @gmail.com ifadesi geçmeli");
            RuleFor(x => x.ReceiverMail)
      .Must(x => x != null && x.ToString().Contains("@") && x.ToString().Contains("@gmail.com"))
      .WithMessage("Mail adresi içinde @gmail.com ifadesi geçmeli");


        }
    }
}
