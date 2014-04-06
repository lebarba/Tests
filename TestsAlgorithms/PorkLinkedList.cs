using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsAlgorithms
{
    class PorkLinkedList
    {

        public class LinkNode
        {
            public  int value;
            public LinkNode next;

        }

        public LinkNode first;

        public PorkLinkedList()
        {
            first = null;
        }

        public void insertLast(int value)
        {
            LinkNode newNode = new LinkNode();
            newNode.value = value;
            newNode.next = null;

            if( first == null)
            {

                first = newNode;
            }
            else
            {
                LinkNode current = first;

                while( current.next != null)
                {
                    current = current.next;

                }

                current.next = newNode;
            }
        }

        public void insertFirst(int value)
        {
            LinkNode oldFirstNode = first;

            LinkNode newNode = new LinkNode();
            newNode.value = value;
            newNode.next = oldFirstNode;

            first = newNode;
        }

        public void removeValue(int value)
        {



            //If the first value is the one.
            if( first.value == value )
            {
                first = first.next;
                return;

            }
            
            LinkNode current = first;
 
            while(current != null)
            {

                if (current.next != null  && current.next.value == value)
                {
                    current.next = current.next.next;
                    break;

                }


                current = current.next;
            }


        }

    }
}
