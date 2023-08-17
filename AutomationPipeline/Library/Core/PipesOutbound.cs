using AutomationPipeline.Example;

namespace AutomationPipeline.Library.Core
{
    public class PipesOutbound<TPipe> : List<TPipe>
        where TPipe : IPipe
    {
        private Filter _sourceFilter;

        public PipesOutbound(Filter filter)
        {
            _sourceFilter = filter;
        }

        public new void Add(TPipe item)
        {
            base.Add(item);
            item.SourceFilter = _sourceFilter;
            item.SourceFilter.ConnectOutboundPipe(item);
        }

        public new void Remove(TPipe item)
        {
            base.Remove(item);
            item.SourceFilter?.DisconnectOutboundPipe(item);
        }

        public new void Clear()
        {
            foreach (var pipe in this)
            {
                pipe.SourceFilter?.DisconnectOutboundPipe(pipe);
            }
            base.Clear();
        }
    }
}
