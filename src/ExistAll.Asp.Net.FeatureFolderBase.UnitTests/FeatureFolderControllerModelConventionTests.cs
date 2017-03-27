using System;
using System.Collections.Generic;
using System.Reflection;
using ExistAll.AspNet.FeatureFolderBase;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using NameSpace.Application.Domain;
using NameSpace.Application.Domain.SubDomain;
using NameSpace.Folder.Domain;
using NameSpace.Folder.Domain.SubDomain;
using Xunit;

namespace ExistAll.Asp.Net.FeatureFolderBase.UnitTests
{
	public class FeatureFolderControllerModelConventionTests
	{
		[Theory]
		[InlineData(typeof(FirstController), @"Application\Domain")]
		[InlineData(typeof(SecondController), @"Application\Domain\SubDomain")]
		public void Apply_WhenNamespaceHasFolderName_ShouldReturnPath(Type controller, string expectedPath)
		{
			var options = new FeatureFolderOptions();
			var service = new FeatureFolderControllerModelConvention(options);
			var controllerType = controller.GetTypeInfo();
			var attributes = new List<string>();
			var model = new ControllerModel(controllerType, attributes);

			service.Apply(model);

			var path = model.Properties[Constants.ControllerPropertyKey];

			Assert.Equal(path, expectedPath);
		}

		[Theory]
		[InlineData(typeof(FirstController))]
		[InlineData(typeof(SecondController))]
		public void Apply_WhenNamespaceDontHasFolderName_ShouldReturnEmptyString(Type controller)
		{
			var options = new FeatureFolderOptions() {FeatureFolderName = "SomeFolder"};
			var service = new FeatureFolderControllerModelConvention(options);
			var controllerType = controller.GetTypeInfo();
			var attributes = new List<string>();
			var model = new ControllerModel(controllerType, attributes);

			service.Apply(model);

			var path = model.Properties[Constants.ControllerPropertyKey];

			Assert.Equal(String.Empty, path);
		}

		[Theory]
		[InlineData(typeof(ForthController), @"Folder\Domain")]
		[InlineData(typeof(ThirdController), @"Folder\Domain\SubDomain")]
		public void Apply_WhenNamespaceHasCustomFolderName_ShouldReturnPath(Type controller, string expectedPath)
		{
			var options = new FeatureFolderOptions(){FeatureFolderName = "Folder"};
			var service = new FeatureFolderControllerModelConvention(options);
			var controllerType = controller.GetTypeInfo();
			var attributes = new List<string>();
			var model = new ControllerModel(controllerType, attributes);

			service.Apply(model);

			var path = model.Properties[Constants.ControllerPropertyKey];

			Assert.Equal(path, expectedPath);
		}
	}
}