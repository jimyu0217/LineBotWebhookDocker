# 使用官方的 .NET SDK 映像作為基礎映像
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# 使用 .NET SDK 映像來編譯應用
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LineBotWebhook/LineBotWebhook.csproj", "LineBotWebhook/"]
RUN dotnet restore "LineBotWebhook/LineBotWebhook.csproj"
COPY . .
WORKDIR "/src/LineBotWebhook"
RUN dotnet build "LineBotWebhook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LineBotWebhook.csproj" -c Release -o /app/publish

# 最終階段：運行應用
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LineBotWebhook.dll"]