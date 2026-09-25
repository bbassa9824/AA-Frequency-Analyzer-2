Option Explicit On
Option Infer On
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1

    Private ReadOnly LFCR As String = vbCrLf

    Private MotifLength As Integer
    Private ANP As Integer
    Private Data1 As String = ""
    Private item1 As String = ""
    Private chrProfiles(19) As String
    Private aCount As Integer
    Private cCount As Integer
    Private dCount As Integer
    Private eCount As Integer
    Private fCount As Integer
    Private gCount As Integer
    Private hCount As Integer
    Private iCount As Integer
    Private kCount As Integer
    Private lCount As Integer
    Private mCount As Integer
    Private nCount As Integer
    Private pCount As Integer
    Private qCount As Integer
    Private rCount As Integer
    Private sCount As Integer
    Private tCount As Integer
    Private vCount As Integer
    Private wCount As Integer
    Private yCount As Integer
    Private HydrophobicCount As Integer
    Private HydrophilicCount As Integer
    Private ChargedCount As Integer
    Public RI As Integer
    Private originalFormWidth As Integer
    Private originalFormHeight As Integer

    Private Class ControlLayoutInfo
        Public Left As Integer
        Public Top As Integer
        Public Width As Integer
        Public Height As Integer
        Public FontSize As Single
    End Class

    Private originalControlLayout As New Dictionary(Of Control, ControlLayoutInfo)

    Private resizingStarted As Boolean = False



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            RI = 0

            ANP = 0


            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()

            ' Convert pasted line-separated data into
            ' comma-separated data before analysis.
            ConvertToCsv()

            ' Remove duplicate motifs only if
            ' the PickUnique checkbox is selected.
            pickunique()

            TextBox2.Text =
                "        " & "," &
                "Ala(a),Cys(c),Asp(D),Glu(E),Phe(F),Gly(G),His(H)," &
                "Ile(I),Lys(K),Leu(L),Met(M),Asn(N),Pro(P),Gln(Q)," &
                "Arg(R),Ser(S),Thr(T),Val(V),Trp(W),Tyr(Y)" &
              "        " & ","
            '"P14" & LFCR & "P13" & LFCR & "P12" & LFCR & "P11" & LFCR & "P10" & LFCR & "P9" & LFCR & "P8" & LFCR & LFCR & "P7" & LFCR & LFCR & "P6" & LFCR & "P5" & LFCR & "P4" & LFCR & "P3" & LFCR & "P2" & LFCR & LFCR & "P1" & LFCR & "P1'" & LFCR & "P2'" & LFCR & LFCR & "P3'" & LFCR & "P4'" & LFCR & "P5'" &LFCR & "P6'"

            TextBox3.Text =
               "        " & "," &
                "Chrged-AA,    Hydrophobic-AA,   Hydrophilic-lAA"

            'TextBox4.Text = ""

            ' Fully qualified InputBox call.
            ' This is more reliable when the program is copied
            ' into another Visual Studio project.
            Dim inputStr As String =
                Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter Motif Length 20 or less",
                    "Motif Length",
                    "20"
                )

            If Not Integer.TryParse(inputStr, MotifLength) Then

                MessageBox.Show(
                    "Invalid motif length. Please enter a number from 1 to 20.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Exit Sub

            End If

            If MotifLength < 1 OrElse MotifLength > 20 Then

                MessageBox.Show(
                    "Motif length must be between 1 and 20.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Exit Sub

            End If


            ' Clear positional profiles left over
            ' from any previous analysis.
            ResetProfiles()


            ' Clean and normalize the input data.
            Cleanup()


            If String.IsNullOrWhiteSpace(Data1) Then

                MessageBox.Show(
                    "No valid motif data was found.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Exit Sub

            End If


            Dim motifs() As String =
                Data1.Split(
                    New Char() {","c},
                    StringSplitOptions.RemoveEmptyEntries
                )

            For Each motif As String In motifs

                item1 = motif.Trim().ToLowerInvariant()

                If item1 = "xxx" Then
                    Exit For
                End If

                ' ItemSortCall performs all validation:
                ' 1. Correct length
                ' 2. Valid amino-acid letters
                ' 3. P1 = R for 20-AA datasets
                ItemSortCall()

            Next


            If ANP = 0 Then

                MessageBox.Show(
                    "No valid motifs matched the motif length you entered.",
                    "No Records Processed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

                Exit Sub

            End If

            ' Generate amino-acid frequencies
            ' for each position.
            For pos As Integer = 1 To MotifLength

                ProfilePositions(
                    pos,
                    chrProfiles(pos - 1)
                )

            Next

            TextBox2.Text &=
                LFCR & LFCR &
                "Number of records processed = " &
                ANP.ToString()

            ' Clear the input box only after
            ' successful completion of the analysis.
            TextBox1.Clear()
        Catch ex As Exception

            MessageBox.Show(
                "Error during analysis: " & ex.Message,
                "Program Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox3.Text = ""
    End Sub
    Private Sub pickunique()

        If CheckBox1.Checked Then

            MessageBox.Show(
                "PickUnique is chosen; therefore only unique motifs will be processed.",
                "PickUnique",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                Exit Sub
            End If

            Dim rawText As String =
                TextBox1.Text.ToLowerInvariant()

            ' Convert any remaining line breaks to commas.
            rawText = rawText.Replace(vbCrLf, ",")
            rawText = rawText.Replace(vbCr, ",")
            rawText = rawText.Replace(vbLf, ",")

            ' Remove whitespace.
            rawText = Regex.Replace(
                rawText,
                "\s+",
                ""
            )


            ' Remove repeated commas.
            rawText = Regex.Replace(
                rawText,
                ",+",
                ","
            )

            ' Remove leading and trailing commas.
            rawText = rawText.Trim(","c)


            If String.IsNullOrWhiteSpace(rawText) Then

                TextBox1.Clear()
                Exit Sub

            End If

            Dim motifs() As String =
                rawText.Split(
                    New Char() {","c},
                    StringSplitOptions.RemoveEmptyEntries
                )

            Dim uniqueMotifs As New List(Of String)

            Dim seen As New HashSet(Of String)(
                StringComparer.OrdinalIgnoreCase
            )

            For Each motif As String In motifs

                Dim cleanMotif As String =
                    motif.Trim().ToLowerInvariant()


                If cleanMotif <> "" AndAlso
                   Not seen.Contains(cleanMotif) Then

                    seen.Add(cleanMotif)
                    uniqueMotifs.Add(cleanMotif)

                End If

            Next

            TextBox1.Text =
                String.Join(",", uniqueMotifs)

        Else

            MessageBox.Show(
                "PickUnique is not chosen; therefore duplicates will not be deleted.",
                "PickUnique",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Exit Sub

        End If

    End Sub


    Private Sub ConvertToCsv()

        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            Exit Sub
        End If

        Dim lines() As String =
            TextBox1.Text.Split(
                New String() {
                    vbCrLf,
                    vbLf,
                    vbCr
                },
                StringSplitOptions.RemoveEmptyEntries
            )


        For idx As Integer = 0 To lines.Length - 1

            lines(idx) =
                Regex.Replace(
                    lines(idx),
                    "\s+",
                    ""
                )
        Next

        TextBox1.Text =
            String.Join(",", lines)

    End Sub

    Private Sub Cleanup()

        Data1 = TextBox1.Text

        If String.IsNullOrWhiteSpace(Data1) Then
            Data1 = ""
            Exit Sub
        End If

        Data1 = Data1.ToLower()

        ' Convert line breaks to commas.
        Data1 = Data1.Replace(vbCrLf, ",")
        Data1 = Data1.Replace(vbCr, ",")
        Data1 = Data1.Replace(vbLf, ",")

        ' Remove all whitespace, including spaces and tabs.
        Data1 = Regex.Replace(Data1, "\s+", "")

        ' Remove repeated commas.
        Data1 = Regex.Replace(Data1, ",+", ",")

        ' Remove leading or trailing commas.
        Data1 = Data1.Trim(","c)

        TextBox1.Text = Data1
    End Sub
    Private Sub ResetCounts()
        aCount = 0
        cCount = 0
        dCount = 0
        eCount = 0
        fCount = 0
        gCount = 0
        hCount = 0
        iCount = 0
        kCount = 0
        lCount = 0
        mCount = 0
        nCount = 0
        pCount = 0
        qCount = 0
        rCount = 0
        sCount = 0
        tCount = 0
        vCount = 0
        wCount = 0
        yCount = 0

    End Sub

    Private Sub ItemSortCall()
        If item1.Length = MotifLength Then

            If Regex.IsMatch(
                item1,
                "^[acdefghiklmnpqrstvwy]+$"
            ) Then

                ' For 20-AA furin-site fragments,
                ' amino acid 14 (P1) must be R.
                If MotifLength = 20 AndAlso item1(13) <> "r"c Then

                    TextBox4.Text &=
                        LFCR &
                        "Rejected - P1 is not R: " &
                        item1

                    RI += 1

                Else

                    ItemSortAA()
                    ANP += 1

                End If

            Else

                TextBox4.Text &=
                    LFCR &
                    "Invalid amino acid: " &
                    item1

                RI += 1

            End If

        Else

            TextBox4.Text &=
                LFCR &
                "Wrong length (" &
                item1.Length.ToString() &
                "): " &
                item1

            RI += 1

        End If

    End Sub
    Private Sub ItemSortAA()
        If String.IsNullOrEmpty(item1) Then

            Throw New Exception(
                "An empty motif was encountered during analysis."
            )

        End If


        If item1.Length < MotifLength Then

            Throw New Exception(
                "A motif shorter than the specified motif length was encountered."
            )

        End If


        For pos As Integer = 1 To MotifLength

            chrProfiles(pos - 1) &=
                item1.Substring(pos - 1, 1)

        Next

    End Sub
    Private Sub ProfilePositions(positionNumber As Integer, chrProfile As String)
        ChargedCount = 0
        HydrophobicCount = 0
        HydrophilicCount = 0
        Dim FreqCharged As Double = 0.0
        Dim FreqHydrophobic As Double = 0.0
        Dim FreqHydrophilic As Double = 0.0

        If ANP = 0 Then Exit Sub

        ResetCounts()

        For Each aa As Char In chrProfile
            Select Case aa
                Case "a"c
                    aCount += 1
                    HydrophobicCount += 1

                Case "c"c
                    cCount += 1
                    HydrophilicCount += 1
                Case "d"c
                    dCount += 1
                    ChargedCount += 1


                Case "e"c
                    eCount += 1
                    ChargedCount += 1

                Case "f"c
                    fCount += 1
                    HydrophobicCount += 1

                Case "g"c
                    gCount += 1
                    HydrophobicCount += 1

                Case "h"c
                    hCount += 1
                    ChargedCount += 1

                Case "i"c
                    iCount += 1
                    HydrophobicCount += 1

                Case "k"c
                    kCount += 1
                    ChargedCount += 1

                Case "l"c
                    lCount += 1
                    HydrophobicCount += 1

                Case "m"c
                    mCount += 1
                    HydrophobicCount += 1

                Case "n"c
                    nCount += 1
                    HydrophilicCount += 1

                Case "p"c
                    pCount += 1
                    HydrophobicCount += 1

                Case "q"c
                    qCount += 1
                    HydrophilicCount += 1

                Case "r"c
                    rCount += 1
                    ChargedCount += 1

                Case "s"c
                    sCount += 1
                    HydrophilicCount += 1

                Case "t"c
                    tCount += 1
                    HydrophilicCount += 1

                Case "v"c
                    vCount += 1
                    HydrophobicCount += 1

                Case "w"c
                    wCount += 1
                    HydrophobicCount += 1

                Case "y"c
                    yCount += 1
                    HydrophobicCount += 1
            End Select
        Next

        Dim FqA As Double = Percent(aCount)
        Dim FqC As Double = Percent(cCount)
        Dim FqD As Double = Percent(dCount)
        Dim FqE As Double = Percent(eCount)
        Dim FqF As Double = Percent(fCount)
        Dim FqG As Double = Percent(gCount)
        Dim FqH As Double = Percent(hCount)
        Dim FqI As Double = Percent(iCount)
        Dim FqK As Double = Percent(kCount)
        Dim FqL As Double = Percent(lCount)
        Dim FqM As Double = Percent(mCount)
        Dim FqN As Double = Percent(nCount)
        Dim FqP As Double = Percent(pCount)
        Dim FqQ As Double = Percent(qCount)
        Dim FqR As Double = Percent(rCount)
        Dim FqS As Double = Percent(sCount)
        Dim FqT As Double = Percent(tCount)
        Dim FqV As Double = Percent(vCount)
        Dim FqW As Double = Percent(wCount)
        Dim FqY As Double = Percent(yCount)

        TextBox2.Text &= LFCR &
        PositionLabel(positionNumber) & "," &
                FqA.ToString("0.0") & "," &
                FqC.ToString("0.0") & "," &
                FqD.ToString("0.0") & "," &
                FqE.ToString("0.0") & "," &
                FqF.ToString("0.0") & "," &
                FqG.ToString("0.0") & "," &
                FqH.ToString("0.0") & "," &
                FqI.ToString("0.0") & "," &
                FqK.ToString("0.0") & "," &
                FqL.ToString("0.0") & "," &
                FqM.ToString("0.0") & "," &
                FqN.ToString("0.0") & "," &
                FqP.ToString("0.0") & "," &
                FqQ.ToString("0.0") & "," &
                FqR.ToString("0.0") & "," &
                FqS.ToString("0.0") & "," &
                FqT.ToString("0.0") & "," &
                FqV.ToString("0.0") & "," &
                FqW.ToString("0.0") & "," &
                FqY.ToString("0.0")

        FreqCharged = (ChargedCount / ANP) * 100
        FreqHydrophobic = (HydrophobicCount / ANP) * 100
        FreqHydrophilic = (HydrophilicCount / ANP) * 100

        FreqCharged = Format(FreqCharged, "0.0")
        FreqHydrophobic = Format(FreqHydrophobic, "0.0")
        FreqHydrophilic = Format(FreqHydrophilic, "0.0")
        'MsgBox(FreqCharged)

        TextBox3.Text &= LFCR &
    PositionLabel(positionNumber) & "," &
    FreqCharged.ToString & ",  " &
    FreqHydrophobic.ToString & ",  " &
    FreqHydrophilic.ToString()

    End Sub

    Private Function Percent(count As Integer) As Double
        If ANP = 0 Then Return 0
        Return (count / ANP) * 100
    End Function

    Private Sub ResetProfiles()
        For idx As Integer = 0 To chrProfiles.Length - 1
            chrProfiles(idx) = ""
        Next
    End Sub
    Private Sub SaveTextBoxToFile(textToSave As String)


        Try

            If SaveFileDialog1.ShowDialog() =
                DialogResult.OK Then


                Using fileWriter As New StreamWriter(
                    SaveFileDialog1.FileName,
                    False
                )

                    fileWriter.Write(textToSave)

                End Using

            End If


        Catch ex As UnauthorizedAccessException

            MessageBox.Show(
                "You do not have permission to save the file in the selected location." &
                LFCR & LFCR &
                ex.Message,
                "File Permission Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )


        Catch ex As IOException

            MessageBox.Show(
                "The file could not be saved. It may be open in another program or the selected location may be unavailable." &
                LFCR & LFCR &
                ex.Message,
                "File Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )


        Catch ex As Exception

            MessageBox.Show(
                "File save failed: " & ex.Message,
                "File Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SaveTextBoxToFile(TextBox3.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SaveTextBoxToFile(TextBox2.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Private Function PositionLabel(positionNumber As Integer) As String

        Dim labels() As String = {
        "P14", "P13", "P12", "P11", "P10",
        "P9", "P8", "P7", "P6", "P5",
        "P4", "P3", "P2", "P1",
        "P1'", "P2'", "P3'", "P4'", "P5'", "P6'"
    }

        If MotifLength = 20 AndAlso
       positionNumber >= 1 AndAlso
       positionNumber <= 20 Then

            Return labels(positionNumber - 1)

        Else

            ' For analyses other than the standard 20-AA window
            Return "P" & positionNumber.ToString()

        End If

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        originalFormWidth = Me.ClientSize.Width
        originalFormHeight = Me.ClientSize.Height

        StoreOriginalLayout(Me.Controls)

        Me.MinimumSize = New Size(
            CInt(Me.Width * 0.65),
            CInt(Me.Height * 0.65)
        )

        resizingStarted = True
    End Sub
    Private Sub StoreOriginalLayout(controls As Control.ControlCollection)

        For Each ctrl As Control In controls

            Dim info As New ControlLayoutInfo

            info.Left = ctrl.Left
            info.Top = ctrl.Top
            info.Width = ctrl.Width
            info.Height = ctrl.Height
            info.FontSize = ctrl.Font.Size

            originalControlLayout(ctrl) = info

            ' If the control contains other controls,
            ' store those controls also.
            If ctrl.HasChildren Then
                StoreOriginalLayout(ctrl.Controls)
            End If

        Next

    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        If Not resizingStarted Then Exit Sub

        If originalFormWidth <= 0 OrElse originalFormHeight <= 0 Then Exit Sub

        ResizeAllControls()

    End Sub
    Private Sub ResizeAllControls()

        Dim widthRatio As Double =
            Me.ClientSize.Width / CDbl(originalFormWidth)

        Dim heightRatio As Double =
            Me.ClientSize.Height / CDbl(originalFormHeight)

        ' Use the smaller ratio for fonts.
        ' This keeps the text proportional without becoming
        ' excessively large in one direction.
        Dim fontRatio As Double =
            Math.Min(widthRatio, heightRatio)

        Me.SuspendLayout()

        Try

            For Each pair In originalControlLayout

                Dim ctrl As Control = pair.Key
                Dim info As ControlLayoutInfo = pair.Value

                ctrl.Left =
                    CInt(Math.Round(info.Left * widthRatio))

                ctrl.Top =
                    CInt(Math.Round(info.Top * heightRatio))

                ctrl.Width =
                    Math.Max(
                        1,
                        CInt(Math.Round(info.Width * widthRatio))
                    )

                ctrl.Height =
                    Math.Max(
                        1,
                        CInt(Math.Round(info.Height * heightRatio))
                    )

                Dim newFontSize As Single =
                    CSng(info.FontSize * fontRatio)

                ' Prevent fonts from becoming too tiny.
                If newFontSize < 6.0F Then
                    newFontSize = 6.0F
                End If

                ctrl.Font =
                    New Font(
                        ctrl.Font.FontFamily,
                        newFontSize,
                        ctrl.Font.Style
                    )

            Next

        Finally

            Me.ResumeLayout()

        End Try

    End Sub
    Private Sub MyForm_Closing(
    ByVal sender As Object,
    ByVal e As FormClosingEventArgs
) Handles Me.FormClosing

        Dim result As DialogResult =
        MessageBox.Show(
            "Do you want to close the program?" &
            vbCrLf & vbCrLf &
            "Please save any results you want to keep before closing.",
            "Close AA-Frequency Analyzer",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2
        )

        If result = DialogResult.No Then
            e.Cancel = True
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class