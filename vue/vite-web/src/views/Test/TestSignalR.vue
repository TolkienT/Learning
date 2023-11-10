<template>
    <div id="divMessages" class="messages">
    </div>

</template>

<script lang="ts" setup>
import * as signalR from "@microsoft/signalr";

const connection = new signalR.HubConnectionBuilder()
    // .withUrl("http://localhost:8090//signalr/messageHub")
    .withUrl(`/signalr/messageHub`)
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.on("/TestSignalR",function(res:any){
    console.log(res)
})
try {
    await connection.start().catch((err: any) => document.write(err));
    console.log("SignalR Connected.");
  } catch (err) {
    console.error(err);
    // setTimeout(start, 1000);
  }
// connection.start().catch((err: any) => document.write(err));

</script>