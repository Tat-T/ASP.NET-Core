# Указываем базовый образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Копируем файлы проекта и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все файлы и собираем проект
COPY . ./
RUN dotnet publish "AnimalApp.csproj" -c Release -o out

# Указываем базовый образ .NET Runtime для выполнения приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Указываем команду для запуска приложения
ENTRYPOINT ["dotnet", "AnimalApp.dll"]
