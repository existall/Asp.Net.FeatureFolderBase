# Asp.Net.FeatureFolderBase

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



