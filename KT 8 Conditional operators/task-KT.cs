using System;
using System.Threading;

namespace IThub
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter you age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your debit:");
            double debit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter wanted credit sum:");
            double credit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter wanted payment time (in month):");
            int paymentTime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Have you an lost's payment? Y/n");
            string lostPayment = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter pices of debts:");
            int picesOfDebts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marital status (line: \"single\", \"married\", \"divorced\", \"widower\")");
            string maritalStatus = Console.ReadLine();
            Console.WriteLine("Are there children under 18? Y/n");
            string childrenUnder18 = Console.ReadLine();

            if (age <= 18 || age >= 81)
            {
                Console.WriteLine("Age error! Wrong age!");
            }
            if (debit < 0) Console.WriteLine("Debit must be > 0"); 
            if (credit <= 0) Console.WriteLine("Credit must be > 0");
            if (paymentTime < 3 || paymentTime > 60) Console.WriteLine("Payment time must be 3 - 60");
            if (lostPayment != "Y" && lostPayment != "N" && lostPayment != "y"  && lostPayment != "n") Console.WriteLine("Lost payment must  be Y/N"); 
            if (picesOfDebts < 0)  Console.WriteLine("PicesOfDebts must be > 0 or equal to 0");
            if (childrenUnder18 != "Y" && childrenUnder18 != "N" && childrenUnder18 != "y"  && childrenUnder18 != "n") Console.WriteLine("Children under 18 be Y/N"); 
            
            int score = 0;
            if (age < 21) score -= 21;
            else if (age <= 25) score -= 10;
            else if (age <= 45) score += 15;
            else if (age <= 60) score += 5;
            else score -= 15;
            if (debit <= 30000) score -= 40;
            else if (debit <= 60000) score -= 10;
            else if (debit <= 100000) score += 10;
            else score += 30;
            switch (lostPayment)
            {
                case "Y":
                    score -= 80;
                    break;
                case "y":
                    score -= 80;
                    break;
            }
            if (credit >= 3) score -= 35;
            if (childrenUnder18 == "Y" || childrenUnder18 == "y") score -= 10;
            if (maritalStatus == "married") score += 25;
            if (credit >= debit*12) score -= 50;
            else if(credit <= debit * 3) score += 25;
            if (paymentTime > 36) score -= 15;
            
            //scoring
            if(score <= -100) Console.WriteLine("GO AWAY!!!");
            else if(score <= -41) Console.WriteLine("The loan was declined. We recommend paying off outstanding payments/increasing your income.");
            else if(score < 1 ) Console.WriteLine("Approved at high rate: 29–35%");
            else if(score < 40) Console.WriteLine("Loan approved: 19–28%");
            else if(score < 80) Console.WriteLine("Good credit history means a good rate: 11–18%");
            else Console.WriteLine("Congratulations! You are our best client! 7–10%");
            
            
        }
    }
}