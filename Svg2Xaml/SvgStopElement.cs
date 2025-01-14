﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgStopElement.cs - This file is part of Svg2Xaml.
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
using System;
using System.Windows.Media;
using System.Xml.Linq;

namespace Svg2Xaml
{
  
  //****************************************************************************
  class SvgStopElement
    : SvgBaseElement
  {
    //==========================================================================
    public readonly SvgLength Offset = new SvgLength(0);
    public readonly SvgColor Color = new SvgColor(0,0,0);
    public readonly SvgLength Opacity = new SvgLength(1);

    //==========================================================================
    public SvgStopElement(SvgDocument document, SvgBaseElement parent, XElement stopElement)
      : base(document, parent, stopElement)
    {
      XAttribute offset_attribute = stopElement.Attribute("offset");
      SvgLength.TryUpdate(ref Offset, offset_attribute?.Value);

      XAttribute stop_color_attribute = stopElement.Attribute("stop-color");
      if(stop_color_attribute != null)
        Color = SvgColor.Parse(stop_color_attribute.Value);

      XAttribute stop_opacity_attribute = stopElement.Attribute("stop-opacity");
      SvgLength.TryUpdate(ref Opacity, stop_opacity_attribute?.Value);
    }

    //==========================================================================
    public GradientStop ToGradientStop()
    {
      Color color = Color.ToColor();
      color.A = (byte)Math.Round(Opacity.ToDouble() * 255);

      GradientStop stop = new GradientStop();
      stop.Color = color;
      stop.Offset = Offset.ToDouble();

      return stop;
    }

  } // class SvgStopElement

}
