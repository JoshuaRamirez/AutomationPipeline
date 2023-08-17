using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Library
{
    public abstract class OneToManyFilter : Filter
    {
        private IPipe? _inboundPipe;
        private PipesOutbound<IPipe> _outboundPipes;

        public OneToManyFilter()
        {
            _outboundPipes = new PipesOutbound<IPipe>(this);
        }

        public PipesOutbound<IPipe> OutboundPipes => _outboundPipes;

        public IPipe? InboundPipe
        {
            get => _inboundPipe;
            set
            {
                if (value != _inboundPipe)
                {
                    DisconnectInboundPipe(_inboundPipe);
                    _inboundPipe = value;
                    ConnectInboundPipe(value);
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
            if (_outboundPipes.Contains(pipe))
            {
                pipe.SourceFilter = null;
            }
        }

        internal override void ConnectInboundPipe(IPipe? pipe)
        {
            if (pipe == null)
            {
                return;
            }
            if (pipe.TargetFilter != this)
            {
                pipe.TargetFilter = this;
            }
        }

        internal override void DisconnectInboundPipe(IPipe? pipe)
        {
            if (pipe == null)
            {
                return;
            }
            if (pipe == InboundPipe)
            {
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
