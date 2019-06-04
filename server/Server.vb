Imports System.Net.Sockets
Imports System.Text

Public Class Servidor

    Dim Host As String
    Dim Port As Integer
    Dim ServerRunning As Boolean
    Dim ServerListener As TcpListener
    Dim ClientConnection As TcpClient
    
    Public Sub New(ByVal ServerHost As String, ByVal ServerPort As Integer)
        Host = ServerHost
        Port = ServerPort
        ServerRunning = False
    End Sub
    
    Public Sub Rutina()
        Try
            Do
                If ServerListener.Pending = True Then
                    ClientConnection = ServerListener.AcceptTcpClient()
                End If
                If Not( ClientConnection Is Nothing ) Then
                    If ClientConnection.Available > 0 Then
                        Dim databytes(1000) As Byte
                        Dim decode As New ASCIIEncoding
                        ClientConnection.Client.Receive(databytes)
                        ' txtRecibido.Text += vbCrLf & "Cliente Android: " & decode.GetString(databytes)
                        Console.WriteLine(vbCrLf & "Client message: " & decode.GetString(databytes))
                    End If
                End If
            Loop Until Not ServerRunning
            
            Console.Write("Stopping server...")
            ServerListener.Stop()
            Console.WriteLine("Server stopped")
        Catch ex As Exception
            Console.WriteLine("Exception while running server: " & ex.Message)
        End Try
    End Sub

    Public Sub StartServer()
        If ServerRunning Then
            Return
        End If
        Try
            ServerRunning = True
            Console.Write("Starting server...")
            ServerListener = New TcpListener(System.Net.IPAddress.Parse(Host), Port)
            ServerListener.Start()
            Dim ServerThread = New Threading.Thread(AddressOf Rutina)
            ServerThread.Start()
            Console.WriteLine("Server started")
        Catch ex As Exception
            Console.WriteLine("Exception starting server: " & ex.Message)
        End Try
    End Sub

    Public Sub StopServer()
        ServerRunning = False
    End Sub

    Public Function IsRunning()
        Return ServerRunning
    End Function

    Public Sub SendMessage(ByVal Message As String)
        Try
            Dim decode As New ASCIIEncoding
            ClientConnection.Client.Send(decode.GetBytes(Message))
        Catch ex As Exception
            Console.WriteLine("Exception sending message to client: " & ex.Message)
        End Try
    End Sub

End Class