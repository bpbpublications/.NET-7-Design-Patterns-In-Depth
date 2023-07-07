<%@ Page language="c#" Codebehind="Inquiry.aspx.cs" AutoEventWireup="false" Inherits="Inquiry" %>
<HTML>
   <body>
      <form id="Form1" >
         کد ملی:<asp:textbox id="txtNationalCode"  />
         <p />
         <asp:button id="btnInquiry" text="Inquiry" OnClick="btnInquiry_Click"  />
         <p />
         <span id="mySpan" ></span>
      </form>
   </body>
</HTML>