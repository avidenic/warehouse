# NiceLabel solution

## Server
As per requirements, I've created a server side application which has a default page that displays customer data. Data is updated through websocket. The app is able to authenticate a user ("Name0" to "Name9" with matching passwords - Password0 to Password9) and exposes one endpoint through which user product quantity can be increased. User must be authenticated to use the endpoint.
The server side application is written using ASP.NET Core 3.

## Client
Client application is a windows desktop application written using the new WPF in .Net Core 3. First page is a login page, where user credentials must be entered. After that user is navigated to second page, which has a form for increasing product quantity.

## Difference between this solution and requirements
* Client side is created WPF, but .Net Core 3 is used to test viability of the framework
* Server side is using ASP.NET Core 3 instead of ASP.NET MVC. The first idea was to test viability of the gRPC protocol, but as I found out, there are too many bugs with it. So I opted for communication via REST.
* Some shortcuts were taken and application was not implemented entirely using proper standards and code practices as I was pressed for time
* Password are hashed using simple unsalted SHA256 hash, but in real world hash would be salted. They are not obfuscated on client side as communication is expected to be done over HTTPS in real world as opposed via HTTP for developing purposes
* Sadly no time for unit tests, except one - to show general familiarization with the concept
* No time for nicer look & feel =(

## How to run the app
First, clone the repository. Make sure you have installed Visual Studio 2019 - Preview version. Community edition will do. Check both dekstop development and web development when installing. Open terminal/command line tool in root folder of this repository and check dotnet SDK version by typing: "dotnet --version". It should be "3.0.100-preview9-014004". If it is not, install it from preview channel: https://dotnet.microsoft.com/download/dotnet-core/3.0

After all the checks, open the solution. Right click on the server application project, select properties and go to "Debug" section. Add new environment variable called "ASPNETCORE_ENVIRONMENT" with value "Development". Save the file.

A new folder called "Properties" should've been created, containing a file called "launchSettings.json";

After that you can start debugging by pressing F5, both server and client should be started.
