# ContactsBackendDotnet

## about
ContactsBackendDotnet is part of "contacts" project that is an initiative where we try to explore frontend and backend implementations in order to better understand it cutting-edge features.
ContactsBackendDotnet presents dotnet platform.

## stack
    dotnet 5
    C# 9
    migrations
    sqlite
    xunit

## features


## development instructions

in order to create the database and connect to sqlite
```
dotnet tool install --global dotnet-ef
dotnet ef database update
```

start the dotnet app from your IDE or by cli
```
dotnet run
```

## local build instructions

build a local docker image
```
docker build --tag contacts.backend.dotnet .
```

execute the local docker image
```
docker run -p 5000:80 contacts.backend.dotnet
```


## todo

## highlights

## warnings
