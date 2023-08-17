namespace AutomationPipeline.Library.Core
{
    public abstract class Filter
    {
        public Guid Id { get; set; }
        public abstract void Run();
        internal abstract void ConnectOutboundPipe(IPipe? pipe);
        internal abstract void DisconnectOutboundPipe(IPipe? pipe);
        internal abstract void ConnectInboundPipe(IPipe? pipe);
        internal abstract void DisconnectInboundPipe(IPipe? pipe);
        protected abstract void Continue();
    }
}
