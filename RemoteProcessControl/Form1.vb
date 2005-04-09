Imports System.IO
Imports System.Threading

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myProcess As Process = New Process()
        Dim s As String
        myProcess.StartInfo.FileName = "net.exe"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.Arguments = "view /DOMAIN:" + TextBox2.Text
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
        sIn.Close()
        sOut.Close()
        sErr.Close()
        myProcess.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ss As String = TreeView1.SelectedNode.Text
        TextBox1.Text = ss
        Dim user As String = TextBox4.Text
        Dim pass As String = TextBox5.Text
        Dim myProcess As Process = New Process()
        Dim s As String
        myProcess.StartInfo.FileName = "tasklist.exe"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.Arguments = "/s " + ss + " /u " + user + " /p " + pass + " /FO CSV"
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



        Dim str(5) As String
        Dim itm As ListViewItem
        str(0) = TextBox1.Text
        str(1) = user
        str(2) = pass
        str(3) = ""
        str(4) = "list"

        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        TextBox3.Text = TextBox3.Text + "Tasklist completed" + vbNewLine



        sIn.Close()
        sOut.Close()
        sErr.Close()
        myProcess.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ss As String = TreeView3.SelectedNode.Text
        Dim myProcess As Process = New Process()
        Dim user As String = TextBox4.Text
        Dim pass As String = TextBox5.Text
        Dim s As String
        myProcess.StartInfo.FileName = "taskkill.exe"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.Arguments = "/s " + TextBox1.Text + " /u " + user + " /p " + pass + " /im " + ss
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


        Dim str(5) As String
        Dim itm As ListViewItem
        str(0) = TextBox1.Text
        str(1) = user
        str(2) = pass
        str(3) = ss
        str(4) = "kill"

        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        TextBox3.Text = TextBox3.Text + s + vbNewLine


        sIn.Close()
        sOut.Close()
        sErr.Close()
        myProcess.Close()
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
        Dim myProcess As Process = New Process()
        Dim s As String
        myProcess.StartInfo.FileName = "tasklist.exe"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.Arguments = "/s " + ss + " /u " + user + " /p " + pass + " /FO CSV"
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



        Dim str(5) As String
        Dim itm As ListViewItem
        str(0) = TextBox1.Text
        str(1) = user
        str(2) = pass
        str(3) = ""
        str(4) = "list"

        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        TextBox3.Text = TextBox3.Text + "Tasklist completed" + vbNewLine



        sIn.Close()
        sOut.Close()
        sErr.Close()
        myProcess.Close()
    End Sub

    Private Sub TasklistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TasklistToolStripMenuItem.Click
        Dim ccc As New System.Threading.Thread(AddressOf tasklist)
        ccc.Start()

    End Sub


End Class
