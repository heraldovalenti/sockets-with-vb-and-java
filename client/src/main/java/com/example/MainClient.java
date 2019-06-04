package com.example;

import java.util.Scanner;

public class MainClient {

    public static void main(String args[]) {
        String host = "127.0.0.1";
        Integer port = 1371;
        if (args.length == 2) {
            host = args[0];
            port = Integer.parseInt( args[1] );
        }
        Client client = null;
        String input = "";
        Scanner scanner = new Scanner(System.in);
        do {
            System.out.println("Client menu:");
            System.out.println("  1. Read message from server");
            System.out.println("  2. Send message to server (Chau)");
            System.out.println("  3. Exit program");
            input = scanner.nextLine();

            switch (input) {
                case "1":
                    client = new Client(host, port);
                    client.readMessage();
                    break;
                case "2":
                    client = new Client(host, port);
                    client.sendMessage("Chau");
                    break;
                case "3":
                    System.out.println("Exiting...");
                    break;
                default:
                    System.out.println("Invalid option.");
            }
        }
        while (!"3".equals( input ));
    }

}
