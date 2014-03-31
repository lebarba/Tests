using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsAlgorithms
{
    class PorkHashMap
    {

        PorkLinkedList[] buckets;

        int allocatedSize;
        int occupancy;

        public PorkHashMap()
        {

            allocatedSize = 100;
            occupancy = 0;

            buckets = new PorkLinkedList[allocatedSize];

        }

        public void insert( int value)
        {

            //Get the bucket number.
            int bucketNumber = value % allocatedSize;

            //See if the bucket has a list created
            if (buckets[bucketNumber] == null) { 
                
                //Create list
                buckets[bucketNumber] = new PorkLinkedList();
                
                //Increase occupancy
                occupancy++;
                
                //If more than 75% occupied
                if( occupancy > (allocatedSize * 3 / 4 ) )
                {

                    //Increase size to double
                    int newSize = allocatedSize * 2;

                    PorkLinkedList[] NewBuckets = new PorkLinkedList[newSize];

                    //Copy old list
                    for (int i = 0; i < allocatedSize; i++)
                    {
                        NewBuckets[i] = buckets[i];
                    }

                    allocatedSize = newSize;
                    
                    buckets = NewBuckets;

                }
            }

            //Insert value.
            buckets[bucketNumber].insertLast(value);

        }
    }
}
