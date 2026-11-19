Public Class frmMain

    Private Sub btnAddPilots_Click(sender As Object, e As EventArgs) Handles btnAddPilots.Click
        Dim frmAddPilotsDisplay As New frmAddPilots
        frmAddPilotsDisplay.ShowDialog()
    End Sub

    Private Sub btnUpdatePilots_Click(sender As Object, e As EventArgs) Handles btnUpdatePilots.Click
        Dim frmUpdatePilotsDisplay As New frmUpdatePilots
        frmUpdatePilotsDisplay.ShowDialog()
    End Sub

    Private Sub btnAddPassengers_Click(sender As Object, e As EventArgs) Handles btnAddPassengers.Click
        Dim frmAddPassengersDisplay As New frmAddPassengers
        frmAddPassengersDisplay.ShowDialog()
    End Sub

    Private Sub btnUpdatePassengers_Click(sender As Object, e As EventArgs) Handles btnUpdatePassengers.Click
        Dim frmUpdatePassengersDisplay As New frmUpdatePassengers
        frmUpdatePassengersDisplay.ShowDialog()
    End Sub

    Private Sub btnShowPassengers_Click(sender As Object, e As EventArgs) Handles btnShowPassengers.Click
        Dim frmShowPassengersDisplay As New frmShowPassengers
        frmShowPassengersDisplay.ShowDialog()
    End Sub
End Class
