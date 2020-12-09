
Namespace Domain.Navigation

    Public Interface INavigationChild(Of TChild)
        Property Childs As HashSet(Of TChild)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2, TChild3, TChild4, TChild5, TChild6, TChild7, TChild8, TChild9)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
        Property Childs3 As HashSet(Of TChild3)
        Property Childs4 As HashSet(Of TChild4)
        Property Childs5 As HashSet(Of TChild5)
        Property Childs6 As HashSet(Of TChild6)
        Property Childs7 As HashSet(Of TChild7)
        Property Childs8 As HashSet(Of TChild8)
        Property Childs9 As HashSet(Of TChild9)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2, TChild3, TChild4, TChild5, TChild6, TChild7, TChild8)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
        Property Childs3 As HashSet(Of TChild3)
        Property Childs4 As HashSet(Of TChild4)
        Property Childs5 As HashSet(Of TChild5)
        Property Childs6 As HashSet(Of TChild6)
        Property Childs7 As HashSet(Of TChild7)
        Property Childs8 As HashSet(Of TChild8)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2, TChild3, TChild4, TChild5, TChild6, TChild7)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
        Property Childs3 As HashSet(Of TChild3)
        Property Childs4 As HashSet(Of TChild4)
        Property Childs5 As HashSet(Of TChild5)
        Property Childs6 As HashSet(Of TChild6)
        Property Childs7 As HashSet(Of TChild7)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2, TChild3, TChild4, TChild5, TChild6)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
        Property Childs3 As HashSet(Of TChild3)
        Property Childs4 As HashSet(Of TChild4)
        Property Childs5 As HashSet(Of TChild5)
        Property Childs6 As HashSet(Of TChild6)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2, TChild3, TChild4, TChild5)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
        Property Childs3 As HashSet(Of TChild3)
        Property Childs4 As HashSet(Of TChild4)
        Property Childs5 As HashSet(Of TChild5)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2, TChild3, TChild4)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
        Property Childs3 As HashSet(Of TChild3)
        Property Childs4 As HashSet(Of TChild4)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2, TChild3)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
        Property Childs3 As HashSet(Of TChild3)
    End Interface

    Public Interface INavigationChild(Of TChild1, TChild2)
        Property Childs1 As HashSet(Of TChild1)
        Property Childs2 As HashSet(Of TChild2)
    End Interface

End Namespace
