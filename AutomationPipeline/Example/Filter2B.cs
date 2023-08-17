using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    internal class Filter2B : OneToOneFilter
    {
        public override void Run()
        {
            Console.WriteLine("Running Filter 2B");
            Continue();
        }
    }
}
