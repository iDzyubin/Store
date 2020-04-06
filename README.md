# Инструкция по запуску

## Предварительная установка SDK

1. .NET Core 3.1. Необходимо установить ASP.NET Core Runtime 3.1.3 с официального сайта (https://dotnet.microsoft.com/download/dotnet-core/3.1)
2. PostgreSQL. Поскольку в качестве базы данных используется PostgreSQL, требуется установить последнюю версию с официального сайта(https://www.postgresql.org/download/windows/)

## Последующие действия

После того, как SDK были установлены, требуется 
1. В инструменте PgAdmin создать пользователя postgres с паролем password.
2. Добавить базу данных store_db.
3. Требуется зайти в папку с проектом и выполнить следующую команду из командной строки / powershell
```
dotnet publish .\Store.sln -c Release -o ".\Store"
```
После этого будет осуществлена сборка проекта

## Использование
Как и любое приложение, проект следует запустить перед использованием. 

Для этого следует перейти в каталог Store и запустить приложение Store.Web.

После чего проект будет развернут на порту 5000 для http и 5001 для https(в приоритете)

Можно пользоваться!
