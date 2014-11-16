using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsAlgorithms
{
    class PorkDynamicArray
    {

        int[] array;
        int initialSize = 4;
        int allocatedSize;
        int size;

        int numberOfAllocations = 0;

        public PorkDynamicArray()
        {
            array = new int[initialSize];
            size = 0;
            allocatedSize = initialSize;
        }

        public void pushValue( int value)
        {
            
            if( size >= allocatedSize )
            {
                //Grow quadratically
               allocatedSize *= 2;

               int[] newArray = new int[allocatedSize];

                //Copy original array.
               for (int i = 0; i < size; i++)
               {
                   newArray[i] = array[i];
               }

               array = newArray;

               numberOfAllocations++;
            }

            //Assign and increase at the end
            array[size] = value;
            size++;
        
        }


    }
}
