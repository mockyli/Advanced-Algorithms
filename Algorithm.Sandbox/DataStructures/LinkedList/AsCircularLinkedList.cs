﻿using System;

namespace Algorithm.Sandbox.DataStructures
{
    //define the generic node
    public class AsCircularLinkedListNode<T> where T : IComparable
    {
        public AsCircularLinkedListNode<T> Prev;
        public AsCircularLinkedListNode<T> Next;

        public T Data;

        public AsCircularLinkedListNode(T data)
        {
            this.Data = data;
        }
    }

    /// <summary>
    /// A singly linked list implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsCircularLinkedList<T> where T : IComparable
    {
        public AsCircularLinkedListNode<T> ReferenceNode;

        //marks this data as the new head (kinda insert first assuming current reference node as head)
        //cost O(1)
        public void Insert(T data)
        {
            var newNode = new AsCircularLinkedListNode<T>(data);

            //if no item exist
            if (ReferenceNode == null)
            {
                //attach the item after reference node
                newNode.Next = newNode;
                newNode.Prev = newNode;

            }
            else
            {
                //attach the item after reference node
                newNode.Prev = ReferenceNode;
                newNode.Next = ReferenceNode.Next;

                ReferenceNode.Next.Prev = newNode;
                ReferenceNode.Next = newNode;

            }

            ReferenceNode = newNode;
        }

        //cost O(n) in worst case O(nlog(n) average?
        public void Delete(T data)
        {
            if (ReferenceNode == null)
            {
                throw new Exception("Empty list");
            }

            //only one element on list
            if (ReferenceNode.Next == ReferenceNode)
            {
                if (ReferenceNode.Data.CompareTo(data)==0)
                {
                    ReferenceNode = null;
                    return;
                }
                throw new Exception("Not found");
            }

            //atleast two elements from here
            var current = ReferenceNode;
            var found = false;
            while (true)
            {
                if (current.Data.CompareTo(data)==0)
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;

                    //match is a reference node
                    if (current == ReferenceNode)
                    {
                        ReferenceNode = current.Next;
                    }

                    found = true;
                    break;
                }

                //terminate loop if we are about to cycle
                if (current.Next == ReferenceNode)
                {
                    break;
                }

                ///move to next item
                current = current.Next;
            }

            if (found == false)
            {
                throw new Exception("Not found");
            }
        }

        //O(n) always
        public int Count()
        {
            var i = 0;

            var current = ReferenceNode;

            if (current == null)
            {
                return 0;
            }
            else
            {
                i++;
            }

            while (current.Next != ReferenceNode)
            {
                i++;
                current = current.Next;
            }

            return i;
        }

        //O(1) always
        public bool IsEmpty()
        {
            return ReferenceNode == null;
        }

        //O(1) always
        public void DeleteAll()
        {
            if (ReferenceNode == null)
            {
                throw new Exception("Empty list");
            }

            ReferenceNode = null;

        }

        //O(n) time complexity
        public AsArrayList<T> GetAllNodes()
        {
            var result = new AsArrayList<T>();

            var current = ReferenceNode;

            if (current == null)
            {
                return result;
            }
            else
            {
                result.AddItem(current.Data);
            }

            while (current.Next != ReferenceNode)
            {
                result.AddItem(current.Data);
                current = current.Next;
            }

            return result;
        }
    }
}