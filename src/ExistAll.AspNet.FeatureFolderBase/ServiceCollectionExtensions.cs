using Microsoft.Extensions.DependencyInjection;

namespace ExistAll.AspNet.FeatureFolderBase
{
	public static class ServiceCollectionExtensions
	{
		public static IMvcBuilder AddFeatureFolders(this IMvcBuilder services, FeatureFolderOptions options)
		{
			Guard.ThrowIfNull(services, nameof(services));
			Guard.ThrowIfNull(options, nameof(options));

			var expander = new FeatureViewLocationExpander(options);

			services.AddMvcOptions(o =>
			{
				if (options.ViewExtractionOption == ViewExtractionOption.Convention ||
					options.ViewExtractionOption == ViewExtractionOption.All)
				{
					o.Conventions.Add(new FeatureFolderControllerModelConvention(options));
				}
			});

			services.AddRazorOptions(o =>
				{
					o.ViewLocationFormats.Clear();

					if (options.ViewExtractionOption == ViewExtractionOption.Explicits ||
						options.ViewExtractionOption == ViewExtractionOption.All)
					{
						o.ViewLocationFormats.Add($@"{options.FeatureFolderName}\{{0}}.cshtml");
					}

					if (options.ViewExtractionOption == ViewExtractionOption.Convention ||
						options.ViewExtractionOption == ViewExtractionOption.All)
					{
						o.ViewLocationFormats.Add($@"{options.FeatureNameConvention}\{{0}}.cshtml");
						o.ViewLocationExpanders.Add(expander);
					}
				});

			return services;
		}

		public static IMvcBuilder AddFeatureFolders(this IMvcBuilder services)
		{
			return AddFeatureFolders(services, new FeatureFolderOptions());
		}
	}
}