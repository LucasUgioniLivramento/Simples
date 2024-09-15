namespace Core.Mediator.Domain
{
    public static class MsgValidation
    {
        public static string VazioErrorMsg => "Informe o campo {0}.";
        public static string UnicoErrorMsg => "Já existe um(a) {0} com a descrição informada.";
        public static string TamanhoMaximoErrorMsg => "O campo {0} não pode ser maior que {1} caracteres.";
    }
}
