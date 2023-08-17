using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Example
{
    internal class PipeC3 : Pipe<Filter2C, Filter3>
    {
        public override void Flow()
        {
            if (SourceFilter == null || TargetFilter == null)
            {
                throw new InvalidOperationException();
            }
            var message = $"Flowing {SourceFilter.Id} through Pipe C3 to {TargetFilter.Id}";
            Console.WriteLine(message);
            Continue();
        }
    }
}
