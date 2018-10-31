## Request Manager
RequestManager is a .NET Core library that provides helper methods to easily send requests in different formats and deserialize the response into objects. 

## Build status
[![Build Status](https://dev.azure.com/StreamWriter/RequestManager/_apis/build/status/StreamWriter.RequestManager)](https://dev.azure.com/StreamWriter/RequestManager/_build/latest?definitionId=1)

## Features
RequestManager handles the requests by reusing the same **HttpClient** object when the requests are sent to the same API. For multiple APIs, the **HttpClient** objects will be saved and reused in the proper situation.

The library can send GET, POST, PUT, PATCH and DELETE requests with JSON, XML or form-data content types, and receive any type of response, with the possibility to translate it from JSON and XML. 

## How to use?

#Sending a request and reading the response

```
var postAndGetJsonResponse = (await _requestSender.PostAsync("/api/test/json",
                                                             new Person() { Id = 2, Name = "John" }))
                             .ResultAs<Person>(ContentType.JSON);
```

You can take a look at the [HomeController](https://github.com/StreamWriter/RequestManager/blob/master/Sandbox/Controllers/HomeController.cs) from the Sandbox project for more examples regarding sending different content types.
