const connection=(new signalR.HubConnectionBuilder).withUrl("/NumberGeneratorHub").configureLogging(signalR.LogLevel.Information).build();connection.start().catch(n=>console.error(n.toString())),connection.on("pushInfo",n=>{$("#numberFromSignalR").html(n)});