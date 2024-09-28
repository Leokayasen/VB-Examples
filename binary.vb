Module Module1
    Sub Main()
        Dim items() As String = {"Florida", "California", "Delaware", "Alabama", "Georgia"}
        Dim item_to_find As String
        Dim found As Boolean = False
        Dim first As Integer = 0
        Dim midpoint As Integer = 0
        Dim last As Integer = items.Count - 1
        Console.WriteLine("Enter the state to find: ")
        item_to_find = Console.ReadLine
        While first <= last And found = False
            midpoint = (first + last) \ 2
            If items(midpoint) = item_to_find Then
                found = True
            Else
                If items(midpoint) < item_to_find Then
                    first = midpoint + 1
                Else
                    last = midpoint - 1
                End If
            End If
        End While
        If found = True Then
            Console.WriteLine("Item found at position " & midpoint)
        Else
            Console.WriteLine("Item not found")
        End If
        Console.ReadLine()
    End Sub
End Module
