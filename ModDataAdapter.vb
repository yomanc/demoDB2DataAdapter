Imports System.IO
Imports System.Net
Imports System.Data
Imports IBM.Data.DB2
Module Module1

    Sub Main()
        Dim connStr As String = "Server=" & "1.2.3.4" & ":" & "55555" & ";Database=" & "DEMODB" & ";UID=" & "Sun" & ";PWD=" & "shayz"
        Dim db2conn = New DB2Connection(connStr)

        CreateDataAdapter(db2conn)

        Console.ReadKey()
    End Sub

    Public Sub CreateDataAdapter(ByVal db2Connection As DB2Connection)
        Dim db2Command As DB2Command = New DB2Command("SELECT Namelist FROM AAA.BBBBBBB", db2Connection)
        Dim myAdapter As DB2DataAdapter = New DB2DataAdapter(db2Command)

        myAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim myDataSet As DataSet = New DataSet
        myAdapter.Fill(myDataSet, "Namelist")
        Dim myTable As DataTable
        Dim myRow As DataRow
        Dim myColumn As DataColumn

        Dim cnt As Integer = 1
        ' Get all data from all tables within the dataset
        For Each myTable In myDataSet.Tables
            For Each myRow In myTable.Rows
                For Each myColumn In myTable.Columns
                    Console.Write("#" & cnt & " " & myRow(myColumn) & Chr(9))
                    cnt += 1
                Next myColumn
                Console.WriteLine()
            Next myRow
            Console.WriteLine()
        Next myTable
    End Sub

End Module
