# Napoleon IT: Android course 

## Способы запуска тестового задания Notes API

1. Просто нажав `F5` в VS Code
2. Через консоль `dotnet run --project NapoleonNotes/NapoleonNotes.csproj`
3. С помощью Docker `docker build -t napoleon .` и `docker run -d --rm -p 8080:8080 napoleon`

**Во всех способах адрес http://localhost:8080/**

---

- _Первые 2 способа требуют установленного .NET Core Runtime (download [here](https://dotnet.microsoft.com/download))_
- _[На случай если вдруг не получается получить доступ к Docker контейнеру](https://docs.docker.com/network/bridge/#enable-forwarding-from-docker-containers-to-the-outside-world)_