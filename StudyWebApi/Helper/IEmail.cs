namespace StudyWebApi.Helper
{
    public interface IEmail
    {
        public bool Enviar(string email, string assunto, string mensagem);
    }
}
