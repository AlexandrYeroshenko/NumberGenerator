const connection = new signalR.HubConnectionBuilder()
    .withUrl("/NumberGeneratorHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
connection.start().catch(err => console.error(err.toString()));

connection.on("pushInfo", (message) => {
    $("#numberFromSignalR").html(message);
});