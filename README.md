# WebForums/ASP.NET-Core

This branch hosts the ASP.NET Core version of the forum software.

## Technologies
The technologies planned for use in this branch include:
  * ASP.NET Core (duh)
  * Blazor

## Concept
The server should act provide a REST API for React to use in order to view and manipulate forums, threads and comments.

The server should also provide proper user authentication, as well as an administrative section for managing the forums themselves.

## Migration from React to Blazor
Originally, this branch was supposed to use ASP.NET Core/React. However, I finally read the docs for Blazor and thought that it would be the better option to use with ASP.NET Core. It offers a lot of the functionality that React does (Components and Routing) and I can use it in a SPA format.