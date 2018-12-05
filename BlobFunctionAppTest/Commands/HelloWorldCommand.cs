using AzureFromTheTrenches.Commanding.Abstractions;

namespace BlobFunctionAppTest.Commands
{
    public class HelloWorldCommand : ICommand
    {
        public string UserName { get; set; }
    }
}
