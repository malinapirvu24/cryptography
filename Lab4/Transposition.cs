namespace Lab4; 

public class Transposition {

    public string Unique(string text) {
        string uniqueText = string.Empty;
        for (int i = 0; i < text.Length; i++) {
            if (uniqueText.Contains(text[i])) {
                continue;
            }

            uniqueText += text[i];
            
        }
        return uniqueText;

    }
    public string CompleteAlphabet(string text) {
        string result = text;
        string baseAlphabet = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < baseAlphabet.Length; i++) {
            if (result.Contains(baseAlphabet[i])) {
                continue;
            }
            result += baseAlphabet[i];
            
        }
        return result;

    }

    public string FinalAlphabet(string text, int lines) {
        string completeAlphabet = new Transposition().CompleteAlphabet(new Transposition().Unique(text));
        List<string> rows = new List<string>();
        int rowLength =(int) Math.Ceiling((float)completeAlphabet.Length / lines);
        for (int i = 0; i < completeAlphabet.Length; i += rowLength) {
            rows.Add(completeAlphabet.Substring(i,Math.Min(rowLength,completeAlphabet.Length-i)));
        }

        string finalAlphabet = string.Empty;
        for (int j = 0; j < rowLength; j++){
            for (int i = 0; i < rows.Count; i++) {
                if(j>=rows[i].Length) continue;
                finalAlphabet += rows[i][j];

            }
            
        }

        return finalAlphabet;
    }
    public string Encipher(string baseAlphabet, string newAlphabet, string clearText) {
        string encText = string.Empty;
        for (int i = 0; i < clearText.Length; i++) {
            encText += newAlphabet[baseAlphabet.IndexOf(clearText[i])];
        }

        return encText;
    }


    public string Decipher(string baseAlphabet, string newAlphabet, string encText) {
        string clearText = string.Empty;
        for (int i = 0; i < encText.Length; i++) {
            clearText += baseAlphabet[newAlphabet.IndexOf(encText[i])];
        }

        return clearText;
    }

    
    
}