﻿#ExternalChecksum("..\..\..\..\..\..\Controls\Plugins\SystemMaintenance\ctlSystemMaintenance_Main.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","C84C610EA230A1BB7EBFB3DC9C6F8737")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''ctlSystemMaintenance_Main
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class ctlSystemMaintenance_Main
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\..\..\..\..\Controls\Plugins\SystemMaintenance\ctlSystemMaintenance_Main.xaml",13)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents StackPanel1 As System.Windows.Controls.StackPanel
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\..\Controls\Plugins\SystemMaintenance\ctlSystemMaintenance_Main.xaml",14)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents Label1 As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\..\Controls\Plugins\SystemMaintenance\ctlSystemMaintenance_Main.xaml",15)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents cmbTypeCode As System.Windows.Controls.ComboBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\..\..\..\Controls\Plugins\SystemMaintenance\ctlSystemMaintenance_Main.xaml",17)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents dgTypeCode As System.Windows.Controls.DataGrid
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/Section8System;component/controls/plugins/systemmaintenance/ctlsystemmaintenance"& _ 
                "_main.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\..\..\..\Controls\Plugins\SystemMaintenance\ctlSystemMaintenance_Main.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.StackPanel1 = CType(target,System.Windows.Controls.StackPanel)
            Return
        End If
        If (connectionId = 2) Then
            Me.Label1 = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 3) Then
            Me.cmbTypeCode = CType(target,System.Windows.Controls.ComboBox)
            Return
        End If
        If (connectionId = 4) Then
            Me.dgTypeCode = CType(target,System.Windows.Controls.DataGrid)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

