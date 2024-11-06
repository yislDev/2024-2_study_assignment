using System;
using System.Linq;

namespace statistics
{
    class Program
    {

        static double getAverage(string course, string[,] data) {
            int courseIndex = -1;
            for (int i = 2; i < data.GetLength(1); i++) {
                if (data[0,i] == course) {
                    courseIndex = i;
                }
            }
            double sum = 0;
            for (int i = 1; i < data.GetLength(0); i++) {
                sum += double.Parse(data[i,courseIndex]);
            }
            return sum / (data.GetLength(0) - 1);
        }
        
        static double getMax(string course, string[,] data) {
            int courseIndex = -1;
            for (int i = 2; i < data.GetLength(1); i++) {
                if (data[0,i] == course) {
                    courseIndex = i;
                }
            }
            double mx = double.Parse(data[1,courseIndex]);
            for (int i = 1; i < data.GetLength(0); i++) {
                double score = double.Parse(data[i,courseIndex]);
                if (mx <= score) {
                    mx = score;
                }
            }
            return mx;
        } 
        
        static double getMin(string course, string[,] data) {
            int courseIndex = -1;
            for (int i = 2; i < data.GetLength(1); i++) {
                if (data[0,i] == course) {
                    courseIndex = i;
                }
            }
            double mn = double.Parse(data[1,courseIndex]);
            for (int i = 1; i < data.GetLength(0); i++) {
                double score = double.Parse(data[i,courseIndex]);
                if (mn >= score) {
                    mn = score;
                }
            }
            return mn;
        }
        
        static int[] getRank(string[,] data) {
            int[] stdTotal = new int[data.GetLength(0)-1];
            for (int i = 1; i < data.GetLength(0); i++) {
                stdTotal[i-1] = 0;
                for (int j = 2; j < data.GetLength(1); j++) {
                    stdTotal[i-1] += int.Parse(data[i,j]);
                }
            }
            int[] stdRank = new int[data.GetLength(0)-1];
            for (int i = 1; i < data.GetLength(0); i++) {
                stdRank[i-1] = 1;
                for (int j = 1; j < data.GetLength(0); j++) {
                    if (stdTotal[i-1] < stdTotal[j-1]) {
                        stdRank[i-1] += 1;
                    }
                }
            }
            return stdRank;
        }

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
            Console.WriteLine("Average Scores:");
            double mathAverage = getAverage("Math", data);
            double scienceAverage = getAverage("Science", data);
            double englishAverage = getAverage("English", data);
            Console.WriteLine("Math: {0:F2}", mathAverage);
            Console.WriteLine("Science: {0:F2}", scienceAverage);
            Console.WriteLine("English: {0:F2}", englishAverage);
            
            Console.WriteLine("\nMax and Min Scores:");
            double mathMax = getMax("Math", data);
            double mathMin = getMin("Math", data);
            double scienceMax = getMax("Science", data);
            double scienceMin = getMin("Science", data);
            double englishMax = getMax("English", data);
            double englishMin = getMin("English", data);
            Console.WriteLine("Math: ({0:D}, {1:D})", (int)mathMax, (int)mathMin);
            Console.WriteLine("Science: ({0:D}, {1:D})", (int)scienceMax, (int)scienceMin);
            Console.WriteLine("English: ({0:D}, {1:D})", (int)englishMax, (int)englishMin);
            
            Console.WriteLine("\nStudents rank by total scores:");
            int[] ranks = new int[stdCount];
            ranks = getRank(data);
            for (int i = 0; i < stdCount; i++) {
                string ranked = "";
                switch (ranks[i]) {
                    case 1:
                        ranked = "1st";
                        break;
                    case 2:
                        ranked = "2nd";
                        break;
                    case 3:
                        ranked = "3rd";
                        break;
                    default:
                        ranked = string.Format("{0}",ranks[i]) + "th";
                        break;
                }
                Console.WriteLine("{0}: {1}", data[i+1,1], ranked);
            }
            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 4th
Bob: 1st
Charlie: 5th
David: 2nd
Eve: 3rd

*/