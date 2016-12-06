Public Class VarGlob
    'Variable para la busqueda de entradas, salidas o embarques
    Public Shared busqueda As String = ""

    Public Shared idUsAutoriza As String = ""


    '####### PARAMETROS DE CONEXION A BDD DE PRODUCCION
    Public Shared UserDB As String = "sa"
    Public Shared PasswordDB As String = "Usuario01"
    Public Shared ServerDB As String = "SERVER2008\SERVER12"
    Public Shared DataBase As String = "MAIZ"
    '####################################################

    '###### PARAMETROS DE CONEXION A DBB DE PRUEBAS
    'Public Shared UserDB As String = "sa"
    'Public Shared PasswordDB As String = "Usuario01"
    'Public Shared ServerDB As String = "MSISTEMAS"
    'Public Shared DataBase As String = "MAIZ_ALFA"
    '####################################################


End Class
