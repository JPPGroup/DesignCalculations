#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/DesignCalculations.Blazor/DesignCalculations.Blazor.csproj", "src/DesignCalculations.Blazor/"]
COPY ["src/DesignCalculations.Engine/DesignCalculations.Engine.csproj", "src/DesignCalculations.Engine/"]
COPY ["src/DesignCalculations.Calculations/DesignCalculations.Calculations.csproj", "src/DesignCalculations.Calculations/"]
RUN dotnet restore "src/DesignCalculations.Blazor/DesignCalculations.Blazor.csproj"
COPY . .
WORKDIR "/src/src/DesignCalculations.Blazor"
RUN dotnet build "DesignCalculations.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesignCalculations.Blazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesignCalculations.Blazor.dll"]