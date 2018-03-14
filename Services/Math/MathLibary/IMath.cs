using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MathLibary
{
    public interface IMath
    {
        /// <summary>
        /// Calcualtes the area of a triangle from the base and height parameter asynchronous.
        /// </summary>
        /// <param name="base">The baseline of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        /// <returns>The area of the triangle.</returns>
        /// <exception cref="ArgumentException">If base or height is 0 or lower.</exception>
        Task<double> CalculateTriangleAreaAsync(double @base, double height);

        /// <summary>
        /// Calculates the circumference of a triangle from its 3 sides asynchronous.
        /// </summary>
        /// <param name="sideA">First side of the triangle.</param>
        /// <param name="sideB">Secund side of the triangle.</param>
        /// <param name="sideC">Third side of the triangle.</param>
        /// <returns>The circumference of the triangle.</returns>
        /// <exception cref="ArgumentException">If sideA, sideB or sideC is 0 or lower.</exception>
        Task<double> CalculateTriangleCircumferenceAsync(double sideA, double sideB, double sideC);

        /// <summary>
        /// Calculates the hypotenuse of a triangle from its 2 legs asynchronous.
        /// </summary>
        /// <param name="leg1">Leg one of the triangle.</param>
        /// <param name="leg2">Leg two of the triangle.</param>
        /// <returns>The hypotenuse of the triangle.</returns>
        /// <exception cref="ArgumentException">If leg1 or leg2 is 0 or lower.</exception>
        Task<double> CalculateTriangleHypotenuseAsync(double leg1, double leg2);

        /// <summary>
        /// Calculates the area of a circle from its radius asynchronous.
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        /// <returns>The area of the circle.</returns>
        /// <exception cref="ArgumentException">If radius is 0 or lower.</exception>
        Task<double> CalculateCircleAreaAsync(double radius);

        /// <summary>
        /// Calculates the circumference of a circle from its radius asynchronous.
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        /// <returns>The circumference of the circle.</returns>
        /// <exception cref="ArgumentException">If radius is 0 or lower.</exception>
        Task<double> CalculateCircleCircumferenceAsync(double radius);

        /// <summary>
        /// Adds a number of doubles together asynchronous.
        /// </summary>
        /// <param name="numbers">A list of doubles to add together.</param>
        /// <returns>The addition result.</returns>
        /// <exception cref="ArgumentException">If numbers is empty.</exception>
        Task<double> AdditionAsync(params double[] numbers);

        /// <summary>
        /// Subtracs a numbers of doubles asynchronous.
        /// </summary>
        /// <param name="numbers">A list of doubles to be subtracted.</param>
        /// <returns>The subtracted result.</returns>
        /// <exception cref="ArgumentException">If numbers is empty.</exception>
        Task<double> SubtractionAsync(params double[] numbers);

        /// <summary>
        /// Multiplies a numbers of doubles together asynchronous.
        /// </summary>
        /// <param name="numbers">A list of doubles to be multiplied.</param>
        /// <returns>The multiplied result.</returns>
        /// <exception cref="ArgumentException">If numbers is empty.</exception>
        Task<double> MultiplicationAsync(params double[] numbers);

        /// <summary>
        /// Divides a number of doubles from each other asynchronous.
        /// </summary>
        /// <param name="numbers">A list of doubles to be divided.</param>
        /// <returns>The divided result.</returns>
        /// <exception cref="ArgumentException">If numbers is empty.</exception>
        Task<double> DivisionAsync(params double[] numbers);


    }
}
