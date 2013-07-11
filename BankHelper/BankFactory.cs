using System;
using System.Collections.Generic;
using System.Configuration;

namespace BankHelper
{
    public class BankFactory
    {
        public string BankName
        {
            get;
            private set;
        }

        private Dictionary<string, Dictionary<string, string>> Mapping
        {
            get;
            set;
        }

        private BankFactory(string bankName)
        {
            BankName = bankName;
            Mapping = (Dictionary<string, Dictionary<string, string>>)ConfigurationManager.GetSection("BankConfiguration");
        }

        public static BankFactory GetFactory(string bankName)
        {
            return new BankFactory(bankName);
        }

        public BoletoNet.IInstrucao CreateInstruction()
        {
            BoletoNet.IInstrucao instrucao = (BoletoNet.IInstrucao)Activator.CreateInstance(Type.GetType(Mapping[BankName]["BoletoNet.IInstrucao"]));
            instrucao.Descricao = Mapping[BankName]["BoletoNet.IInstrucao.Value"];
            return instrucao;
        }

        public BoletoNet.IEspecieDocumento CreateDocumentReceipt()
        {
            BoletoNet.IEspecieDocumento especieDocumento = (BoletoNet.IEspecieDocumento)Activator.CreateInstance(Type.GetType(Mapping[BankName]["BoletoNet.IEspecieDocumento"]));
            especieDocumento.Codigo = Mapping[BankName]["BoletoNet.IEspecieDocumento.Value"];
            return especieDocumento;
        }
    }
}