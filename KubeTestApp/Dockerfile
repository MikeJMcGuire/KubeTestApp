FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["KubeTestApp/KubeTestApp/KubeTestApp.csproj", "KubeTestApp/KubeTestApp/"]
RUN dotnet restore "KubeTestApp/KubeTestApp/KubeTestApp.csproj"
COPY . .
WORKDIR "/src/KubeTestApp/KubeTestApp"
RUN dotnet build "KubeTestApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubeTestApp.csproj" -c Release -o /app/publish

FROM base AS final

RUN addgroup --system --gid 1000 dotnet && adduser --system --uid 1000 --ingroup dotnet --shell /bin/sh dotnet

WORKDIR /app
COPY --from=publish /app/publish .

USER 1000
ENTRYPOINT ["dotnet", "KubeTestApp.dll"]