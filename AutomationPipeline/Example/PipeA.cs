namespace AutomationPipeline.Example
{
    public class PipeA : Pipe<Filter1, Filter2>
    {
        public override void Flow()
        {
            if (SourceFilter == null || TargetFilter == null)
            {
                throw new InvalidOperationException();
            }
            var message = $"Flowing {SourceFilter.Id} through Pipe A to {TargetFilter.Id}";
            Console.WriteLine(message);
            Continue();
        }
    }
}
