using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

[assembly:InternalsVisibleTo("ExistAll.Asp.Net.FeatureFolderBase.UnitTests")]
namespace ExistAll.AspNet.FeatureFolderBase
{
	internal class FeatureFolderControllerModelConvention : IControllerModelConvention
	{
		private readonly string _folderName;

		public FeatureFolderControllerModelConvention(FeatureFolderOptions options)
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