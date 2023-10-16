public class BadCode
{
    public static void Main(string[] args)
    {
        // This code is difficult to read and understand.
        int[] numbers = new int[]{1, 2, 3, 4, 5};
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        // This code is unnecessary complex.
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine(sum);

        // This code has no comments.
        // ...
    }
}
