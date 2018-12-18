using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                    .Requires()
                    .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caractéres")
                    .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter no máximo 40 caractéres")
                    .HasMinLen(LastName, 3, "Name.LastName", "SobreNome deve conter pelo menos 3 caractéres")
                    .HasMaxLen(LastName, 40, "Name.LastName", "SobreNome deve conter no máximo 40 caractéres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}