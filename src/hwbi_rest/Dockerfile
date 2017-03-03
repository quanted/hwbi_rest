FROM microsoft/aspnetcore:1.0.1
ARG source
WORKDIR /app
EXPOSE 8888
COPY ${source:-bin/Release/PublishOutput} .
ENTRYPOINT ["dotnet", "hwbi_rest.dll"]
