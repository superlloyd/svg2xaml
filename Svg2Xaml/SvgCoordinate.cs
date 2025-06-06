﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgCoordinate.cs - This file is part of Svg2Xaml.
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
namespace Svg2Xaml
{


    //****************************************************************************
    /// <summary>
    ///   A coordinate.
    /// </summary>
    class SvgCoordinate
      : SvgLength
    {

        //==========================================================================
        public SvgCoordinate(double value)
          : base(value)
        {
            // ...
        }

        //==========================================================================
        public SvgCoordinate(double value, string unit)
          : base(value, unit)
        {
            // ...
        }

        //==========================================================================
        public static new SvgCoordinate Parse(string value)
        {
            SvgLength length = SvgLength.Parse(value);

            return new SvgCoordinate(length.Value, length.Unit);

        }
        public static bool TryUpdate(ref SvgCoordinate result, string value)
        {
            if (TryParse(value, out var x))
            {
                result = x;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool TryParse(string value, out SvgCoordinate result)
        {
            if (SvgLength.TryParse(value, out var length))
            {
                result = new SvgCoordinate(length.Value, length.Unit);
                return true;
            }
            else
            {
                result = default(SvgCoordinate);
                return false;
            }
        }

    } // class SvgCoordinate

}
