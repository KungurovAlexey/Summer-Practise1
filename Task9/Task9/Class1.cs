using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class DoubleLinkedList<T>
    {
        T data;
        DoubleLinkedList<T> next;
        DoubleLinkedList<T> previous;
        public int Count
        {
            get
            {
                return SeachCount(this);
            }
        }
        public DoubleLinkedList()
        {
            data = default;
            next = null;
            previous = null;
        }
        private DoubleLinkedList(T item)
        {
            data = item;
            next = null;
            previous = null;
        }
        public DoubleLinkedList<T> Add(T item)
        {
            DoubleLinkedList<T> begin = this;
            if (begin.Count == 0)
            {
                begin.data = item;
                begin.next = null;
                begin.previous = null;
            }
            else
            {
                if (begin.Count == 1)
                {
                    DoubleLinkedList<T> temp = new DoubleLinkedList<T>();
                    temp.data = item;
                    temp.previous = begin;
                    begin.next = temp;
                }
                else
                {
                    DoubleLinkedList<T> temp = new DoubleLinkedList<T>(item);
                    temp.next = null;
                    DoubleLinkedList<T> temp1 = begin;
                    for (int i = 1; i < begin.Count; i++)
                    {
                        temp1 = temp1.next;
                    }
                    temp1.next = temp;
                    temp.previous = temp1;
                }
            }
            return begin;
        }
        int SeachCount(DoubleLinkedList<T> begin)
        {
            int count = 0;
            DoubleLinkedList<T> temp = begin;
            if (temp.data.ToString() == "0") return 0;
            else
            {
                do
                {
                    count++;
                    if (temp.next != null)
                    {
                        temp = temp.next;
                    }
                    else
                    {
                        break;
                    }
                } while (temp != begin);
            }
            return count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            DoubleLinkedList<T> current = this;
            for (int i = 0; i < this.Count; i++)
            {
                yield return current.data;
                current = current.next;

            }
        }
        public DoubleLinkedList<T> Remove(int index)
        {
            DoubleLinkedList<T> begin = this;
            DoubleLinkedList<T> temp = begin;
            if (index > begin.Count)
            {
                Console.WriteLine("Такого элемента нет");
            }
            else
            {
                for (int i = 1; i < index; i++)
                {
                    temp = temp.next;
                }
                if (temp.previous == null)
                {
                    if (temp.next == null)
                    {
                        begin.data = default;
                    }
                    else
                    {
                        begin = temp.next;
                    }
                }
                else
                {
                    if (temp.next == null)
                    {
                        DoubleLinkedList<T> temp1 = temp.previous;
                        temp1.next = null;
                    }
                    else
                    {
                        DoubleLinkedList<T> temp2 = temp.previous;
                        DoubleLinkedList<T> temp3 = temp.next;
                        temp2.next = temp3;
                        temp3.previous = temp2;
                    }
                }
            }
            return begin;
        }
        public static T Take(int index, DoubleLinkedList<T> collection)
        {
            DoubleLinkedList<T> begin = collection;
            DoubleLinkedList<T> temp = begin;
            for (int i = 1; i < index; i++)
            {
                temp = temp.next;
            }
            return temp.data;
        }
        public int IndexOf(T item)
        {
            int index = -1;
            DoubleLinkedList<T> begin = this;
            DoubleLinkedList<T> temp = begin;
            for (int i = 1; i < begin.Count + 1; i++)
            {
                if (item.ToString() == temp.data.ToString())
                {
                    index = i;
                    break;
                }
                temp = temp.next;
            }
            if (index == -1)
            {
                Console.WriteLine("Такого элемента нет");
                return 0;
            }
            return index;
        }
        public static DoubleLinkedList<int> CreateCollection(int n)
        {
            DoubleLinkedList<int> collection = new DoubleLinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                collection.Add(i);
            }
            return collection;
        }
    }
}
