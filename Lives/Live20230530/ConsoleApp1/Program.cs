using System.Runtime.InteropServices;

namespace ConsoleApp1
{

    public interface IServicoEnergia
    {
        public bool VerificarParcelasPendentes(string cpf);
    }

    public interface IServicoEmail
    {
        public void DispararEmail(string emailDestino, string assunto, string corpoEmail);
    }

    public class CEB : IServicoEnergia
    {
        public bool VerificarParcelasPendentes(string cpf)
        {
            Console.WriteLine("CEB - Verificando pendencias");
            return true;
        }
    }

    public class Enel : IServicoEnergia
    {
        public bool VerificarParcelasPendentes(string cpf)
        {
            Console.WriteLine("Anel - Verificando pendencias");
            return true;
        }
    }

    public class SendGridServicoEmail : IServicoEmail
    {
        public void DispararEmail(string emailDestino, string assunto, string corpoEmail)
        {
            Console.WriteLine($"Sendgrid - Email enviado com sucesso para {emailDestino} com assunto {assunto} e mensagem {corpoEmail}");
        }
    }

    public class GmailServicoEmail : IServicoEmail
    {
        public void DispararEmail(string emailDestino, string assunto, string corpoEmail)
        {
            Console.WriteLine($"Gmail - Email enviado com sucesso para {emailDestino} com assunto {assunto} e mensagem {corpoEmail}");
        }
    }


    public class ClienteServico
    {
        private readonly IServicoEnergia _servicoEnergia;
        private readonly IServicoEmail _servicoEmail;
        public ClienteServico(IServicoEmail servicoEmail, IServicoEnergia servicoEnergia)
        {
            _servicoEmail = servicoEmail;
            _servicoEnergia = servicoEnergia;
        }

        public void VerificarParcelasPendencias(string cpf)
        {
            bool temParcelasPendentes = _servicoEnergia.VerificarParcelasPendentes(cpf);
            if(temParcelasPendentes)
            {
                string corpoEmail = "Vc deve, favor pagar rapido para nao ficar no escuro";
                string emailDestino = "charles@gmail.com";
                string assunto = "Vc deve!";

                _servicoEmail.DispararEmail(emailDestino, assunto, corpoEmail);
            }
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            // Determinar as dependencias
            ClienteServico clienteServico = new ClienteServico(
                new GmailServicoEmail(), 
                new CEB()
            );

            // Usar
            clienteServico.VerificarParcelasPendencias("123");

            Console.ReadKey();

        }
    }
}
