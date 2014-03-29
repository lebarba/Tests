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
         mergesort
          
         eliminate recursive
         k complimentary pairs
         fizzbuzz
         Combinatory
         Permutations
         Random number generator
         convert string to number
         Convert number to string
         swap xor
         horners rule
         Search in string
         */

        static void Main(string[] args)
        {
            //insertionSortTest();

          //  bubbleSortTest();
            //quickSortTest();

            mergeTwoSortedArrays
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


            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] b = { 2, 5, 7, 8};


            int i, j;

            int[] c = new int[a.Length + b.Length];

            i = j = 0;

            int k = 0;

            //While the i and j indices are inside their arrays.
            while (i < a.Length && j < b.Length)
            {

                if (a[i] <= b[j])
                {
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

        }
    }
}
