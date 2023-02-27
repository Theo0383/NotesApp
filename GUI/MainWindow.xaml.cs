using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Note selectedNote;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            Repository repo = new();
            List<Note> notes = repo.GetAllNotes();
            listbox.ItemsSource = notes;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedNote = listbox.SelectedItem as Note;
            if(selectedNote != null)
            {
                textBox.Text = selectedNote.Text;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedNote.Text = textBox.Text;
            Repository repo = new();
            repo.Update(selectedNote);
        }
    }
}
