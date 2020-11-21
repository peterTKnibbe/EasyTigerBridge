Public Class Form1
    Private Sub ButtonBrowseEZ_Click(sender As Object, e As EventArgs) Handles ButtonBrowseEZ.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then Me.TextBoxEZ.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub ButtonBrowseTV_Click(sender As Object, e As EventArgs) Handles ButtonBrowseTV.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then Me.TextBoxTV.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub ButtonConfigure_Click(sender As Object, e As EventArgs) Handles ButtonConfigure.Click
        If Not IO.Directory.Exists(Me.TextBoxEZ.Text) Then MsgBox($"Unable to find EZDental directory {Me.TextBoxEZ.Text}")
        If Not IO.Directory.Exists(Me.TextBoxTV.Text) Then MsgBox($"Unable to find TigerView directory {Me.TextBoxTV.Text}")
        If Me.TextBoxBridgeName.Text.Length < 1 Then MsgBox("Please give the bridge a name like 'TigerLink'.")
        Dim dllDest = IO.Path.Combine(Me.TextBoxEZ.Text, Me.TextBoxBridgeName.Text.Trim() & ".dll")
        If IO.File.Exists(dllDest) Then IO.File.Delete(dllDest)
        IO.File.Copy("EasyDentalBridgeDll.dll", dllDest)
        Dim iniPath = IO.Path.Combine(Me.TextBoxEZ.Text, "easyLink.ini")
        Dim currentText = If(IO.File.Exists(iniPath), IO.File.ReadAllText(iniPath), String.Empty)
        Dim newText As String = String.Empty
        If currentText.Length < 1 Then
            newText = "[General]" & vbNewLine &
                          "Orientation=0" & vbNewLine &
                          "XPosition=1773" & vbNewLine &
                          "YPosition=0" & vbNewLine &
                          "DisplayStyle=2" & vbNewLine &
                          "AlwaysOnTop=0" & vbNewLine &
                          "HideToolTip=0" & vbNewLine &
                          "ShowDescriptions=0" & vbNewLine &
                          "HideSplash=0" & vbNewLine &
                          "SmallIcons=0" & vbNewLine &
                          "MaxToolsShowing=10" & vbNewLine &
                          "TopTool=0"
        ElseIf currentText.IndexOf("[TigerLink]") < 1 Then
            newText = currentText
        Else
            newText = currentText.Substring(0, currentText.IndexOf("[TigerLink]"))
        End If
        If Not newText.Last.Equals(vbNewLine) Then newText &= vbNewLine

        newText &= "[TigerLink]" & vbNewLine &
                        "Description = Link to TigerView Application" & vbNewLine &
                        "Installed Link Version=12" & vbNewLine &
                        $"ExeFile = {IO.Path.Combine(Me.TextBoxTV.Text, "Tiger1.exe")}" & vbNewLine &
                        "WorkDir =" & vbNewLine &
                        $"KeyFile = {Me.TextBoxBridgeName.Text.Trim()}.dll" & vbNewLine &
                        "IconIndex = 0" & vbNewLine &
                        "DisplayOrder = 0" & vbNewLine &
                        "DisplayStyle = 0" & vbNewLine

        IO.File.Move(iniPath, iniPath & ".orig")
        IO.File.AppendAllText(iniPath, newText)
        Me.Label4.Text = "Configuration complete."
    End Sub
End Class
