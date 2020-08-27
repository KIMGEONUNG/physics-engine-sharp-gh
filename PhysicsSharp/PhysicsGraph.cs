using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    /// <summary>
    /// Special case of graph data structure. 
    /// Represenation is Adjacent list
    /// </summary>
    public class PhysicsGraph
    {
        /// <summary>
        /// Spring constant in Hook's law
        /// </summary>
        private double K = 4;

        /// <summary>
        /// Damping coefficient 
        /// </summary>
        private double damping = 0.9;

        /// <summary>
        /// Gravity accerleration
        /// </summary>
        private Vector3d gravityA = new Vector3d(0, 0, -10);

        /// <summary>
        /// mass of each vectex 
        /// </summary>
        private double particleMass = 20;

        private Vertex[] Vertices;
        private Spring[] Springs;
        public PhysicsGraph(IEnumerable<Vertex> vertices, IEnumerable<Spring> springs)
        {
            Vertices = vertices.ToArray();
            Springs = springs.ToArray();
        }

        public int CountOfVertex()
        {
            return Vertices.Length;
        }

        private Tuple<Vertex[], Spring[]> FindAdjacents(int id)
        {
            var vertices = new List<Vertex>();
            var springs = new List<Spring>();
            foreach (var s in Springs)
            {
                if (s.IsConnected(id))
                {
                    Spring spring = s;
                    int vertexId = s.GetOther(id);
                    Vertex vertex = Vertices.Single(n => n.Id == vertexId);

                    vertices.Add(vertex);
                    springs.Add(s);
                }
            }

            return new Tuple<Vertex[], Spring[]>(vertices.ToArray(), springs.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outerForce">generally gravity</param>
        public void EstimateForce()
        {
            Vector3d gravity = gravityA * particleMass; 
            foreach (Vertex v in Vertices)
            {
                Vector3d springForce = new Vector3d(); 
                // Sum of elastic force
                Tuple<Vertex[], Spring[]> adjs = FindAdjacents(v.Id);
                for (int i = 0; i < adjs.Item1.Length; i++)
                {
                    Vertex other = adjs.Item1[i];
                    Spring s = adjs.Item2[i];
                    double dist = v.position.DistanceTo(other.position);
                    double stringLength = s.Length;
                    if (dist <= stringLength)
                    {
                        continue;
                    }

                    double diff = dist - stringLength;

                    double coef = (-1) * this.K * diff;
                    Vector3d dir = v.position - other.position;
                    dir.Unitize();
                    Vector3d elasticForce = dir * coef;

                    springForce += elasticForce;
                }
                Vector3d dampingForce = damping * v.currentVelocity;
                Vector3d force = gravity + springForce - dampingForce;
                v.EstimateExpected(force, particleMass); 
            }
        }

        public void Update()
        {
            foreach (var v in Vertices)
            {
                v.Update();
            }
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (Vertex v in Vertices)
            {
                s += v.ToString();
                s += "\n";
            }
            foreach (Spring sp in Springs)
            {
                s += sp.ToString();
                s += "\n";
            }
            return s;
        }
    }
}
