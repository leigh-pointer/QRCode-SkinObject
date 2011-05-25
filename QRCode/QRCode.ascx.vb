' Copyright (c) 2010 Subzero Solutions
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.

Imports DotNetNuke


Namespace SubzeroSolutions.DotNetNuke.SkinObjects
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The ViewQRCode class displays the content
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Partial Class QRCode
        Inherits UI.Skins.SkinObjectBase

#Region "Constants"
        Const GOOGLECHARTAPI As String = "http://chart.apis.google.com/chart?chs={0}x{0}&chf=a,s,000000&cht=qr&choe=ISO-8859-1&chld=|{1}&chl={2}"
#End Region

#Region "Properties"
        Private _URL As String = String.Empty        Private _Size As Integer = 150        Private _Margin As Integer = 5
        Public Property URL() As String
        	Get
        		Return _URL
        	End Get
        	Set(ByVal Value As String)
        		_URL = Value
        	End Set
        End Property


        Public Property Size() As Integer
            Get
                Return _Size
            End Get
            Set(ByVal Value As Integer)
                _Size = Value
            End Set
        End Property

        Public Property Margin() As Integer
            Get
                Return _Margin
            End Get
            Set(ByVal Value As Integer)
                _Margin = Value
            End Set
        End Property


#End Region

#Region "Event Handlers"
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Try
                Dim strURLToRender As String = String.Empty
                If _URL.Length Then
                    strURLToRender = _URL
                Else
                    strURLToRender = Global.DotNetNuke.Common.NavigateURL()
                End If
                With qrImage
                    .ImageUrl = String.Format(GOOGLECHARTAPI, Size, Margin, strURLToRender)
                    .AlternateText = strURLToRender
                    .ToolTip = strURLToRender
                End With

            Catch exc As Exception        'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Page_Load runs when the control is loaded
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

#End Region


    End Class

End Namespace