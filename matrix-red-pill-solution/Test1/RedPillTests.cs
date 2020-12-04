using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test1
{
    [TestClass]
    public class RedPillTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IMatrixHuman neo = new Neo();
            IRedPill redPill = new RedPill();

            try
            {
                neo.Swallow(redPill);

            }
            catch (RedPillException ex)
            {
                Assert.IsTrue(ex.Location.Vector.X == 10 && ex.Location.Vector.Y == 11 && ex.Location.Vector.Z == 12);
            }
        }
    }

    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    public interface ICropLocation
    {
        Vector Vector { get; set; }
    }

    public class CropLocation : ICropLocation
    {
        public Vector Vector { get; set; }
    }


    public class RedPill : IRedPill
    {
        public void AdjustAttributeLevels()
        {
            /*
             All the Matrix complex code related to human swalling stuff here.
             At somepoing the RedPill program will forte AdjustAttributeLevel underlying calls to
            set CropLocation which is what Morpheus need to locate Neo inside the Real world.
            We are simulating that!
             */

            throw new RedPillException(10, 11, 12);

        }
    }

    public class RedPillException : Exception
    {
        public ICropLocation Location { get; set; }

        public RedPillException(double x, double y, double z) : base("")
        {
            Location = new CropLocation();
            Location.Vector = new Vector(x, y, z);
        }
    }

    public interface ISwallowable
    {
        /// <summary>
        /// Carbs, protein, Dopamine, Vitamin, Minerals, etc;
        /// </summary>
        void AdjustAttributeLevels();
    }

    public interface IRedPill : ISwallowable
    {

    }

    public class Neo : MatrixHuman
    {

    }

    public class NeoBoss : MatrixHuman
    {

    }

    public abstract class MatrixHuman : IMatrixHuman
    {
        public ICropLocation Location { get; }

        public void Swallow(ISwallowable swallowable)
        {
            swallowable.AdjustAttributeLevels();
        }
    }

    public interface IMatrixHuman
    {
        ICropLocation Location { get; }
        void Swallow(ISwallowable swallowable);
    }
}
