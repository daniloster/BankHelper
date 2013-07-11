<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BoletoWebAppDemo._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
            <asp:Panel ID="panelDados" runat="server">
                <h3>Dados do Boleto</h3>
                <table border="0">
                    <tr>
                        <td>Vencimento:
                        </td>
                        <td>
                            <asp:TextBox ID="txtVencimento" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Valor:
                        </td>
                        <td>
                            <asp:TextBox ID="txtValorBoleto" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Nosso Número:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNossoNumeroBoleto" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Número Documento:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNumeroDocumentoBoleto" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <h3>Dados do Cendente</h3>
                <table border="0">
                    <tr>
                        <td>CPF/CNPJ:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCPFCNPJ" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Código:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodigoCedente" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Nome:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNomeCedente" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Agência:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAgenciaCendente" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Conta:
                        </td>
                        <td>
                            <asp:TextBox ID="txtContaCedente" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <h3>Dados do Sacado</h3>
                <table border="0">
                    <tr>
                        <td>CPF/CNPJ:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCPFCNPJSacado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Nome:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNomeSacado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Endereço:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnderecoSacado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Bairro:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBairroSacado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Cidade:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCidadeSacado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>CEP:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCEPSacado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>UF:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUFSacado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="panelBoleto" runat="server"></asp:Panel>
            <asp:Button ID="BtnGerarBoleto" runat="server" Text="Imprimir " OnClick="BtnGerarBoleto_Click" />
            <asp:Button ID="BtnGerarBoletoFactory" runat="server" Text="Imprimir Factory" OnClick="BtnGerarBoletoFactory_Click" />
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Getting Started</h5>
            ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
        </li>
        <li class="two">
            <h5>Add NuGet packages and jump-start your coding</h5>
            NuGet makes it easy to install and update free libraries and tools.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
        </li>
        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
        </li>
    </ol>
</asp:Content>