Imports System.Data.SQLite
Imports System.IO

Public Class frmUpdatePassengers
    Private Sub frmUpdatePassengers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim databasePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))
        Dim connectionString As String =
    "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strQuery As String = "SELECT intStateID, strState FROM TStates"
            Using command As New SQLiteCommand(strQuery, conn)
                Dim adapter As New SQLiteDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                cboState.DataSource = dataTable
                cboState.DisplayMember = "strState"
                cboState.ValueMember = "intStateID"
            End Using


            Dim strPilotQuery = "SELECT intPassengerID, strFirstName || ' ' || strLastName AS strFullName FROM TPassengers"

            Using command As New SQLiteCommand(strPilotQuery, conn)
                Dim adapter As New SQLiteDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                cboPassenger.DataSource = dataTable
                cboPassenger.DisplayMember = "strFullName"
                cboPassenger.ValueMember = "intPassengerID"
            End Using

        End Using
    End Sub

    Private Sub cboPassenger_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPassenger.SelectedIndexChanged
        If TypeOf cboPassenger.SelectedValue Is DataRowView OrElse cboPassenger.SelectedValue Is Nothing Then
            Exit Sub
        End If

        Dim databasePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))
        Dim connectionString As String = "Data Source=" & databasePath & ";Version=3;"
        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strPilotQuery As String = $"SELECT * FROM TPassengers WHERE intPassengerID = {cboPassenger.SelectedValue}"
            Using command As New SQLiteCommand(strPilotQuery, conn)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    reader.Read()
                    txtFirstName.Text = reader.GetString(1)
                    txtLastName.Text = reader.GetString(2)
                    txtAddress.Text = reader.GetString(3)
                    txtCity.Text = reader.GetString(4)
                    cboState.SelectedValue = reader.GetInt32(5)
                    txtZip.Text = reader.GetString(6)
                    txtPhone.Text = reader.GetString(7)
                    txtEmail.Text = reader.GetString(8)
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim strZip As String
        Dim strPhone As String
        Dim strEmail As String
        Dim intStateID As Integer
        Dim intPassengerID As Integer

        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strAddress = txtAddress.Text
        strCity = txtCity.Text
        strZip = txtZip.Text
        strPhone = txtPhone.Text
        strEmail = txtEmail.Text
        intStateID = cboState.SelectedValue
        intPassengerID = cboPassenger.SelectedValue

        Dim strUpdateQuery As String =
            $"UPDATE TPassengers
            SET strFirstName = '{strFirstName}',
            strLastName = '{strLastName}',
            strAddress = '{strAddress}',
            strCity = '{strCity}',
            strZip = '{strZip}',
            strPhoneNumber = '{strPhone}',
            strEmail = '{strEmail}',
            intStateID = {intStateID}
            WHERE intPassengerID = {intPassengerID}"

        Dim databasePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))
        Dim connectionString As String = "Data Source=" & databasePath & ";Version=3;"
        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Using command As New SQLiteCommand(strUpdateQuery, conn)
                command.ExecuteNonQuery()
            End Using

        End Using

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class