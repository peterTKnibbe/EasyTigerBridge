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
            Console.WriteLine("Found Bridge Configuration File at " & configPath)
            Dim configLines As String = IO.File.ReadAllText(configPath)
            Dim iniInd As Integer = configLines.IndexOf("iniPath=") + "iniPath=".Length
            Dim nlInd As Integer = configLines.IndexOf(vbNewLine)
            iniPath = configLines.Substring(iniInd, nlInd - iniInd)
            Dim part2 As String = configLines.Substring(configLines.IndexOf("TigerViewPath="))
            Dim pathInd As Integer = "TigerViewPath=".Length
            nlInd = part2.IndexOf(vbNewLine)
            tigerPath = part2.Substring(pathInd, nlInd - pathInd)
            Console.WriteLine("Set ini file path = " & iniPath)
            Console.WriteLine("Set Tiger1 executable path = " & tigerPath)
        Else
            Console.WriteLine("Did not find bridge configuration file at " & configPath)
            Console.WriteLine("Press Enter to Exit.")
            Console.ReadLine()
            Exit Sub
        End If

        If IO.File.Exists(iniPath) Then IO.File.Delete(iniPath)
        Try
            IO.File.WriteAllText(iniPath, iniLines)
        Catch ex As Exception
            Console.WriteLine("Exception in attempt to write ini file: " & ex.Message)
            Console.WriteLine("Press Enter to Exit.")
            Console.ReadLine()
        End Try

        Dim iniExists As Boolean = IO.File.Exists(iniPath)
        Dim exeExists As Boolean = IO.File.Exists(iniPath) AndAlso IO.File.Exists(tigerPath)
        If Not iniExists Then
            Console.WriteLine("ini file not found at " & iniPath & ".")
        ElseIf Not exeExists Then
            Console.WriteLine("exe file not found at " & tigerPath & ".")
        Else
            Console.WriteLine("ini and exe files both found. Proceeding.")
            Dim si As New ProcessStartInfo
            si.FileName = tigerPath
            si.Arguments = "Slave"
            Try
                Process.Start(si)
                Console.WriteLine("Started process at tigerPath.")
            Catch ex As Exception
                Console.WriteLine("Exception at start process: " & ex.Message)
            End Try
        End If

        Console.WriteLine("Press Enter to Exit.")
        Console.ReadLine()

    End Sub

End Module
