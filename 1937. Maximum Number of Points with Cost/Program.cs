public class Program{
    public static void Main(){
        Solution solution = new Solution();
        int[][] points2 = new int[100000][];
        for (int i = 0; i < points2.Length; i++){
            points2[i] = new int[1]{100000};
        }
        Console.WriteLine(solution.MaxPoints(points2));
    }
}

public class Solution {
    public long MaxPoints(int[][] points) {
        long[] newLine;
        long[] oldLine;
        
        newLine = LiftLine(points[0]);

        for(int i = 1; i < points.Length; i++){
            oldLine = newLine;
            newLine = PropagateValues(oldLine, LiftLine(points[i]));
        }

        return MaxOfList(newLine);
    }

    private long[] LiftLine(int[] points){
        long[] newLine = new long[points.Length];
        for(int i = 0; i < points.Length; i++){
            newLine[i] = points[i];
        }
        return newLine;
    }

    private long MaxOfList(long[] list){
        long max = list[0];
        for(int i = 1; i<list.Length; i++)
            if(list[i] > max)
                max = list[i];
        return max;
    }

    private long[] PropagateValues(long[] topLine, long[] currLine){
        long[] newLine = new long[currLine.Length];
        long[] potentialAddition = new long[currLine.Length];

        for(int i = 0; i < currLine.Length; i++){
            potentialAddition[i] = topLine[i]; 
        }
        for(int i = 1; i < potentialAddition.Length; i++){
            potentialAddition[i] = MaxOfList([ potentialAddition[i], potentialAddition[i-1]-1 ]);
        }
        for(int i = potentialAddition.Length - 2; i >= 0; i--){
            potentialAddition[i] = MaxOfList([ potentialAddition[i], potentialAddition[i+1]-1 ]);
        }

        for(int i = 0; i < newLine.Length; i++){
            newLine[i] = currLine[i] + potentialAddition[i];
        }
        
        return newLine;
    }

    private int abs(int num){
        if(num < 0) 
            return -num;
        return num;
    }
}