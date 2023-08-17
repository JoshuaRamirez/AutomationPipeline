using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Example
{
    internal class PipeB1 : Pipe<Filter2, Filter2A>
    {
        public override void Flow()
        {
            if (SourceFilter == null || TargetFilter == null)
            {
                throw new InvalidOperationException();
            }
            var message = $"Flowing {SourceFilter.Id} through Pipe B1 to {TargetFilter.Id}";
            Console.WriteLine(message);
            Continue();
        }
    }
}
