namespace ChainOfResponsabilityImplementation
{
    internal class MyApplication
    {
        private LinkedList<ApplicationMiddleware> _middlewares = new LinkedList<ApplicationMiddleware>();

        public void Use<TMiddleware>() where TMiddleware : ApplicationMiddleware
        {
            var middleware = Activator.CreateInstance<TMiddleware>();

            _middlewares.AddLast(middleware);
        }

        public async Task Run(string[] args)
        {
            var runApplicationMiddleware = new RunApplicationMiddleware();

            _middlewares.AddLast(runApplicationMiddleware);

            var node = _middlewares.First!;

            while (node.Next != null)
            {
                var next = node.Next;

                node.Value.SetNext(next.Value);

                node = next;
            }

            await _middlewares.First!.Value.Handle(args);
        }

        private class RunApplicationMiddleware : ApplicationMiddleware
        {
            public override Task Handle(string[] args)
            {
                Console.WriteLine("A aplicação está em execução");
                Console.WriteLine("Pressione alguma tecla para finalizar...");
                
                Console.ReadKey();

                return Task.CompletedTask;
            }
        }
    }
}
