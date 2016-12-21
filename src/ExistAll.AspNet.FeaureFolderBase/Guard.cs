﻿using System;

namespace ExistAll.AspNet.FeaureFolderBase
{
	internal static class Guard
	{
		public static void ThrowIfNull<T>(T obj, string name) where T : class
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(name));
			}
		}
	}
}