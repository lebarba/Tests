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
         QuickSort
         mergesort
          
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
            insertionSortTest();
        
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


        private static void bubbleSortTest(int[] a)
        {
            int[] array = new int[] { 4, 5, 1, 2, 3, 5, 9, 8 };


            printArray(array);
        }
    }
}
