using System.Drawing;
using System.Windows.Forms;

namespace fmDataTool.Loader.Base
{
    public static class RichTextBoxEx
    {
        public static void AppendText(this RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            box.Select(start, end - start);
            {
                box.SelectionColor = color;
            }
            box.SelectionLength = 0;
        }
    }
}
