FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
COPY ["airelax/bin/Release/net5.0/publish/", "app/"]
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "airelax.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY [".", "./"]
#RUN dotnet restore 
#COPY . .
#WORKDIR /src
#RUN dotnet build -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENV ASPNETCORE_URLS http://*:5000
#ENTRYPOINT ["dotnet", "ci-cd-test.dll"]
