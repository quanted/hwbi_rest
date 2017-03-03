FROM microsoft/aspnetcore:1.1.0
WORKDIR /app
<<<<<<< HEAD
EXPOSE 8888
COPY ${source:-bin/Release/PublishOutput} .
=======
EXPOSE 80
COPY . .
>>>>>>> b2a2ae678d5d3020b7282a523b284b9ad08a2e30
ENTRYPOINT ["dotnet", "hwbi_rest.dll"]
