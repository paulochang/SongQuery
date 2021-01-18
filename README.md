# SongQuery
A simple Genius REST API C.ient


## How to run and build
To run this app, you have several alternatives

### Using docker-compose 
From the root, run the following command

```
docker-compose run songquerygui sh
 ```

### Manually building with dotnet

#### Prerequisites
- [The .NET 5.0 SDK or later](https://dotnet.microsoft.com/download)

#### Building and running
From the root, run the following command in the Terminal

```
 dotnet run --configuration Release --project SongQuery/SongQueryGui.csproj  
 ```
