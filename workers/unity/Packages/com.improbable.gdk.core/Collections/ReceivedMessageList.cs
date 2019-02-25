using System;
using System.Collections;
using System.Collections.Generic;

namespace Improbable.Gdk.Core
{
    /// <summary>
    ///     Wrapper around an array for use in command and update managers
    ///     Returns values by ref and values added can not be modified
    /// </summary>
    /// <remarks>
    ///     Intended use is to use Add, Clear, Sort, ref [], and to iterate via a regular for loop
    ///     Missing most safety checks used in List as it is for internal use only
    ///     T constrained to struct so that null checks aren't needed
    ///     Does not detect the array being edited during iteration
    ///     Items are not set to default on clear
    /// </remarks>
    internal class ReceivedMessageList<T> : ICollection<T> where T : struct
    {
        private static readonly T[] EmptyArray = new T[0];

        private T[] items;
        private int size;

        public int Count => size;

        public bool IsReadOnly => false;

        public ReceivedMessageList()
        {
            items = EmptyArray;
        }

        public ref T this[int index]
        {
            get
            {
                if (index >= size || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return ref items[index];
            }
        }

        public void Add(T item)
        {
            if (items.Length <= size)
            {
                int targetLength = items.Length == 0 ? 4 : items.Length * 2;
                var temp = new T[targetLength];
                Array.Copy(items, temp, size);
                items = temp;
            }

            items[size] = item;
            ++size;
        }

        public void Clear()
        {
            size = 0;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(items, 0, size, comparer);
        }

        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            foreach (var element in items)
            {
                if (comparer.Equals(element, item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new InvalidOperationException(
                "Can not remove a single element from a ReceivedMessageList. Please use Clear");
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly ReceivedMessageList<T> list;

            private int currentIndex;

            public Enumerator(ReceivedMessageList<T> list)
            {
                this.list = list;
                currentIndex = -1;
            }

            public bool MoveNext()
            {
                ++currentIndex;

                if (currentIndex >= list.size)
                {
                    currentIndex = -1;
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1)
                    {
                        return default(T);
                    }

                    return list[currentIndex];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}
