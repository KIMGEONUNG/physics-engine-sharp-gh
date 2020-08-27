using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsGraph
{
    [DebuggerDisplay("{X} , {Y} , {Z}")]
    public struct Vector3d
    {
        public double X;
        public double Y;
        public double Z;
        public Vector3d(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vector3d operator *(Vector3d v, double a)
        {
            return new Vector3d(v.X * a, v.Y * a, v.Z * a);
        }
        public static Vector3d operator *( double a,Vector3d v)
        {
            return new Vector3d(v.X * a, v.Y * a, v.Z * a);
        }
        public static Vector3d operator +(Vector3d v1, Vector3d v2)
        {
            return new Vector3d(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vector3d operator -(Vector3d v1, Vector3d v2)
        {
            return new Vector3d(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public void Unitize()
        {
            double len = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

            this.X = this.X / len;
            this.Y = this.Y / len;
            this.Z = this.Z / len;
        }
    }
}
