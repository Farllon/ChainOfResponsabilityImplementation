namespace ChainOfResponsabilityImplementation
{
    public abstract class ApplicationMiddleware
    {
        protected ApplicationMiddleware _next;

        public void SetNext(ApplicationMiddleware next)
            => _next = next;

        public abstract Task Handle(string[] args);
    }
}
