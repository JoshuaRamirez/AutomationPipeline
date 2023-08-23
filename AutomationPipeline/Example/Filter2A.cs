using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    internal class Filter2A : OneToOneFilter
    {
        public override void Run()
        {
            Console.WriteLine($"Running Filter 2A: {this.Id}");
            Continue();
        }
    }
}
