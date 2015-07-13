BankHelper
==========

Library to help with bank payments


How to use
==========

It is simple, you need the BankHelper.dll (download the solution and compile or download the dll inside debug folder of the project BankHelper) and Boleto.Net.dll (which may be found at http://boletonet.codeplex.com/). After that, you'll need make some changes in your Web.config file.

Requirements
============

* BoletoNet
* Documentation about value and references may be found at: 
** https://github.com/BoletoNet/boletonet/wiki 
** http://boletonet.codeplex.com/
** http://boletonet.codeplex.com/wikipage?title=Documenta%C3%A7%C3%A3o&referringTitle=Home


Web.config File Example
=======================

```
<!-- 
  Example of configuration to put into main configuration file.
  Look at Web.config file in BoletoWebAppDemo project.
-->
<configuration>
  <configSections>
    <section name="BankConfiguration" type="BankHelper.Configuration.BankConfigurationHandler, BankHelper" />
  </configSections>

  <!-- That is the handler to generate barcode. -->
  <system.webServer>
    <handlers>
      <add name="ImagemCodigoBarra" verb="*" path="ImagemCodigoBarra.ashx" type="BoletoNet.ImagemCodigoBarraHandler" />
    </handlers>
  </system.webServer>
  
  <!-- That is the configuration to generate receipt to Santander. -->
  <BankConfiguration>
    <!-- That should be the same tag to get a factory instance -->
    <Santader>
      <add interface="BoletoNet.IInstrucao" class="BoletoNet.Instrucao_Santander, Boleto.Net" value="Não Receber após o vencimento" />
      <add interface="BoletoNet.IEspecieDocumento" class="BoletoNet.EspecieDocumento_Santander, Boleto.Net" value="17" />
    </Santader>
    <!-- That should be the same tag to get a factory instance -->
    <Itau>
      ...
    </Itau>
  </BankConfiguration>
</configuration>
```

Enjoy yourself!
