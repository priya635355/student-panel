<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="Student_pannel.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card p-4 shadow-sm mx-auto" style="max-width: 600px;">
            <h3 class="text-center text-secondary mb-4">Personal Information</h3>

            <div class="mb-3">
                <label for="txtName" class="form-label fw-bold">Name:</label>
                <asp:TextBox ID="txtName" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtCourse" class="form-label fw-bold">Course:</label>
                <asp:TextBox ID="txtCourse" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtRollNumber" class="form-label fw-bold">Roll Number:</label>
                <asp:TextBox ID="txtRollNumber" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtUsername" class="form-label fw-bold">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label fw-bold">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtGender" class="form-label fw-bold">Gender:</label>
                <asp:TextBox ID="txtGender" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtAddress" class="form-label fw-bold">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtParentsName" class="form-label fw-bold">Parents Name:</label>
                <asp:TextBox ID="txtParentsName" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtParentsContact" class="form-label fw-bold">Parents Contact:</label>
                <asp:TextBox ID="txtParentsContact" runat="server" Text="N/A" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success mx-2" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger mx-2" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>

   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
