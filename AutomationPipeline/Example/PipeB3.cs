using AutomationPipeline.Library.Core;

namespace AutomationPipeline.Example
{
    internal class PipeB3 : Pipe<Filter2, Filter2C>
    {
        public override void Flow()
        {
            if (SourceFilter == null || TargetFilter == null)
            {
                throw new InvalidOperationException();
            }
            var message = $"Flowing {SourceFilter.Id} through Pipe B3 to {TargetFilter.Id}";
            Console.WriteLine(message);
            Continue();
        }
    }
}
