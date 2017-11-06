Module VarGlob
    'Variable para la busqueda de entradas, salidas o embarques
    Public busqueda As String = ""
    Public idUsAutoriza As String = ""
    Public IdUsuarioG As String

    '#################################################### 
    '###### PARAMETROS DE CONEXION A DBB DE PRUEBAS
    'Public UserDB As String = "sa"
    'Public PasswordDB As String = "Usuario01"
    'Public ServerDB As String = "MSISTEMAS"
    'Public DataBase As String
    'Public ConexionPrincipal As String '***** CONEXION A SERVIDOR PRUEBAS 
    'Public ConexionMaster As String = "Data Source=MSISTEMAS;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Usuario01" '*****  CONEXION MSISTEMAS
    'Function ConexionP(ByVal UsuCon As String) As String
    '    Try
    '        DataBase = IIf(Acceso.ConUsu = Nothing, ConexionBDD.ConUsu, Acceso.ConUsu)
    '        ConexionPrincipal = "Data Source=MSISTEMAS;Initial Catalog=" & DataBase & ";User ID=sa;Password=Usuario01"
    '        Acceso.ConUsu = Nothing
    '        ConexionBDD.ConUsu = Nothing
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return ConexionPrincipal
    'End Function
    '####################################################
    ''####### PARAMETROS DE CONEXION A BDD DE PRODUCCION
    Public UserDB As String = "sa"
    Public PasswordDB As String = "Usuario01"
    Public ServerDB As String = "SERVER2008\SERVER12"
    Public DataBase As String
    Public ConexionPrincipal As String '***** CONEXION A SERVIDOR PRINCIPAL 
    Public ConexionMaster As String = "Data Source=SERVER2008\SERVER12;Initial Catalog=master;User ID=sa;Password=Usuario01" '***** CONEXION A SERVIDOR PRINCIPAL 
    Function ConexionP(ByVal UsuCon As String) As String
        Try
            DataBase = IIf(Acceso.ConUsu = Nothing, ConexionBDD.ConUsu, Acceso.ConUsu)
            ConexionPrincipal = "Data Source=SERVER2008\SERVER12;Initial Catalog=" & DataBase & ";User ID=sa;Password=Usuario01"
            Acceso.ConUsu = Nothing
            ConexionBDD.ConUsu = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return ConexionPrincipal
    End Function

End Module
