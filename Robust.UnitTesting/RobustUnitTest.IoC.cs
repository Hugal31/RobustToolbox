using System;
using Robust.Client;
using Robust.Server;
using Robust.Shared.IoC;

namespace Robust.UnitTesting
{
    public partial class RobustUnitTest
    {
        /// <summary>
        /// Registers all the types into the <see cref="IoCManager"/> with <see cref="IoCManager.Register{TInterface, TImplementation}"/>
        /// </summary>
        private void RegisterIoC()
        {
            switch (Project)
            {
                case UnitTestProject.Client:
                    ClientIoC.RegisterIoC(GameController.DisplayMode.Headless);
                    break;

                case UnitTestProject.Server:
                    ServerIoC.RegisterIoC();
                    break;

                default:
                    throw new NotSupportedException($"Unknown testing project: {Project}");
            }

            OverrideIoC();

            IoCManager.BuildGraph();
        }
    }
}
