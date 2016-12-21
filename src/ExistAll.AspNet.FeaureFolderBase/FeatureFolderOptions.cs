﻿using System;

namespace ExistAll.AspNet.FeaureFolderBase
{
	public class FeatureFolderOptions
	{
		public FeatureFolderOptions()
		{
			ViewExtractionOption = ViewExtractionOption.All;
			FeatureFolderName = "Application";
			FeatureNameConvention = "{Application}";
		}

		public ViewExtractionOption ViewExtractionOption { get; set; }

		public string FeatureFolderName { get; set; }


		public string FeatureNameConvention { get; set; }
	}
}