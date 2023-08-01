# Web API для бронирования номеров в отеле
## Назначение проектов в решении:
    Entities — все сущности приложения, в том числе модели базы данных и исключений
    Contracts — интерфейсы репозиториев, логгера и прочие общие контракты
    LoggerService — реализация сервиса для логгирования, дающий абстракцию над выбранным пакетом
    Repository — реализация репозиториев, конфигурация сущностей, методы расширения и наследуемый от DbContext контекст
    Service.Contracts — интерфейсы для уровня сервисов
    Service — реализация уровня сервисов
    HotelBooking — основной проект, содержащий Program.cs, методы расширения, логи и MappingProfile
    HotelBooking.Presentation — реализация уровеня представления: контроллеры, а также используемые в них фильтры
    Shared — содержит Data Transfer Objects, а также сущности, отображающие query-параметры в запросе
## Реализованный функционал и интересные фичи:
    Onion-архитектура проекта (разделение на независимые уровни Domain, Service & Presentation layers)
    Аутентификация и авторизация реализованы с помощью Identity и JWT (Access + Refresh)
    Глобальная обработка исключений с помощью кастомного middleware
    Форматирование данных в reponse в соответствии с заголовком Accept. Поддерживаются: JSON, XML, CSV
    Пагинация, фильтрация, поиск и сортировка реализованы с помощью query-параметров
    Кеширование на стороне клиента с помощью ETag и Last-Modified
    Поддерживается Data Shaping. Поддерживаемые сущности: Room
    Поддерживается HATEOAS. Поддерживаемые сущности: Room
    Присутствует Rate Limiting
    Присутствует Swagger-документация
    Соблюдены принципы DRY и KISS
## Запуск проекта:
1. Добавить через командную строку от имени **Администратора** переменную окружения для `JWT Secret`:
   
   ```
   setx SECRET "your_jwt_secret" /M
   ```
3. Провести миграцию (Add-Migration, Update-Database) из основного проекта `HotelBooking`
