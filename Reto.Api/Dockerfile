#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Reto.Api/Reto.Api.csproj", "Reto.Api/"]
COPY ["Reto.Infraestructura/Reto.Infraestructura.csproj", "Reto.Infraestructura/"]
COPY ["Reto.Dto/Reto.Dto.csproj", "Reto.Dto/"]
COPY ["Reto.Persistencia/Reto.Persistencia.csproj", "Reto.Persistencia/"]
COPY ["Reto.SeedWork/Reto.SeedWork.csproj", "Reto.SeedWork/"]
COPY ["Reto.Entidades/Reto.Entidades.csproj", "Reto.Entidades/"]
RUN dotnet restore "Reto.Api/Reto.Api.csproj"
COPY . .
WORKDIR "/src/Reto.Api"
RUN dotnet build "Reto.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reto.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reto.Api.dll"]