namespace FLAMINIS
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InicializaControles();
        }
        
        private void InicializaControles()
        {
            try
            {
                System.Collections.Generic.List<Herramientas.Utilerias.cComboBox> _elementos = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBox>();
                _elementos.Add(new Herramientas.Utilerias.cComboBox() { ID = 0, DESCR = "SELECCIONE" });
                _elementos.Add(new Herramientas.Utilerias.cComboBox() { ID = 1, DESCR = "4 CHAN" });
                ComboPlataforma.DisplayMemberPath = "DESCR";
                ComboPlataforma.ItemsSource = _elementos;
                ComboPlataforma.SelectedIndex = 0;
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}