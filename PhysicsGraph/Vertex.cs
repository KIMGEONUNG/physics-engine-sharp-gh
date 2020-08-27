using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsGraph
{
    /// <summary>
    /// vertex of graph data structure
    /// </summary>
    public class Vertex
    {
        private const double timeUnit = 0.5;

        public readonly int Id;
        public Vector3d currentVelocity = new Vector3d();

        public bool isAnchor;
        public Point3d position;
        public Point3d? expected;

        public Vertex(int id, bool isAnchor, Point3d position)
        {
            this.Id = id;
            this.isAnchor = isAnchor;
            this.position = position;
        }

        public void Update()
        {
            if (!expected.HasValue)
            {
                throw new Exception("None expected value");
            }

            this.position = expected.Value;
            this.expected = null;
        }

        public void EstimateExpected(Vector3d force, double mass)
        {
            if (isAnchor)
            {
                this.expected = this.position;
                return;
            }

            Vector3d a = force * (1/mass);
            Vector3d nextVelocity = currentVelocity + a * timeUnit;
            Point3d nextPositon = this.position + (nextVelocity * timeUnit);

            this.expected = nextPositon;
            this.currentVelocity = nextVelocity;
        }

        public override string ToString()
        {
            return $"{this.Id} : ({this.position.X},{this.position.Y},{this.position.Z})";
        }
    }
}
