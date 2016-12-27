# ExistAll.AspNet.FeatureFolderBase

### Installation
```
    Install-Package ExistAll.AspNet.FeatureFolderBase 
```

Microsoft MVC is a wonderful tool, Yet out of the box it uses convention based Mapping between controllers and actions to the name
of the view it should render. Thus means that Controllers should be in the Controllers Folder and Views should be in the Views Folder.

Feature Folder Base provides a way to structure your project around the features. Gather the feature Views, Models and Controllers in one folder.

```csharp
public void ConfigureServices(IServiceCollection services)
{			
	services.AddMvc()
	    .AddFeatureFolders();
}
```

The Default value for the main folder is Application changing the main folder name simply use FeatureFolderOptions:

```csharp
public void ConfigureServices(IServiceCollection services)
{			
	services.AddMvc()				
        .AddFeatureFolders(new FeatureFolderOptions()
		{
		    FeatureFolderName = "SomeFolder"
		});
}
```

FeatureFolderBase supports Conventions and or Explicit View location:

By setting ```FeatureFolderOptions.ViewExtractionOption``` you can choose what FeatureFolderBase will support

```csharp
public enum ViewExtractionOption
{
	Explicits,
	Convention,
	All
}
```

## Explicit View Location:

By creating a new folder under the Appication folder and placing the view under that folder we can give the View method only the name of the folder and the view and FeatureFolderBase will search for the view under ```Application/NewFolderName/ViewName```

```csharp 
public class SomeController : Controller
{
	public IActionResult NotImportantName()
	{
		return View("FeatureFolder/FeatureView"); // the view should be in Application/FeatureFloder/FeatureView.cshtml
	}
}
```

## Convention View Location

```csharp 
namespace Company.Application.Home // The convention is based upon namespace --> folder structure

public class SomeController : Controller
{
	public IActionResult ViewName()
	{
		return View(); // the view should be in Application/Home/ViewName.cshtml
	}
}
```
