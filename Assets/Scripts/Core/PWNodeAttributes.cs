﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace PW.Core
{
	[AttributeUsage(AttributeTargets.Field)]
	public class PWInput : Attribute
	{
		public string	name = null;
		
		public PWInput()
		{
		}
		
		public PWInput(string fieldName)
		{
			name = fieldName;
		}
	}
	
	[AttributeUsage(AttributeTargets.Field)]
	public class PWOutput : Attribute
	{
		public string	name = null;

		public PWOutput()
		{
		}
		
		public PWOutput(string fieldName)
		{
			name = fieldName;
		}
	}
	
	[AttributeUsage(AttributeTargets.Field)]
	public class PWOffset : Attribute
	{
		public Vector2	offset;
		public int		multiPadding = 0;
		
		public PWOffset(int x, int y, int multiPadding)
		{
			offset.x = x;
			offset.y = y;
			this.multiPadding = multiPadding;
		}

		public PWOffset(int x, int y)
		{
			offset.x = x;
			offset.y = y;
		}
		
		public PWOffset(int y)
		{
			offset.x = 0;
			offset.y = y;
		}
	}
	
	[AttributeUsage(AttributeTargets.Field)]
	public class PWColor : Attribute
	{
		public Color		color;

		public PWColor(float r, float g, float b)
		{
			color.r = r * .8f;
			color.g = g * .8f;
			color.b = b * .8f;
			color.a = 1;
		}

		public PWColor(float r, float g, float b, float a)
		{
			color.r = r;
			color.g = g;
			color.b = b;
			color.a = a;
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class PWMultiple : Attribute
	{
		public SerializableType[]	allowedTypes;
		public int		minValues;
		public int		maxValues;
		
		public PWMultiple(int min, int max, params Type[] allowedTypes)
		{
			this.allowedTypes = allowedTypes.Cast< SerializableType >().ToArray();
			minValues = min;
			maxValues = max;
		}

		public PWMultiple(int min, params Type[] allowedTypes)
		{
			List< SerializableType > ts = new List< SerializableType >();
			foreach (var t in allowedTypes)
				ts.Add((SerializableType)t);
			this.allowedTypes = ts.ToArray();
			minValues = min;
			maxValues = 100;
		}
		
		public PWMultiple(params Type[] allowedTypes)
		{
			List< SerializableType > ts = new List< SerializableType >();
			foreach (var t in allowedTypes)
				ts.Add((SerializableType)t);
			this.allowedTypes = ts.ToArray();
			minValues = 0;
			maxValues = 100;
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class PWGeneric : Attribute
	{
		public SerializableType[]	allowedTypes;

		public PWGeneric(params Type[] allowedTypes)
		{
			this.allowedTypes = new SerializableType[allowedTypes.Length];
			for (int i = 0; i < allowedTypes.Length; i++)
				this.allowedTypes[i] = (SerializableType)allowedTypes[i];
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class PWMirror : Attribute
	{
		public string	fieldName;

		public PWMirror(string fieldName)
		{
			this.fieldName = fieldName;
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class PWNotRequired : Attribute
	{
		public PWNotRequired() {}
	}
}
