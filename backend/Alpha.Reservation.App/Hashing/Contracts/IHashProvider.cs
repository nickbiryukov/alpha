namespace Alpha.Reservation.App.Hashing.Contracts
{
    public interface IHashProvider
    {
        string CreateHash(string value, string salt);

        string CreateHash(string value);

        string CreateSalt();

        bool Validate(string value, string valueHash);
    }
}