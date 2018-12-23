using AzureFromTheTrenches.Commanding;
using AzureFromTheTrenches.Commanding.Abstractions;
using BlobFunctionAppTest.Auditors;
using BlobFunctionAppTest.Commands;
using BlobFunctionAppTest.Handlers;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;

namespace BlobFunctionAppTest
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration, ICommandingConfigurator

    {
        private const string ContainerName = "myblobcontainer";
        private const string StorageConnectionName = "storageConnection";

        public ICommandRegistry AddCommanding(ICommandingDependencyResolverAdapter dependencyResolver)
        {
            var registry = dependencyResolver.AddCommanding();
            var auditRootOnly = false;
            dependencyResolver
                .AddPreDispatchCommandingAuditor<ConsoleAuditor>(auditRootOnly)
                .AddPostDispatchCommandingAuditor<ConsoleAuditor>(auditRootOnly)
                .AddExecutionCommandingAuditor<ConsoleAuditor>(auditRootOnly);
            return registry;
        }

        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                    commandRegistry.Register<HelloWorldCommandHandler>()                    
                )
                .Functions(functions => functions
                    .Storage(StorageConnectionName, storage => storage
                        .BlobFunction<HelloWorldCommand>($"{ContainerName}/{{name}}")
                    )
                )
                //.OutputAuthoredSource(@"D:\Lib\Azure Functions\wip\outputfolder")
                ;
        }
    }
}
