package io.ubsub.example;

import io.socket.client.IO;
import io.socket.client.Socket;

public class Main {
    private static final String USER_ID = "HypW9sEVE";
    private static final String USER_KEY = "463e501e5f66b72987d13770406b7b3f8e11f98f0add9ff1";
    private static final String TOPIC_ID = "rkxsfcsVN4";

    public static void main(String[] args) throws Throwable {
        String url = String.format("https://socket.ubsub.io/socket?userId=%s&userKey=%s&topicId=%s", USER_ID, USER_KEY, TOPIC_ID);

        Socket sock = IO.socket(url);
        sock.on(Socket.EVENT_CONNECT, (x) -> {
            System.out.println("Connected!");
        });
        sock.on("event", x -> {
            System.out.println(x.toString());
        });
        sock.connect();
    }
}
