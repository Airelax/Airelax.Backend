#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#COPY ["airelax/bin/Release/net5.0/publish/", "/app/publish"]
#WORKDIR /app
#ENV ASPNETCORE_URLS http://*:5000
#ENTRYPOINT ["dotnet", "airelax.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY [".", "./"]
RUN dotnet restore 

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# build Vue app
FROM node:alpine as buildvue

# RUN apk --no-cache --virtual build-dependencies add python2 make g++

WORKDIR /src
COPY Airelax.Frontend/package.json .

RUN npm install

# webpack build
COPY Airelax.Frontend .
RUN npm run build

# RUN apk del build-dependencies

FROM base AS final
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT Develop
ENV ASPNETCORE_URLS http://*:5000

COPY --from=publish /app/publish .
COPY --from=buildvue /src/dist /app/wwwroot

ENTRYPOINT ["dotnet", "Airelax.dll"]