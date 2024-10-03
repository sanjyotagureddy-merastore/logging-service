# merastore-logging-service
## Overview

The Logging API SDK provides a simple and efficient way to interact with the Logging API of MeraStore. This SDK allows you to create and retrieve request and response logs with ease, utilizing best practices for HTTP client usage and error handling.

## Features

- **Create Request Logs**: Easily send request log data to the Logging API.
- **Retrieve Request Logs**: Fetch existing request logs by their unique identifiers.
- **Create Response Logs**: Send response log data to the Logging API.
- **Retrieve Response Logs**: Fetch existing response logs by their unique identifiers.
- **Built-in Retry Logic**: Automatically retries requests with configurable retry policies using Polly.

## Usage
Register the SDK
``` csharp
    services.AddLoggingApiServices();
```

Build the SDK

``` csharp
    var baseUrl = "http://logging-api.merastore.com:8101";
    var builder = new ClientBuilder(); // Make sure the correct builder is used
    LoggingApiClient _clientInstance = builder
                                        .WithUrl(baseUrl)
                                        .UseDefaultRetryPolicy()
                                        .Build();
```

Usage Example:

Create Request Log
``` csharp
    await _client.CreateRequestLogAsync(new BaseDto()
    {
        Content = content,
        Endpoint = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}"
    });
```

Create Response Log
``` csharp
    await _client.CreateResponseLogAsync(new BaseDto()
    {
        Content = content,
        Endpoint = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}"
    });
```