﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FunctionSeries.cs" company="OxyPlot">
//   http://oxyplot.codeplex.com, license: Ms-PL
// </copyright>
// <summary>
//   The FunctionSeries generates its dataset from a Func.
//   Define f(x) and make a plot on the range [x0,x1]
//   or define fx(t) and fy(t) and make a plot on the range [t0,t1]
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The FunctionSeries generates its dataset from a Func.
    ///   Define f(x) and make a plot on the range [x0,x1]
    ///   or define fx(t) and fy(t) and make a plot on the range [t0,t1]
    /// </summary>
    public class FunctionSeries : LineSeries
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSeries"/> class.
        /// </summary>
        public FunctionSeries()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSeries"/> class.
        /// </summary>
        /// <param name="f">
        /// The function f(x).
        /// </param>
        /// <param name="x0">
        /// The start x value.
        /// </param>
        /// <param name="x1">
        /// The end x value.
        /// </param>
        /// <param name="dx">
        /// The increment in x.
        /// </param>
        /// <param name="title">
        /// The title (optional).
        /// </param>
        public FunctionSeries(Func<double, double> f, double x0, double x1, double dx, string title = null)
        {
            this.Title = title;
            for (double x = x0; x <= x1 + dx / 2; x += dx)
            {
                this.Points.Add(new DataPoint(x, f(x)));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSeries"/> class.
        /// </summary>
        /// <param name="f">
        /// The function f(x).
        /// </param>
        /// <param name="x0">
        /// The start x value.
        /// </param>
        /// <param name="x1">
        /// The end x value.
        /// </param>
        /// <param name="n">
        /// The number of points.
        /// </param>
        /// <param name="title">
        /// The title (optional).
        /// </param>
        public FunctionSeries(Func<double, double> f, double x0, double x1, int n, string title = null)
            : this(f, x0, x1, (x1 - x0) / (n - 1), title)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSeries"/> class.
        /// </summary>
        /// <param name="fx">
        /// The function fx(t).
        /// </param>
        /// <param name="fy">
        /// The function fy(t).
        /// </param>
        /// <param name="t0">
        /// The t0.
        /// </param>
        /// <param name="t1">
        /// The t1.
        /// </param>
        /// <param name="dt">
        /// The increment dt.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public FunctionSeries(
            Func<double, double> fx, Func<double, double> fy, double t0, double t1, double dt, string title = null)
        {
            this.Title = title;
            foreach (IDataPoint pt in GetPoints(fx, fy, t0, t1, dt))
            {
                this.Points.Add(pt);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSeries"/> class. 
        /// The function series.
        /// </summary>
        /// <param name="fx">
        /// The function fx(t).
        /// </param>
        /// <param name="fy">
        /// The function fy(t).
        /// </param>
        /// <param name="t0">
        /// The t0.
        /// </param>
        /// <param name="t1">
        /// The t1.
        /// </param>
        /// <param name="n">
        /// The number of points.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public FunctionSeries(
            Func<double, double> fx, Func<double, double> fy, double t0, double t1, int n, string title = null)
            : this(fx, fy, t0, t1, (t1 - t0) / (n - 1), title)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The get points.
        /// </summary>
        /// <param name="fx">
        /// The fx.
        /// </param>
        /// <param name="fy">
        /// The fy.
        /// </param>
        /// <param name="t0">
        /// The t 0.
        /// </param>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <param name="dt">
        /// The dt.
        /// </param>
        /// <returns>
        /// </returns>
        public static IEnumerable<IDataPoint> GetPoints(
            Func<double, double> fx, Func<double, double> fy, double t0, double t1, double dt)
        {
            for (double t = t0; t <= t1 + dt / 2; t += dt)
            {
                yield return new DataPoint(fx(t), fy(t));
            }
        }

        #endregion
    }
}