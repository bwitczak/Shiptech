namespace Faker;

public static class FakerExtensions
{
    public static string LetterWithOptionalDigit(this Bogus.Faker faker, double digitProbability)
    {
        char letter = (char)faker.Random.Int('A', 'Z');

        if (!(faker.Random.Double() < digitProbability))
        {
            return letter.ToString();
        }

        int digit = faker.Random.Int(0, 9);
        return $"{letter}{digit}";
    }
}
