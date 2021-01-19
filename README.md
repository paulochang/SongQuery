# SongQuery
A simple Genius REST API Client.

This program will retrieve all the songs for an artist using the Genius REST API. 


## How to run and build
To build this app, first set the Genius REST API key in the SongProvider class 
https://github.com/paulochang/SongQuery/blob/master/InfoProvider/SongProvider.cs#L11

For more information on how to obtain a key, visit https://docs.genius.com/#/getting-started-h1

Afterwards,
To run this app, you have various alternatives:

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

## Using the program
The use the program simply follow the instructions on screen.
The program will then ask you to input an artist name, query it and if possible, it will return the list of songs matching that artist.
