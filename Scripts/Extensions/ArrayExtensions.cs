using UnityEngine;
using System.Collections;

namespace GeoTetra.GTCommon.Extensions
{
	public static class ArrayExtensions
	{
		public static void Populate<T>(this T[] arr, T value)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = value;
			}
		}

		public static void Populate<T>(this T[] arr, T value, int startIndex)
		{
			for (int i = startIndex; i < arr.Length; i++)
			{
				arr[i] = value;
			}
		}

		public static void Populate<T>(this T[] arr, T value, int startIndex, int endIndex)
		{
			for (int i = startIndex; i < endIndex; i++)
			{
				arr[i] = value;
			}
		}
	}
}