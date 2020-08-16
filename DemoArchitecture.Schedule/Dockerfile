#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DemoArchitecture.Schedule/DemoArchitecture.Schedule.csproj", "DemoArchitecture.Schedule/"]
RUN dotnet restore "DemoArchitecture.Schedule/DemoArchitecture.Schedule.csproj"
COPY . .
WORKDIR "/src/DemoArchitecture.Schedule"
RUN dotnet build "DemoArchitecture.Schedule.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoArchitecture.Schedule.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoArchitecture.Schedule.dll"]