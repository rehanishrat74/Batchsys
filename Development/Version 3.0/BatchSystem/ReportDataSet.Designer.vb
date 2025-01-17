﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.1433
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



'''<summary>
'''Represents a strongly typed in-memory cache of data.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
 Global.System.Serializable(),  _
 Global.System.ComponentModel.DesignerCategoryAttribute("code"),  _
 Global.System.ComponentModel.ToolboxItem(true),  _
 Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"),  _
 Global.System.Xml.Serialization.XmlRootAttribute("ReportDataSet"),  _
 Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class ReportDataSet
    Inherits Global.System.Data.DataSet
    
    Private tableSerialReport As SerialReportDataTable
    
    Private _schemaSerializationMode As Global.System.Data.SchemaSerializationMode = Global.System.Data.SchemaSerializationMode.IncludeSchema
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub New()
        MyBase.New
        Me.BeginInit
        Me.InitClass
        Dim schemaChangedHandler As Global.System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler MyBase.Relations.CollectionChanged, schemaChangedHandler
        Me.EndInit
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context, false)
        If (Me.IsBinarySerialized(info, context) = true) Then
            Me.InitVars(false)
            Dim schemaChangedHandler1 As Global.System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
            AddHandler Me.Tables.CollectionChanged, schemaChangedHandler1
            AddHandler Me.Relations.CollectionChanged, schemaChangedHandler1
            Return
        End If
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(String)),String)
        If (Me.DetermineSchemaSerializationMode(info, context) = Global.System.Data.SchemaSerializationMode.IncludeSchema) Then
            Dim ds As Global.System.Data.DataSet = New Global.System.Data.DataSet
            ds.ReadXmlSchema(New Global.System.Xml.XmlTextReader(New Global.System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("SerialReport")) Is Nothing) Then
                MyBase.Tables.Add(New SerialReportDataTable(ds.Tables("SerialReport")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, Global.System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXmlSchema(New Global.System.Xml.XmlTextReader(New Global.System.IO.StringReader(strSchema)))
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As Global.System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.Browsable(false),  _
     Global.System.ComponentModel.DesignerSerializationVisibility(Global.System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property SerialReport() As SerialReportDataTable
        Get
            Return Me.tableSerialReport
        End Get
    End Property
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.BrowsableAttribute(true),  _
     Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Visible)>  _
    Public Overrides Property SchemaSerializationMode() As Global.System.Data.SchemaSerializationMode
        Get
            Return Me._schemaSerializationMode
        End Get
        Set
            Me._schemaSerializationMode = value
        End Set
    End Property
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Tables() As Global.System.Data.DataTableCollection
        Get
            Return MyBase.Tables
        End Get
    End Property
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Relations() As Global.System.Data.DataRelationCollection
        Get
            Return MyBase.Relations
        End Get
    End Property
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub InitializeDerivedDataSet()
        Me.BeginInit
        Me.InitClass
        Me.EndInit
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Overrides Function Clone() As Global.System.Data.DataSet
        Dim cln As ReportDataSet = CType(MyBase.Clone,ReportDataSet)
        cln.InitVars
        cln.SchemaSerializationMode = Me.SchemaSerializationMode
        Return cln
    End Function
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As Global.System.Xml.XmlReader)
        If (Me.DetermineSchemaSerializationMode(reader) = Global.System.Data.SchemaSerializationMode.IncludeSchema) Then
            Me.Reset
            Dim ds As Global.System.Data.DataSet = New Global.System.Data.DataSet
            ds.ReadXml(reader)
            If (Not (ds.Tables("SerialReport")) Is Nothing) Then
                MyBase.Tables.Add(New SerialReportDataTable(ds.Tables("SerialReport")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, Global.System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXml(reader)
            Me.InitVars
        End If
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function GetSchemaSerializable() As Global.System.Xml.Schema.XmlSchema
        Dim stream As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream
        Me.WriteXmlSchema(New Global.System.Xml.XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return Global.System.Xml.Schema.XmlSchema.Read(New Global.System.Xml.XmlTextReader(stream), Nothing)
    End Function
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars()
        Me.InitVars(true)
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars(ByVal initTable As Boolean)
        Me.tableSerialReport = CType(MyBase.Tables("SerialReport"),SerialReportDataTable)
        If (initTable = true) Then
            If (Not (Me.tableSerialReport) Is Nothing) Then
                Me.tableSerialReport.InitVars
            End If
        End If
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "ReportDataSet"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/ReportDataSet.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = Global.System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableSerialReport = New SerialReportDataTable
        MyBase.Tables.Add(Me.tableSerialReport)
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeSerialReport() As Boolean
        Return false
    End Function
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As Global.System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = Global.System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Shared Function GetTypedDataSetSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
        Dim ds As ReportDataSet = New ReportDataSet
        Dim type As Global.System.Xml.Schema.XmlSchemaComplexType = New Global.System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As Global.System.Xml.Schema.XmlSchemaSequence = New Global.System.Xml.Schema.XmlSchemaSequence
        Dim any As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable
        If xs.Contains(dsSchema.TargetNamespace) Then
            Dim s1 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream
            Dim s2 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream
            Try 
                Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                dsSchema.Write(s1)
                Dim schemas As Global.System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator
                Do While schemas.MoveNext
                    schema = CType(schemas.Current,Global.System.Xml.Schema.XmlSchema)
                    s2.SetLength(0)
                    schema.Write(s2)
                    If (s1.Length = s2.Length) Then
                        s1.Position = 0
                        s2.Position = 0
                        
                        Do While ((s1.Position <> s1.Length)  _
                                    AndAlso (s1.ReadByte = s2.ReadByte))
                            
                            
                        Loop
                        If (s1.Position = s1.Length) Then
                            Return type
                        End If
                    End If
                    
                Loop
            Finally
                If (Not (s1) Is Nothing) Then
                    s1.Close
                End If
                If (Not (s2) Is Nothing) Then
                    s2.Close
                End If
            End Try
        End If
        xs.Add(dsSchema)
        Return type
    End Function
    
    Public Delegate Sub SerialReportRowChangeEventHandler(ByVal sender As Object, ByVal e As SerialReportRowChangeEvent)
    
    '''<summary>
    '''Represents the strongly named DataTable class.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     Global.System.Serializable(),  _
     Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class SerialReportDataTable
        Inherits Global.System.Data.DataTable
        Implements Global.System.Collections.IEnumerable
        
        Private columnSerials As Global.System.Data.DataColumn
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "SerialReport"
            Me.BeginInit
            Me.InitClass
            Me.EndInit
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal table As Global.System.Data.DataTable)
            MyBase.New
            Me.TableName = table.TableName
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            Me.InitVars
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property SerialsColumn() As Global.System.Data.DataColumn
            Get
                Return Me.columnSerials
            End Get
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Default ReadOnly Property Item(ByVal index As Integer) As SerialReportRow
            Get
                Return CType(Me.Rows(index),SerialReportRow)
            End Get
        End Property
        
        Public Event SerialReportRowChanging As SerialReportRowChangeEventHandler
        
        Public Event SerialReportRowChanged As SerialReportRowChangeEventHandler
        
        Public Event SerialReportRowDeleting As SerialReportRowChangeEventHandler
        
        Public Event SerialReportRowDeleted As SerialReportRowChangeEventHandler
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddSerialReportRow(ByVal row As SerialReportRow)
            Me.Rows.Add(row)
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddSerialReportRow(ByVal Serials As String) As SerialReportRow
            Dim rowSerialReportRow As SerialReportRow = CType(Me.NewRow,SerialReportRow)
            Dim columnValuesArray() As Object = New Object() {Serials}
            rowSerialReportRow.ItemArray = columnValuesArray
            Me.Rows.Add(rowSerialReportRow)
            Return rowSerialReportRow
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As Global.System.Collections.IEnumerator Implements Global.System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As Global.System.Data.DataTable
            Dim cln As SerialReportDataTable = CType(MyBase.Clone,SerialReportDataTable)
            cln.InitVars
            Return cln
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As Global.System.Data.DataTable
            Return New SerialReportDataTable
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnSerials = MyBase.Columns("Serials")
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnSerials = New Global.System.Data.DataColumn("Serials", GetType(String), Nothing, Global.System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnSerials)
            Me.columnSerials.MaxLength = 255
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewSerialReportRow() As SerialReportRow
            Return CType(Me.NewRow,SerialReportRow)
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As Global.System.Data.DataRowBuilder) As Global.System.Data.DataRow
            Return New SerialReportRow(builder)
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As Global.System.Type
            Return GetType(SerialReportRow)
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.SerialReportRowChangedEvent) Is Nothing) Then
                RaiseEvent SerialReportRowChanged(Me, New SerialReportRowChangeEvent(CType(e.Row,SerialReportRow), e.Action))
            End If
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.SerialReportRowChangingEvent) Is Nothing) Then
                RaiseEvent SerialReportRowChanging(Me, New SerialReportRowChangeEvent(CType(e.Row,SerialReportRow), e.Action))
            End If
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.SerialReportRowDeletedEvent) Is Nothing) Then
                RaiseEvent SerialReportRowDeleted(Me, New SerialReportRowChangeEvent(CType(e.Row,SerialReportRow), e.Action))
            End If
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.SerialReportRowDeletingEvent) Is Nothing) Then
                RaiseEvent SerialReportRowDeleting(Me, New SerialReportRowChangeEvent(CType(e.Row,SerialReportRow), e.Action))
            End If
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveSerialReportRow(ByVal row As SerialReportRow)
            Me.Rows.Remove(row)
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
            Dim type As Global.System.Xml.Schema.XmlSchemaComplexType = New Global.System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As Global.System.Xml.Schema.XmlSchemaSequence = New Global.System.Xml.Schema.XmlSchemaSequence
            Dim ds As ReportDataSet = New ReportDataSet
            Dim any1 As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny
            any1.Namespace = "http://www.w3.org/2001/XMLSchema"
            any1.MinOccurs = New Decimal(0)
            any1.MaxOccurs = Decimal.MaxValue
            any1.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any1)
            Dim any2 As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny
            any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
            any2.MinOccurs = New Decimal(1)
            any2.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any2)
            Dim attribute1 As Global.System.Xml.Schema.XmlSchemaAttribute = New Global.System.Xml.Schema.XmlSchemaAttribute
            attribute1.Name = "namespace"
            attribute1.FixedValue = ds.Namespace
            type.Attributes.Add(attribute1)
            Dim attribute2 As Global.System.Xml.Schema.XmlSchemaAttribute = New Global.System.Xml.Schema.XmlSchemaAttribute
            attribute2.Name = "tableTypeName"
            attribute2.FixedValue = "SerialReportDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable
            If xs.Contains(dsSchema.TargetNamespace) Then
                Dim s1 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream
                Dim s2 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream
                Try 
                    Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                    dsSchema.Write(s1)
                    Dim schemas As Global.System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator
                    Do While schemas.MoveNext
                        schema = CType(schemas.Current,Global.System.Xml.Schema.XmlSchema)
                        s2.SetLength(0)
                        schema.Write(s2)
                        If (s1.Length = s2.Length) Then
                            s1.Position = 0
                            s2.Position = 0
                            
                            Do While ((s1.Position <> s1.Length)  _
                                        AndAlso (s1.ReadByte = s2.ReadByte))
                                
                                
                            Loop
                            If (s1.Position = s1.Length) Then
                                Return type
                            End If
                        End If
                        
                    Loop
                Finally
                    If (Not (s1) Is Nothing) Then
                        s1.Close
                    End If
                    If (Not (s2) Is Nothing) Then
                        s2.Close
                    End If
                End Try
            End If
            xs.Add(dsSchema)
            Return type
        End Function
    End Class
    
    '''<summary>
    '''Represents strongly named DataRow class.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class SerialReportRow
        Inherits Global.System.Data.DataRow
        
        Private tableSerialReport As SerialReportDataTable
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As Global.System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableSerialReport = CType(Me.Table,SerialReportDataTable)
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Serials() As String
            Get
                Try 
                    Return CType(Me(Me.tableSerialReport.SerialsColumn),String)
                Catch e As Global.System.InvalidCastException
                    Throw New Global.System.Data.StrongTypingException("The value for column 'Serials' in table 'SerialReport' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSerialReport.SerialsColumn) = value
            End Set
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsSerialsNull() As Boolean
            Return Me.IsNull(Me.tableSerialReport.SerialsColumn)
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetSerialsNull()
            Me(Me.tableSerialReport.SerialsColumn) = Global.System.Convert.DBNull
        End Sub
    End Class
    
    '''<summary>
    '''Row event argument class
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class SerialReportRowChangeEvent
        Inherits Global.System.EventArgs
        
        Private eventRow As SerialReportRow
        
        Private eventAction As Global.System.Data.DataRowAction
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As SerialReportRow, ByVal action As Global.System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As SerialReportRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Action() As Global.System.Data.DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class

Namespace ReportDataSetTableAdapters
    
    '''<summary>
    '''Represents the connection and commands used to retrieve and save data.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     Global.System.ComponentModel.DesignerCategoryAttribute("code"),  _
     Global.System.ComponentModel.ToolboxItem(true),  _
     Global.System.ComponentModel.DataObjectAttribute(true),  _
     Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner"& _ 
        ", Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),  _
     Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>  _
    Partial Public Class SerialReportTableAdapter
        Inherits Global.System.ComponentModel.Component
        
        Private WithEvents _adapter As Global.System.Data.OleDb.OleDbDataAdapter
        
        Private _connection As Global.System.Data.OleDb.OleDbConnection
        
        Private _commandCollection() As Global.System.Data.OleDb.OleDbCommand
        
        Private _clearBeforeFill As Boolean
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.ClearBeforeFill = true
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private ReadOnly Property Adapter() As Global.System.Data.OleDb.OleDbDataAdapter
            Get
                If (Me._adapter Is Nothing) Then
                    Me.InitAdapter
                End If
                Return Me._adapter
            End Get
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Property Connection() As Global.System.Data.OleDb.OleDbConnection
            Get
                If (Me._connection Is Nothing) Then
                    Me.InitConnection
                End If
                Return Me._connection
            End Get
            Set
                Me._connection = value
                If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                    Me.Adapter.InsertCommand.Connection = value
                End If
                If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                    Me.Adapter.DeleteCommand.Connection = value
                End If
                If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                    Me.Adapter.UpdateCommand.Connection = value
                End If
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    If (Not (Me.CommandCollection(i)) Is Nothing) Then
                        CType(Me.CommandCollection(i),Global.System.Data.OleDb.OleDbCommand).Connection = value
                    End If
                    i = (i + 1)
                Loop
            End Set
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected ReadOnly Property CommandCollection() As Global.System.Data.OleDb.OleDbCommand()
            Get
                If (Me._commandCollection Is Nothing) Then
                    Me.InitCommandCollection
                End If
                Return Me._commandCollection
            End Get
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property ClearBeforeFill() As Boolean
            Get
                Return Me._clearBeforeFill
            End Get
            Set
                Me._clearBeforeFill = value
            End Set
        End Property
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitAdapter()
            Me._adapter = New Global.System.Data.OleDb.OleDbDataAdapter
            Dim tableMapping As Global.System.Data.Common.DataTableMapping = New Global.System.Data.Common.DataTableMapping
            tableMapping.SourceTable = "Table"
            tableMapping.DataSetTable = "SerialReport"
            tableMapping.ColumnMappings.Add("Serials", "Serials")
            Me._adapter.TableMappings.Add(tableMapping)
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitConnection()
            Me._connection = New Global.System.Data.OleDb.OleDbConnection
            Me._connection.ConnectionString = Global.BatchSystem.My.MySettings.Default.BatchSystemConnectionString
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitCommandCollection()
            Me._commandCollection = New Global.System.Data.OleDb.OleDbCommand(0) {}
            Me._commandCollection(0) = New Global.System.Data.OleDb.OleDbCommand
            Me._commandCollection(0).Connection = Me.Connection
            Me._commandCollection(0).CommandText = "SELECT        Serials"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"FROM            SerialReport"
            Me._commandCollection(0).CommandType = Global.System.Data.CommandType.Text
        End Sub
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),  _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, true)>  _
        Public Overloads Overridable Function Fill(ByVal dataTable As ReportDataSet.SerialReportDataTable) As Integer
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            If (Me.ClearBeforeFill = true) Then
                dataTable.Clear
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Return returnValue
        End Function
        
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),  _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], true)>  _
        Public Overloads Overridable Function GetData() As ReportDataSet.SerialReportDataTable
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            Dim dataTable As ReportDataSet.SerialReportDataTable = New ReportDataSet.SerialReportDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace
