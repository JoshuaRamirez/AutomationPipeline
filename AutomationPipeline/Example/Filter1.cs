using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    public class Filter1 : OneToOneFilter
    {
        public override void Run()
        {
            Console.WriteLine($"Running Filter 1: {this.Id}");
            Continue();
        }
    }
}
