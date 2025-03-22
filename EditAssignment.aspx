<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditAssignment.aspx.cs" Inherits="Student_pannel.EditAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5">
        <h2 class="text-center">Edit Assignment</h2>
        <div class="card mb-4">
            <div class="card-body">
                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Assignment Title:</div>
                    <div class="col-md-8 col-12">
                        <asp:TextBox ID="TextBoxAssignmentTitle" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Assignment Description:</div>
                    <div class="col-md-8 col-12">
                        <asp:TextBox ID="TextBoxAssignmentDescription" runat="server" TextMode="MultiLine" Rows="4" class="form-control" required></asp:TextBox>
                    </div>
                </div>
                <div class="text-center">
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" class="btn btn-primary" OnClick="ButtonUpdate_Click" />
                </div>
                <div class="text-center mt-3">
                    <asp:Label ID="LabelStatus" runat="server" class="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
