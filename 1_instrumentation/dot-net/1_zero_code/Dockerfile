FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /src
EXPOSE 8080

# Copy project file and restore as distinct layers
COPY src/*.csproj .
RUN dotnet restore

# Copy source code and publish app
COPY src/. .
RUN dotnet build

CMD ["dotnet", "run"]