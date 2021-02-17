Module Module1
    Private iniPath As String = "C:\Windows\tiger1.ini"
    Private configPath As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "Bridge.config")
    Private tigerPath As String = "C:\TigerView8\Tiger1.exe"

    Sub Main()
        Dim argCount As Integer = 0
        Dim iniLines As String = "[Slave]" & vbNewLine & "PatientID="
        If My.Application.CommandLineArgs.Count < 2 Then
            Console.WriteLine("Enter patient ID")
            Dim patID As String = Console.ReadLine
            iniLines &= patID & vbNewLine
            Console.WriteLine("Enter patient First Name")
            Dim fName As String = Console.ReadLine
            iniLines &= "FirstName=" & fName & vbNewLine
            Console.WriteLine("Enter patient Last Name")
            Dim lName As String = Console.ReadLine
            iniLines &= "LastName=" & lName & vbNewLine
            Console.WriteLine("Enter patient Middle Initial")
            Dim mInit As String = Console.ReadLine
            iniLines &= "MiddleName=" & mInit & vbNewLine
            Console.WriteLine("Enter patient DOB")
            Dim dob As String = Console.ReadLine
            If dob.Length > 5 Then iniLines &= "DOB=" & dob & vbNewLine
        Else
            For Each arg As String In My.Application.CommandLineArgs
                Console.WriteLine("Found argument " & arg)
                If argCount < 1 Then
                    If arg.Equals("Bridge") Then
                        Continue For
                    ElseIf arg.Equals("Slave") Then
                        'Skip this one, but increment argCount
                    End If
                ElseIf argCount < 2 Then
                    iniLines &= arg & vbNewLine
                ElseIf argCount < 3 Then
                    iniLines &= "FirstName=" & arg & vbNewLine
                ElseIf argCount < 4 Then
                    iniLines &= "LastName=" & arg & vbNewLine
                Else
                    If arg.Length > 2 Then
                        iniLines &= "DOB=" & arg & vbNewLine
                    Else
                        iniLines &= "MiddleName=" & arg & vbNewLine
                    End If
                End If
                argCount += 1
            Next
        End If

        If IO.File.Exists(configPath) Then
            Dim configLines As String = IO.File.ReadAllText(configPath)
            Dim iniInd As Integer = configLines.IndexOf("iniPath=") + "iniPath=".Length
            Dim nlInd As Integer = configLines.IndexOf(vbNewLine)
            iniPath = configLines.Substring(iniInd, nlInd - iniInd)
            Dim part2 As String = configLines.Substring(configLines.IndexOf("TigerViewPath="))
            Dim pathInd As Integer = "TigerViewPath=".Length
            nlInd = part2.IndexOf(vbNewLine)
            tigerPath = part2.Substring(pathInd, nlInd - pathInd)
        End If

        If IO.File.Exists(iniPath) Then IO.File.Delete(iniPath)
        IO.File.WriteAllText(iniPath, iniLines)

        Dim si As New ProcessStartInfo
        si.FileName = tigerPath
        si.Arguments = "Slave"
        Process.Start(si)

    End Sub

End Module
