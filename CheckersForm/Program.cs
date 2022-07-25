using System.Windows.Forms;

namespace CheckersForm
{
    internal class Program
    {
        public static void Main()
        {
            Form game = new GameForm();
            game.ShowDialog();
        }
    }
}
