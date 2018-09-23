using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*Sharyl Hammer
 * ITD 1253 C#
 * Fall 2016
 * November 30, 2016
 */
namespace Module9Project
{
    public partial class frmIgPayAtinLay : Form
    {
        public frmIgPayAtinLay()
        {
            InitializeComponent();
        }
        public bool IsValidData()
        {
            return
                IsPresent(txtconQuote, "Translate Sentence");

        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                lblMessage.Text = "The textbox can not be blank. Please enter a quote.";
                textBox.Focus();
                return false; 
            }

            return true;
        }




        private string GetPigLatin(string RawText)
          {
          //  string word = "";
            string pigword = "";
            string firstLetter;
            string restofWord;
            string vowels = "AEIOUaeiou";
            int letterPos;
            string hold_value = " ";

            int wordPos;
            
            string con_word = "";
            string rclean = "";

            RawText = RawText.Trim();
            rclean = RawText.Replace(".", "");
            RawText = rclean;

            
           // string[] words = RawText.Split(' ');
           // string words = RawText.Split(' ');
            // We have split the string into words!!
            // Now we have to manipulate each word.
            



            foreach(string word in RawText.Split())
            {
                firstLetter = word.Substring(0, 1);
                restofWord = word.Substring(1, word.Length - 1);

                letterPos = vowels.IndexOf(firstLetter);
               

                if (letterPos == -1)
                {
                    // we have found a constant
                    // we have to determine if there is a vowel in the word.
                    // place restofWord in loop.

                    // string[] letter = restofWord.Split(' ');  

                    for (int i = 0; i < restofWord.Length; i++)

                    {

                      //  letterPos = vowels.IndexOf(firstLetter);
                        hold_value = restofWord[i].ToString();
                        wordPos = vowels.IndexOf(hold_value);
                        if (wordPos == -1)
                        {
                            if (con_word == "")
                            {
                                con_word = restofWord;
                                con_word = con_word + firstLetter + restofWord[i];
                                con_word = con_word.Remove(0, 1);
                            }
                            else
                            {
                                con_word = con_word + restofWord[i];
                                con_word = con_word.Remove(0, 1);
                            }


                        }
                        else
                        {
                            //need to break out of loop
                            break;
                        }
                        
                   }
                    if (con_word == "")
                    {
                        pigword += restofWord + firstLetter + "ay ";
                    }
                    else
                    {
                        
                        pigword += con_word + "ay ";
                    }

                    con_word = "";
                }
                      
                else
                   // we have found a vowel
                {
                pigword += word + "way ";

                
                }


        }
            return pigword;
     }

           

     
        private void frmIgPayAtinLay_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)

        {
            lblMessage.Text = "";
            txtconQuote.Text = "";
            txtconQuote.Focus();
        }

        private void btnPigLatin_Click(object sender, EventArgs e)
        {
            

            try
            {
                string RawText;

                string pigquote = "";

                RawText = txtconQuote.Text;
              
                // Validate here.
                if (IsValidData())
                {
                    pigquote = this.GetPigLatin(RawText);
                    //Displays Pig Latin Quote.
                    int a = pigquote.Length;
             
                    // Removing extra space and placing period at end of pigquote.
                    pigquote = pigquote.Remove(pigquote.Length - 1);
                    pigquote = pigquote + ".";
                    lblMessage.Text = pigquote.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "\n\n";
            }
           

        }

        private void txtconQuote_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
