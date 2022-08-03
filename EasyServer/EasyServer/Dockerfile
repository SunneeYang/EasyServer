FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EasyServer/EasyServer.csproj", "EasyServer/"]
RUN dotnet restore "EasyServer/EasyServer.csproj"
COPY . .
WORKDIR "/src/EasyServer"
RUN dotnet build "EasyServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyServer.dll"]
