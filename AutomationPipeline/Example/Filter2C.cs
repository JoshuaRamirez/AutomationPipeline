using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    internal class Filter2C : OneToOneFilter
    {
        public override void Run()
        {
            Console.WriteLine("Running Filter 2C");
            Continue();
        }
    }
}
