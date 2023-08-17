using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Library
{
    public abstract class OneToOneFilter : Filter
    {
        private IPipe? _outboundPipe;
        private IPipe? _inboundPipe;

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
            if (pipe == OutboundPipe)
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
            if (_outboundPipe == null)
            {
                return;
            }
            _outboundPipe.Flow();
        }
    }
}
