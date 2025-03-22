<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Attendence.aspx.cs" Inherits="Student_pannel.Attendence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card p-4 shadow-sm">
            <h2 class="text-center mb-4">Attendance Tracking System</h2>
            
           
            <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold" Visible="false"></asp:Label>
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success fw-bold" Visible="false"></asp:Label>

          
            <form class="row g-3">
                <div class="col-md-6">
                    <label for="txtStudentName" class="form-label fw-bold">Student Name:</label>
                    <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control" />
                </div>

                <div class="col-md-6">
                    <label for="AttendanceDate" class="form-label fw-bold">Date:</label>
                    <asp:TextBox ID="AttendanceDate" runat="server" CssClass="form-control" TextMode="Date" />
                </div>

                <div class="col-md-6">
                    <label for="ddlStatus" class="form-label fw-bold">Status:</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Present" Value="Present"></asp:ListItem>
                        <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-md-12 text-center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Mark Attendance" CssClass="btn btn-success mt-3" OnClick="btnSubmit_Click" />
                </div>
            </form>

           
            <asp:GridView ID="gvAttendance" runat="server" CssClass="table table-striped table-bordered mt-4" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                    <asp:BoundField DataField="AttendanceDate" HeaderText="Date" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>

           
            <div class="mt-3">
                <asp:Label ID="lblTotalClasses" runat="server" Text="Total Classes: 0" CssClass="d-block"></asp:Label>
                <asp:Label ID="lblPresentClasses" runat="server" Text="Present Classes: 0" CssClass="d-block"></asp:Label>
                <asp:Label ID="lblAttendancePercentage" runat="server" Text="Attendance Percentage: 0.00%" CssClass="d-block"></asp:Label>
            </div>
        </div>
    </div>

  
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
