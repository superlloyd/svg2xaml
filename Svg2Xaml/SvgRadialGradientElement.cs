﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgRadialGradientElement.cs - This file is part of Svg2Xaml.
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
    class SvgRadialGradientElement
      : SvgGradientBaseElement
    {
        //==========================================================================
        public readonly SvgCoordinate CX = new SvgCoordinate(0.5);
        public readonly SvgCoordinate CY = new SvgCoordinate(0.5);
        public readonly SvgLength R = new SvgCoordinate(0.5);
        public readonly SvgCoordinate FX = null;
        public readonly SvgCoordinate FY = null;

        //==========================================================================
        public SvgRadialGradientElement(SvgDocument document, SvgBaseElement parent, XElement radialGradientElement)
          : base(document, parent, radialGradientElement)
        {
            XAttribute cx_attribute = radialGradientElement.Attribute("cx");
            SvgCoordinate.TryUpdate(ref CX, cx_attribute?.Value);

            XAttribute cy_attribute = radialGradientElement.Attribute("cy");
            SvgCoordinate.TryUpdate(ref CY, cy_attribute?.Value);

            XAttribute r_attribute = radialGradientElement.Attribute("r");
            SvgCoordinate.TryUpdate(ref R, r_attribute?.Value);

            XAttribute fx_attribute = radialGradientElement.Attribute("fx");
            SvgCoordinate.TryUpdate(ref FX, fx_attribute?.Value);

            XAttribute fy_attribute = radialGradientElement.Attribute("fy");
            SvgCoordinate.TryUpdate(ref FY, fy_attribute?.Value);

        }

        //==========================================================================
        protected override GradientBrush CreateBrush()
        {
            RadialGradientBrush brush = new RadialGradientBrush();
            brush.ColorInterpolationMode = ColorInterpolationMode.SRgbLinearInterpolation;
            return brush;
        }

        //==========================================================================
        protected override GradientBrush SetBrush(GradientBrush brush)
        {
            RadialGradientBrush radial_gradient_brush = base.SetBrush(brush) as RadialGradientBrush;
            if (radial_gradient_brush != null)
            {
                double cx = CX.ToDouble();
                double cy = CY.ToDouble();
                double fx = (FX != null) ? FX.ToDouble() : cx;
                double fy = (FY != null) ? FY.ToDouble() : cy;

                radial_gradient_brush.GradientOrigin = new Point(fx, fy);
                radial_gradient_brush.RadiusX = R.ToDouble();
                radial_gradient_brush.RadiusY = R.ToDouble();
                radial_gradient_brush.Center = new Point(cx, cy);
            }
            return brush;
        }

    } // class SvgRadialGradientElement

}