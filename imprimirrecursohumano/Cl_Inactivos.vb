Imports System.Drawing.Printing

Partial Class Cl_Impresión

#Region " 1 - AUTORIZACIÓN EXÁMENES PREOCUPACIONALES DPTO. MÉDICO"
    Private WithEvents DocImp_AutorizacionExamenesDeptoMedico As New PrintDocument

    Private Sub DocImpr_AutorizacionExamenesDeptoMedico(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_AutorizacionExamenesDeptoMedico.PrintPage

    End Sub
#End Region

End Class