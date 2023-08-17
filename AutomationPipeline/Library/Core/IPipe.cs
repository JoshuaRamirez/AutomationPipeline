namespace AutomationPipeline.Library.Core
{
    public interface IPipe
    {
        Guid Id { get; set; }
        Filter? SourceFilter { get; set; }
        Filter? TargetFilter { get; set; }
        void Flow();
    }
}
