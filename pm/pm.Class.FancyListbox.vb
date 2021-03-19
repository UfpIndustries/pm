Public Class fancyListbox

    
    Inherits Windows.Forms.ListView
    Public ReadOnly Property IndexFromPoint(ByVal point As Point)
        Get
            Dim item As ListViewItem = Me.GetItemAt(point.X, point.Y)

            If item Is Nothing Then
                Return -1
            Else
                Return item.Index
            End If



        End Get
    End Property ' Returns the index of an item from a given point
    Public Property SelectedItem()      ' Gets/Sets the selected item 
        Get
            If Me.SelectedIndex = -1 Then Return Nothing

            For Each item In Me.SelectedItems
                Return item
            Next

            Return Nothing
        End Get

        Set(ByVal value)
            Me.SelectedIndex = value
        End Set
    End Property '   Retuns the SelectedItem    
    Public Property SelectedIndex()
        Get
            For Each item As ListViewItem In Me.CheckedItems
                Return item.Index
            Next

            Return Nothing
        End Get

        Set(ByVal value)
            Me.Items(value).selected = True
        End Set
    End Property '           Sets/Gets the selected index of the node
    Public Sub New()
        Me.View = Windows.Forms.View.Details '     Enter Details Mode
        Me.CheckBoxes = True '                     Display Check boxes
        Me.Columns.Add("Text") '                   Create a column so data will appear         
        Me.HeaderStyle = ColumnHeaderStyle.None '  Hide the Column Headers
        Me.Columns(0).Width = Me.Width '           Set the Column Width to the width of the control
        Me.MultiSelect = False        
        Me.FullRowSelect = True
    End Sub '                          Force the ListView to look like a Checked List Box
    Public Sub BoldEntry(ByVal ItemToFormat As String)

        ' Clear all bolded entries
        For i As Integer = 0 To Me.Items.Count - 1
            Dim listItem As ListViewItem = Me.Items(i)
            listItem.Font = New System.Drawing.Font(Me.Font, FontStyle.Regular)
        Next

        ' Bold the one we want
        For i As Integer = 0 To Me.Items.Count - 1
            Dim listItem As ListViewItem = Me.Items(i)
            If listItem.Text.ToLower = ItemToFormat.ToLower Then
                listItem.Font = New System.Drawing.Font(Me.Font, FontStyle.Bold)
            End If
        Next

        Me.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub '                    Bold the Specified item
    

    

End Class



