<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTestWs.aspx.cs" Inherits="TRF.Web.WebForm1" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #Select1 {
            width: 145px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        TEST WebServices
        <label >wsTRFRichiesta.asmx</label>
        <br />
        <br />Metodo&nbsp;&nbsp;
        <asp:DropDownList ID="DdlMetodo" runat="server" AutoPostBack=true></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Test evento
        <asp:DropDownList ID="DdlEvento" runat="server"></asp:DropDownList><br />
        <br />
        Input Id missione
        <input id="TextIdMissione" type="text" runat="server" value="IdMissione1"  /><br />
        <div id="divUser_Dominio" runat="server" visible="false">
            <label >User name windows</label> <input id="TextUserName" type="text" runat="server" value="svalerio"  /><br />
            <label >Domain</label> <input id="TextDomain" type="text" runat="server" value="sdgitaly"  />
        </div>
        <br />
        <input id="ButtonOk" type="button" value="Esegui" runat="server" />
        <br /> <br />
        <label>Result Data</label>        
        <textarea id="TextAreaResultData" runat="server" rows="30" cols="60"></textarea>
        <label>Result Schema</label>    
        <textarea id="TextAreaResultSchema" runat="server" rows="30" cols="60"></textarea>
    </div>
    </form>
</body>
</html>
