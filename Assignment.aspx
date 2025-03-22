<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="Student_pannel.Assignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2 class="text-center">Assignment Details</h2>

       
        <div class="card mb-4">
            <div class="card-header bg-primary text-white">
                Teacher Section
            </div>
            <div class="card-body">
                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Assignment Title:</div>
                    <div class="col-md-8 col-12">
                        <asp:Label ID="LabelAssignmentTitle" runat="server" class="form-control-plaintext"></asp:Label>
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Description:</div>
                    <div class="col-md-8 col-12">
                        <asp:Label ID="LabelAssignmentDescription" runat="server" class="form-control-plaintext"></asp:Label>
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Due Date:</div>
                    <div class="col-md-8 col-12">
                        <asp:Label ID="LabelAssignmentDueDate" runat="server" class="form-control-plaintext"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

       
        <div class="card mb-4">
            <div class="card-header bg-primary text-white">
                Student Section
            </div>
            <div class="card-body">
                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Student Name:</div>
                    <div class="col-md-8 col-12">
                        <asp:TextBox ID="TextBoxStudentName" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Assignment Title:</div>
                    <div class="col-md-8 col-12">
                        <asp:TextBox ID="TextBoxStudentAssignmentTitle" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Assignment Description:</div>
                    <div class="col-md-8 col-12">
                        <asp:TextBox ID="TextBoxStudentAssignmentDescription" runat="server" TextMode="MultiLine" Rows="4" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-4 col-12 font-weight-bold">Upload Assignment:</div>
                    <div class="col-md-8 col-12">
                        <asp:FileUpload ID="FileUploadAssignment" runat="server" class="form-control-file" />
                    </div>
                </div>

                <div class="text-center">
                    <asp:Button ID="ButtonSubmitStudent" runat="server" Text="Submit" class="btn btn-primary" OnClick="ButtonSubmitStudent_Click" />
                </div>

                <div class="text-center mt-3">
                    <asp:Label ID="LabelStatus" runat="server" class="text-danger"></asp:Label>
                </div>
            </div>
        </div>

       
        <h4 class="text-center">Your Submissions</h4>
        <div class="table-responsive">
            <asp:GridView ID="GridViewSubmissions" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mt-4">
                <Columns>
                    <asp:BoundField DataField="AssignmentTitle" HeaderText="Assignment Title" />
                    <asp:BoundField DataField="AssignmentDescription" HeaderText="Description" />
                    <asp:BoundField DataField="AssignmentSubDate" HeaderText="Submission Date" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:TemplateField HeaderText="File Path">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDownload" runat="server" CssClass="btn btn-link" Text="Download" CommandArgument='<%# Eval("FilePath") %>' OnCommand="ButtonDownload_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SubmissionStatus" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
