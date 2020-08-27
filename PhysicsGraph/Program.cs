using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            double len = 20;
            Vertex[] vs = new Vertex[]
                {
                    new Vertex(0,true, new Point3d(0,0,0)),
                    new Vertex(1,false, new Point3d(1*len,0,0)),
                    new Vertex(2,false, new Point3d(2*len,0,0)),
                    new Vertex(3,false, new Point3d(3*len,0,0)),
                    new Vertex(4,true, new Point3d(4*len,0,0)),
                };
            Spring[] sp = new Spring[]
                {
                    new Spring(0,1,len),
                    new Spring(1,2,len),
                    new Spring(2,3,len),
                    new Spring(3,4,len),
                };

            //Vertex[] vs = new Vertex[]
            //    {
            //        new Vertex(0,true, new Point3d(0,0,0)),
            //        new Vertex(1,false, new Point3d(2,0,0)),
            //        new Vertex(2,true, new Point3d(4,0,0)),
            //    };

            //double len = 2;
            //Spring[] sp = new Spring[]
            //    {
            //        new Spring(0,1,len),
            //        new Spring(1,2,len),
            //    };

            PhysicsNetwork graph = new PhysicsNetwork(vs, sp);
            for (int i = 0; i < 100; i++)
            {
                graph.EstimateForce();
                graph.Update();
                Console.WriteLine(graph);
            }
        }
    }
}
