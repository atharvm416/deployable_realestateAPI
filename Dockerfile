# Use the official .NET SDK image to build your application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file first (if needed, good practice for multi-project solutions)
COPY "RealEstateAPI.sln" "./"

# Copy the project file and restore dependencies.
# Note the path: "RealEstateAPI/RealEstateAPI.csproj"
COPY ["RealEstateAPI/RealEstateAPI.csproj", "RealEstateAPI/"]
RUN dotnet restore "RealEstateAPI/RealEstateAPI.csproj"

# Copy the rest of the source code
# This copies everything from the Git repository's root
COPY . .

# Go into the project directory to build and publish
WORKDIR "/src/RealEstateAPI"
RUN dotnet build "RealEstateAPI.csproj" -c Release -o /app/build

# Publish the application for runtime
FROM build AS publish
RUN dotnet publish "RealEstateAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET ASP.NET runtime image to run your application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Expose the port Kestrel listens on. Render typically injects a PORT env var.
# Your application should be configured to listen on http://0.0.0.0:$PORT
EXPOSE 8080 # This is a common default. If your Kestrel is on 80, use 80.

# Copy the published output from the 'publish' stage
COPY --from=publish /app/publish .

# Define the entry point for your application
ENTRYPOINT ["dotnet", "RealEstateAPI.dll"]