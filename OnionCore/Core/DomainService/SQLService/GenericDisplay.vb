Imports System.Reflection

Public Module GenericDisplay
    Public Sub DisplayGenericType(ByVal t As Type)

        Console.WriteLine(vbCrLf & t.ToString())
        Console.WriteLine("   Is this a generic type? " & t.IsGenericType)
        Console.WriteLine("   Is this a generic type definition? " & t.IsGenericTypeDefinition)

        ' Get the generic type parameters or type arguments.
        Dim typeParameters() As Type = t.GetGenericArguments()
        Console.WriteLine("   List {0} type arguments:", typeParameters.Length)

        For Each tParam As Type In typeParameters
            If tParam.IsGenericParameter Then DisplayGenericParameter(tParam) Else Console.WriteLine("      Type argument: {0}", tParam)
        Next
    End Sub

    Public Sub DisplayGenericParameter(ByVal tp As Type)
        Console.WriteLine("      Type parameter: {0} position {1}", tp.Name, tp.GenericParameterPosition)

        Dim classConstraint As Type = Nothing

        For Each iConstraint As Type In tp.GetGenericParameterConstraints()
            If iConstraint.IsInterface Then Console.WriteLine("         Interface constraint: {0}", iConstraint)
        Next

        If classConstraint IsNot Nothing Then Console.WriteLine("         Base type constraint: {0}", tp.BaseType) Else Console.WriteLine("         Base type constraint: None")

        Dim sConstraints As GenericParameterAttributes = tp.GenericParameterAttributes And GenericParameterAttributes.SpecialConstraintMask
        If sConstraints = GenericParameterAttributes.None Then
            Console.WriteLine("         No special constraints.")
        Else
            If GenericParameterAttributes.None <> (sConstraints And GenericParameterAttributes.DefaultConstructorConstraint) Then
                Console.WriteLine("         Must have a parameterless constructor.")
            End If
            If GenericParameterAttributes.None <> (sConstraints And GenericParameterAttributes.ReferenceTypeConstraint) Then
                Console.WriteLine("         Must be a reference type.")
            End If
            If GenericParameterAttributes.None <> (sConstraints And GenericParameterAttributes.NotNullableValueTypeConstraint) Then
                Console.WriteLine("         Must be a non-nullable value type.")
            End If
        End If
    End Sub

End Module
