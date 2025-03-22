<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Student_pannel.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="alert alert-info welcome">
            <h2>Welcome, <asp:Label ID="lblStudentName" runat="server" Text="Priya Vishvkarma"></asp:Label>!</h2>
        </div>

        <div class="card dashboard mb-4">
            <div class="card-body">
                <h3 class="card-title">Dashboard Overview</h3>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <div class="card stat text-center">
                            <div class="card-body">
                                <h4 class="card-title">Attendance Percentage</h4>
                                <asp:Label ID="lblTotalClasses" runat="server" Text="Total Classes: 0"></asp:Label><br />
                                <asp:Label ID="lblPresentClasses" runat="server" Text="Present Classes: 0"></asp:Label><br />
                                <asp:Label ID="lblAttendancePercentage" runat="server" Text="Attendance Percentage"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 mb-4">
                        <div class="card stat text-center">
                            <div class="card-body">
                                <h4 class="card-title">Fees Status</h4>
                                <asp:Label ID="lblFeesStatus" runat="server" Text="Fees Status"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 mb-4">
                        <div class="card stat text-center">
                            <div class="card-body">
                                <h4 class="card-title">Assignments Status</h4>
                                <asp:Label ID="lblAssignment" runat="server" Text="Assignments Status"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6 mb-4">
                <div class="card section">
                    <div class="card-body">
                        <h3>Personal Information</h3>
                        <p>Name: <asp:Label ID="lblName" runat="server" Text="Student Name"></asp:Label></p>
                        <p>Roll Number: <asp:Label ID="lblRollNumber" runat="server" Text="Roll Number"></asp:Label></p>
                        <p>Course: <asp:Label ID="lblCourse" runat="server" Text="Course Name"></asp:Label></p>
                    </div>
                </div>
            </div>

            <div class="col-md-6 mb-4">
                <div class="card section">
                    <div class="card-body">
                        <h3>Fees Details</h3>
                        <p>Total Fees: <asp:Label ID="lblTotalFees" runat="server" Text="Total Fees"></asp:Label></p>
                        <p>Amount Paid: <asp:Label ID="lblAmountPaid" runat="server" Text="Amount Paid"></asp:Label></p>
                        <p>Due Amount: <asp:Label ID="lblDueAmount" runat="server" Text="Due Amount"></asp:Label></p>
                    </div>
                </div>
            </div>

            <div class="col-md-6 mb-4">
                <div class="card section">
                    <div class="card-body">
                        <h3>Assignment</h3>
                        <p>Assignment Title: <asp:Label ID="lblAssignmentTitle" runat="server" Text="Assignment Title:"></asp:Label></p>
                        <p>Due Date: <asp:Label ID="lblDueDate" runat="server" Text="Due Date:"></asp:Label></p>
                        <p>Submission Method: <asp:Label ID="lblSubmissionMethod" runat="server" Text="Submission Method:"></asp:Label></p>
                    </div>
                </div>
            </div>

            <div class="col-md-6 mb-4">
                <div class="card section">
                    <div class="card-body">
                        <h3>Attendance Information</h3>
                        <asp:Label ID="Label1" runat="server" Text="Total Classes: 0"></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" Text="Present Classes: 0"></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text="Attendance Percentage"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="col-md-12 mb-4">
                <div class="card section">
                    <div class="card-body">
                        <h3>Notifications</h3>
                        <asp:GridView ID="gvNotifications" runat="server" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField HeaderText="Message" DataField="Message" />
                                <asp:BoundField HeaderText="Date" DataField="Date" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
   
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
