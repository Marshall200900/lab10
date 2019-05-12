using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class MySortedDictionary<K,T>:IEnumerable where K:IComparable where T:IComparable
    {
        private int capacity;
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
        

        
        public MySortedDictionary()
        {
            capacity = 10;
        }
        public MySortedDictionary(int capacity)
        {
            this.capacity = capacity;
        }
        public MySortedDictionary(MySortedDictionary<K, T> c)
        {
            foreach(KeyValuePair<K, T> p in c)
            {
                dict.Add(p.Key, p.Value);
            }
        }
        public bool ContainsKey(K key)
        {
            foreach (KeyValuePair<K, T> p in dict)
            {
                if(key.CompareTo(p.Key) == 0)
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
                if (val.CompareTo(p.Value) == 0)
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
            return this;
            
        }
        public void Remove(T val)
        {
            dict.Remove(dict.First(p => p.Value.CompareTo(val) == 0).Key);
        }
        public void RemoveAt(int index)
        {
            dict.Remove(GetKey(index));
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)dict).GetEnumerator();
        }
    }
}
