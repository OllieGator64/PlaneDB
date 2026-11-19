Imports System.Data.SQLite
Imports System.IO
Public Class frmUpdatePilots
    Private Sub frmUpdatePilots_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim databasePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))
        Dim connectionString As String =
    "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strQuery As String = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"
            Using command As New SQLiteCommand(strQuery, conn)
                Dim adapter As New SQLiteDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                cboRoles.DataSource = dataTable
                cboRoles.DisplayMember = "strPilotRole"
                cboRoles.ValueMember = "intPilotRoleID"
            End Using


            Dim strPilotQuery = "SELECT intPilotID, strFirstName || ' ' || strLastName AS strFullName FROM TPilots"

            Using command As New SQLiteCommand(strPilotQuery, conn)
                Dim adapter As New SQLiteDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                cboPilots.DataSource = dataTable
                cboPilots.DisplayMember = "strFullName"
                cboPilots.ValueMember = "intPilotID"
            End Using

        End Using
    End Sub

    Private Sub cboPilots_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPilots.SelectedIndexChanged
        If TypeOf cboPilots.SelectedValue Is DataRowView OrElse cboPilots.SelectedValue Is Nothing Then
            Exit Sub
        End If

        Dim databasePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))
        Dim connectionString As String = "Data Source=" & databasePath & ";Version=3;"
        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strPilotQuery As String = $"SELECT * FROM TPilots WHERE intPilotID = {cboPilots.SelectedValue}"
            Using command As New SQLiteCommand(strPilotQuery, conn)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    reader.Read()
                    txtFirstName.Text = reader.GetString(1)
                    txtLastName.Text = reader.GetString(2)
                    txtEmployeeID.Text = reader.GetString(3)
                    txtHire.Text = reader.GetString(4)
                    txtTermination.Text = reader.GetString(5)
                    txtLicense.Text = reader.GetString(6)
                    cboRoles.SelectedValue = reader.GetInt32(7)
                End Using
            End Using

        End Using

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As Integer
        Dim strHireDate As String
        Dim strTerminationDate As String
        Dim strLicenseDate As String
        Dim intPilotRole As Integer
        Dim intPilotID As Integer

        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strEmployeeID = txtEmployeeID.Text
        strHireDate = txtHire.Text
        strTerminationDate = txtTermination.Text
        strLicenseDate = txtLicense.Text
        intPilotRole = cboRoles.SelectedValue
        intPilotID = cboPilots.SelectedValue

        Dim strUpdateQuery As String =
            $"UPDATE TPilots
            SET strFirstName = '{strFirstName}',
            strLastName = '{strLastName}',
            strEmployeeID = '{strEmployeeID}',
            dtmDateOfHire = '{strHireDate}',
            dtmDateOfTermination = '{strTerminationDate}',
            dtmDateOfLicense = '{strLicenseDate}',
            intPilotRoleID = {intPilotRole}
            WHERE intPilotID = {intPilotID}"

        Dim databasePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))
        Dim connectionString As String = "Data Source=" & databasePath & ";Version=3;"
        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Using command As New SQLiteCommand(strUpdateQuery, conn)
                command.ExecuteNonQuery()
            End Using

        End Using

    End Sub
End Class