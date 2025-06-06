﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgCircleElement.cs - This file is part of Svg2Xaml.
//
//    Copyright (C) 2009,2011 Boris Richter <himself@boris-richter.net>
//
//  --------------------------------------------------------------------------
//
//  Svg2Xaml is free software: you can redistribute it and/or modify it under 
//  the terms of the GNU Lesser General Public License as published by the 
//  Free Software Foundation, either version 3 of the License, or (at your 
//  option) any later version.
//
//  Svg2Xaml is distributed in the hope that it will be useful, but WITHOUT 
//  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or 
//  FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public 
//  License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public License 
//  along with Svg2Xaml. If not, see <http://www.gnu.org/licenses/>.
//
//  --------------------------------------------------------------------------
//
//  $LastChangedRevision$
//  $LastChangedDate$
//  $LastChangedBy$
//
////////////////////////////////////////////////////////////////////////////////
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace Svg2Xaml
{

    //****************************************************************************
    /// <summary>
    ///   Represents an &lt;circle&gt; element.
    /// </summary>
    class SvgCircleElement
      : SvgDrawableBaseElement
    {
        //==========================================================================
        /// <summary>
        ///   The x-coordinate of the circle's center.
        /// </summary>
        public readonly SvgCoordinate CenterX = new SvgCoordinate(0);

        //==========================================================================
        /// <summary>
        ///   The y-coordinate of the circle's center.
        /// </summary>
        public readonly SvgCoordinate CenterY = new SvgCoordinate(0);

        //==========================================================================
        /// <summary>
        ///   The circle's radius.
        /// </summary>
        public readonly SvgLength Radius = new SvgLength(0);

        //==========================================================================
        public SvgCircleElement(SvgDocument document, SvgBaseElement parent, XElement circleElement)
          : base(document, parent, circleElement)
        {
            XAttribute cx_attribute = circleElement.Attribute("cx");
            SvgCoordinate.TryUpdate(ref CenterX, cx_attribute?.Value);

            XAttribute cy_attribute = circleElement.Attribute("cy");
            SvgCoordinate.TryUpdate(ref CenterY, cy_attribute?.Value);

            XAttribute r_attribute = circleElement.Attribute("r");
            SvgLength.TryUpdate(ref Radius, r_attribute?.Value);
        }

        //==========================================================================
        public override Geometry GetBaseGeometry()
        {
            var eg = new EllipseGeometry(
              new Point(CenterX.ToDouble(),
              CenterY.ToDouble()),
              Radius.ToDouble(),
              Radius.ToDouble());
            return eg;
        }

        public override Drawing GetBaseDrawing()
        {
            var bd = base.GetBaseDrawing();
            var gd = bd as GeometryDrawing;
            if (gd != null && gd.Brush != null)
            {
                if (this.Transform != null)
                {
                    var tf = this.Transform.ToTransform();
                    if (gd.Brush.Transform != null)
                    {
                        var tg = new TransformGroup();
                        tg.Children.Add(gd.Brush.Transform);
                        tg.Children.Add(tf);
                        gd.Brush.Transform = tg;
                    }
                    else
                    {
                        gd.Brush.Transform = tf;
                    }
                }
            }

            return bd;
        }
    } // class SvgCircleElement

}