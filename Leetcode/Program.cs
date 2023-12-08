using System.ComponentModel;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] {i, j};
                }
            }
        }
        return new int[] { 0, 0 };
    }



    public bool IsSubsequence(string s, string t)
    {
        if (s=="") return true;
        string line = "";
        foreach(char item in t)
        {
            if (item == s[line.Length])
            {
                line += item;
                if (line.Length == s.Length) return true;
            }
        }
        return false;
    }



    public bool IsPalindrome(int x)
    {
        string line = x.ToString();
        for (int i = line.Length; i > line.Length/2; i--)
        {
            if (line[i] != line[line.Length - i]) return false;
        }
        return true;
    }






      public class ListNode {
          public int val;
          public ListNode next;
          public ListNode(int val=0, ListNode next=null) {
              this.val = val;
              this.next = next;
          }
      }
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // считывание чисел
        string num1 = Convert.ToString(l1.val);
        string num2 = Convert.ToString(l2.val);
        while (l1.next != null)
        {
            l1 = l1.next;
            num1 += Convert.ToString(l1.val);
        }
        while (l2.next != null)
        {
            l2 = l2.next;
            num2 += Convert.ToString(l2.val);
        }

        // переворачивание чисел
        num1 = new string(num1.Reverse().ToArray());
        num2 = new string(num2.Reverse().ToArray());


        string result = ColumnAddition(num1, num2);
        int resSize = result.Length - 1; // кол-во цифр в ответе

        return Func(result, resSize);
    }
    private static string ColumnAddition(string num1, string num2)
    {
        string result = "";
        bool transfer = false;
        string min;
        string max;
        if (Math.Min(num1.Length, num2.Length) == num1.Length)
        {
            min = num1; max = num2;
        }
        else
        {
            min = num2; max = num1;
        }
        char[] columns = new char[2];
        for (int i = 0; i < max.Length; i++)
        {
            columns[0] = max[max.Length - 1 - i];
            try
            {
                columns[1] = min[min.Length - 1 - i];
            }
            catch
            {
                columns[1] = '0';
            }

            if (transfer)
                result += ((int)Char.GetNumericValue(columns[0]) + (int)Char.GetNumericValue(columns[1]) + 1) % 10;
            else
                result += ((int)Char.GetNumericValue(columns[0]) + (int)Char.GetNumericValue(columns[1])) % 10;

            if (transfer)
                if (((int)Char.GetNumericValue(columns[0]) + (int)Char.GetNumericValue(columns[1]) + 1) >= 10)
                    transfer = true;
                else
                    transfer = false;
            else
                if (((int)Char.GetNumericValue(columns[0]) + (int)Char.GetNumericValue(columns[1])) >= 10)
                transfer = true;
            else
                transfer = false;

        }
        if (transfer) result += '1';
        return new string(result.Reverse().ToArray());
    }
    private static ListNode Func(string num, int indx)
    { // запись ответа q
        if (indx >= 0)
            return new ListNode(
                Convert.ToInt32(
                    Convert.ToString(
                        num[indx])), 
                Func(num, indx - 1));
        else return null;
    }



    public static void Main(string[] args)
    {
        ListNode l = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null)))))));
        ListNode l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null))));
        ListNode a = AddTwoNumbers(l, l1);

        //long a = 100;
        //System.Console.WriteLine(a);

    }
}