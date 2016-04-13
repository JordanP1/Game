using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    //A chatlog used to print out text and inform the user
    //the details of combat and other messages.

    public class Chatlog
    {
        //Using a custom RichTextBox to act as a chatlog
        //to print text to.
        RichTextBoxScroll _textBox;

        public Chatlog(RichTextBoxScroll textBox)
        {
            this._textBox = textBox;
        }

        //Writes a string to the chatlog without appending a new line.
        public void WriteString(string text, Color color)
        {
            //Place caret at the very bottom right before new
            //text gets appended for color application.
            this._textBox.SelectionStart = this._textBox.Text.Length;
            //Change color of newly appended text.
            this._textBox.SelectionColor = color;

            //Append the text to the chatlog.
            this._textBox.AppendText(text);

            //Set color back to default.
            this._textBox.SelectionColor = this._textBox.ForeColor;
        }

        //Overload to use the default chatlog text color.
        public void WriteString(string text)
        {
            this.WriteString(text, this._textBox.ForeColor);
        }

        //Writes a string to the chatlog, appending a new line beforehand.
        public void WriteLine(string text, Color color)
        {
            //Append a new line if the chatlog has pre-existing text.
            if (this._textBox.Text.Length > 0)
            {
                this._textBox.AppendText(Environment.NewLine);
            }

            //Write the string.
            this.WriteString(text, color);
        }

        //Overload to use the default chatlog text color.
        public void WriteLine(string text)
        {
            this.WriteLine(text, this._textBox.ForeColor);
        }
    }
}
