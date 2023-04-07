namespace ChainOfResponsabilityImplementation.Middlewares
{
    public class CheckEnvironmentMiddleware : ApplicationMiddleware
    {
        private string EnvironmentArgumentName = "--environment";

        public override Task Handle(string[] args)
        {
            var environmentArgIndex = Array.IndexOf(args, EnvironmentArgumentName);

            if (environmentArgIndex != -1)
            {
                try
                {
                    var environmentArg = args[environmentArgIndex + 1];

                    if (environmentArg.StartsWith("--"))
                    {
                        Console.WriteLine("O ambiente selecionado não é válido");

                        return Task.CompletedTask;
                    }

                    Console.WriteLine("Ambiente selecionado: {0}", environmentArg);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Não foi possível encontrar o argumento relacionado ao ambiente");

                    return Task.CompletedTask;
                }
            }

            return _next is not null ? _next.Handle(args) : Task.CompletedTask;
        }
    }
}
