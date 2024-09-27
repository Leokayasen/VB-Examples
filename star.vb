Module Module1
    Function astar(graph As Dictionary(Of String, Dictionary(Of String, Integer)), h As Dictionary(Of String, Integer), start As String, goal As String)
        'Initialise
        Dim infinity As Integer = 2147483647
        Dim g As New Dictionary(Of String, Integer)
        Dim f As New Dictionary(Of String, Integer)
        Dim previous_vertex As New Dictionary(Of String, String)
        Dim shortest_path As New List(Of String)
        Dim shortest As String
        Dim cost As Integer

        'Set the g and f for all vertices to infinity
        For Each vertex In graph
            g.Add(vertex.Key, infinity)
            f.Add(vertex.Key, infinity)
        Next
        'Set the g and f from the start vertex to 0
        g(start) = 0
        f(start) = 0

        'Consider each vertex
        While graph.Count > 0
            'Find the vertex with the shortest f from the start
            shortest = Nothing
            For Each vertex In graph
                If shortest = Nothing Then
                    shortest = vertex.Key
                ElseIf f(vertex.Key) < f(shortest) Then
                    shortest = vertex.Key
                End If
            Next

            'Calculate shortest g & f value for each edge
            For Each neighbour In graph(shortest)
                cost = neighbour.Value
                'Update f value and previous vertex if lower
                If graph.ContainsKey(neighbour.Key) And cost + g(shortest) + h(neighbour.Key) < f(neighbour.Key) Then
                    g(neighbour.Key) = cost + g(shortest)
                    f(neighbour.Key) = cost + g(shortest) + h(neighbour.Key)
                    previous_vertex(neighbour.Key) = shortest
                End If
            Next

            'The vertex has now been visited, remove it from the vertices to consider
            graph.Remove(shortest)
        End While

        'Generate the shortest shortest_path
        'Start from the goal, adding vertices to the front of the list
        Dim current_vertex As String = goal
        While current_vertex <> start
            shortest_path.Insert(0, current_vertex)
            current_vertex = previous_vertex(current_vertex)
        End While
        'Add the start vertex
        shortest_path.Insert(0, start)

        'Return the shortest shortest_path
        Return shortest_path
    End Function

    Sub main()
        Dim graph = New Dictionary(Of String, Dictionary(Of String, Integer)) From {
        {"A", New Dictionary(Of String, Integer) From {{"B", 4}, {"C", 3}, {"D", 2}}},
        {"B", New Dictionary(Of String, Integer) From {{"A", 4}, {"E", 4}}},
        {"C", New Dictionary(Of String, Integer) From {{"A", 3}, {"D", 1}}},
        {"D", New Dictionary(Of String, Integer) From {{"A", 2}, {"C", 1}, {"F", 2}}},
        {"E", New Dictionary(Of String, Integer) From {{"B", 4}, {"G", 2}}},
        {"F", New Dictionary(Of String, Integer) From {{"D", 2}, {"G", 5}}},
        {"G", New Dictionary(Of String, Integer) From {{"E", 2}, {"F", 5}}}
        }

        Dim h = New Dictionary(Of String, Integer) From {
        {"A", 12}, {"B", 6}, {"C", 9}, {"D", 12}, {"E", 3}, {"F", 9}, {"G", 0}
        }

        Dim optimal_path = astar(graph, h, "A", "G")
        For Each vertex In optimal_path
            Console.WriteLine(vertex)
        Next
        Console.ReadLine()
    End Sub
End Module
