using System.Diagnostics.Contracts;
using System.IO;    
using System;

public class Program
{
    public static void Main()
    {
        var sol = new Solution();
        var res = sol.RemoveOccurences("daabcbaabcbc", 0, "abc");
        Console.WriteLine(res);
    }
}

public class Solution
{
    public string RemoveOccurences(String s, int start, String part)
    {
        while(s.Contains(part)){
            var index = s.IndexOf(part);
            s = s.Remove(index, part.Length);
        }
        return s;
    }
}