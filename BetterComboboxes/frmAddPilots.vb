Imports System.Data.SQLite
Imports System.IO
Public Class frmAddPilots

    Private Sub frmAddPilots_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        End Using

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim intNextPrimaryKey As Integer
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As Integer
        Dim strHireDate As String
        Dim strTerminationDate As String
        Dim strLicenseDate As String
        Dim intPilotRole As Integer

        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strEmployeeID = txtEmployeeID.Text
        strHireDate = txtHire.Text
        strTerminationDate = txtTermination.Text
        strLicenseDate = txtLicense.Text
        intPilotRole = cboRoles.SelectedValue

        Dim databasePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
    "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strKeyQuery As String = "SELECT MAX(intPilotID) + 1 FROM TPilots"
            Using command As New SQLiteCommand(strKeyQuery, conn)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    reader.Read()
                    intNextPrimaryKey = reader.GetInt32(0)
                End Using
            End Using

            Dim strInsertQuery As String =
            $"INSERT INTO TPilots VALUES ({intNextPrimaryKey}, '{strFirstName}', '{strLastName}', {strEmployeeID}, '{strHireDate}', '{strTerminationDate}',  '{strLicenseDate}', {intPilotRole})"
            Using command As New SQLiteCommand(strInsertQuery, conn)
                command.ExecuteNonQuery()
            End Using


        End Using


    End Sub
End Class