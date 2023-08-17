using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Example
{
    internal class PipeC1 : Pipe<Filter2A, Filter3>
    {
        public override void Flow()
        {
            if (SourceFilter == null || TargetFilter == null)
            {
                throw new InvalidOperationException();
            }
            var message = $"Flowing {SourceFilter.Id} through Pipe C1 to {TargetFilter.Id}";
            Console.WriteLine(message);
            Continue();
        }
    }
}
