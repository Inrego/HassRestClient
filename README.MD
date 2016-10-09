# HassRestClient
HassRestClient is a C# client for Home Assistant, using the REST api available. See more about the REST api [here](https://home-assistant.io/developers/rest_api/).
It uses the async Task pattern for easy consumption in an async application.

All functions are implemented except for error log and history. Usage is pretty simple: Instantiate the ApiClient class and call the functions.

Supported targets:

 - .NET Framework 4.5
 - ASP.NET Core 1.0
 - Windows 8
 - Windows Phone 8.1
 - Xamarin.Android
 - Xamarin.iOS

## Usage

	var url = @"http://localhost:8123/";
	var password = "Verysecretpassword!1";
	using (var client = new ApiClient(url, password))
	{
		var bootstrap = await client.GetBootstrapAsync();
	}
