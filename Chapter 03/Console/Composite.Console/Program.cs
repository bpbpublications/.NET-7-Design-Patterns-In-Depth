using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMenuComponent menu = new Menu()
            {
                Text = "Overview",
                Url = "/overview.html",
                Children = new List<IMenuComponent>()
                {
                    new MenuItem{Text ="Intro",Url="/intro.html"},
                    new MenuItem{Text ="Architecture Component",Url="/arch.html"},
                    new MenuItem{Text ="Class Libraries",Url="/class.html"},
                    new Menu{
                        Text ="Tutorials",
                        Url="/tutorials.html",
                        Children=new List<IMenuComponent>
                        {
                            new MenuItem{Text ="Template Changes",Url="/tpl.html"},
                            new Menu{
                                Text ="Use Visual Studio",
                                Url="/vs.html",
                                Children=new List<IMenuComponent>
                                {
                                    new MenuItem{Text ="New Project",Url="/new-project.html"},
                                    new MenuItem{Text ="Debug",Url="/debug.html"},
                                    new MenuItem{Text ="Publish",Url="/publish.html"}
                                }
                            }
                        }
                    }
                }
            };

            Console.WriteLine(menu.Print());
            Console.Read();
        }
    }
}
