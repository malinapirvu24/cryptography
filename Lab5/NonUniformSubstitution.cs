namespace Lab5; 

public class NonUniformSubstitution {
                            //   A    B     C     D     E     F     G
    static string[] table = {"2", "91", "99", "61", "8", "62", "65", 
        //   H    I     J     K     L     M     N
        "90", "5", "92", "68", "95", "98", "60", 
        //   0    P    Q     R     S    T    U    V    W     X      Y    Z
           "3", "1", "97", "93", "4", "0", "7", "96", "67", "63", "64", "94"}; // ...

    public static string Cipher(string clearText) {
        string encText = "";
        foreach (char letter in clearText.ToUpper()) {
            encText += table[letter - 'A'];
        }

        return encText;
    }
}