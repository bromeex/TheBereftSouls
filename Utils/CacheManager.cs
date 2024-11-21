using System.Collections.Generic;
using Terraria.ModLoader;

namespace TheBereftSouls.Utils
{
    public class CacheManager
    {
        class Node
        {
            public string Name;
            public Mod mod;
            public dynamic Value;
            public Node Prev;
            public Node Next;

            public Node(string name, Mod mod_, dynamic value)
            {
                Name = name;
                mod = mod_;
                Value = value;
                Prev = null;
                Next = null;
            }
        }

        public class LRUCache
        {
            private int capacity;
            private Dictionary<string, Node> cache;
            private Node head;
            private Node tail;
  
            /// <summary>
            /// Initializes a new instance of the <see cref="LRUCache"/> class.
            /// </summary>
            /// <param name="capacity"></param>
            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                cache = new Dictionary<string, Node>();
                head = new Node(string.Empty, null, -1);
                tail = new Node(string.Empty, null, -1);
                head.Next = tail;
                tail.Prev = head;
            }

            // Add a node right after the head
            // (most recently used position)
            private void Add(Node node)
            {
                Node nextNode = head.Next;
                head.Next = node;
                node.Prev = head;
                node.Next = nextNode;
                nextNode.Prev = node;
            }

            // Remove a node from the doubly linked list
            private static void Remove(Node node)
            {
                Node prevNode = node.Prev;
                Node nextNode = node.Next;
                prevNode.Next = nextNode;
                nextNode.Prev = prevNode;
            }

            // Get the value for a given key
            public dynamic Get(string name)
            {
                if (!cache.ContainsKey(name))
                {
                    return null;
                }

                Node node = cache[name];
                Remove(node);
                Add(node);
                return node.Value;
            }

            public dynamic Get(string name, out Mod mod)
            {
                if (!cache.ContainsKey(name))
                {
                    mod = null;
                    return null;
                }

                Node node = cache[name];
                Remove(node);
                Add(node);
                mod = node.mod;
                return node.Value;
            }

            // Put a key-value pair into the cache
            public void Put(string name, Mod mod, dynamic value)
            {
                if (cache.ContainsKey(name))
                {
                    Node oldNode = cache[name];
                    Remove(oldNode);
                    cache.Remove(name);
                }

                while (cache.Count >= capacity)
                {
                    Node lruNode = tail.Prev;
                    Remove(lruNode);
                    cache.Remove(lruNode.Name);
                }

                Node newNode = new (name, mod, value);
                Add(newNode);
                cache[name] = newNode;
            }
            public void UpdateSize()
            {
                while (cache.Count >= capacity)
                    capacity++;
            }
            public void UpdateSize(int ammount)
            {
                while (cache.Count >= capacity)
                    capacity += ammount;
            }
        }
    }
}
