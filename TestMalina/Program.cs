namespace TestMalina {
    class Program {
        
        public static void Main(string[] args) {
            List<int> order = new List<int> { 2,1,5,0,6,4,3};

            string result = Help.ReadByColumns("tiohnngteigoiemovatoegnzhnie", 4, order);
            Console.WriteLine(result);

            
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string text = "VHSHCKDOWOLFRKFKYFYYHYLH".ToLower();
            string pp = Help.ReadByColumns(text, 4);
            for (int i = 0; i < 26; i++) {
                Console.WriteLine(i); //pt index 17
                Console.WriteLine(Help.EncipherCaesar(alphabet,i));
                Console.WriteLine(Help.DecipherCaesar(pp.,i));
                Console.WriteLine();
                
            }
            string text = "VHSHCKDOWOLFRKFKYFYYHYLH".ToLower();
            Help.ReadByColumns(text, 4);




        }
    }
}