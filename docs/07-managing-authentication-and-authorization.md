# 7.1 Managing Authentication and Authorization

|||
|-|-|
|![](img/07-a1.jpg)| Authentication is used to identify a user's identity. It is in authentication that the user proves who he is |
|![](img/07-a2.jpg)| Authorization is used to determine what an authenticated user can access and what actions he can take |

`ASP.NET Core` supports configuration and security management in `Blazor` applications  
Security scenarios are different for `Blazor Server` and `Blazor WebAssembly` projects  
In `Blazor Server` projects, authorization checks are able to determine:    
- The user interface options presented to the user 
- Access rules for application areas and components

In `Blazor WebAssembly` projects authorization is used only to determine which user interface options will be presented  
A `WebAssembly` application cannot enforce authorization access rules

### Blazor Server: Authentication
`Blazor` uses existing `ASP.NET Core` authentication mechanisms to establish the user's identity  
`Blazor Server` applications operate over a real-time connection that is created using `SignalR`  
The `Blazor Server App` template allows you to configure the authentication mechanism  
Authentication uses _cookies_ or another process to determine the user's identity and uses the same mechanism as `ASP.NET Core` applications  
The project can track the identity of the logged in user and apply authorization rules
