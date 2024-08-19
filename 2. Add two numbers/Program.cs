public class Program{
    public static void Main(){
        ListNode
    }
}

 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
 }
 
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode currNum = l1;
        while(l2 != null){
            if(currNum.next == null){
                currNum.next = new ListNode();
            }
            
            int tempSum = currNum.val + l2.val;
            if(tempSum >= 10) {
                if(currNum.next == null){
                    currNum.next = new ListNode();
                }
                currNum.next.val += 1;
            }
            currNum.val += tempSum%10;
            
            l2 = l2.next;
            if(l2 != null){
                if(currNum.next == null){
                    currNum.next = new ListNode();
                }
                currNum = currNum.next;
            }
        }
        return l1;
    }
}