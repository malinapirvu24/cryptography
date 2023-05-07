namespace Lab5 {
    class Program {
        public static string ShowGroups(string text, int groupSize, char padding = '\0') {
            string result = "";
            for (int i = 0; i < text.Length; i += groupSize) {
                string pad = new string(padding, groupSize - Math.Min(groupSize, text.Length - i));
                result += text.Substring(i,Math.Min(groupSize,text.Length-i))+pad+" ";
               
            }

            return result;
        }
        
        
        //scriu psvm
        public static void Main(string[] args) {
            string clearText = "TOAMNASENUMARABOBOCII";
            Console.Write(ShowGroups(NonUniformSubstitution.Cipher(clearText),5,'0'));
        }
        
    }
}