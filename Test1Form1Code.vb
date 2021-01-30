Option Explicit On
Option Strict On
Option Infer On
Imports System.Windows.Forms
Imports System.IO
Imports Scripting
Imports System.Drawing
Imports System.Text
Imports Microsoft.VisualBasic.PowerPacks
Public Class frTest1
    Dim JakostA As String = ""          'souhrne zobrazeni
    Dim JakostB As String = ""
    Dim JakostC As String = ""

    Dim PocCB As Integer = 0          'pocet CheckBoxu

    Private Sub frTest1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(cisloProgresBaru)
        tmPbVteriny.Start()                                                           'inicializace casu
        tmCas.Start()                                                           'inicializace casu
        Me.ssCasAktual.Text = DateTime.Now.ToString("T")
        Me.pbVteriny.Maximum = cisloProgresBaru * 1000
        Me.ssPocetCBAktual.Text = Me.PocCB.ToString
    End Sub

    Private Sub tmPbVteriny_Tick(sender As Object, e As EventArgs) Handles tmPbVteriny.Tick
        Me.pbVteriny.Value += Me.tmPbVteriny.Interval
        If Me.pbVteriny.Value = Me.pbVteriny.Maximum Then Me.tmPbVteriny.Stop()
    End Sub
    Private Sub tlSpustPbVteriny_Click(sender As Object, e As EventArgs) Handles tlSpustPbVteriny.Click
        Me.tmPbVteriny.Stop()
        Me.pbVteriny.Value = 0
        Me.tmPbVteriny.Start()
        Me.pbVteriny.Value += Me.tmPbVteriny.Interval
        If Me.pbVteriny.Value = Me.pbVteriny.Maximum Then Me.tmPbVteriny.Stop()
    End Sub


    Private Sub msKonec_Click(sender As Object, e As EventArgs) Handles msKonec.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub msOtevrit_Click(sender As Object, e As EventArgs) Handles msOtevrit.Click
        Dim OtevSoubor As Windows.Forms.DialogResult
        With Me.OpenDial
            .Title = "Zvolte soubor"
            .Filter = "Vsechno (*.*)|*.*|Textove soubory (*.Txt)|*.txt"
            .FilterIndex = 2
            .CheckFileExists = True

            Dim data As String = ""
            Dim obsah As String = ""
            OtevSoubor = .ShowDialog()
            If (OtevSoubor.Equals(DialogResult.OK)) Then
                FileOpen(1, OpenDial.FileName, OpenMode.Input)
                Do While Not EOF(1)
                    data = LineInput(1) & vbCrLf
                    obsah += data
                Loop
                FileClose(1)
                Me.tbSoubor.Text = obsah
            Else
                MsgBox("Stornovano")
            End If
        End With
    End Sub

    Private Sub msUlozit_Click(sender As Object, e As EventArgs) Handles msUlozit.Click
        Dim ZavSoubor As Windows.Forms.DialogResult
        ZavSoubor = SaveDial.ShowDialog()
        If ZavSoubor = Windows.Forms.DialogResult.OK Then
            FileOpen(1, SaveDial.FileName, OpenMode.Output)
            Write(1, Me.tbSoubor.Text)
            FileClose(1)
        Else
            MsgBox("Stornovano")
        End If
    End Sub
    Private Sub rbVarA_CheckedChanged(sender As Object, e As EventArgs) Handles rbVarA.CheckedChanged
        If Me.rbVarA.Checked Then
            Me.JakostA = Me.rbVarA.Text
        Else
            Me.JakostA = ""
        End If
    End Sub
    Private Sub rbVarB_CheckedChanged(sender As Object, e As EventArgs) Handles rbVarB.CheckedChanged
        If Me.rbVarB.Checked Then
            Me.JakostB = Me.rbVarB.Text
        Else
            Me.JakostB = ""
        End If
    End Sub
    Private Sub rbVarC_CheckedChanged(sender As Object, e As EventArgs) Handles rbVarC.CheckedChanged
        If Me.rbVarC.Checked Then
            Me.JakostC = Me.rbVarC.Text
        Else
            Me.JakostC = ""
        End If
    End Sub
    Private Sub tmCas_Tick(sender As Object, e As EventArgs) Handles tmCas.Tick  'stanoveni casu
        Me.ssCasAktual.Text = DateTime.Now.ToString("T")
        Me.laOvoceHmotnost.Text = "Vybrano: " + Me.cbJidlo.Text + " " + Me.tbHmotnost.Value.ToString + " kg "
        Me.laOvoceHmotnost.Text += JakostA + JakostB + JakostC
        'Me.ssPocetCBAktual.Text = Me.PocCB.ToString
    End Sub
    Sub VypocitejNasobeni()
        Dim A As Double
        Dim B As Double
        Dim S As Double
        A = Val(Me.nuCislo1.Value)  'replace vymeni carku za tecku
        B = Val(Me.nuCislo2.Value)
        S = A * B
        Me.laSoucinVys.Text = S.ToString
    End Sub

    Private Sub nuCislo1_ValueChanged(sender As Object, e As EventArgs) Handles nuCislo1.ValueChanged
        VypocitejNasobeni()
    End Sub
    Private Sub nuCislo2_ValueChanged(sender As Object, e As EventArgs) Handles nuCislo2.ValueChanged
        VypocitejNasobeni()
    End Sub

    Private Sub tlSmazObr_Click(sender As Object, e As EventArgs) Handles tlSmazObr.Click
        Me.pbObrazek.Image = Nothing
    End Sub

    Private Sub tlZobrazObr_Click(sender As Object, e As EventArgs) Handles tlZobrazObr.Click
        Me.pbObrazek.Image = Image.FromFile("E:\Programator\VS_B\VB_cv\KYTICKA1.png")
    End Sub

    Private Sub cb1_CheckedChanged(sender As Object, e As EventArgs) Handles cb1.CheckedChanged
        If Me.cb1.Checked Then
            Me.PocCB += 1
            Me.VypisCB()
        Else
            Me.PocCB -= 1
            Me.VypisCB()
        End If
    End Sub
    Private Sub cb2_CheckedChanged(sender As Object, e As EventArgs) Handles cb2.CheckedChanged
        If Me.cb2.Checked Then
            Me.PocCB += 1
            Me.VypisCB()
        Else
            Me.PocCB -= 1
            Me.VypisCB()
        End If
    End Sub
    Private Sub cb3_CheckedChanged(sender As Object, e As EventArgs) Handles cb3.CheckedChanged
        If Me.cb3.Checked Then
            Me.PocCB += 1
            Me.VypisCB()
        Else
            Me.PocCB -= 1
            Me.VypisCB()
        End If
    End Sub
    Private Sub cb4_CheckedChanged(sender As Object, e As EventArgs) Handles cb4.CheckedChanged
        If Me.cb4.Checked Then
            Me.PocCB += 1
            Me.VypisCB()
        Else
            Me.PocCB -= 1
            Me.VypisCB()
        End If
    End Sub
    Private Sub cb5_CheckedChanged(sender As Object, e As EventArgs) Handles cb5.CheckedChanged
        If Me.cb5.Checked Then
            Me.PocCB += 1
            Me.VypisCB()
        Else
            Me.PocCB -= 1
            Me.VypisCB()
        End If
    End Sub
    Private Sub cb6_CheckedChanged(sender As Object, e As EventArgs) Handles cb6.CheckedChanged
        If Me.cb6.Checked Then
            Me.PocCB += 1
            Me.VypisCB()
        Else
            Me.PocCB -= 1
            Me.VypisCB()
        End If
    End Sub
    Private Sub cb7_CheckedChanged(sender As Object, e As EventArgs) Handles cb7.CheckedChanged
        If Me.cb7.Checked Then
            Me.PocCB += 1
            Me.VypisCB()
        Else
            Me.PocCB -= 1
            Me.VypisCB()
        End If
    End Sub
    Sub VypisCB()
        Me.ssPocetCBAktual.Text = Me.PocCB.ToString
    End Sub

    Private Sub msNapoveda_Click(sender As Object, e As EventArgs) Handles msNapoveda.Click
        MsgBox("Toto je nápověda k tomuto programu")

    End Sub

End Class