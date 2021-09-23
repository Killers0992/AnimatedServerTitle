using AnimatedServerTitle.Models;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimatedServerTitle
{
    public class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public List<AnimateTitle> Titles { get; set; } = new List<AnimateTitle>()
        {
            new AnimateTitle()
            {
                DisplayTime = 1f,
                Title = new List<string>()
                {
                    "<color=yellow> > </color> ExampleTitle <color=yellow> < </color>",
                    "<size=15>Check your discord server.</size>"
                }
            },
            new AnimateTitle()
            {
                DisplayTime = 1f,
                Title = new List<string>()
                {
                    "<color=yellow> > > </color> ExampleTitle <color=yellow> < < </color>",
                    "<size=15>Dont break server rules.</size>"
                }
            },
            new AnimateTitle()
            {
                DisplayTime = 1f,
                Title = new List<string>()
                {
                    "<color=yellow> > </color> ExampleTitle <color=yellow> < </color>",
                    "<size=15><color=red>Dont teamkill your team!</color></size>"
                }
            }
        };
    }
}
