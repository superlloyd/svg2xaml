﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgRectElement.cs - This file is part of Svg2Xaml.
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
    ///   Represents a &lt;rect&gt; element.
    /// </summary>
    class SvgRectElement
      : SvgDrawableBaseElement
    {
        //==========================================================================
        public readonly SvgCoordinate X = new SvgCoordinate(0.0);
        public readonly SvgCoordinate Y = new SvgCoordinate(0.0);
        public readonly SvgLength Width = new SvgLength(0.0);
        public readonly SvgLength Height = new SvgLength(0.0);
        public readonly SvgLength CornerRadiusX = new SvgLength(0.0);
        public readonly SvgLength CornerRadiusY = new SvgLength(0.0);

        //==========================================================================
        public SvgRectElement(SvgDocument document, SvgBaseElement parent, XElement rectElement)
          : base(document, parent, rectElement)
        {
            XAttribute x_attribute = rectElement.Attribute("x");
            SvgCoordinate.TryUpdate(ref X, x_attribute?.Value);

            XAttribute y_attribute = rectElement.Attribute("y");
            SvgCoordinate.TryUpdate(ref Y, y_attribute?.Value);

            XAttribute width_attribute = rectElement.Attribute("width");
            SvgLength.TryUpdate(ref Width, width_attribute?.Value);

            XAttribute height_attribute = rectElement.Attribute("height");
            SvgLength.TryUpdate(ref Height, height_attribute?.Value);

            XAttribute rx_attribute = rectElement.Attribute("rx");
            SvgCoordinate.TryUpdate(ref CornerRadiusX, rx_attribute?.Value);

            XAttribute ry_attribute = rectElement.Attribute("ry");
            SvgCoordinate.TryUpdate(ref CornerRadiusY, ry_attribute?.Value);
        }

        //==========================================================================
        public override Geometry GetBaseGeometry()
        {
            return new RectangleGeometry(new Rect(new Point(X.ToDouble(), Y.ToDouble()),
                                         new Size(Width.ToDouble(), Height.ToDouble())),
                                         CornerRadiusX.ToDouble(),
                                         CornerRadiusY.ToDouble());
        }

    } // class SvgRectElement

}