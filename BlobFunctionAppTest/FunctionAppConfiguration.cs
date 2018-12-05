using BlobFunctionAppTest.Commands;
using BlobFunctionAppTest.Handlers;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;

namespace BlobFunctionAppTest
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        private const string ContainerName = "myblobcontainer";
        private const string StorageConnectionName = "storageConnection";

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
