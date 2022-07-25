namespace CheckersForm
{
    using System.Drawing;
    using System.Windows.Forms;

    internal class CheckerPictureBox : PictureBox
    {
        public Point BoardLocation { get; set; }
    }
}
