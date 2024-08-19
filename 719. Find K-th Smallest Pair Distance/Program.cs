using System.Diagnostics.CodeAnalysis;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        int[] nums;
        int k;
        Setup(out nums, out k, 19);
        int result = solution.SmallestDistancePair(nums, k);
        Console.WriteLine(result);
    }

    private static void Setup(out int[] nums, out int k, int testCase)
    {
        switch (testCase)
        {
            case 19:
                nums = ReadInputs("input2.txt");
                k = 25000000;
                break;
            case 18:
                nums = ReadInputs("input.txt");
                k = 25000000;
                break;
            default:
                nums = new int[]{1,6,1};
                k = 1;
                break;
        }
    }

    private static int[] ReadInputs(string filename)
    {
        using StreamReader readtext = new StreamReader("C:\\Users\\ndzia\\Documents\\Programming\\leetcode\\719. Find K-th Smallest Pair Distance\\" + filename);
        var line = readtext.ReadLine();
        string[] split = line.Split(new char[1] { ',' });
        List<int> numbers = new List<int>();
        int parsed;

        foreach (string n in split)
        {
            if (int.TryParse(n, out parsed))
                numbers.Add(parsed);
        }

        return numbers.ToArray();
    }
}


public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Dictionary<int, int> dists = new Dictionary<int, int>();

        watch = Lap(watch, "setup");

        for(int i = 0; i < nums.Length - 1; i++){
            watch = Lap(watch, "calc: " + i);

            for(int j = i + 1; j < nums.Length; j++){
                int dist = abs(nums[i] - nums[j]);
                if(!dists.ContainsKey(dist)) dists[dist] = 1;
                else dists[dist]++;
            } 
        }
        watch = Lap(watch, "dist calc");

        var keys = dists.Keys.ToArray();
        keys = QuickSort(keys, 0, keys.Length - 1);

        watch = Lap(watch, "sort");

        int sum = 0;
        int index = -1;
        while(sum < k){
            index++;
            sum += dists[keys[index]];
        }

        watch = Lap(watch, "dist find");
        
        return keys[index];
    }

    private System.Diagnostics.Stopwatch Lap(System.Diagnostics.Stopwatch watch, string lapName){
        watch.Stop();
        Console.WriteLine(watch.Elapsed + " - " + lapName);
        watch = System.Diagnostics.Stopwatch.StartNew();
        return watch;
    }

    private int abs(int a){
        if(a < 0) 
            return -a;
        return a;
    }

    private int[] QuickSort(int[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];

        while(i < j){
            while(array[i] < pivot){
                i++;
            }
            while(array[j] > pivot){
                j--;
            }
            if(i <= j){
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if(leftIndex < j)
            QuickSort(array, leftIndex, j);

        if(rightIndex > i)
            QuickSort(array, i, rightIndex);

        return array;
        
    }
}