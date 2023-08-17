using AutomationPipeline.Library;

namespace AutomationPipeline.Example
{
    public class Filter2 : OneToManyFilter
    {
        public override void Run()
        {
            Console.WriteLine("Running Filter 2");
            Continue();
        }
    }
}
