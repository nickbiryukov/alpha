using System;
using System.Security.Cryptography;
using System.Text;
using Alpha.Reservation.App.Hashing.Contracts;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Alpha.Reservation.App.Hashing
{
    public class HashProvider : IHashProvider
    {
        private const int Iteration = 10000;
        private const int KeySize = 32;

        public string CreateHash(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: Iteration,
                numBytesRequested: KeySize);

            return Convert.ToBase64String(valueBytes);
        }

        public string CreateHash(string value)
        {
            var salt = CreateSalt();
            var hash = CreateHash(value, salt);

            return $"{salt}.{hash}";
        }

        public string CreateSalt()
        {
            var randomBytes = new byte[32];

            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public bool Validate(string value, string hash)
        {
            var parts = hash.Split('.', 2);

            if (parts.Length != 2)
                throw new FormatException(
                    "Unexpected hash format. Should be formatted as `{salt}.{hash}`");

            var saltPart = parts[0];
            var keyPart = parts[1];

            var newHash = CreateHash(value, saltPart);

            return newHash == keyPart;
        }
    }
}