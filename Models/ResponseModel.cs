namespace WebApiLivros.Models
{
    // padronizar mensagens de retorno
    public class ResponseModel<T> // Generico, pois pode ser qualquer tipo de dado, tanto livro quanto autor
    {
        public T? Dados { get; set; }// Dados que serão retornados, do livro e do autor
                                     // pode ser nulo, ja que pode ocorrer algum problema neste get
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
