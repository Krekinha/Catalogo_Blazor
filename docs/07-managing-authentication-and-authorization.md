## 07. Managing Authentication and Authorization

|||
|-|-|
|![](img/07-a1.jpg)| Authentication is used to identify a user's identity. It is in authentication that the user proves who he is |
|![](img/07-a2.jpg)| Authorization is used to determine what an authenticated user can access and what actions he can take |

ASP.NET Core supports configuration and security management in Blazor applications  
Security scenarios are different for Blazor Server and Blazor WebAssembly projects  
In Blazor Server projects, authorization checks are able to determine:    
- The user interface options presented to the user 
- Access rules for application areas and components

In `Blazor WebAssembly` projects authorization is used only to determine which user interface options will be presented  
A WebAssembly application cannot enforce authorization access rules
