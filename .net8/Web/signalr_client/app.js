const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://172.16.200.31:5250/chatHub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    }) // 替换为你的 SignalR 服务 URL
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

// 定义接收消息的处理程序
connection.on("ReceiveMessage", (user, message) => {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(li);
});

// 启动连接
start();

// 发送消息
document.getElementById("sendButton").addEventListener("click", async (event) => {
    const user = "User"; // 可以替换为实际用户名
    const message = document.getElementById("messageInput").value;
    try {
        await connection.invoke("SendMessage", user, message);
    } catch (err) {
        console.error(err);
    }
    event.preventDefault();
});