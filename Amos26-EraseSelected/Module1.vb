Imports System
Imports Microsoft.VisualBasic
Imports Amos
Imports AmosEngineLib
Imports AmosEngineLib.AmosEngine.TMatrixID
Imports MiscAmosTypes
Imports MiscAmosTypes.cDatabaseFormat

<System.ComponentModel.Composition.Export(GetType(Amos.IPlugin))>
Public Class CustomCode
    Implements IPlugin

    Public Function Name() As String Implements IPlugin.Name
        Return "Erase Selected"
    End Function

    Public Function Description() As String Implements IPlugin.Description
        Return "Erases everything selected in the model."
    End Function

    Public Function Mainsub() As Integer Implements IPlugin.MainSub
        Dim variable As PDElement
        Dim allVariables As New Collection
        Dim removeVariables As New Collection

        For Each variable In pd.PDElements
            If variable.IsSelected() Then
                allVariables.Add(variable)
            End If
        Next

        For i As Int32 = allVariables.Count - 1 To 1 Step -1
            Dim var = allVariables(i)
            pd.EditErase(var)
        Next

    End Function

End Class
