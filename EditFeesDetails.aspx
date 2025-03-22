<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditFeesDetails.aspx.cs" Inherits="Student_pannel.EditFeesDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card p-4 shadow-sm">
            <h2 class="text-center mb-4">Edit Fee Details</h2>

            <form class="row g-3">
                <div class="col-md-6">
                    <label for="Username" class="form-label fw-bold">Username:</label>
                    <asp:TextBox ID="Username" runat="server" CssClass="form-control" Enabled="false" />
                </div>

                <div class="col-md-6">
                    <label for="StudentID" class="form-label fw-bold">Student ID:</label>
                    <asp:TextBox ID="StudentID" runat="server" CssClass="form-control" Enabled="false" />
                </div>

                <div class="col-md-6">
                    <label for="TotalFee" class="form-label fw-bold">Total Fee:</label>
                    <asp:TextBox ID="TotalFee" runat="server" CssClass="form-control" />
                </div>

                <div class="col-md-6">
                    <label for="AmountPaid" class="form-label fw-bold">Amount Paid:</label>
                    <asp:TextBox ID="AmountPaid" runat="server" CssClass="form-control" />
                </div>

                <div class="col-md-6">
                    <label for="PaymentDate" class="form-label fw-bold">Payment Date:</label>
                    <asp:TextBox ID="PaymentDate" runat="server" CssClass="form-control" TextMode="Date" />
                </div>

                <div class="col-md-6">
                    <label for="Status" class="form-label fw-bold">Status:</label>
                    <asp:TextBox ID="Status" runat="server" CssClass="form-control" />
                </div>

                <div class="col-12 text-center">
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn btn-primary mt-3" OnClick="ButtonUpdate_Click" />
                     <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary mt-3" OnClick="ButtonCancel_Click" />
                </div>
            </form>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
