
namespace Lab4 {
    public class SimpleSubstitution {
        
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public string Encipher(string text,int key) {
            string encText = string.Empty;
            IntOps obj = new IntOps(26);

            for (int i = 0; i < text.Length; i++) {
                int index = alphabet.IndexOf(text[i]);
                int finalIndex = obj.Add(index, key);
                encText += alphabet[finalIndex];
            }
            return encText;
        }

        public string Decipher(string text, int key) {
            return Encipher(text, -key);
        }
        
    }
}