FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Airelax/Airelax.csproj", "Airelax/"]
RUN dotnet restore "Airelax/Airelax.csproj"
COPY . .
WORKDIR "/src/Airelax"
RUN dotnet build "Airelax.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Airelax.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Airelax.dll"]
