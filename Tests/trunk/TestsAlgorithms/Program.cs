using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace TestsAlgorithms
{
    class Program
    {

        /*Pending: 
        -Hashtable
         hash probe
         Heap
         queue
         stack
         -single linked list
         -QuickSort
         -mergesort
          
         eliminate recursion
          Combinatory
         Permutations
         k complimentary pairs
         -fizzbuzz

         Random number generator
         -convert string to number
         -Convert number to string
         -swap xor
         -modulus
         -horners rule
         -Search in string
         substitute
         build binary tree from list.
         -GCD, LCM
         binary shifts ( xor, masking)
         exponential by squaring
         tree traversal
         */

        class TreeNode
        {
            public TreeNode left, right;
            public int value;

        }

        class GraphNode
        {
            public int value;
            public List<GraphNode> neighbourgs;
        }
        /*
         *1 + 2 + 3 + 4 =  (n * (n+1)) / 2;
         */
        private static int RecursionCounter = 0;

        static void Main(string[] args)
        {
            //insertionSortTest();

          //  bubbleSortTest();
            //quickSortTest();

            //mergeTwoSortedArrays();


            //FizzBuzzTest();

            //PorkLinkedList list = new PorkLinkedList();

            //list.insertFirst(0);
            //list.insertLast(1);
            //list.insertLast(2);
            //list.insertLast(3);
            //list.insertLast(4);
            //list.insertLast(5);
            //list.insertLast(6);
            //list.insertLast(7);

            //PorkLinkedList.LinkNode nthNode = nthToLast(list, 3);



            


            //iterativeInOrderBST(root);
            //PorkDynamicArray myArray = new PorkDynamicArray();

            //for (int i = 0; i < 100000; i++)
            //{
            //    myArray.pushValue(i);
            //}

            //PorkHashMap hash = new PorkHashMap();

            //Random rnd = new Random();
            //for (int i = 0; i < 200000; i++)
            //{
            //    hash.insert(rnd.Next(), rnd.Next() );
            //}

            //int pos = findSubString("abcdefghijkmlnopqrst", "abc");

            //int times = findRepeatedStrings("abcdeabcdeabcde", "5");
            //Console.WriteLine(RecursionCounter);

            //float[] coeffs = new float[] { 2,2,4,2 };

           // float result = evaluatePolynomialHorner(coeffs, 3.0f);

           // int result = lcm(111, 112);


            //int maxThreads = 2;

            //Thread[] threads = new Thread[maxThreads];
            //for (int i = 0; i < maxThreads; i++)
            //{
            //    Thread t = new Thread(new ThreadStart(doWork));
            //    threads[i] = t;
            //}

            //for (int i = 0; i < maxThreads; i++)
            //    threads[i].Start();

            //bool balanced = isBSTBalanced(root);

            //bool isBST = isABST(root);

            //Console.WriteLine(isMatch("abcd", "abc"));


            int[] a = { 1, 3, 4, 5, 7, 8 };

            int[] a2 = { 8, 7, 5, 4, 3, 1 };
            int[] b = {8,8,9,10,11,12 };

            int[] sequence = { 5, 21, 3, 22, 12, 7, 26, 14 };

            int[] sequence2 = { -5, -21, 3, 12, 118, 2, 14,20,1 };


            Array.Sort(sequence2);


            
            TreeNode root = new TreeNode();
            root.value = 4;

            root.left = new TreeNode();
            root.left.value = 2;
            root.right = new TreeNode();
            root.right.value = 6;


            root.left.left = new TreeNode();
            root.left.left.value = 1;
            root.left.right = new TreeNode();
            root.left.right.value = 3;





            root.right.left = new TreeNode();
            root.right.left.value = 5;
            root.right.right = new TreeNode();
            root.right.right.value = 8;


            
            root.right.right.right = new TreeNode();
            root.right.right.right.value = 9;


            //result = mergeTwoSortedArrays2(a, b);
            //int element = getKthLargestElement(a2, 1);

            //int maximal = maximalDrop(sequence);
            //print(permute("abc"));

            //print3SumTriplets(sequence2);


            //PrintBSTInOrderNonRecursive(root);

            int n = 7351;
            int[] memo = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                memo[i] = -1;
            }

            Console.WriteLine("min steps: " + GetMinStepsToOne_Memoization(n, memo));


            int[] dp = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = 0;
            }
            Console.WriteLine("min steps: " + GetMinStepsToOne_DynamicProgramming(n, dp));

        }

        //http://www.codechef.com/wiki/tutorial-dynamic-programming
        /// <summary>
        /// Returns the minimum steps to bring a n number to one using   -1, n/2, n/3
        /// uses memoization or Top-Down approach.
        /// </summary>
        static int GetMinStepsToOne_Memoization(int n, int[] memo)
        {

            //Base case
            if (n == 1)
                return 0;
            if (n < 1)
                return -1;

            //Already computed
            if (memo[n] != -1)
                return memo[n];


            int r;

            r = 1 + GetMinStepsToOne_Memoization(n - 1, memo);

            if( n % 2 == 0)
                r = Math.Min(1 + GetMinStepsToOne_Memoization(n / 2, memo), r);

            if (n % 3 == 0)
                r = Math.Min(1 + GetMinStepsToOne_Memoization(n / 3, memo), r);

            memo[n] = r;

            return r;
        }


        static int GetMinStepsToOne_DynamicProgramming(int n, int[] dp)
        {

            if (n < 1) return -1;

            //Base case
            if (n == 1) return 0;


            for (int i = 2; i < n + 1; i++)
            {

                //Substract one
                dp[i] = 1 + dp[i - 1];

                //N / 2
                if (i % 2 == 0)
                    dp[i] = Math.Min(dp[i], 1 + dp[i / 2]);

                //N / 3
                if (i % 3 == 0)
                    dp[i] = Math.Min(dp[i], 1 + dp[i / 3]);

            }

            return dp[n];
        }

        static void BFSTraverseGraph(GraphNode startingNode)
        {

            Queue<GraphNode> nodeQueue = new Queue<GraphNode>();
            HashSet<GraphNode> visited = new HashSet<GraphNode>();

            nodeQueue.Enqueue(startingNode);
            visited.Add(startingNode);

            GraphNode current;
            while (nodeQueue.Count > 0)
            {
                current = nodeQueue.Dequeue();

                Console.Write(current.value + ", ");

                for (int i = 0; i < startingNode.neighbourgs.Count; i++)
                {
                    if (visited.Contains(startingNode.neighbourgs[i]) == false)
                    {
                        visited.Add(startingNode.neighbourgs[i]);
                    }
                }
            }

        }

        static void print3SumTriplets(int[] a)
        {

            //Value, list of pairs
            Dictionary<int, List<Tuple<int, int>>> pairs = new Dictionary<int, List<Tuple<int, int>>>();

            for (int i = 0; i < a.Length - 1; i++)
            {

                for (int j = i + 1; j < a.Length; j++)
                {

                    int complement = -(a[i] + a[j]);

                    if (!pairs.ContainsKey(complement))
                        pairs.Add(complement, new List<Tuple<int, int>>());

                    pairs[complement].Add(new Tuple<int, int>(i, j));
                }

            }

            for (int i = 0; i < a.Length; i++)
            {

                if (a[i] <=0 && pairs.ContainsKey(a[i]))
                {
                    List<Tuple<int, int>> tupleList = pairs[ a[i] ];

                    for (int j = 0; j < tupleList.Count; j++)
                    {
                        //if (tupleList[j].Item1 != tupleList[j].Item2 && tupleList[j].Item2 != i)
                        {

                            Console.WriteLine("(" + a[i] + "," + a[tupleList[j].Item1] + "," +a[ tupleList[j].Item2] + ")");
                        }

                    }

                }

            }

        }

        private static List<string> permute(string str)
        {
            List<string> result = new List<string>();
            if (str.Length == 1)
            {
                result.Add(str);
                return result;
            }

            char c = str[0];
            List<string> result2 = permute(str.Substring(1));
            foreach (string r in result2)
            {
                insertCharBetweenLetters(c, r, result);
            }

            return result;
        }

        private static void insertCharBetweenLetters(char c, string s, List<string> res)
        {
            for (int i = 0; i <= s.Length; i++)
            {
                res.Add(s.Substring(0, i) + c + s.Substring(i));
            }
        }



        private static List<string> combine(string str)
        {
            List<string> result = new List<string>();
            combine(str, "", 0, result);
            return result;
        }

        private static void combine(string str, string prefix, int start, List<string> result)
        {
            for (int i = start; i < str.Length; i++)
            {
                string currentPrefix = prefix + str[i];
                result.Add(currentPrefix);
                combine(str, currentPrefix, i + 1, result);
            }
        }

        private static void print(List<string> l)
        {
            Console.Write("[");
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i]);
                if (i < l.Count - 1)
                    Console.Write(",");
            }
            Console.WriteLine("]");
        }



        static int maximalDrop(int[] array)
        {

            if (array.Length == 0)
                throw new Exception();


            int max = array[0];
            int maxDiff = 0;

            for (int i = 1; i < array.Length; i++)
            {

                if( array[i] > max)
                {
                    max = array[i];

                }

                int diff = max - array[i];
                if( diff > 0  && diff > maxDiff)
                {

                    maxDiff = diff;
                }
            }

            return maxDiff;
        }


        static int getKthLargestElement(int[] array, int k)
        {

            return getKthElement(array, array.Length - k );
        }

        static int getKthElement(int[] array, int k)
        {


            if (k > array.Length || array.Length == 0)
                throw new Exception();

            int i = 0, j = array.Length;
            int pivotPos;

            pivotPos = (i + j) / 2;


            List<int> leftArray = new List<int>();
            List<int> rightArray = new List<int>();
                
            for (int c = i; c < j; c++)
            {
                if (c != pivotPos)
                {
                    if (array[c] < array[pivotPos])
                    {
                        leftArray.Add(array[c]);
                    }
                    else
                    {
                        rightArray.Add(array[c]);
                    }
                }
            }

            //Place new pivot where the left array ends.
            int newPivotPlace = leftArray.Count;

            if (newPivotPlace == array.Length - 1 - k)
                return array[newPivotPlace];

            if(k < newPivotPlace)
            {
                return getKthElement(leftArray.ToArray(), k);
            }
            else
            {
                return getKthElement(rightArray.ToArray(), k - leftArray.Count - 1);

            }

        }



        static Object syncObj1 = new Object();
        static Object syncObj2 = new Object();
        static int a = 0;
        static int b = 1;
        private static void doWork()
        {


                lock (syncObj1)
                {

                    lock (syncObj2)
                    {
                        a = a + 1;
                    }
                    Console.WriteLine(a);
                }

                lock (syncObj2)
                {

                    lock (syncObj1)
                    {
                        b = b + 1;
                        Thread.Sleep(100000);
                    }
                    Console.WriteLine(a);
                }

        }


        private static void  traverseBSTPreOrder(TreeNode root)
        {

            if (root == null)
                return;

            Console.WriteLine(root.value);
            traverseBSTPreOrder(root.left);
            traverseBSTPreOrder(root.right);
        }

        private static void traverseBSTInOrder(TreeNode root)
        {

            if (root == null)
                return;

            traverseBSTInOrder(root.left);
            Console.WriteLine(root.value);
            traverseBSTInOrder(root.right);
        }


       private static bool isABST(TreeNode root)
       {

           if (root == null)
               return false;

           Stack<TreeNode> pendingNodes = new Stack<TreeNode>();

           TreeNode current = root;

           int lastValue = int.MinValue;

           bool done = false;
           while(!done)
           {

               if (current != null)
               {
                   pendingNodes.Push(current);
                   current = current.left;
               }
               else
               {

                   if (pendingNodes.Count == 0)
                   {
                       done = true;
                   }
                   else
                   {
                       current = pendingNodes.Pop();

                       if (current.value < lastValue)
                           return false;

                       lastValue = current.value;

                       current = current.right;
                   }
               }



           }

           return true;

       }


       static void PrintBSTInOrderNonRecursive(TreeNode root)
       {

           Stack<TreeNode> stack = new Stack<TreeNode>();
           TreeNode current;
           current = root;

           while (true)
           {

               if (current != null)
               {
                    stack.Push(current);

                   //PREORDER goes here
                    current = current.left;
               }
               else
               {
                   if (stack.Count == 0)
                       return;



                   current = stack.Pop();

                   //IN ORDER GOES HERE
                   Console.Write(current.value + ", "); 
                   current = current.right;


                   Console.Write(current.value + ", "); 
               }


           }


       }


       private static void breadthFirstBST(TreeNode root)
       {

           if (root == null)
               return;

           Queue<TreeNode> pendingNodes = new Queue<TreeNode>();
                    
           TreeNode current;
           
           current = root;
           while (current != null)
           {



               Console.WriteLine(current.value);

               if (current.left != null)
                   pendingNodes.Enqueue(current.left);

               
               if (current.right != null)
                   pendingNodes.Enqueue(current.right);

               if (pendingNodes.Count <= 0)
                   return;

               current = pendingNodes.Dequeue();
           }


       }

        private static bool isBSTBalanced(TreeNode root)
       {

           return Math.Abs( maxDepth(root.left) - maxDepth(root.right) ) <= 1;
       }


        private static int maxDepth(TreeNode root)
        {

            if (root == null)
                return 0;

            return 1 + Math.Max(maxDepth(root.left), maxDepth(root.right));
        }


       private static void iterativeInOrderBST(TreeNode root)
       {

           if (root == null)
               return;

           Stack<TreeNode> pendingNodes = new Stack<TreeNode>();
           TreeNode current;
           bool done = false;

           current = root;
           
           while (!done)
           {

               if (current != null)
               {
                   //Keep pushing the left items until the leaf is found.

                    pendingNodes.Push(current);

                    //Console.WriteLine(current.value); Preorder
                    current = current.left;
               }
               else
               {

                   if( pendingNodes.Count == 0)
                   {
                       done = true;
                   }
                   else
                   {
                      
                       current = pendingNodes.Pop();

                       Console.WriteLine(current.value); //In order
                       current = current.right;

                       
                   }

               }
           }
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



        static int[] mergeTwoSortedArrays2(int[] a, int[] b)
        {

            int i, j, k;

            int[] result = new int[a.Length + b.Length];

            i = j = k = 0;


            while (i < a.Length && j < b.Length)
            {


                if (a[i] < b[j])
                {

                    result[k] = a[i];

                    i++;

                }
                else
                {
                    result[k] = b[j];

                    j++;

                }

                k++;
            }


            if (i < a.Length)
            {

                while (i < a.Length)
                {
                    result[k] = a[i];
                    i++;
                    k++;
                }

            }

            if (j < b.Length)
            {
                while (j < b.Length)
                {
                    result[k] = b[j];
                    j++;
                    k++;
                }

            }

            return result;

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


        //http://algs4.cs.princeton.edu/53substring/Brute.java.html
        private static int findSubString(string fullString, string subString)
        {
            //Check if substring is empty.
            if (subString.Length <= 0)
                return -1;

            //Go from first char to last char minus the pattern length
            for (int i = 0; i <= fullString.Length - subString.Length; i++)
            {
                int j;

                for ( j = 0; j < subString.Length; j++)
                {

                    if (fullString[i + j] != subString[j])
                        break;
                }

                if (j == subString.Length)
                    return i;
            }

            return -1;
        }

        private static int findRepeatedStrings(string fullString, string subString)
        {
            if (subString.Length <= 0)
                return 0;

            int times = 0;

            int i = 0;

            while( i <= fullString.Length - subString.Length)
            {
                int j;

                for (j = 0; j < subString.Length; j++)
                {

                    if (fullString[i + j] != subString[j])
                        break;
                }

                
                if (j == subString.Length)
                {
                    times++;

                    //Advance the pointer to skip the chars from the pattern found.
                    i += subString.Length;
                }else
                {
                    i++;
                }

            }

            return times;
        }


        private static float evaluatePolynomialHorner( float[] coeff, float x)
        {

            float result = 0;

            for(int c = coeff.Length - 1 ; c >= 0 ; c-- )
            {

                result = result * x + coeff[c]; 
            }

            return result;
        }



       public static int gcd(int a, int b)
       {

           //If remainder is 0 stop there.
           if( b == 0 )
                return a;

           return gcd(b, a % b);

       }
       private static int lcm(int a, int b)
       {
           return a * (b / gcd(a, b));
       }


       private static PorkLinkedList.LinkNode nthToLast(PorkLinkedList listHead, int n)
       {

           PorkLinkedList.LinkNode p1, p2;

           p1 = p2 = listHead.first;

           //Advance p2 n - 1 elements
           for (int i = 0; i < n  -1 ; i++)
           {
               p2 = p2.next;

               //List not long enough to have nth element.
               if (p2 == null)
                   return null;
           }

           //Advance both pointers until p2 is the last element.
           while(p2.next != null)
           {
               p2 = p2.next;
               p1 = p1.next;
           }

           return p1;

       }



       static void printLevels(TreeNode root)
       {


           Queue<TreeNode> currentLevel = new Queue<TreeNode>();
           Queue<TreeNode> nextLevel = new Queue<TreeNode>();

           currentLevel.Enqueue(root);

           while (currentLevel.Count > 0)
           {

               TreeNode current = currentLevel.Dequeue();

               Console.Write(current.value);

               if (current.left != null) nextLevel.Enqueue(current.left);
               if (current.right != null) nextLevel.Enqueue(current.right);

               if (currentLevel.Count == 0)
               {
                   Queue<TreeNode> tempNode = currentLevel;
                   currentLevel = nextLevel;
                   nextLevel = tempNode;

                   Console.Write("\n");
               }
               else
               {
                   Console.Write(", ");
               }

           }
       }

       static TreeNode findCommonAncestor(TreeNode root, TreeNode a, TreeNode b)
       {



           if (isNodeOnTree(root.left, a) && isNodeOnTree(root.left, b))
               return findCommonAncestor(root.left, a, b);


           if (isNodeOnTree(root.right, a) && isNodeOnTree(root.right, b))
               return findCommonAncestor(root.right, a, b);

           return root;
       }



       static bool isNodeOnTree(TreeNode root, TreeNode node)
       {

           if (root == null) return false;

           if (root == node) return true;


           return isNodeOnTree(root.left, node) || isNodeOnTree(root.right, node);

       }

       static bool CheckIsOneEditDistance(string a, string b)
       {

           if (a == null || b == null)
               return false;

           int lengthDiff = Math.Abs(a.Length - b.Length);

           //If the lengths differ more than 1 then there are more than one edit.
           if (lengthDiff > 1)
               return false;


           //If strings are the same length.
           if (lengthDiff == 0)
           {

               int charsDifferent = 0;

               for (int c = 0; c < a.Length; c++)
               {
                   if (a[c] != b[c])
                   {
                       charsDifferent++;

                   }
               }


               if (charsDifferent == 1)
                   return true;
               else
                   return false;
           }
           else
           {
               int minLength = Math.Max(a.Length, b.Length) - 1;

               //Iterate from 0 to length - 1. One of the strings is 1 character short.
               for (int c = 0; c < minLength; c++)
               {
                   //We already have an edit because lengths are diff by one.
                   //If one char is different then, we would have more than one edit.
                   if (a[c] != b[c])
                   {
                       return false;

                   }
               }

               return true;

           }
       }
       static int getSqrtOfInteger(int num)
       {

           if (num <= 0)
               return 0;



           double lastVal, currentVal;

           currentVal = lastVal = num / 2;


           while (true)
           {

               lastVal = currentVal;

               currentVal = currentVal - (currentVal * currentVal - num) / (2.0 * currentVal);


               if (Math.Abs(lastVal - currentVal) < 1.0)
                   break;

           }


           
           return (int)currentVal;
       }


       }
}
