using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Example
{
    internal class PipeB2 : Pipe<Filter2, Filter2B>
    {
        public override void Flow()
        {
            if (SourceFilter == null || TargetFilter == null)
            {
                throw new InvalidOperationException();
            }
            var message = $"Flowing {SourceFilter.Id} through Pipe B2 to {TargetFilter.Id}";
            Console.WriteLine(message);
            Continue();
        }
    }
}
