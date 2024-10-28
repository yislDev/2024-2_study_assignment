using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            
            // --------------------
        }

        // fold 함수
        static T fold<T>(int now, int ed, T accu, Func<int, T, T> func)
        {
            if (now == ed) return accu;
            else return fold(now + 1, ed, func(now, accu), func);
        }
    }
}

/* example output
Average Scores: 
Math: 70.00
Science: 67.80
English: 68.40

Max and min Scores: 
Math: (94, 79)
Science: (90, 76)
English: (92, 78)

Students sorted by total score:
Charlie: 252
Alice: 253
Eve: 256
David: 262
Bob: 264

*/
