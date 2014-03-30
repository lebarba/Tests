using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsAlgorithms
{
    class Program
    {

        /*Pending: 
         Hashtable
         Heap
         queue
         stack
         -QuickSort
         -mergesort
          
         eliminate recursion
         k complimentary pairs
         -fizzbuzz
         Combinatory
         Permutations
         Random number generator
         -convert string to number
         -Convert number to string
         -swap xor
         -modulus
         horners rule
         Search in string
         LCD, LCM
         binary shifts ( xor, masking)
         exponential by squaring
         tree traversal
         */

        private static int RecursionCounter = 0;

        static void Main(string[] args)
        {
            //insertionSortTest();

          //  bubbleSortTest();
            //quickSortTest();

            //mergeTwoSortedArrays();


            //FizzBuzzTest();

            PorkLinkedList list = new PorkLinkedList();

            list.insertFirst(0);
            list.insertLast(1);
            list.insertLast(2);
             list.insertLast(5);
            


            list.removeValue(6);
            //Console.WriteLine(RecursionCounter);
        }

        private static void xorSwap( ref int a, ref int b)
        {
            a = a ^ b;
            b = a ^ b; //b
            a = a ^ b;           
        }


        private static void verifyArrayAfterSort( int[] array)
        {

           for( int c = 0 ; c < array.Length - 1; c++)
           {
               if (array[c] > array[c + 1])
               {
                   Console.WriteLine("array not sorted");
                   return;
               }

           }

           Console.WriteLine("array is sorted");  
        }

        private static void printArray( int[] array)
        {
            for (int c = 0; c < array.Length; c++)
                Console.Write(array[c].ToString() + ", ");

            Console.Write(Environment.NewLine);
        }

        private static void insertionSortTest()
        {
           
            int[] array = new int[] {4,5,1,2,3,5,9,8};


            printArray(array);

            int i, j, key;

            for(  j = 1 ; j < array.Length ; j++)
            {
                key = array[j];

                //Start from the right to the left
                i = j - 1;

                //Keep shifting the values until find the place
                while( i >= 0 && array[i] > key)
                {
                    //Shift the array values to the right.
                    array[i + 1] = array[i];

                    i--;
                }

                array[i + 1] = key;


            }

            printArray(array);
            verifyArrayAfterSort(array);
        }


        private static void bubbleSortTest()
        {
            int[] a = new int[] { 4, 5, 1, 2, 3, 5, 9, 8 };


            printArray(a);

            int i, j;
            for(i = 0 ; i < a.Length -1 ; i++ )
            {

                for ( j = 0; j < a.Length - i - 1; j++)
                {
                    
                    if( a[j+1] < a[j])
                    {
                        int aux = a[j + 1];

                        a[j + 1] = a[j];
                        a[j] = aux;
 
                    }
                }
            }

            printArray(a);
            verifyArrayAfterSort(a);

        }


        private static void quickSortTest()
        {
            int[] a = new int[] { 4, 5, 1, 2, 3, 5, 9, 8 };


            printArray(a);
            quickSortTest(ref a, 0, a.Length - 1);



            printArray(a);
            verifyArrayAfterSort(a);

        }

        private static void quickSortTest(ref int [] a, int p, int r)
        {
            int q;

            if( p < r)
            {
                //q = partitionInPlace(ref a, p, r);

                q = partitionInPlace2(ref a, p, r);

                quickSortTest(ref a, p, q - 1);
                quickSortTest(ref a, q + 1, r);

            }
        }


        private static int partitionInPlace(ref int[] a, int p, int r)
        {

            int x = a[r];

            int i, j;

            i = p - 1;

            //From p to r
            for( j = p; j < r - 1 ; j++)
            {
                if( a[j] < x )
                {
                    i++;
                    int temp = a[j];
                    a[j] = a[i];
                    a[i] = temp;
                }

                int temp2 = a[i+1];
                a[i+1] = a[r];
                a[r] = temp2;
            }

            return i + 1;

        }

        private static void swap( ref int[] a, int pos1, int pos2)
        {
            int temp = a[pos1];

            a[pos1] = a[pos2];

            a[pos2] = temp;

        }

        private static int partitionInPlace2(ref int[] a, int p, int r)
        {

            int i, j;
            int pivotKey;

            //Take the pivot key at the leftmost element;
            pivotKey = a[p];


            //i is set to the left most element.
            i = p;

            //j is set after the rightmost element.
            j = r + 1;

            //Do while true
            while( true )
            {

                //Find the element that needs to be swapped. It is greater or equal to than the pivot.
                //If i is the hi, then break.
                while (a[++i] < pivotKey)
                    if (i == r) break;

                //Decrement j until we find an element smaller than the pivot.
                while (a[--j] > pivotKey)
                    if (j == p) break;


                //If both index meet, then break. skip exchange
                if (i >= j)
                    break;

                //Swap the values found.
                swap(ref a, i, j);
            }

            //exchange pivot
            swap(ref a, p, j);

            return j;
        }



        private static void mergeTwoSortedArrays()
        {


            int[] a = { 1, 3, 4, 5,  7, 8 };
            int[] b = { 1, 2, 3, 4, 6, 7};


            int i, j, k;

            //Create a new array with capacity to hold both arrays.
            int[] c = new int[a.Length + b.Length];


            i = j = k = 0;
            
            //While the i and j indices are inside their arrays.
            while (i < a.Length && j < b.Length)
            {

                //determine the smallest value of two arrays
                if (a[i] <= b[j])
                {
                    //Assign it to the resulting array.
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = b[j];
                    j++;
                }

                k++;
            }

            //See if any array has pending items to add
            if( i < a.Length)
            {

                while (i < a.Length)
                    c[k++] = a[i++];
            }
            else
            {
                while (j < b.Length)
                    c[k++] = b[j++];
            }

            printArray(c);
        }


        private static int modulus(int a, int b)
        {
            //Example 11%5 = 1
            // 11/5 = 2 (integer)
            // 11 - 2 * 5 = 1
            return a - b * (a / b); 

        }

        private static int toNumber(string number)
        {

            //-48 is the key to ascii

            int value = 0;
            int start = 0;

            if (number.Length <= 0)
                return 0;

            //Check negative number.
            if (number[0] == '-')
                start = 1;

            for (int i = start; i < number.Length; i++)
            {

                value += (int) Math.Pow(10, number.Length- i -1) * (number[i] - 48);

            }

            if (start == 1)
                value *= -1;

            return value;
        }

        private static int power(int x, int y)
        {
            int accum = x;


            if (y == 0)
                return 1;

            if (y == 1)
                return x;

            for (int i = 1; i < y; i++)
            {
                accum *= x;
            }

            return accum;
        }


        private static void toString( int num )
        {

            int remaining = num;

            Stack<char> digits = new Stack<char>();

            while ( remaining > 0 )
            {

                Console.WriteLine(remaining % 10);

                digits.Push((char) ((remaining % 10) + '0'));
                remaining /= 10;
            }


            while ( digits.Count > 0)
            {
                Console.Write(digits.Pop());
            }
        }

        private static long factorial(long n)
        {
            RecursionCounter++;
            if (n == 0)
                return 1;

            return n * factorial(n - 1);

        }

        private static ulong factorialNonRecursive(ulong n)
        {

            ulong accum = n;

            for (ulong i = n - 1; i >=1 ; i--)
            {
                accum = accum * i;
            }
            

            return accum;
        }


        private static void FizzBuzzTest()
        {

            for (int i = 1; i <= 100; i++)
            {

                if( i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    if( i % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine(i);

                    }

                }


            }

        }
    }
}
