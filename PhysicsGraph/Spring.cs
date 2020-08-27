using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsGraph
{
    /// <summary>
    /// Edge of graph data structure 
    /// </summary>
    public class Spring
    {
        /// <summary>
        /// Hook's law coefficient 
        /// </summary>
        private HashSet<int> connection;
        public double Length;

        public Spring(int id1, int id2, double length)
        {
            this.connection = new HashSet<int> { id1, id2 };
            Length = length;
        }

        public bool IsConnected(int i)
        {
            return connection.Contains(i);
        }

        public int GetOther(int id)
        {
            int a = connection.First();
            int b = connection.Last();

            if (a == id)
            {
                return b;
            }
            else if (b == id)
            {
                return a;
            }
            throw new Exception();
        }
    }
}
