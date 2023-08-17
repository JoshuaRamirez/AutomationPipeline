using AutomationPipeline.Library;

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
        get 
        { 
            return _sourceFilter; 
        }
        set
        {
            var originalSourceFilter = _sourceFilter;
            _sourceFilter = value;
            if (_sourceFilter != null)
            {
                if (_sourceFilter.PipeOut != this)
                {
                    _sourceFilter.PipeOut = this;
                }
            }
            if (originalSourceFilter != null)
            {
                if (originalSourceFilter.PipeOut != this)
                {
                    originalSourceFilter.PipeOut = null;
                }
            }
        }
    }
    public TTargetFilter? TargetFilter
    {
        get
        {
            return _targetFilter;
        }
        set
        {
            var originalTargetFilter = _targetFilter;
            _targetFilter = value;
            if (_targetFilter != null)
            {
                if (_targetFilter.PipeIn != this)
                {
                    _targetFilter.PipeIn = this;
                }
            }
            if (originalTargetFilter != null)
            {
                if (originalTargetFilter.PipeIn != this)
                {
                    originalTargetFilter.PipeIn = null;
                }
            }
        }
    }

    Filter? IPipe.SourceFilter { get => _sourceFilter; set => _sourceFilter = (TSourceFilter?)value; }
    Filter? IPipe.TargetFilter { get => _targetFilter; set => _targetFilter = (TTargetFilter?)value; }

    protected void Continue()
    {
        if (_sourceFilter != null)
        {
            if (_targetFilter != null)
            {
                _targetFilter.Run();
            }
        }
    }

    public abstract void Flow();
        

}
