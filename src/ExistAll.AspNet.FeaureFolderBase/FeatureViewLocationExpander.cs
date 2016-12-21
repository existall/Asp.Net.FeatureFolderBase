using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace ExistAll.AspNet.FeaureFolderBase
{
	internal class FeatureViewLocationExpander : IViewLocationExpander
	{
		private readonly string _placeholder;

		public FeatureViewLocationExpander(FeatureFolderOptions options)
		{
			_placeholder = options.FeatureNameConvention;
		}

		public void PopulateValues(ViewLocationExpanderContext context) { }

		public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
		{
			Guard.ThrowIfNull(context, nameof(context));
			Guard.ThrowIfNull(viewLocations, nameof(viewLocations));

			var controllerDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
			var featureName = controllerDescriptor?.Properties[Constants.ControllerPropertyKey] as string;

			foreach (var location in viewLocations)
			{
				yield return location.Replace(_placeholder, featureName);
			}
		}
	}
}