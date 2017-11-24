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
