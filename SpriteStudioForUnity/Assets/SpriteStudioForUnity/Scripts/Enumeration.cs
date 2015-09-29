namespace SpriteStudioForUnity
{
	public enum PartType
	{
		Null,
		Normal,
	}
	
	public enum PartBoundsType
	{
		None,
		Circle,
	}
	
	public enum PartInheritType
	{
		Parent,
		Self,
	}

	public enum PartAlphaBlendType
	{
		Mix,
		Add,
		Sub,
		Mul,
	}

	public enum PartSortMode
	{
		Prio,
	}

	public enum ColorBlendType
	{
		Mix,
		Add,
		Sub,
		Mul,
	}

	public enum ColorBlendTarget
	{
		Whole,
		Vertex,
	}

	public enum VertexNo
	{
		LeftBottom = 0,
		RightBottom,
		RightTop,
		LeftTop,
		Center,
		
		Triangle4Count,
		Triangle2Count = Center,

	}

	public static class Extensions
	{
		public static PartType ToPartType (this string s)
		{
			switch (s) {
			case "normal":
				return PartType.Normal;
			case "null":
				return PartType.Null;
			default:
				return PartType.Normal;
			}
		}
		
		public static PartBoundsType ToBoundType (this string s)
		{
			switch (s) {
			case "none":
				return PartBoundsType.None;
			case "circle":
				return PartBoundsType.Circle;
			default:
				return PartBoundsType.None;
			}
		}
		
		public static PartInheritType ToInheritType (this string s)
		{
			switch (s) {
			case "parent":
				return PartInheritType.Parent;
			case "self":
				return PartInheritType.Self; 
			default:
				return PartInheritType.Parent;
			}
		}
		
		public static PartAlphaBlendType ToAlphaBlendType (this string s)
		{
			switch (s) {
			case "mix":
				return PartAlphaBlendType.Mix;
			case "add":
				return PartAlphaBlendType.Add;
			case "sub":
				return PartAlphaBlendType.Sub;
			case "mul":
				return PartAlphaBlendType.Mul;
			default:
				return PartAlphaBlendType.Mix;
			}
		}

		public static ColorBlendType ToColorBlendType (this string s)
		{
			switch (s) {
			case "mix":
				return ColorBlendType.Mix;
			case "add":
				return ColorBlendType.Add;
			case "sub":
				return ColorBlendType.Sub;
			case "mul":
				return ColorBlendType.Mul;
			default:
				return ColorBlendType.Mix;
			}
		}

		public static ColorBlendTarget ToColorBlendTarget (this string s)
		{
			switch (s) {
			case "whole":
				return ColorBlendTarget.Whole;
			case "vertex":
				return ColorBlendTarget.Vertex;
			default:
				return ColorBlendTarget.Whole;
			}
		}
		
		public static PartSortMode ToSortMode (this string s)
		{
			switch (s) {
			case "prio":
				return PartSortMode.Prio;
			default:
				return PartSortMode.Prio;
			}
		}


	}
}