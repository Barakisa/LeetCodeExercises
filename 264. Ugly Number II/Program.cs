public class Program {
    public static void Main(){
        Solution sol = new Solution();
        Console.WriteLine(sol.NthUglyNumber(1600));
    }
}

public class Solution {
    public int NthUglyNumber(int n) {
        int num = 0;
        PriorityQueue<int, int> backlog = new PriorityQueue<int, int>([(1, 1)]);
        Dictionary<int, bool> usage = new Dictionary<int, bool>{ { 1, true } };
        var listToEnqueue = new List<(int, int)>();
        
        for(int i = 0; i < n; i++){
            num = backlog.Dequeue();
            listToEnqueue.Clear();

            CheckNewNum(ref listToEnqueue, ref usage, num, 2);
            CheckNewNum(ref listToEnqueue, ref usage, num, 3);
            CheckNewNum(ref listToEnqueue, ref usage, num, 5);

            backlog.EnqueueRange(listToEnqueue);
        }
        return num;
    }

    private void CheckNewNum(ref List<(int, int)> listToEnqueue, ref Dictionary<int, bool> usage, int num, int multi){
        int newNum = num*multi;
        if(Int32.MaxValue/multi > num && !usage.ContainsKey(newNum)){
            listToEnqueue.Add((newNum, newNum));
            usage.Add(newNum, true);
        }
    }
}