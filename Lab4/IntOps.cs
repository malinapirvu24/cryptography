namespace Lab4 {
    public class IntOps {
        int n;

        public IntOps(int n) {
            this.n = n;
        }

        public void ShowNumbersBinary() {
            for (int i = 0; i <= n; i++) {
                Console.WriteLine(i + ": " +
                                  Convert.ToString(i, 2).PadLeft(7, '0'));
            }
        }

        public int Add(int x, int y) {
            return (((x + y) % n) + n) % n;
        }

        public int Multiply(int x, int y) {
            return (x * y) % n;
        }

        // inversul lui x? y a.i. x * y mod n = 1??????????? 
        public int Inverse(int x) {
            for (int i = 0; i < n; i++) {
                if (Multiply(x, i) == 1) {
                    return i;
                }
            }

            return -1;
        }
        // n = 5
        // 1, 2, 3, 4    *
        // 1, 1
        // 2, 3
        // 3, 2
        // 4, 4

        // n = 6
        // 1, 2, 3, 4, 5
        // 1,1
        // 2 ?
        // 3 ?
        // 4 ?
        // 5, 5

        public void ShowInverses() {
            for (int i = 1; i < n; i++) {
                Console.WriteLine(i + " " + Inverse(i));
            }
        }
    }
}