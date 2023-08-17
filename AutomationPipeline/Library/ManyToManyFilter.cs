using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Library
{
    public abstract class ManyToManyFilter : Filter
    {
        private readonly PipesInbound<IPipe> _inboundPipes;
        private readonly PipesOutbound<IPipe> _outboundPipes;

        public ManyToManyFilter()
        {
            _inboundPipes = new PipesInbound<IPipe>(this);
            _outboundPipes = new PipesOutbound<IPipe>(this);
        }

        public PipesInbound<IPipe> InboundPipes => _inboundPipes;
        public PipesOutbound<IPipe> OutboundPipes => _outboundPipes;

        internal override void ConnectOutboundPipe(IPipe? pipe)
        {
            if (pipe == null || _outboundPipes.Contains(pipe))
            {
                return;
            }
            if (pipe.SourceFilter != this)
            {
                pipe.SourceFilter = this;
            }
            _outboundPipes.Add(pipe);
        }

        internal override void DisconnectOutboundPipe(IPipe? pipe)
        {
            if (pipe == null)
            {
                return;
            }
            if (_outboundPipes.Contains(pipe))
            {
                _outboundPipes.Remove(pipe);
                pipe.SourceFilter = null;
            }
        }

        internal override void ConnectInboundPipe(IPipe? pipe)
        {
            if (pipe == null || _inboundPipes.Contains(pipe))
            {
                return;
            }
            if (pipe.TargetFilter != this)
            {
                pipe.TargetFilter = this;
            }
            _inboundPipes.Add(pipe);
        }

        internal override void DisconnectInboundPipe(IPipe? pipe)
        {
            if (pipe == null)
            {
                return;
            }
            if (_inboundPipes.Contains(pipe))
            {
                _inboundPipes.Remove(pipe);
                pipe.TargetFilter = null;
            }
        }
        protected override void Continue()
        {
            if (_outboundPipes.Count == 0)
            {
                return;
            }
            _outboundPipes.ForEach(pipe =>
            {
                pipe.Flow();
            });
        }
    }
}
