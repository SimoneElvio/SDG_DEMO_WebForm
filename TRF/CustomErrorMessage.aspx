<%@ Page Language="C#" AutoEventWireup="True" Inherits="_CustomErrorMessage" Codebehind="CustomErrorMessage.aspx.cs" %>
<!DOCTYPE html>
<html lang="en">

<head runat="server">
    
    <title>
	SDG
    </title>

    <script type="text/javascript">
        window.history.forward(1);
    </script>

    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <style>
        .error-template {padding: 40px 15px;text-align: center;}
        .error-actions {margin-top:15px;margin-bottom:15px;}
        .error-actions .btn { margin-right:10px; }
        .error-details {}
    </style>
</head>

<body>
    

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="error-template">
                    <div style="margin: 0 auto 20px; width:90px;"><img src="Web/assets/images/logo.jpg" id="logo" alt="logo" style="width:90px;" /></div>
                    <h1>Oops!</h1>
                    <h2>Si &egrave; verificato un errore oppure la tua sessione &egrave; scaduta</h2>
                    <br /><br />
                    <div class="error-actions">
                        <a href="Web/Login/frm_LGN.aspx" class="btn btn-primary btn-lg"><span class="glyphicon glyphicon-home"></span> Torna al login </a>
                        <%--<a href="http://www.jquery2dotnet.com" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-envelope"></span> Contact Support </a>--%>
                    </div>
                    <br /><br />
                    <div class="error-details alert alert-danger">
                        <label id="LabelError" runat="server">Attenzione. Non sei autorizzato a visualizzare questa pagina.</label>    
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>

</html>