<template>
    <div id="divMessages" class="messages">
    </div>
    <div class="input-zone">
        <label id="lblMessage" for="tbMessage">Message:</label>
        <input id="tbMessage" class="input-zone-input" type="text" />
        <button id="btnSend">Send</button>
    </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import * as signalR from "@microsoft/signalr";

const divMessages: any = document.querySelector("#divMessages");
const tbMessage: any = document.querySelector("#tbMessage");
const btnSend: any = document.querySelector("#btnSend");
const username = new Date().getTime();

const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:8090/Chat")
    .build();
connection.on("messageReceived", (username: string, message: string) => {
    let messages = document.createElement("div");
    messages.innerHTML =
        `<div class="message-author">${username}</div><div>${message}</div>`;
    divMessages.appendChild(messages);
    divMessages.scrollTop = divMessages.scrollHeight;
});
connection.start().catch((err: any) => document.write(err));
tbMessage.addEventListener("keyup", (e: KeyboardEvent) => {
    if (e.key === "Enter") {
        send();
    }
});
btnSend.addEventListener("click", send);
function send() {
    connection.send("newMessage", username, tbMessage.value)
        .then(() => tbMessage.value = "");
}

export default {
    methods: {
        send() {
            connection.send("newMessage", username, tbMessage.value)
                .then(() => tbMessage.value = "");
        }
    }
}


</script>