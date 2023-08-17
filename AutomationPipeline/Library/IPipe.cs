namespace AutomationPipeline.Library
{
    public interface IPipe
    {
        public Guid Id { get; set; }
        public Filter? SourceFilter { get; set; }
        public Filter? TargetFilter { get; set; }
        public void Flow();
    }
}
