using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoublyLinkedListWithErrors
{
    // Definition of the doubly linked list
    public class DLList
    {
        public DLLNode head; // Pointer to the head of the list
        public DLLNode tail; // Pointer to the tail of the list

        // Constructor to initialize an empty list
        public DLList()
        {
            head = null;
            tail = null;
        }

        /*-------------------------------------------------------------------
        * The methods below include several errors. Your task is to write
        * unit tests to discover these errors. During delivery, the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */

        // Add a node to the tail of the list
        public void AddToTail(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                tail.next = p;
                p.previous = tail; // Fix: Set previous before updating the tail
                tail = p;
            }
        } // end of AddToTail

        // Add a node to the head of the list
        public void AddToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of AddToHead

        // Remove the head node from the list
        public void RemoveHead()
        {
            if (this.head == null) return;  // List is already empty

            if (this.head.next == null)     // Only one node in the list
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.next;
                this.head.previous = null;
            }
        } // end of RemoveHead

        // Remove the tail node from the list
        public void RemoveTail()
        {
            if (this.tail == null) return; // Check if the list is empty

            if (this.head == this.tail) // Case: Only one node in the list
            {
                this.head = null;
                this.tail = null;
                return;
            }

            // Fix: Update the tail pointer to point to the previous node before the current tail
            this.tail = this.tail.previous;

            // Fix: Ensure the new tail's next pointer is set to null
            if (this.tail != null) // Check that the tail is not null before modifying its next pointer
            {
                this.tail.next = null;
            }
        } // end of RemoveTail

        /*-------------------------------------------------
         * Return null if the node with the given number does not exist.
         * ----------------------------------------------*/

        // Search for a node with a specific value
        public DLLNode Search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                if (p.num == num)  // Fix: Check the current node's value before moving to the next node
                {
                    return p; // Return the node if found
                }
                p = p.next;  // Move to the next node after checking
            }
            return null; // Return null if the node is not found
        } // end of Search

        // Remove a specific node from the list
        public void RemoveNode(DLLNode p)
        {
            // If the list is empty or the node is not in the list, do nothing
            if (this.head == null || this.tail == null || !IsNodeInList(p)) return;

            if (p == this.head && p == this.tail) // Only one node in the list
            {
                this.head = null;
                this.tail = null;
                return;
            }

            if (p.next == null) // Case: Removing the tail node
            {
                this.tail = this.tail.previous;
                if (this.tail != null) // Check that tail is not null before modifying its next pointer
                {
                    this.tail.next = null;
                }
                p.previous = null;
            }
            else if (p.previous == null) // Case: Removing the head node
            {
                this.head = this.head.next;
                if (this.head != null) // Check that head is not null before modifying its previous pointer
                {
                    this.head.previous = null;
                }
                p.next = null;
            }
            else // Case: Removing a node in the middle of the list
            {
                p.next.previous = p.previous;
                p.previous.next = p.next;
                p.next = null;
                p.previous = null;
            }
        } // end of RemoveNode

        // Helper method to check if a node is in the list
        private bool IsNodeInList(DLLNode p)
        {
            var current = this.head;
            while (current != null)
            {
                if (current == p)
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        } // end of IsNodeInList

        // Calculate the total sum of node values
        public int Total()
        {
            int sum = 0;
            DLLNode p = head;

            while (p != null)
            {
                sum += p.num;
                p = p.next;  // This is correct, but the issue likely happens when the list is empty or improperly handled
            }

            return sum;
        } // end of Total
    } // end of DLList class
}
