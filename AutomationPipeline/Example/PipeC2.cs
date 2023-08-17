using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Example
{
    internal class PipeC2 : Pipe<Filter2B, Filter3>
    {
        public override void Flow()
        {
            if (SourceFilter == null || TargetFilter == null)
            {
                throw new InvalidOperationException();
            }
            var message = $"Flowing {SourceFilter.Id} through Pipe C2 to {TargetFilter.Id}";
            Console.WriteLine(message);
            Continue();
        }
    }
}
