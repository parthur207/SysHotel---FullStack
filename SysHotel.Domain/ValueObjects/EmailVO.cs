using System;
using System.Text.RegularExpressions;

namespace SysHotel.Domain.ValueObjects
{
    public class EmailVO : IEquatable<EmailVO>
    {
        public string Endereco { get; }

        // Regex simples e eficiente para validar formato básico de e-mail
        private const string EmailRegexPattern =
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        private static readonly Regex EmailRegex =
            new Regex(EmailRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Construtor imutável
        public EmailVO(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("O e-mail não pode ser vazio.");

            if (!EmailRegex.IsMatch(endereco))
                throw new ArgumentException("Formato de e-mail inválido.");

            Endereco = endereco.Trim();
        }

        // Evita new desnecessário
        public static EmailVO From(string endereco) => new EmailVO(endereco);

        // Igualdade de Value Object
        public bool Equals(EmailVO? other)
        {
            if (other is null) return false;
            return Endereco.Equals(other.Endereco, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj) => Equals(obj as EmailVO);

        public override int GetHashCode() =>
            Endereco.ToLowerInvariant().GetHashCode();

        // Conversão implícita (qualidade de vida)
        public static implicit operator string(EmailVO email) => email.Endereco;

        public override string ToString() => Endereco;
    }
}
