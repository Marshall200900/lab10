using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class MySortedDictionary<K,T>:IEnumerable, IEnumerator where K:IComparable
    {
        public int position = -1;
        private int capacity;
        public int Count
        {
            get
            {
                return dict.Count;
            }
            
        }
        public T Current
        {
            get
            {
                try
                {
                    return dict[GetKey(position)];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (capacity < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    capacity = value;
                }
            }
        }
        private Dictionary<K, T> dict;
        private List<T> Values {
            get
            {
                List<T> list = new List<T>(10);
                foreach(KeyValuePair<K, T> d in dict)
                {
                    list.Add(d.Value);
                }
                return list;
            }
        }
        private List<K> Keys
        {
            get
            {
                List<K> list = new List<K>(10);
                foreach (KeyValuePair<K, T> d in dict)
                {
                    list.Add(d.Key);
                }
                return list;
            }
        }

        object IEnumerator.Current => Current;

        public MySortedDictionary()
        {
            Capacity = 10;
            dict = new Dictionary<K, T>(Capacity);
        }
        public MySortedDictionary(int capacity)
        {
            Capacity = capacity;
            dict = new Dictionary<K, T>(Capacity);
        }
        public MySortedDictionary(MySortedDictionary<K, T> c)
        {
            dict = new Dictionary<K, T>(Capacity);
            foreach (KeyValuePair<K, T> p in c)
            {
                dict.Add(p.Key, p.Value);
            }
           
        }
        public bool ContainsKey(K key)
        {
            foreach (KeyValuePair<K, T> p in dict)
            {
                if(key.Equals(p.Key))
                {
                    return true;
                }
                
            }
            return false;
        }
        public bool ContainsValue(T val)
        {
            foreach (KeyValuePair<K, T> p in dict)
            {
                if (val.Equals(p.Value))
                {
                    return true;
                }

            }
            return false;
        }

        public T GetByIndex(int index)
        {
            return dict.ElementAt(index).Value;
        }
        public K GetKey(int index)
        {
            return dict.ElementAt(index).Key;
        }
        public int IndexOfKey(K key)
        {
            return dict.Keys.ToList().IndexOf(key);
        }
        public int IndexOfValue(T val)
        {
            return dict.Values.ToList().IndexOf(val);
        }
        public void SetByIndex(int index, T val)
        {
            dict[GetKey(index)] = val;
        }
        public void Add(K key, T val)
        {
            dict.Add(key, val);
        }
        public void Clear()
        {
            dict = new Dictionary<K, T>();
            capacity = 10;
        }
        public MySortedDictionary<K, T> Clone()
        {
            MySortedDictionary<K, T> dict2 = new MySortedDictionary<K, T>(this);
            return dict2;
            
        }
        public void Remove(T val)
        {
            dict.Remove(dict.First(p => p.Value.Equals(val)).Key);
        }
        public void RemoveAt(int index)
        {
            dict.Remove(GetKey(index));
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)dict).GetEnumerator();
        }

        public bool MoveNext()
        {
            position++;
            return position < dict.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
