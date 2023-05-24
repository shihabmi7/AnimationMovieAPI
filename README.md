## AnimationMovieAPI
A restful web api with Asp.net core 6 & Entity Framework

To run this you need to create Database name MovieContext & correspondin table as below.

SQL Command to create database & table. 

- Create database MovieContext;

- use  MovieContext;

- CREATE TABLE Movies (Id int, Title varchar(100), Genre VARCHAR(100), ReleaseDate DateTime);

- INSERT INTO Movies VALUES('2','Life is Cool','lIGFEsTYLE','2001/06/02'); // add some rows

- SELECT * From Movies; 

For local database, you need to update your connection strings in appsettings.json like below:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    // this should be your database name & your own db connection string. 
    "MovieContext": "Server=localhost\\SQLEXPRESS;Database=MovieContext;Trusted_Connection=True;Encrypt=False"
  }
}
// For local development, the ASP.NET Core configuration system reads the connection string from the appsettings.json file.```

# See the picture is the output after is runs

![AnimationMovieApi](https://github.com/shihabmi7/AnimationMovieAPI/assets/5005589/66ecda81-41a6-47c7-9d6f-07c4863fd013)
