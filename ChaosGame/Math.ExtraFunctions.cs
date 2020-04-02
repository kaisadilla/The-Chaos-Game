using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGNamespaces.ExtraFunctions {
    public static class ExtraMath {
        /// <summary>
        /// Gets the value that is at the [proportion] way between [valueA] and [valueB].
        /// If [proportion] is 0, it returns [valueA]. If [proportion] is 1, it returns [valueB].
        /// If [proportion] is 0.5, it returns the middle value between [valueA] and [valueB].
        /// </summary>
        /// <param name="valueA"></param>
        /// <param name="valueB"></param>
        /// <param name="proportion"></param>
        public static double MiddleValue(double valueA, double valueB, double proportion) {
            return valueA - ((valueA - valueB) * proportion);
        }
        /// <summary>
        /// Gets the value equal to [valueA] + 1/[compression] the distance between [valueA] and [valueB].
        /// If [proportion] is 1, it returns [valueB].
        /// If [proportion] is higher than 1, it returns a number between [valueA] and [valueB].
        /// If [proportion] is between 0 and 1, it returns a number beyond [valueA] and [valueB].
        /// If [proportion] is lower than 0, it returns a number before [valueA] and [valueB].
        /// If [proportion] is 0, this method will throw a DivideByZeroException.
        /// </summary>
        /// <param name="valueA"></param>
        /// <param name="valueB"></param>
        /// <param name="proportion"></param>
        /// <exception cref="DivideByZeroException">Thrown when [compression] is 0.</exception>
        public static double MiddleValueByCompression(double valueA, double valueB, double compression) {
            return valueB - ((valueB - valueA) / compression);
        }

        //Obtained from here http://tripsintech.com/rotate-a-point-around-another-point-code/
        /// <summary>
        /// Returns a point equal to [point] rotated around [original] by [angle], clockwise.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="origin"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static System.Drawing.Point RotatePointAroundOrigin(System.Drawing.Point point, System.Drawing.Point origin, double angle) {
            double radians = angle.ConvertToRadians();
            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            //Translate point back to origin.
            point.X -= origin.X;
            point.Y -= origin.Y;
            //Rotate point
            double xNew = point.X * cos - point.Y * sin;
            double yNew = point.X * sin + point.Y * cos;

            System.Drawing.Point rotatedPoint = new System.Drawing.Point((int)xNew + origin.X, (int)yNew + origin.Y);
            return rotatedPoint;
        }
        /// <summary>
        /// Converts the passed number from degrees to radians.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double ConvertToRadians(this double angle) {
            return (Math.PI / 180d) * angle;
        }
    }
}
