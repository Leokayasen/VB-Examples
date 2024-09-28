Module Module1
	Sub main()
		Dim dictionary = New Dictionary(Of String, String) From {
				{"England", "London"},
				{"France", "Paris"},
				{"Germany", "Berlin"}}
		Dim key As String
		Console.Write("Enter the key: ")
		key = Console.ReadLine
		If dictionary.ContainsKey(key) Then
			Console.WriteLine(dictionary(key))
		Else
			Console.WriteLine("Not Found")
		End If
		Console.ReadLine()
	End Sub
End Module
