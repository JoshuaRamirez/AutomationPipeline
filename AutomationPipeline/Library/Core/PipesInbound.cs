namespace AutomationPipeline.Library.Core
{
    public class PipesInbound<TPipe> : List<TPipe>
        where TPipe : IPipe
    {
        private readonly Filter _targetFilter;

        public PipesInbound(Filter targetFilter)
        {
            _targetFilter = targetFilter;
        }
        public new void Add(TPipe item)
        {
            base.Add(item);
            item.TargetFilter = _targetFilter;
            item.TargetFilter.ConnectInboundPipe(item);
        }

        public new void Remove(TPipe item)
        {
            base.Remove(item);
            item.TargetFilter?.DisconnectInboundPipe(item);
        }

        public new void Clear()
        {
            foreach (var pipe in this)
            {
                pipe.TargetFilter?.DisconnectInboundPipe(pipe);
            }
            base.Clear();
        }
    }
}
