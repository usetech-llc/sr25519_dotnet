FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base
WORKDIR /src

COPY ["./Schnorrkel/", "Schnorrkel/"]
RUN dotnet restore Schnorrkel/Schnorrkel.csproj
COPY . .

COPY ["./sr25519_tests/", "sr25519_tests/"]
RUN dotnet restore sr25519_tests/sr25519_tests.csproj
COPY . .

WORKDIR "/src/Schnorrkel"
RUN dotnet build "Schnorrkel.csproj" -c Release -o /app

WORKDIR "/src/Schnorrkel"