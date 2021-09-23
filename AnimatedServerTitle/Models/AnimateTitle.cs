using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimatedServerTitle.Models
{
    public class AnimateTitle
    {
        [Description("DisplayTime in seconds.")]
        public float DisplayTime { get; set; } = 0.3f;
        public List<string> Title { get; set; } = new List<string>();
    }
}
