using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CardNumber).NotEmpty().WithMessage("Kart numarası boş bırakılamaz.");
            RuleFor(c => c.ExpireYear).NotEmpty().WithMessage("Kart son kullanma tarihi boş bırakılamaz.");
            RuleFor(c => c.ExpireMonth).NotEmpty().WithMessage("Kartın son kullanma tarihi boş bırakılamaz.");
            RuleFor(c => c.Cvv).NotEmpty().WithMessage("Kart cvv numarası boş bırakılamaz.");
            RuleFor(c => c.CardOwner).NotEmpty().WithMessage("Kart sahibi alanı boş bırakılamaz.");

        }
    }
}
