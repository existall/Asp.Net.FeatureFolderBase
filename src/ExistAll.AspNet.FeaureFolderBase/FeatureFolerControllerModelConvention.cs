using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ExistAll.AspNet.FeaureFolderBase
{
	internal class FeatureFolerControllerModelConvention : IControllerModelConvention
	{
		private readonly string _folderName;

		public FeatureFolerControllerModelConvention(FeatureFolderOptions options)
		{
			_folderName = options.FeatureFolderName;
		}

		public void Apply(ControllerModel controller)
		{
			Guard.ThrowIfNull(controller, nameof(controller));
			
			var path = GetFeaturePathByNamespace(controller);
			controller.Properties.Add(Constants.ControllerPropertyKey, path);
		}

		private string GetFeaturePathByNamespace(ControllerModel model)
		{
			var @namespace = model.ControllerType.Namespace;
			var result = @namespace.Split('.')
				.SkipWhile(s => s != _folderName)
				.Aggregate("", Path.Combine);

			return result;
		}
	}
}