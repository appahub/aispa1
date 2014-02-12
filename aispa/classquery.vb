Imports System.Configuration
Imports System.Data.SqlClient

Public Class classquery
    Dim connection As String = ConfigurationSettings.AppSettings("connection")
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim emp_id As Integer
    Public Function selectdataInt(ByVal sql As String) As Integer
        connectDB()
        Dim returnval As Integer = 0
        Try
            cmd = New SqlCommand(sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            reader.Read()
            returnval = reader(0).ToString()
        Catch ex As Exception
            'MsgBox("sql wrong : " + ex.Message.ToString())
            closeDB()
        End Try
        closeDB()
        Return returnval
    End Function
    Public Function selectdatatoarraylist(ByVal sql As String) As ArrayList
        connectDB()
        Dim data As ArrayList = New ArrayList
        Try
            cmd = New SqlCommand(sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim pname As String = reader(0).ToString()
                Dim pbrand As String = reader(1).ToString()
                Dim pcap As String = reader(2).ToString()
                Dim qty As String = reader(3).ToString()
                Dim pid As String = reader(4).ToString()
                Dim dpid As String = reader(5).ToString()
                Dim arr() As String = {pname, pbrand, pcap, qty, pid, dpid}
                data.Add(arr)
            End While
        Catch ex As Exception
            ' MsgBox("sql wrong : " + ex.Message.ToString())
            closeDB()
        End Try
        closeDB()
        Return data
    End Function
    Public Function countdata(ByVal sql As String) As Integer
        connectDB()
        Dim returnval As Integer = 0
        Try
            cmd = New SqlCommand(sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            returnval = reader.HasRows
        Catch ex As Exception
            'MsgBox("sql wrong : " + ex.Message.ToString())
            closeDB()
        End Try
        closeDB()
        Return returnval
    End Function
    Public Function DMLData(ByVal sql As String) As Boolean
        connectDB()
        Dim returnval As Boolean = False
        Try
            cmd = New SqlCommand(sql, con)
            If cmd.ExecuteNonQuery() Then
                returnval = True
            End If
        Catch ex As Exception
            'MsgBox("sql wrong : " + ex.Message.ToString() + " " + sql)
            closeDB()
        End Try
        closeDB()
        Return returnval
    End Function
    Public Function selectDatatoGrid(ByVal sql As String) As DataTable
        Dim returnval As New DataTable
        connectDB()
        Try
            cmd = New SqlCommand(sql, con)
            returnval.Load(cmd.ExecuteReader())
        Catch ex As Exception
            MsgBox("sql wrong : " + ex.Message.ToString() + "/n/n" + sql)
            closeDB()
            returnval = Nothing
            closeDB()
        End Try
        closeDB()
        Return (returnval)
    End Function
    Private Sub connectDB()
        con = New SqlConnection(connection)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Sub
    Private Sub closeDB()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Public Function GetEmpId() As Integer
        Return emp_id
    End Function
    Public Sub SetEmdId(ByVal id As Integer)
        emp_id = id
    End Sub
End Class
