using Microsoft.Extensions.DependencyInjection;

namespace ExistAll.AspNet.FeaureFolderBase
{
	public static class ServiceCollectionExtensions
	{
		public static IMvcBuilder FeatureFolder(this IMvcBuilder target, FeatureFolderOptions options)
		{
			target.AddRazorOptions(o =>
			{
				o.ViewLocationFormats.Clear();
			});

			return target;
		}
	}
}