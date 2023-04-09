
namespace Lab3 {
    
    public class Substitution {
        public Substitution() { }
        public void computeFrecv(string text) {
            int[] frecv = new int[26]; // initializeaza cu 0
            foreach (char c in text) {
                frecv[c - 'a']++;
            }

            int index = 0;
            foreach (int val in frecv) {
                Console.WriteLine((char)('a' + index) + ": " + val);
                index++;
                
            }
        }
    }

    public class Program {
        
        static string Encipher(string baseAlphabet, string newAlphabet, string clearText) {
            string encText = string.Empty;
            for (int i = 0; i < clearText.Length; i++) {
                encText += newAlphabet[baseAlphabet.IndexOf(clearText[i])];
            }

            return encText;
        }
        
        static string Decipher(string baseAlphabet, string newAlphabet, string encText) {
            string clearText = string.Empty;
            for (int i = 0; i < encText.Length; i++) {
                int index = newAlphabet.IndexOf(encText[i]);
                if (index == -1) {
                    clearText += "-";
                }
                else {
                    clearText += baseAlphabet[newAlphabet.IndexOf(encText[i])]; 
                }
               
            }

            return clearText;
        }

        public static void Main() {
            string encText = "";
            string[] alphabets= {
                "abcdefghijklmnopqrstuvwxyz",
                "cgshpjtin-fzwokr-mqluv-b-a",
                "w---f---z--------djte-----"
                
            };
            
            
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\RiderProjects\\CryptographyLab\\Lab3\\hw2.txt");
            encText = String.Join("", lines);
            
            new Substitution().computeFrecv(lines[1]);
            Console.WriteLine(Decipher(alphabets[0], alphabets[1], lines[0]));
            Console.WriteLine(Decipher(alphabets[0], alphabets[2], lines[1]));
            
        }


    }
}

