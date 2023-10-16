// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine("The time is " + DateTime.Now);
public class BadCode {
    public static void main(String[] args) {
        // This code is difficult to read and understand.
        int[] numbers = new int[]{1, 2, 3, 4, 5};
        for (int i = 0; i < numbers.length; i++) {
            if (numbers[i] % 2 == 0) {
                System.out.println(numbers[i]);
            }
        }

        // This code is unnecessary complex.
        int sum = 0;
        for (int i = 0; i < numbers.length; i++) {
            sum += numbers[i];
        }
        System.out.println(sum);

        // This code has no comments.
        // ...
    }
}


