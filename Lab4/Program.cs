namespace Lab4 {
    public class Program {
        public static void Main() {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\RiderProjects\\CryptographyLab\\Lab4\\hw1.txt");
            string encText = String.Join("", lines);
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < 26; i++) {
                Console.WriteLine(i); //pt index 17
                Console.WriteLine(new SimpleSubstitution().Encipher(alphabet,i));
                Console.WriteLine(new SimpleSubstitution().Decipher(encText,i));
                Console.WriteLine();
                
            }

            string key = "cryptography";
            string finalAlphabet = new Transposition().FinalAlphabet(key,3);
            string text = "ITWASDISCLOSEDYESTERDAYTHATSEVERAL".ToLower();
            string encrypted = new Transposition().Encipher(alphabet, finalAlphabet, text);
            int separator=5;
            for (int i = 0; i < encrypted.Length; i += separator) {
                Console.Write(encrypted.Substring(i,Math.Min(separator,encrypted.Length-i)));
                Console.Write(" ");
            }

        }
    }
}


