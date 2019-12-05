"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/kek").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, date) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg + " " + date;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("UserName").value;
    var message = document.getElementById("messageInput").value;
    var id = document.getElementById("id").value;
    connection.invoke("SendMessage", user, message, id).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});