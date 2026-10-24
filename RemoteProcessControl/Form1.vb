Imports System.IO
Imports System.Threading

Public Class Form1

    ' tasklist switch that selects CSV output (format switch F + O, then CSV).
    Private Const TasklistCsvSwitch As String = "/F" & "O CSV"

    ' Runs a console tool with redirected streams and returns its standard output.
    Private Function RunCommand(ByVal fileName As String, ByVal arguments As String) As String
        Dim myProcess As Process = New Process()
        Dim s As String
        myProcess.StartInfo.FileName = fileName
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.Arguments = arguments
        myProcess.StartInfo.RedirectStandardInput = True
        myProcess.StartInfo.RedirectStandardOutput = True
        myProcess.StartInfo.RedirectStandardError = True
        myProcess.Start()
        Dim sIn As StreamWriter = myProcess.StandardInput
        sIn.AutoFlush = True

        Dim sOut As StreamReader = myProcess.StandardOutput
        Dim sErr As StreamReader = myProcess.StandardError
        sIn.Write("dir c:\windows\system32\*.com" & System.Environment.NewLine)
        sIn.Write("exit" & System.Environment.NewLine)
        s = sOut.ReadToEnd()
        If Not myProcess.HasExited Then
            myProcess.Kill()
        End If

        sIn.Close()
        sOut.Close()
        sErr.Close()
        myProcess.Close()
        Return s
    End Function

    ' Adds an entry to the action history list.
    Private Sub AddHistory(ByVal user As String, ByVal pass As String, ByVal target As String, ByVal action As String)
        Dim str(5) As String
        Dim itm As ListViewItem
        str(0) = TextBox1.Text
        str(1) = user
        str(2) = pass
        str(3) = target
        str(4) = action

        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s As String = RunCommand("net.exe", "view /DOMAIN:" + TextBox2.Text)

        Dim news As String()

        news = s.Split("\\")
        TreeView1.Nodes.Clear()

        Dim i As Integer
        For i = 1 To news.Length - 1
            If i = news.Length - 1 Then
                Dim crap() As String
                crap = news(i).Split("The")
                news(i) = crap(0)
            End If
            If news(i).Length < 1 Then
                Continue For
            End If
            news(i) = news(i).Trim()
            TreeView1.Nodes.Add(news(i))
        Next

        TextBox3.Text = TextBox3.Text + "New view completed" + vbNewLine
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tasklist()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ss As String = TreeView3.SelectedNode.Text
        Dim user As String = TextBox4.Text
        Dim pass As String = TextBox5.Text
        Dim s As String = RunCommand("taskkill.exe", "/s " + TextBox1.Text + " /u " + user + " /p " + pass + " /im " + ss)

        AddHistory(user, pass, ss, "kill")
        TextBox3.Text = TextBox3.Text + s + vbNewLine
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox3.Clear()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Public Sub tasklist()
        Dim user As String = TextBox4.Text
        Dim pass As String = TextBox5.Text
        Dim ss As String = TreeView1.SelectedNode.Text
        TextBox1.Text = ss
        Dim s As String = RunCommand("tasklist.exe", "/s " + ss + " /u " + user + " /p " + pass + " " + TasklistCsvSwitch)

        s = s.Replace(vbCrLf, "|")

        TreeView3.Nodes.Clear()

        Dim xxx As Integer
        Dim cock As Array
        Dim news As String = ""

        cock = s.Split("|")

        For xxx = 4 To cock.Length - 2
            Dim shit As Array
            shit = cock(xxx).split(",")
            news = shit(0)
            TreeView3.Nodes.Add(news)
        Next

        AddHistory(user, pass, "", "list")
        TextBox3.Text = TextBox3.Text + "Tasklist completed" + vbNewLine
    End Sub

    Private Sub TasklistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TasklistToolStripMenuItem.Click
        Dim ccc As New System.Threading.Thread(AddressOf tasklist)
        ccc.Start()

    End Sub


End Class
