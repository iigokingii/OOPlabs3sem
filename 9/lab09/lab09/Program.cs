﻿using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
namespace lab09
{
    class Services : IOrderedDictionary,
    {
        Queue type;
        int counter = 0;
        public void Add(object key, object value)
        {
            type.Enqueue(new DictionaryEntry(key, value));
        }
        public int Count
        {
            get
            {
                return type.Count;
            }
        }
        public bool IsSynchronized
        {
            get
            {
                return type.IsSynchronized;
            }
        }
        public object SyncRoot
        {
            get
            {
                return type.SyncRoot;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public ICollection Values
        {
            get
            {
                Queue temp = type;
                Queue valueQueue = new Queue(type.Count);
                for (int i = 0; i < temp.Count; i++)
                {
                    valueQueue.Enqueue(((DictionaryEntry)type.Dequeue()).Value);
                }
                type = temp;
                return valueQueue;
            }
        }
        public ICollection Keys
        {
            get
            {
                Queue temp = type;
                Queue keyQueue = new Queue(type.Count);
                for (int i = 0; i < temp.Count; i++)
                {
                    keyQueue.Enqueue(((DictionaryEntry)type.Dequeue()).Key);
                }
                type = temp;
                return keyQueue;
            }
        }
        public int IndexOfKey(object key)
        {
            Queue temp = type;
            for (int i = 0; i < temp.Count; i++)
            {
                type.Dequeue();
                if (((DictionaryEntry)type.Dequeue()).Key == key)
                {
                    type = temp;
                    return i;
                }
            }
            return -1;
        }
        public object this[object key]
        {
            get
            {
                int tmp = IndexOfKey(key);
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < type.Count; i++)
                {
                    if (tmp == i)
                    {
                        result.Enqueue(temp.Dequeue());
                    }
                    temp.Dequeue();
                }
                return ((DictionaryEntry)result.Dequeue()).Value;
            }
            set
            {
                int tmp = IndexOfKey(key);
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < temp.Count; i++)
                {

                    if (tmp == i)
                    {
                        type.Dequeue();
                        type.Enqueue(new DictionaryEntry(key, value));//
                    }
                    type.Dequeue();
                }
            }
        }

        public object this[int index]
        {
            get
            {
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < type.Count; i++)
                {

                    if (index == i)
                    {
                        result.Enqueue(temp.Dequeue());
                    }
                    temp.Dequeue();
                }
                return ((DictionaryEntry)result.Dequeue()).Value;
            }
            set
            {
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < type.Count; i++)
                {

                    if (index == i)
                    {
                        result.Enqueue(temp.Dequeue());
                    }
                    temp.Dequeue();
                }
                object key = ((DictionaryEntry)result.Dequeue()).Key;
                temp = type;
                for (int i = 0; i < temp.Count; i++)
                {

                    if (index == i)
                    {
                        type.Enqueue(new DictionaryEntry(key, value));      //123123123123
                        break;
                    }
                    type.Dequeue();
                }
            }
        }
       










    }
    /*public class TypeEnum : IDictionaryEnumerator
    {
        public Queue type;
        int position = -1;
        public TypeEnum(Queue _type)
        {
            type = _type;
        }
        public bool MoveNext()
        {
            position++;
            return (position < type.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get
            {
                try
                {
                    Queue result = new Queue();
                    Queue temp = type;
                    for (int i = 0; i < temp.Count; i++)
                    {

                        if (position == i)
                        {
                            result.Enqueue(temp.Dequeue());
                        }
                        temp.Dequeue();
                    }
                    return result.Dequeue();
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidCastException();
                }
            }
        }
        public DictionaryEntry Entry
        {
            get
            {
                return (DictionaryEntry)Current;
            }
        }

    }*/



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
