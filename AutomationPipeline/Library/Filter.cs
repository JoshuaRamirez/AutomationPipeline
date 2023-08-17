namespace AutomationPipeline.Library
{
    public abstract class Filter
    {
        private IPipe? _pipeIn;
        private IPipe? _pipeOut;

        public Filter()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public IPipe? PipeIn
        {
            get
            {
                return _pipeIn;
            }
            set
            {
                var originalPipeIn = _pipeIn;
                _pipeIn = value;
                if (_pipeIn != null)
                {
                    if (_pipeIn.TargetFilter != this)
                    {
                        _pipeIn.TargetFilter = this;
                    }
                }
                if (originalPipeIn != null)
                {
                    if (originalPipeIn.TargetFilter != this)
                    {
                        originalPipeIn.TargetFilter = null;
                    }
                }
                
            }
        }
        public IPipe? PipeOut
        {
            get
            {
                return _pipeOut;
            }
            set
            {
                var originalPipeOut = _pipeOut;
                _pipeOut = value;
                if (_pipeOut != null)
                {
                    if (_pipeOut.SourceFilter != this)
                    {
                        _pipeOut.SourceFilter = this;
                    }
                }
                if (originalPipeOut != null)
                {
                    if (originalPipeOut.SourceFilter != this)
                    {
                        originalPipeOut.SourceFilter = null;

                    }
                }
            }
        }

        public abstract void Run();

        protected void Continue()
        {
            if (_pipeOut != null)
            {
                _pipeOut.Flow();
            }
        }
    }
}
