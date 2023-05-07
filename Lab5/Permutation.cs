namespace Lab5;

public class Permutation {
    public static void Generate() {
        int[] perm = { 0, 1, 2, 3, 4, 5, 6 };
        char[] chars = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
            'v', 'w', 'x', 'y', 'z'
        };

        Random r = new Random();
        for (int it = 1; it <= 100; it++) {
            int i = r.Next(26);
            int j = r.Next(26);

            // char aux = chars[i];
            // chars[i] = chars[j];
            // chars[j] = aux;

            (chars[i], chars[j]) = (chars[j], chars[i]); //swap

            for (int k = 0; k < chars.Length; k++) {
                Console.Write(chars[k] + " ");
            }

            Console.WriteLine();
        }
    }
}