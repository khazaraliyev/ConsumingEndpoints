#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Infrastructure/TaskMediapark.API/TaskMediapark.API.csproj", "Infrastructure/TaskMediapark.API/"]
COPY ["Core/TaskMediapark.Service/TaskMediapark.Service.csproj", "Core/TaskMediapark.Service/"]
COPY ["Core/TaskMediapark.Domain/TaskMediapark.Domain.csproj", "Core/TaskMediapark.Domain/"]
COPY ["Infrastructure/TaskMediapark.Persistence/TaskMediapark.Persistence.csproj", "Infrastructure/TaskMediapark.Persistence/"]
RUN dotnet restore "Infrastructure/TaskMediapark.API/TaskMediapark.API.csproj"
COPY . .
WORKDIR "/src/Infrastructure/TaskMediapark.API"
RUN dotnet build "TaskMediapark.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskMediapark.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskMediapark.API.dll"]