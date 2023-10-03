import * as signalR from "@microsoft/signalr";

class ChatService {
  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7055/CShatHub") // Replace with your SignalR hub URL
      .build();

    this.hubConnection.start().catch((err) => console.error(err));
  }

  onReceiveMessage(callback) {
    this.hubConnection.on("ReceiveMessage", callback);
  }

  sendMessage(user, message) {
    this.hubConnection.invoke("SendMessage", user, message).catch((err) => console.error(err));
  }

}

const chatService = new ChatService();
export default chatService;