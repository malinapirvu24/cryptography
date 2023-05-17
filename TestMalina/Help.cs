namespace TestMalina {
    public class Help {
        // Alfabet        
        public static string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";


        // TODO Pentru citire fisier -> returneaza array de stringuri
        // TODO (fiecare linie din fisier e un string)
        // File.ReadAllLines("C:\\Users\\Admin\\RiderProjects\\CryptographyLab\\TestMalina\\input.txt");

        /// <summary>
        /// Adunare modulo n
        /// </summary>
        /// <param name="a">primul numar</param>
        /// <param name="b">al doilea numar</param>
        /// <param name="n">modulo</param>
        /// <returns>Rezultatul operatiei (a + b) % n</returns>
        public static int AddModN(int a, int b, int n) {
            int res = a + b;
            while (res < 0) {
                res += n;
            }

            return res % n;
        }

        /// <summary>
        /// Scadere modulo n
        /// </summary>
        /// <param name="a">primul numar</param>
        /// <param name="b">al doilea numar</param>
        /// <param name="n">modulo</param>
        /// <returns>Rezultatul operatiei (a - b) % n</returns>
        public static int SubModN(int a, int b, int n) {
            int res = a - b;
            while (res < 0) {
                res += n;
            }

            return res % n;
        }

        /// <summary>
        /// Inmultire modulo n
        /// </summary>
        /// <param name="a">primul numar</param>
        /// <param name="b">al doilea numar</param>
        /// <param name="n">modulo</param>
        /// <returns>Rezultatul operatiei (a * b) % n</returns>
        public static int MulModN(int a, int b, int n) {
            int res = a * b;
            while (res < 0) {
                res += n;
            }

            return res % n;
        }

        /// <summary>
        /// Invers modulo n
        /// </summary>
        /// <param name="a">numar</param>
        /// <param name="n">modulo</param>
        /// <returns>Inversul modulo n al numarului a. Daca nu exista, -1</returns>
        public static int InverseModN(int a, int n) {
            for (int b = 0; b < n; b++) {
                if (MulModN(a, b, n) == 1) {
                    return b;
                }
            }

            return -1;
        }

        /// <summary>
        /// Encriptare cifru Cezar
        /// </summary>
        /// <param name="text">textul original</param>
        /// <param name="shift">numar de rotiri</param>
        /// <returns>Textul criptat</returns>
        public static string EncipherCaesar(string text, int shift) {
            string encText = string.Empty;

            for (int i = 0; i < text.Length; i++) {
                int index = englishAlphabet.IndexOf(text[i]);
                int finalIndex = AddModN(index, shift, 26);
                encText += englishAlphabet[finalIndex];
            }

            return encText;
        }

        /// <summary>
        /// Decriptare cifru Cezar
        /// </summary>
        /// <param name="encText">textul criptat</param>
        /// <param name="shift">numar de rotiri</param>
        /// <returns>Textul decriptat</returns>
        public static string DecipherCaesar(string encText, int shift) {
            return EncipherCaesar(encText, -shift);
        }

        /// <summary>
        /// Substituie literele din alfabetul original cu literele corespunzatoare din alfabetul nou
        /// </summary>
        /// <param name="originalAlphabet">alfabetul original</param>
        /// <param name="newAlphabet">alfabetul nou</param>
        /// <param name="text">textul care trebuie criptat</param>
        /// <returns>Textul criptat</returns>
        public static string Substitution(string originalAlphabet, string newAlphabet, string text) {
            string encText = string.Empty;
            for (int i = 0; i < text.Length; i++) {
                encText += newAlphabet[originalAlphabet.IndexOf(text[i])];
            }

            return encText;
        }

        /// <summary>
        /// Functie de generat alfabet prin transpozitie bazata pe un cuvant cheie (cheie mixata)
        /// </summary>
        /// <param name="key">cuvantul cheie</param>
        /// <param name="lines">numarul de linii in care sa fie impartit alfabetul</param>
        /// <param name="order">ordinea de citire a coloanelor (incepand cu 0) (default: 0 -> n - 1)</param>
        /// <returns>Alfabetul obtinut prin transpozitie</returns>
        public static string TranspositionAlphabet(string key, int lines, List<int>? order = null) {
            if (order == null) {
                order = new List<int>();
            }

            // Pastreaza doar literele unice din text, in ordinea aparitiei
            string uniqueText = string.Empty;
            for (int i = 0; i < key.Length; i++) {
                if (uniqueText.Contains(key[i])) {
                    continue;
                }

                uniqueText += key[i];
            }

            // Completeaza cu literele din alfabet care nu apar deja
            string newAlphabet = uniqueText;
            string baseAlphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < baseAlphabet.Length; i++) {
                if (newAlphabet.Contains(baseAlphabet[i])) {
                    continue;
                }

                newAlphabet += baseAlphabet[i];
            }

            // Separare alfabet nou pe randuri
            List<string> rows = new List<string>();
            int rowLength = (int)Math.Ceiling((float)newAlphabet.Length / lines);
            for (int i = 0; i < newAlphabet.Length; i += rowLength) {
                rows.Add(newAlphabet.Substring(i, Math.Min(rowLength, newAlphabet.Length - i)));
            }

            string finalAlphabet = string.Empty;
            if (order.Count == 0) {
                for (int j = 0; j < rowLength; j++) {
                    for (int i = 0; i < rows.Count; i++) {
                        if (j >= rows[i].Length) continue;
                        finalAlphabet += rows[i][j];
                    }
                }
            }
            else {
                for (int o = 0; o < order.Count; o++) {
                    int j = order.IndexOf(o);
                    for (int i = 0; i < rows.Count; i++) {
                        if (j >= rows[i].Length) continue;
                        finalAlphabet += rows[i][j];
                    }
                }
            }

            return finalAlphabet;
        }

        /// <summary>
        /// Criptare neuniforma (prefixe)
        /// </summary>
        /// <param name="text">text de criptat</param>
        /// <returns>Textul criptat neuniform</returns>
        public static string EncipherNonUniform(string text) {
            string[] table = {
                //A   B     C     D     E    F     G
                "2", "91", "99", "61", "8", "62", "65",
                //H    I    J     K     L     M     N
                "90", "5", "92", "68", "95", "98", "60",
                //0   P    Q     R     S    T    U
                "3", "1", "97", "93", "4", "0", "7",
                //V    W     X     Y     Z
                "96", "67", "63", "64", "94"
            };

            string encText = string.Empty;
            foreach (char letter in text.ToUpper()) {
                encText += table[letter - 'A'];
            }

            return encText;
        }

        /// <summary>
        /// Genereaza o permutare a alfabetului
        /// </summary>
        /// <returns>Permutare a alfabetului</returns>
        public static string AlphabetPermutation() {
            char[] chars = englishAlphabet.ToCharArray();
            Random r = new Random();
            for (int it = 1; it <= 100; it++) {
                int i = r.Next(26);
                int j = r.Next(26);

                (chars[i], chars[j]) = (chars[j], chars[i]); //swap
            }

            return string.Join("", chars);
        }

        /// <summary>
        /// Criptare polialfabetica
        /// </summary>
        /// <param name="key">cheia de criptare</param>
        /// <param name="text">textul de criptat</param>
        /// <returns>Textul criptat</returns>
        public static string EncipherPolyAlphabetic(string key, string text) {
            // Generare alfabete
            List<string> alphabets = new List<string>();
            foreach (char c in key) {
                int index = englishAlphabet.IndexOf(c);
                alphabets.Add(EncipherCaesar(englishAlphabet, index));
            }

            // Criptare
            string result = string.Empty;
            for (int i = 0; i < text.Length; i++) {
                int pos = englishAlphabet.IndexOf(text[i]);
                result += alphabets[(i % alphabets.Count)][pos];
            }

            return result;
        }

        /// <summary>
        /// Decriptare polialfabetica
        /// </summary>
        /// <param name="key">cheie de decriptare</param>
        /// <param name="encText">text de decriptat</param>
        /// <returns>Text decriptat</returns>
        public static string DecipherPolyAlphabetic(string key, string encText) {
            // Generare alfabete
            List<string> alphabets = new List<string>();
            foreach (char c in key) {
                int index = englishAlphabet.IndexOf(c);
                alphabets.Add(EncipherCaesar(englishAlphabet, index));
            }

            // Decriptare
            string result = string.Empty;
            for (int i = 0; i < encText.Length; i++) {
                int pos = alphabets[(i % alphabets.Count)].IndexOf(encText[i]);
                result += englishAlphabet[pos];
            }

            return result;
        }

        /// <summary>
        /// (Ultima din curs) Criptare cu transpozitie pe coloane cu ordine data de pozitia in alfabet a caracterelor din cheie
        /// </summary>
        /// <param name="key">cheie de criptat</param>
        /// <param name="text">text de criptat</param>
        /// <returns>Textul criptat</returns>
        public static string EncipherColumnTransposition(string key, string text) {
            List<string> rows = new List<string>();
            int rowLength = key.Length;
            for (int i = 0; i < text.Length; i += rowLength) {
                rows.Add(text.Substring(i, Math.Min(rowLength, text.Length - i)));
            }

            string result = string.Empty;
            for (int c = 0; c < englishAlphabet.Length; c++) {
                if (!key.Contains(englishAlphabet[c])) {
                    continue;
                }

                int j = key.IndexOf(englishAlphabet[c]);
                c--;
                key = key[..j] + "#" + key[(j + 1)..];
                for (int i = 0; i < rows.Count; i++) {
                    if (j < rows[i].Length) {
                        result += rows[i][j];
                    }
                }
            }

            return result;
        }


        // --- METODE PRINTARE SI CITIRE ---


        /// <summary>
        /// Printeaza in terminal frecventele caracterelor din text + histograma orizontala.
        /// </summary>
        /// <param name="text">text</param>
        public static void PrintCharacterFrequency(string text) {
            int[] freq = new int[26]; // initializeaza cu 0

            // Calculare frecvente
            foreach (char c in text) {
                freq[c - 'a']++;
            }

            // Afisare frecvente
            for (int i = 0; i < freq.Length; i++) {
                Console.WriteLine((char)('a' + i) + ": " + freq[i] + "\t" + new string('#', freq[i]));
            }
        }

        /// <summary>
        /// Metoda de printat text in grupuri de litere separate de spatii
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="groupSize">nr de litere intr-un grup</param>
        /// <param name="padding">OPTIONAL (poate fi omis) padding</param>
        /// <returns>Text impartit in grupuri</returns>
        public static string SplitIntoGroups(string text, int groupSize, char padding = '\0') {
            string result = "";
            for (int i = 0; i < text.Length; i += groupSize) {
                string pad = new string(padding, groupSize - Math.Min(groupSize, text.Length - i));
                result += text.Substring(i, Math.Min(groupSize, text.Length - i)) + pad + " ";
            }

            return result;
        }

        public static string ReadByColumns(string text, int lines, List<int>? order = null) {
            if (order == null) {
                order = new List<int>();
            }

            List<string> rows = new List<string>();
            int rowLength = (int)Math.Ceiling((float)text.Length / lines);
            for (int i = 0; i < text.Length; i += rowLength) {
                rows.Add(text.Substring(i, Math.Min(rowLength, text.Length - i)));
            }

            string result = string.Empty;
            if (order.Count == 0) {
                for (int j = 0; j < rowLength; j++) {
                    for (int i = 0; i < rows.Count; i++) {
                        if (j >= rows[i].Length) continue;
                        result += rows[i][j];
                    }
                }
            }
            else {
                for (int o = 0; o < order.Count; o++) {
                    int j = order.IndexOf(o);
                    for (int i = 0; i < rows.Count; i++) {
                        if (j >= rows[i].Length) continue;
                        result += rows[i][j];
                    }
                }
            }

            return result;
        }
    }
}