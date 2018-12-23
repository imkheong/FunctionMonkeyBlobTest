using AzureFromTheTrenches.Commanding.Abstractions;
using BlobFunctionAppTest.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BlobFunctionAppTest.Handlers
{
    internal class HelloWorldCommandHandler : ICommandHandler<HelloWorldCommand>
    {
        public Task ExecuteAsync(HelloWorldCommand command)
        {
            Console.WriteLine($"Hello {command.UserName}");
            return Task.CompletedTask;
        }
    }
}
