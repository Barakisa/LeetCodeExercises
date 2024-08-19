/* solution: find smallest prime factor, divide the current n by it, add the prime number the total amount of steps
    this works, because the snmalles prime factor - is the smallest amount of pastes of n_i-1 you need to do the get the n_i
*/

public class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        int n = 9;
        Console.WriteLine(sol.MinSteps(n));
    }
}

public class Solution
{
    public int MinSteps(int n)
    {
        int steps = 0;
        while(n > 1){
            int smol = SmallestPrime(n);
            n /= smol;
            steps += smol;
        }

        return steps;
    }

    private int SmallestPrime(int n)
    {
        for(int i = 2; i < n; i++){
            if(n%i == 0)
                return i;
        }

        return n;
    }

}