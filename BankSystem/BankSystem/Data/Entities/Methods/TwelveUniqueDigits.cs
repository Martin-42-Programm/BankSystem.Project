namespace BankSystem.Data.Entities.Methods;

public class TwelveUniqueDigits
{
    private static Random random = new Random();
    private static HashSet<string> generatedNumbers = new HashSet<string>();

    public static string GenerateUnique12DigitNumber()
    {
        string number;
        do
        {
            number = new string(Enumerable.Range(0, 12)
                .Select(_ => (char)('0' + random.Next(0, 10)))
                .ToArray());
        } while (!generatedNumbers.Add(number)); // Only adds if it's unique

        return number;
    }
}