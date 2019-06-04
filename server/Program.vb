Imports System

Module Program
    Dim Servidor as Servidor = New Servidor("127.0.0.1", 1371)

    Sub Main(args As String())
        Dim Input
        Dim ShouldExit
        Do
            Console.WriteLine("Server menu:")
            Console.WriteLine("  1) Start the server")
            Console.WriteLine("  2) Stop the server")
            Console.WriteLine("  3) Send message to client (with vbCrLf)")
            Console.WriteLine("  4) Send message to client (without vbCrLf)")
            Console.WriteLine("  5) Print server status")
            Console.WriteLine("  6) Exit program")
            Console.Write("Enter an option: ")
            Input = Console.ReadLine()
            ShouldExit = ProcessInput(Input)
        Loop Until ShouldExit
    End Sub

    Function ProcessInput(ByVal Input As String)
        Select Case input
            Case "1"
                Servidor.StartServer()
            Case "2"
                Servidor.StopServer()
            Case "3"
                Servidor.SendMessage("Alojaa" & vbCrLf)
            Case "4"
                Servidor.SendMessage("Alojaa")
            Case "5"
                If Servidor.IsRunning() Then
                    Console.WriteLine("Server is running")
                Else
                    Console.WriteLine("Server is stopped")
                End If
            Case "6"
                Servidor.StopServer()
                Console.WriteLine("Exiting...")
                Return True
            Case Else
                Console.WriteLine("Invalid option.")
        End Select
        Return False
    End Function
End Module