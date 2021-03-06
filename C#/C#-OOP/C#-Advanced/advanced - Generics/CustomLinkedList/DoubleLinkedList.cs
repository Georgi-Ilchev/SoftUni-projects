﻿using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace CustomLinkedList
{
    public class DoubleLinkedList<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public T Value { get; set; }
        }
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            var newHead = new ListNode(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }
        public void AddLast(T element)
        {
            ListNode newTail = new ListNode(element);
            if (this.Count == 0)
            {
                this.tail = this.head = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is empty!");
            }
            T removedElement = this.head.Value;

            ListNode newHead = this.head.NextNode;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                newHead.PreviousNode = null;
                this.head = newHead;
            }
            this.Count--;
            return removedElement;
        }
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is empty!");
            }
            T removedElement = this.tail.Value;

            ListNode newTail = this.tail.PreviousNode;

            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                newTail.NextNode = null;
                this.tail = newTail;
            }
            this.Count--;
            return removedElement;
        }
        public void ForEach(Action<T> action, bool shouldStartFromHead = true)
        {
            ListNode currentNode = this.head;

            if (!shouldStartFromHead)
            {
                currentNode = this.tail;
            }

            while (currentNode != null)
            {
                action(currentNode.Value);

                if (!shouldStartFromHead)
                {
                    currentNode = currentNode.PreviousNode;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                }
            }
        }
        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            var currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }
            return array;
        }
    }
}
