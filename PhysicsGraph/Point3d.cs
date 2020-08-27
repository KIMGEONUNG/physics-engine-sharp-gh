using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsGraph
{
    public struct Point3d
    {
        public double X; 
        public double Y; 
        public double Z;
        public Point3d(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            List<double> a;
        }
        public double DistanceTo(Point3d other)
        {
            return Math.Sqrt(
                Math.Pow(X - other.X, 2)+
                Math.Pow(Y - other.Y, 2)+
                Math.Pow(Z - other.Z, 2));
        }
        public static Point3d operator +(Point3d p, Vector3d v)
        {
            return new Point3d(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
        }
        public static Point3d operator +(Point3d p1, Point3d p2)
        {
            return new Point3d(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }
        public static Vector3d operator -(Point3d p1, Point3d p2)
        {
            return new Vector3d(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }
    }
}
