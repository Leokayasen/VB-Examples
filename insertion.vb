Module Module1
	Sub Main()
		Dim items() As String = {"Florida", "Georgia", "Delaware", "Alabama", "California"}
		Dim n As Integer = items.Count
		Dim index, index2 As Integer
		Dim current As String
		For index = 1 To n-1
			current = items(index)
			index2 = index
			While index2 > 0 AndAlso items(index2 - 1) > current
				items(index2) = items(index2 - 1)
				index2 = index2 - 1
				items(index2) = current
			End While
		Next

	Console.WriteLine(String.Join(", ", items))
	Console.ReadLine()
	End Sub
End Module
