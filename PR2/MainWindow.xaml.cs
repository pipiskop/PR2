using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PR2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static List list;
        public static DateTime selectedDate = DateTime.Today;
        public MainWindow()
        {
            InitializeComponent();
            list = new List(selectedDate);
            Update();
            Data.SelectedDate = selectedDate;
        }
        public void Update()
        {
            selectedDate = list.VibData;
            Page.Items.Clear();
            list.UpNotes();
            foreach (Note note in list.Note)
            {
                Page.Items.Add(note.NAMING);
            }
            Naming.Text = "";
            Description.Text = "";
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            list.DeleteNote(heaed: list.SEAzer);
            Update();
        }
        private void Create(object sender, RoutedEventArgs e)
        {
            string nazvaniye = Naming.Text;
            string opisaniye = Description.Text;
            list.CreateNote(nazvaniye, opisaniye, selectedDate);
            Update();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            string nazvniye_ = Naming.Text;
            string opisaniye_ = Description.Text;
            Update();
        }
        private void Chenge(object sender, SelectionChangedEventArgs e)
        {
            if (Page.SelectedIndex != -1)
            {
                list.SEAzer = Page.SelectedIndex;
                Note selectedNote = list.Note[list.SEAzer];
                Naming.Text = selectedNote.NAMING;
                Description.Text = selectedNote.Description;
            }
        }
    }
}
