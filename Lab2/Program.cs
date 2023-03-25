namespace Lab2 {
    class Program {
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
                clearText += baseAlphabet[newAlphabet.IndexOf(encText[i])];
            }

            return clearText;
        }

        static void Main(string[] args) {
            string encText = "vcnovnlcwnormnwcqcrlcwcochphurcvcscolcnolpmqpwpqlmnczczcknolczonmpsumprmpapolcolnnskohuspmnnjcsuzlclnnhppzpslmkonsclpzpskwuonsclnnqnlpiokzktncnojkmwclnpnnwrmpuocsusclplmpnqcurclmuqluhpolnhpzcjnpscmpqpmnpvpsipcqpmnphnocouzlmpnqluhpolnnquolnovnlclnqcqnqruockrnonchpqrmpsppcspskoqnhpmccjnrmkgzpwpzpsppbnqlcnojcsuzlclprulcohrmkruopqnqkzulnnhcschkmpqscspcqlcnolczonmpmprmpanolckskolnoucmpcnonlnclnvpzkmjjkmwuzcmpzkmhpjpphgcsf";
            string baseAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string newAlphabet = "vylsobfrdhpwgxukmicneajqzt";//random alphabet substitution

            string decText = Decipher(baseAlphabet, newAlphabet, encText);
            
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\RiderProjects\\lab2\\lab2\\hw1.txt");
            foreach (string line in lines) {
                Console.WriteLine(Decipher(baseAlphabet, baseAlphabet, line));
                Console.WriteLine();
            }

            //Console.WriteLine(encText==Encipher(baseAlphabet,newAlphabet,Decipher(baseAlphabet,newAlphabet, encText)));
            //Console.WriteLine(decText);
        }
    }
}