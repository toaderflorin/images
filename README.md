# images
The application was build with VS 2017 Community Edition. Make sure you clone the repo and restore the Nuget packages for the whole solution. The easiest way to run the aplication is to start the tests from the *Images.Tests* project.

## Considerations
For ease of maintainability and separation of concerns, the application has been split into three projects *Images*, *Images.Service* (which contains the service layer) and *Images.Tests*. This also makes it easy for the tests to reference the service.

The color profiles are defined in the *appsettings.json* file, in a custom configuration section.

```
"ProfilesConfig": {
  "Profiles": [
    {
      "Name": "red",
      "R": 230,
      "G": 50,
      "B": 0
    },
    {
      "Name": "blue",
      "R": 0,
      "G": 0,
      "B": 200
    }
  ],
  "Tolerance": 40.0
}

```
The API can be called like this (the url of the image needs to be url encoded):
```
http://localhost:55786?api/images?url=https%3A%2F%2Fimg.buzzfeed.com%2Fbuzzfeed-static%2Fstatic%2F2016-01%2F7%2F11%2Fenhanced%2Fwebdr03%2Fenhanced-buzz-32618-1452185446-0.jpg
```

The service will compute the average color of the pixels and will return the closest matching profile within the tolerance defined in the configuration file. If no color profile can be find to be a match, the API will return a 404.
