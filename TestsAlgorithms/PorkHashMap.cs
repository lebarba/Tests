using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsAlgorithms
{
    class PorkHashMap
    {


        struct hashNode
        {
            public int key;
            public int value;

        };


        List<hashNode>[] buckets;



        int allocatedSize;
        int occupancy;

        public PorkHashMap()
        {

            allocatedSize = 100;
            occupancy = 0;

            buckets = new List<hashNode>[allocatedSize];

        }

        public void insert( int key, int value)
        {

            //Get the bucket number.
            int bucketNumber = key % allocatedSize;

            //See if the bucket has a list created
            if (buckets[bucketNumber] == null) { 
                
                //Create list
                buckets[bucketNumber] = new List<hashNode>();
                
                //Increase occupancy
                occupancy++;
                
                //If more than 75% occupied
                if( occupancy > (allocatedSize * 3 / 4 ) )
                {

                    //Increase size to double
                    int newSize = allocatedSize * 2;

                    List<hashNode>[] NewBuckets = new List<hashNode>[newSize];

                    //Copy old list
                    for (int j = 0; j < allocatedSize; j++)
                    {
                        NewBuckets[j] = buckets[j];
                    }

                    allocatedSize = newSize;
                    
                    buckets = NewBuckets;

                }
            }


            hashNode newNode = new hashNode();
            newNode.key = key;
            newNode.value = value;

            //Insert value.
            int i;
            for ( i = 0; i < buckets[bucketNumber].Count; i++)
            {
                if( buckets[bucketNumber][i].key == key )
                {
                    (buckets[bucketNumber])[i] = newNode;
                    break;
                }
            }

            //if not found
            if( i == buckets[bucketNumber].Count )
            {
                buckets[bucketNumber].Add(newNode);
            }

        }
    }
}
