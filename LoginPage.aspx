<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Student_pannel.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
   
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center align-items-center vh-100">
            <div class="card p-4 shadow-sm" style="width: 100%; max-width: 350px;">
                <h2 class="text-center mb-4">Login</h2>
                <div class="form-group mb-3">
                    <label for="txtUsername" class="form-label">Username:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group mb-3">
                    <label for="txtPassword" class="form-label">Password:</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success w-100" OnClick="btnLogin_Click" />
                <div class="text-center mt-3">
                    <p>Contact Information: <a href="mailto:support@yourdomain.com">support@yourdomain.com</a></p>
                </div>
            </div>
        </div>
    </form>

   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
