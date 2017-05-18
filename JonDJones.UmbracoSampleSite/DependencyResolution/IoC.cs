// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace WebApplication2.DependencyResolution {
    using JonDJones.Com.Interfaces;
    using JonDJones.Core.Dependencies;
    using JonDJones.Core.MVC;
    using StructureMap;

    public static class IoC {
        public static IContainer Initialize() {
            var container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.Assembly("JonDJones.Core");
                    scan.Assembly("JonDJones.Com.Interfaces");
                });

                x.For<IWebsiteDependencies>().Use<WebsiteDependencies>();

                x.ForConcreteType<RedisAttribute>()
                    .Configure.Setter<IWebsiteDependencies>()
                    .Is(new WebsiteDependencies());
                x.Policies.SetAllProperties(y => y.OfType<IWebsiteDependencies>());
            });

            var target = new RedisAttribute();
            container.BuildUp(target);

            return container;
        }
    }
}