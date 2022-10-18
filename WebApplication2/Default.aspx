<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
<p>Thank you for choosing DHR Health, Please let us know how your visit went</p>
    <div class="container">
       <div class="form-content">
            <div class="form-group-input">
                <h4>Patient Details</h4>

                <div class="form-input">
                    <label>First Name</label>
                    <asp:TextBox ID="firstName" autocomplete="off" runat="server" />
                </div>
                <div class="form-input">
                    <label>Last Name</label>
                    <asp:TextBox ID="lastName" autocomplete="off" runat="server" />
          
                </div>
                <div class="form-input">
                    <label>Phone Number</label>
                    <asp:TextBox ID="phoneNum" class="number" placeholder="Ex. 956-362-8677" autocomplete="off" runat="server" />
                </div>
            </div>

            <div class="form-dropdown-group">
                <h4>Satisfaction Assesment</h4>
                <div class="form-dropdown ">
                  <label>1. Courtesy of staff who admitted you</label>
                     <asp:dropdownlist runat="server" id="Dropdownlist1">
                         <asp:listitem text="Select an option" value="0"></asp:listitem>
                         <asp:listitem text="Happy" value="3"></asp:listitem>
                         <asp:listitem text="Neutral" value="2"></asp:listitem>
                         <asp:listitem text="Unhappy" value="1"></asp:listitem>
                    </asp:dropdownlist>
                </div>
                <div class="form-dropdown">
                  <label>2. Room cleanliness</label>
                     <asp:dropdownlist runat="server" id="Dropdownlist2"> 
                         <asp:listitem text="Select an option" value="0"></asp:listitem>
                         <asp:listitem text="Happy" value="3"></asp:listitem>
                         <asp:listitem text="Neutral" value="2"></asp:listitem>
                         <asp:listitem text="Unhappy" value="1"></asp:listitem>
                    </asp:dropdownlist>
                </div>
                <div class="form-dropdown">
                  <label>3. Noise level in and around your room</label>
                     <asp:dropdownlist runat="server" id="Dropdownlist3"> 
                         <asp:listitem text="Select an option" value="0"></asp:listitem>
                         <asp:listitem text="Happy" value="3"></asp:listitem>
                         <asp:listitem text="Neutral" value="2"></asp:listitem>
                         <asp:listitem text="Unhappy" value="1"></asp:listitem>
                    </asp:dropdownlist>
                </div>
                <div class="form-dropdown">
                  <label> 4. Quality of food</label>
                     <asp:dropdownlist runat="server" id="Dropdownlist4"> 
                         <asp:listitem text="Select an option" value="0"></asp:listitem>
                         <asp:listitem text="Happy" value="3"></asp:listitem>
                         <asp:listitem text="Neutral" value="2"></asp:listitem>
                         <asp:listitem text="Unhappy" value="1"></asp:listitem>
                    </asp:dropdownlist>
                </div>
                <div class="form-dropdown">
                  <label>5. Friendliness/courtesy of nurses</label>
                     <asp:dropdownlist runat="server" id="Dropdownlist5"> 
                         <asp:listitem text="Select an option" value="0"></asp:listitem>
                         <asp:listitem text="Happy" value="3"></asp:listitem>
                         <asp:listitem text="Neutral" value="2"></asp:listitem>
                         <asp:listitem text="Unhappy" value="1"></asp:listitem>
                    </asp:dropdownlist>
                </div>
            </div>
            <asp:Button  ID="btnEvent" Text="Submit" OnClick="btnEvent_Click" runat="server"/>
       </div>
    </div>         
    <h4>
        <asp:Literal ID="ltConnectionMessage" runat="server" />
    </h4>
</asp:Content>
