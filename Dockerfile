FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["NapoleonNotes/NapoleonNotes.csproj", "NapoleonNotes/"]
RUN dotnet restore "NapoleonNotes/NapoleonNotes.csproj"
COPY . .
WORKDIR "/src/NapoleonNotes"
RUN dotnet build "NapoleonNotes.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NapoleonNotes.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NapoleonNotes.dll"]
