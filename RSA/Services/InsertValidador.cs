using FluentValidation;
using RSA.Domain;

namespace RSA.Services
{
    public class InsertRequestValidator : AbstractValidator<InsertRequest>
    {
        public InsertRequestValidator()
        {
            RuleFor(x => x.KeySize).Must(y => y.Equals(1024) || y.Equals(2048) || y.Equals(4096)).WithMessage("Not Allowed Values");
            RuleFor(x => x.PrivateKeyPassword).NotEmpty().When(m => m.Encryption).WithMessage("Private Key Password Must Be Informed");
        }
    }
}
