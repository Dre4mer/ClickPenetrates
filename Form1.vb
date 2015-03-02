Imports System.Runtime.InteropServices
Imports WindowsApplication2.User32Wrappers

Public Class Form1

    Private _InitialStyle As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        _InitialStyle = GetWindowLong(Me.Handle, GWL.ExStyle)
        SetFormToTransparent()

        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.Black

        Me.TopMost = True

    End Sub

    Private Sub SetFormToTransparent()
        SetWindowLong(Me.Handle, GWL.ExStyle, _InitialStyle Or WS_EX.Layered Or WS_EX.Transparent)
        SetLayeredWindowAttributes(Me.Handle, 0, 255 * 0.7, LWA.Alpha)
    End Sub

    Private Sub SetFormToOpaque()
        SetWindowLong(Me.Handle, GWL.ExStyle, _InitialStyle Or WS_EX.Layered)
        SetLayeredWindowAttributes(Me.Handle, 0, 255, LWA.Alpha)
    End Sub
End Class

Public Class User32Wrappers
    Public Enum GWL As Integer
        ExStyle = -20
    End Enum

    Public Enum WS_EX As Integer
        Transparent = &H20
        Layered = &H80000
    End Enum

    Public Enum LWA As Integer
        ColorKey = &H1
        Alpha = &H2 'Window alpha
    End Enum

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")> _
    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As GWL) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")> _
    Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As GWL, ByVal dwNewLong As WS_EX) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetLayeredWindowAttributes")> _
    Public Shared Function SetLayeredWindowAttributes(ByVal hWnd As IntPtr, ByVal crKey As Integer, ByVal alpha As Byte, ByVal dwFlags As LWA) As Boolean
    End Function
End Class
