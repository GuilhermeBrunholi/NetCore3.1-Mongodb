FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
# Copy everything and build
COPY . ./
RUN dotnet restore "./TesteApi.csproj"
RUN dotnet publish "TesteApi.csproj" -c Release -o out
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TesteApi.dll"]