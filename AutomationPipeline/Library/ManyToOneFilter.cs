using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Library
{
    public abstract class ManyToOneFilter : Filter
    {
        private IPipe? _outboundPipe;
        private readonly PipesInbound<IPipe> _inboundPipes;

        public ManyToOneFilter()
        {
            _inboundPipes = new PipesInbound<IPipe>(this);
        }

        public PipesInbound<IPipe> InboundPipes => _inboundPipes;

        public IPipe? OutboundPipe
        {
            get => _outboundPipe;
            set
            {
                if (value != _outboundPipe)
                {
                    DisconnectOutboundPipe(_outboundPipe);
                    _outboundPipe = value;
                    ConnectOutboundPipe(value);
                }
            }
        }

        internal override void ConnectOutboundPipe(IPipe? pipe)
        {
            if (pipe == null)
            {
                return;
            }
            if (pipe.SourceFilter != this)
            {
                pipe.SourceFilter = this;
            }
        }

        internal override void DisconnectOutboundPipe(IPipe? pipe)
        {
            if (pipe == null)
            {
                return;
            }
            if (pipe == OutboundPipe)
            {
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
            if (_outboundPipe == null)
            {
                return;
            }
            _outboundPipe.Flow();
        }
    }
}
