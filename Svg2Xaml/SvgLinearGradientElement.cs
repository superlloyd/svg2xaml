﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgLinearGradientElement.cs - This file is part of Svg2Xaml.
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
    ///   Represents a &lt;linearGradient&gt; element.
    /// </summary>
    class SvgLinearGradientElement
      : SvgGradientBaseElement
    {
        //==========================================================================
        public readonly SvgCoordinate X1 = new SvgCoordinate(0);
        public readonly SvgCoordinate Y1 = new SvgCoordinate(0);
        public readonly SvgCoordinate X2 = new SvgCoordinate(1);
        public readonly SvgCoordinate Y2 = new SvgCoordinate(0);

        //==========================================================================
        public SvgLinearGradientElement(SvgDocument document, SvgBaseElement parent, XElement linearGradientElement)
          : base(document, parent, linearGradientElement)
        {
            XAttribute x1_attribute = linearGradientElement.Attribute("x1");
            SvgCoordinate.TryUpdate(ref X1, x1_attribute?.Value);

            XAttribute y1_attribute = linearGradientElement.Attribute("y1");
            SvgCoordinate.TryUpdate(ref Y1, y1_attribute?.Value);

            XAttribute x2_attribute = linearGradientElement.Attribute("x2");
            SvgCoordinate.TryUpdate(ref X2, x2_attribute?.Value);

            XAttribute y2_attribute = linearGradientElement.Attribute("y2");
            SvgCoordinate.TryUpdate(ref Y2, y2_attribute?.Value);
        }

        //==========================================================================
        protected override GradientBrush CreateBrush()
        {
            return new LinearGradientBrush();
        }

        //==========================================================================
        protected override GradientBrush SetBrush(GradientBrush brush)
        {
            LinearGradientBrush linear_gradient_brush = base.SetBrush(brush) as LinearGradientBrush;
            if (linear_gradient_brush != null)
            {
                linear_gradient_brush.StartPoint = new Point(X1.ToDouble(), Y1.ToDouble());
                linear_gradient_brush.EndPoint = new Point(X2.ToDouble(), Y2.ToDouble());
            }
            return brush;
        }

    } // class SvgLinearGradientElement

}