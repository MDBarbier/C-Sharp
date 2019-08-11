FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["dockerdemos/dockerdemos.csproj", "dockerdemos/"]
RUN dotnet restore "dockerdemos/dockerdemos.csproj"
COPY . .
WORKDIR "/src/dockerdemos"
RUN dotnet build "dockerdemos.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dockerdemos.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dockerdemos.dll"]