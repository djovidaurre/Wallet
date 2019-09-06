<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterTransaction.aspx.cs" Inherits="WebWallet.Transaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <asp:Label Id="lbl_IdWallet" Text="Id Wallet:" runat="server" ></asp:Label>
            <asp:TextBox Id="txt_IdWallet" runat="server"></asp:TextBox>
             <asp:Button ID="btn_Consultar" Text="Consult" runat="server" OnClick="btn_Consultar_Click" />
         </div>
         <div>
            <asp:Label Id="lbl_IdTypeTransaction" Text="Id Transaction:" runat="server" ></asp:Label>
            <asp:TextBox Id="txt_IdTypeTransaction" runat="server"></asp:TextBox>
         </div>
         <div>
            <asp:Label Id="lbl_Amount" Text="Id Amount:" runat="server" ></asp:Label>
            <asp:TextBox Id="txt_Amount" runat="server"></asp:TextBox>
         </div>
            <asp:Button ID="bnt_Register" Text="Register"  runat="server" OnClick="bnt_Registro_Click" />
         <div>
            
             <asp:Label Id="lbl_balance" Text="Closing Balance:" runat="server" ></asp:Label>
         </div>
         <div>
             <p>Transaction Detail</p>  
             <asp:DataGrid ID="dg_transaccion" runat="server"></asp:DataGrid>
         </div>
    </form>
</body>
</html>
