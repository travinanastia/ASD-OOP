using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_ASD
{
    public class LinkedList
    {
        public LinkedList Next;
        public int Data;
        public LinkedList(int Data, LinkedList Next)
        {
            this.Data = Data;
            this.Next = Next;
        }
        public static LinkedList GetList(int[] MainArray)
        {
            int i = MainArray.Length - 1;
            var last = new LinkedList(MainArray[i], null);
            while (i > 0)
            {
                i--;
                var temp = new LinkedList(MainArray[i], last);
                last = temp;
            }
            return last;
        }
        public static LinkedList GetElement(LinkedList head, int iterations)
        {
            for (int index = 0; index < iterations; index++)
            {
                head = head.Next;
            }
            return head;
        }
        public static int GetLength(LinkedList head)
        {
            int counter = 0;
            while (head.Next != null)
            {
                counter++;
                head = head.Next;
            }
            return counter;
        }
    }
}
