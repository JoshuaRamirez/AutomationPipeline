using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    internal class Filter3 : ManyToOneFilter
    {
        public override void Run()
        {
            Console.WriteLine($"Running Filter 3: {this.Id}");
            Continue();
        }
    }
}
