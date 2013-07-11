using BankHelper;
using BoletoNet;
using System;
using System.Globalization;
using System.Web.UI;

namespace BoletoWebAppDemo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtVencimento.Text = new DateTime(2009, 3, 6).ToString("dd/MM/yyyy");
                txtValorBoleto.Text = "656,40";
                txtNumeroDocumentoBoleto.Text = "B20005446";

                //'Cedente
                txtCodigoCedente.Text = "0806498";
                txtNossoNumeroBoleto.Text = "000033320071";
                txtCPFCNPJ.Text = "59.323.998/0001-08";
                txtNomeCedente.Text = "Uniabc";
                txtAgenciaCendente.Text = "432";
                txtContaCedente.Text = "0806498";

                //'Sacado
                txtCPFCNPJSacado.Text = "000.000.000-00";
                txtNomeSacado.Text = "Fulano de Silva";
                txtEnderecoSacado.Text = "SSS 154 Bloco J Casa 23";
                txtBairroSacado.Text = "Testando";
                txtCidadeSacado.Text = "Testelândia";
                txtCEPSacado.Text = "70000000";
                txtUFSacado.Text = "DF";

                //'alterei so esses
                //' Vencimento: 6/3/2009
                //'Valor:    656,40
                //'Nosso Número:   0000033320071
                //'            Número(Documento) : B20005446()

                //'Dados do Cendente
                //'CPF/CNPJ: 59.323.998/0001-08
                //'Código:    0806498
                //'Nome:       Uniabc()
                //'Agência:   432
                //'Conta:   0806498
            }
        }

        protected void BtnGerarBoletoFactory_Click(object sender, EventArgs e)
        {
            BankFactory factory = BankFactory.GetFactory("Santander");

            //'Informa os dados do cedente
            Cedente c = new Cedente(txtCPFCNPJ.Text, txtNomeCedente.Text, txtAgenciaCendente.Text, txtContaCedente.Text);
            //'Dependendo da carteira, é necessário informar o código do cedente (o banco que fornece)
            c.Codigo = int.Parse(txtCodigoCedente.Text);

            //'Dados para preenchimento do boleto (data de vencimento, valor, carteira e nosso número)
            Boleto b = new Boleto(DateTime.Parse(txtVencimento.Text), decimal.Parse(txtValorBoleto.Text, NumberStyles.AllowDecimalPoint), "102", txtNossoNumeroBoleto.Text, c);

            //'Dependendo da carteira, é necessário o número do documento
            b.NumeroDocumento = txtNumeroDocumentoBoleto.Text;

            //'Informa os dados do sacado
            b.Sacado = new Sacado(txtCPFCNPJSacado.Text, txtNomeSacado.Text);
            b.Sacado.Endereco.End = txtEnderecoSacado.Text;
            b.Sacado.Endereco.Bairro = txtBairroSacado.Text;
            b.Sacado.Endereco.Cidade = txtCidadeSacado.Text;
            b.Sacado.Endereco.CEP = txtCEPSacado.Text;
            b.Sacado.Endereco.UF = txtUFSacado.Text;

            b.Instrucoes.Add(factory.CreateInstruction());
            b.EspecieDocumento = factory.CreateDocumentReceipt();

            BoletoBancario bb = new BoletoBancario();
            bb.CodigoBanco = 33; //'-> Referente ao código do Santander
            bb.Boleto = b;
            bb.MostrarCodigoCarteira = true;
            bb.Boleto.Valida();

            //'true -> Mostra o compravante de entrega
            //'false -> Oculta o comprovante de entrega
            bb.MostrarComprovanteEntrega = true;

            panelDados.Visible = false;

            bb.MontaHtmlNoArquivoLocal(@"Z:\Documentos\Projects\Csharp\BoletoWebAppDemo\boleto_exemplo.html");

            if (panelBoleto.Controls.Count == 0)
            {
                panelBoleto.Controls.Add(bb);
            }
        }

        protected void BtnGerarBoleto_Click(object sender, EventArgs e)
        {
            //'Informa os dados do cedente
            Cedente c = new Cedente(txtCPFCNPJ.Text, txtNomeCedente.Text, txtAgenciaCendente.Text, txtContaCedente.Text);
            //'Dependendo da carteira, é necessário informar o código do cedente (o banco que fornece)
            c.Codigo = int.Parse(txtCodigoCedente.Text);

            //'Dados para preenchimento do boleto (data de vencimento, valor, carteira e nosso número)
            Boleto b = new Boleto(DateTime.Parse(txtVencimento.Text), decimal.Parse(txtValorBoleto.Text, NumberStyles.AllowDecimalPoint), "102", txtNossoNumeroBoleto.Text, c);

            //'Dependendo da carteira, é necessário o número do documento
            b.NumeroDocumento = txtNumeroDocumentoBoleto.Text;

            //'Informa os dados do sacado
            b.Sacado = new Sacado(txtCPFCNPJSacado.Text, txtNomeSacado.Text);
            b.Sacado.Endereco.End = txtEnderecoSacado.Text;
            b.Sacado.Endereco.Bairro = txtBairroSacado.Text;
            b.Sacado.Endereco.Cidade = txtCidadeSacado.Text;
            b.Sacado.Endereco.CEP = txtCEPSacado.Text;
            b.Sacado.Endereco.UF = txtUFSacado.Text;

            Instrucao_Santander i = new Instrucao_Santander();
            i.Descricao = "Não Receber após o vencimento";
            b.Instrucoes.Add(i);

            //'Espécie do Documento - [R] Recibo
            b.EspecieDocumento = new EspecieDocumento_Santander("17");

            BoletoBancario bb = new BoletoBancario();
            bb.CodigoBanco = 33; //'-> Referente ao código do Santander
            bb.Boleto = b;
            bb.MostrarCodigoCarteira = true;
            bb.Boleto.Valida();

            //'true -> Mostra o compravante de entrega
            //'false -> Oculta o comprovante de entrega
            bb.MostrarComprovanteEntrega = true;

            panelDados.Visible = false;

            bb.MontaHtmlNoArquivoLocal(@"Z:\Documentos\Projects\Csharp\BoletoWebAppDemo\boleto_exemplo.html");

            if (panelBoleto.Controls.Count == 0)
            {
                panelBoleto.Controls.Add(bb);
            }

            //'03399.08063 49800.000330 32007.101028 8 41680000065640 -> correta
            //'03399.08063 49800.000330 32007.101028 8 41680000065640
            //'03399.08063 49800.000330 32007.101028 1 41680000065640
            //'03399.08063 49800.003334 20071.301012 6 41680000065640
            //'03399.08063 49800.000330 32007.101028 1 41680000065640

            //'03399.08063 49800.003334 20071.301020 4 41680000065640
            //'03399.08063 49800.003334 20071.301020 4 41680000065640
        }
    }
}