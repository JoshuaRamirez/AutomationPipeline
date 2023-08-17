namespace AutomationPipeline.Library.Core
{
    public abstract class Pipe<TSourceFilter, TTargetFilter> : IPipe
    where TTargetFilter : Filter
    where TSourceFilter : Filter
    {
        private TSourceFilter? _sourceFilter;
        private TTargetFilter? _targetFilter;

        public Pipe()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public TSourceFilter? SourceFilter
        {
            get => _sourceFilter;
            set
            {
                if (_sourceFilter == value) return;
                if (_sourceFilter != null)
                {
                    _sourceFilter.DisconnectOutboundPipe(this);
                }
                _sourceFilter = value;
                _sourceFilter?.ConnectOutboundPipe(this);
            }
        }

        public TTargetFilter? TargetFilter
        {
            get => _targetFilter;
            set
            {
                if (_targetFilter == value) return;
                if (_targetFilter != null)
                {
                    _targetFilter.DisconnectInboundPipe(this);
                }
                _targetFilter = value;
                _targetFilter?.ConnectInboundPipe(this);
            }
        }

        Filter? IPipe.SourceFilter
        {
            get => _sourceFilter;
            set => SourceFilter = (TSourceFilter?)value;
        }

        Filter? IPipe.TargetFilter
        {
            get => _targetFilter;
            set => TargetFilter = (TTargetFilter?)value;
        }

        public abstract void Flow();

        protected void Continue()
        {
            if (_targetFilter == null)
            {
                return;
            }
            _targetFilter.Run();
        }

    }
}
