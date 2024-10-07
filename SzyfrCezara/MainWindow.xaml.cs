using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SzyfrCezara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly char[] alfabet = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ż', 'ź' };
        private const int alfabetLength = 35;
        private string textToEncrypt = "";
        private int encryptCipherKey;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            encryptCipherKey = Convert.ToInt32(textBox3.Text);
            if (encryptCipherKey > 34 || encryptCipherKey < 1)
            {
                MessageBox.Show("Podaj wartość z przedziału 1 do 34");
            }
            else
            {
                textBox2.Clear();
                textToEncrypt = textBox1.Text.ToLower().Replace(" ", string.Empty);
                EncryptText();
            }

        }

        private void EncryptText()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                for (int j = 0; j < alfabet.Length; j++)
                {
                    if (textToEncrypt[i] == alfabet[j])
                    {
                        if (j + encryptCipherKey >= alfabet.Length)
                        {
                            sb.Append(alfabet[j + encryptCipherKey - alfabetLength]);
                            continue;
                        }
                        else
                        {
                            sb.Append(alfabet[j + encryptCipherKey]);
                            continue;
                        }
                    }
                }
            }
            textBox2.Text += sb.ToString();
        }

        private string textToDecrypt = "";
        private int decryptCipherKey;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            decryptCipherKey = Convert.ToInt32(decryptCipherKeyTextBox.Text);
            if (decryptCipherKey > 34 || decryptCipherKey < 1)
            {
                MessageBox.Show("Podaj wartość z przedziału 1 do 34");
            }
            else
            {
                decryptedTextBox.Clear();
                textToDecrypt = decryptTextBox.Text.ToLower().Replace(" ", string.Empty);
                DecryptText();
            }
        }

        private void DecryptText()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < textToDecrypt.Length; i++)
            {
                for (int j = 0; j < alfabet.Length; j++)
                {
                    if (textToDecrypt[i] == alfabet[j])
                    {
                        if (j - encryptCipherKey < 0)
                        {
                            sb.Append(alfabet[alfabetLength - Math.Abs(j - decryptCipherKey)]);
                            continue;
                        }
                        else
                        {
                            sb.Append(alfabet[j - decryptCipherKey]);
                            continue;
                        }
                    }
                }
            }
            decryptedTextBox.Text += sb.ToString();
        }
    }
}