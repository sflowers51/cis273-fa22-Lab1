using System;
using System.Collections;

namespace KthToLast
{
    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        public DoublyLinkedListNode(T data = default(T),
                                    DoublyLinkedListNode<T> prev = null,
                                    DoublyLinkedListNode<T> next = null)
        {
            Data = data;
            Prev = prev;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

    public class DoublyLinkedList<T> : IList<T>
    {
        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }

        public T? First => IsEmpty ? default(T) : Head.Data;

        public T? Last => IsEmpty ? default(T) : Tail.Data;

        public bool IsEmpty => Length == 0;

        // Length is not accessible so you have to use length
        private int length = 0;
        public int Length => length;

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Append(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }

            length++;

        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            length = 0;
        }

        public bool Contains(T value)
        {
            if (length == 0)
            {
                return false;
            }

            // traverse

            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public int FirstIndexOf(T value)
        {
            int index = 0;

            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;

            }

            return -1;
        }

        public T? Get(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            // traverse

            var currentNode = Head;
            int currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    return currentNode.Data;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            return default(T);
        }

        // Incomplete
        public void InsertAfter(T newValue, T existingValue)
        {
            var currentNode = Head;
            var newNode = new DoublyLinkedListNode<T>(newValue);

            while (currentNode != null)
            {


                if (currentNode.Data.Equals(existingValue))
                {


                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;

                    if (currentNode == Tail)
                    {
                        Tail = newNode;

                    }


                    length++;
                    return;
                }
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                Append(newValue);
                return;
            }
        }
    
    

        public void InsertAt(T value, int index)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Prepend(value);
            }

            // traverse

            var currentNode = Head;
            int currentIndex = 0;

            while (currentNode != null)
            {
                // find the node at index -1
                if (currentIndex == index - 1)
                {
                    //insert new node

                    var newNode = new DoublyLinkedListNode<T>(value);

                    currentNode.Next.Prev = newNode;
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                    newNode.Prev = currentNode;


                    if (currentNode == Tail)
                    {
                        Tail = newNode;
                    }
                    length++;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }



        }

        public void Prepend(T value)
        {

            var newNode = new DoublyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }

            else
            {
                Head.Prev = newNode;
                newNode.Next = Head;
                Head = newNode;
            }
            length++;

        }

        public void Remove(T value)
        {
            //If list is empty, we're done, son.

            if (IsEmpty)
            {
                return;
            }

            //Remove head

            if (Head.Data.Equals(value))
            {

                //1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    //Head = null;
                }

                else
                {
                    Head = Head.Next;
                }
                length--;
                return;
            }

            // Remove non-head node

            var currentNode = Head;

            while (currentNode != null)
            {
                // if you already find the node htat needs to be removed, you cannot change the one before 
                //you cannot go backwards
                if (currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;

                    if (nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }

                    else
                    {
                        currentNode.Next = currentNode.Next.Next;

                        nodeToDelete.Next = null;

                    }

                    return;
                }

                currentNode = currentNode.Next;
            }
        }

        // Incomplete
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
                return;
            }

            if (IsEmpty)
            {
                return;
            }

            if (Head.Data.Equals(index))
            {

                //1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    //Head = null;
                }

                else
                {
                    Head = Head.Next;
                }
                length--;
                return;
            }



            // Remove non-head node

            var currentNode = Head;

            int currentIndex = 0;

            while (currentNode != null)
            {


                if ((currentIndex + 1).Equals(index) && currentNode.Next != null)
                {
                    var nodeToDelete = currentNode.Next;

                    if (nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }

                    else
                    {
                        currentNode.Next = currentNode.Next.Next;

                        nodeToDelete.Next = null;

                    }

                    return;
                }
                currentNode = currentNode.Next;
                currentIndex++;
            }
        }

        // Incomplete
        public IList<T> Reverse()
        {
            var reversedList = new DoublyLinkedList<T>();

            int index = 0;
            var currentNode = Head;

            while (index != length)
            {
                reversedList.Prepend(currentNode.Data);
                index++;
                currentNode = currentNode.Next;

            }

            return reversedList;
        }

        public override string ToString()
        {
            string result = "[";

            for (var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                result += currentNode.ToString();
                if (currentNode != Tail)
                {
                    result += ",";
                }
            }
            result += "]";

            return result;
        }

        public T KthToLast(int k)
        {
            var currentNode = Tail;

            for (int i = 0; i < k; i++)
            {
                currentNode = currentNode.Prev;
            }

            return currentNode.Data;
        }

    }
}
