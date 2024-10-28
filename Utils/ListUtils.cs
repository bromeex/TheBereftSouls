using System.Collections.Generic;

namespace TheBereftSouls.Utils
{
    public class ListUtils
    {
        public static void AddSomeElements(HashSet<int> list, HashSet<int> insert)
        {
            foreach (int element in insert)
                list.Add(element);
        }
        public static void AddSomeElements(List<int> list, List<int> insert)
        {
            foreach (int element in insert)
                list.Add(element);
        }
        public static void AddSomeElements(ICollection<int> list, ICollection<int> insert)
        {
            lock (list)
            {
                foreach (int element in insert)
                    list.Add(element);
            }
        }
    }
}
