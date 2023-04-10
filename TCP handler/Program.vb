Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module Program
    Public IP As String = ""
    Public Port As Integer = 0
    Sub Main(args As String())

    End Sub
    Public Sub WriteData(message As String)
        Dim data As String = message
        Dim client As TcpClient = New TcpClient()
        client.Connect(New IPEndPoint(IPAddress.Parse(IP), Port))
        Dim stream As NetworkStream = client.GetStream()
        Dim sendBytes As Byte() = Encoding.ASCII.GetBytes(data)
        stream.Write(sendBytes, 0, sendBytes.Length)
    End Sub


    Public Function readData() As String
        Dim localAdress As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim port As Integer = 62918
        Dim server As New TcpListener(localAdress, port)
        server.Start()
        Dim client As TcpClient = server.AcceptTcpClient()
        Dim requesterIP As String = client.Client.RemoteEndPoint.ToString().Split(New Char() {":"})(0)
        Dim data As String
        Dim bytes(256) As Byte
        Dim stream As NetworkStream = client.GetStream
        stream.Read(bytes, 0, bytes.Length)
        data = Encoding.ASCII.GetString(bytes, 0, 256)
        client.Close()
        server.Stop()
        Return data
    End Function
End Module
