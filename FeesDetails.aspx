<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FeesDetails.aspx.cs" Inherits="Student_pannel.FeesDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .records-section {
            background-color: #f8f9fa;
            border: 1px solid #dee2e6;
            border-radius: 0.375rem;
            padding: 20px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            margin-top: 30px;
        }

        .table-responsive {
            max-height: 400px;
            overflow-y: auto;
        }

        .table {
            margin-bottom: 0;
        }

        .records-section h3 {
            margin-bottom: 20px;
            color: #495057;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card p-4 shadow-sm">
            <h2 class="text-center mb-4">Student Fee and Payment Details</h2>

            <form class="row g-3">
                <div class="col-md-6">
                    <label for="Username" class="form-label fw-bold">Username:</label>
                    <asp:TextBox ID="Username" runat="server" CssClass="form-control" />
                </div>

                <div class="col-md-6">
                    <label for="StudentID" class="form-label fw-bold">Student ID:</label>
                    <asp:TextBox ID="StudentID" runat="server" CssClass="form-control" />
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

                <div class="col-12 text-center">
                    <asp:Button ID="ButtonInsert" runat="server" Text="Insert Payment Details" CssClass="btn btn-primary mt-3" OnClick="ButtonInsert_Click" />
                </div>
            </form>

            <div class="records-section">
                <h3 class="text-center">Payment Records</h3>
                <div class="table-responsive">
                    <asp:GridView ID="GridViewFeeDetails" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False"
                        OnRowDeleting="GridViewFeeDetails_RowDeleting" DataKeyNames="StudentID">
                        <Columns>
                            <asp:TemplateField HeaderText="Username">
                                <ItemTemplate>
                                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Student ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentID" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Fee">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalFee" runat="server" Text='<%# Eval("TotalFee") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount Paid">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmountPaid" runat="server" Text='<%# Eval("AmountPaid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Payment Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblPaymentDate" runat="server" Text='<%# Eval("PaymentDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CssClass="btn btn-warning btn-sm"
                                        PostBackUrl='<%# Eval("StudentID", "EditFeesDetails.aspx?StudentID={0}") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger btn-sm"
                                        OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
