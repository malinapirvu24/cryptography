namespace Lab1
{
    class Program
    {
        static void Main(string[] args) {
            SimpleSubstitution simpleSubstitution = new SimpleSubstitution();
            string message = "" + Console.ReadLine(); 
            //new IntOps(6).ShowInverses();
            Console.WriteLine(simpleSubstitution.Encipher(message,2));
            Console.WriteLine(simpleSubstitution.Decipher(simpleSubstitution.Encipher(message,2),2));
        }
    }
    
   
   }