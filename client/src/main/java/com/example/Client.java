package com.example;

import java.io.*;
import java.net.InetSocketAddress;
import java.net.Socket;

public class Client {

    private String host;
    private int port;

    public Client(String host, int port) {
        this.host = host;
        this.port = port;
    }

    public void sendMessage(String message) {
        try {
            Socket socket = new Socket(host,port);
            OutputStream os = socket.getOutputStream();
            PrintWriter  pw = new PrintWriter(os);

            pw.write(message);
            System.out.println("Message sent: " + message);

            pw.close();
            os.close();
            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void readMessage() {
        try {
            Socket socket = new Socket(host,port);
            InputStream is = socket.getInputStream();
            InputStreamReader isr = new InputStreamReader(is);
            BufferedReader br = new BufferedReader(isr);

            String messageReceived = br.readLine();
            System.out.println("Message read: " + messageReceived);

            br.close();
            isr.close();
            is.close();
            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
