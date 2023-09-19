using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{

    public class Slide
    {
        public string Text { get; }

        public Slide(string text)
        {
            Text = text;
        }
    }
}
