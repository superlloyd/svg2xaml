﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgSkewTransform.cs - This file is part of Svg2Xaml.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Media;

namespace Svg2Xaml
{

    //****************************************************************************
    class SvgSkewTransform
      : SvgTransform
    {
        public readonly double AngleX;
        public readonly double AngleY;

        //==========================================================================
        public SvgSkewTransform(double angleX, double angleY)
        {
            AngleX = angleX;
            AngleY = angleY;
        }

        //==========================================================================
        public override Transform ToTransform()
        {
            return new SkewTransform(AngleX, AngleY);
        }

        //==========================================================================
        public static new SvgSkewTransform Parse(string transform)
        {
            string[] tokens = transform.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 2)
                throw new FormatException("A skew transformation must have two values");

            return new SvgSkewTransform(Double.Parse(tokens[0].Trim(), CultureInfo.InvariantCulture.NumberFormat),
                                        Double.Parse(tokens[1].Trim(), CultureInfo.InvariantCulture.NumberFormat));
        }

    } // class SvgSkewTransform

}
