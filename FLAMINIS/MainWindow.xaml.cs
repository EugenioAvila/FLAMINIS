namespace FLAMINIS
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        private System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion> _clasificaciones = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion>();
        private System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxSubClasificacion> _subClasificaciones = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxSubClasificacion>();
        public MainWindow()
        {
            InitializeComponent();
            InicializaControles();
        }
        
        private void InicializaControles()
        {
            try
            {
                #region plataformas
                System.Collections.Generic.List<Herramientas.Utilerias.cComboBox> _elementos = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBox>();
                _elementos.Add(new Herramientas.Utilerias.cComboBox() { ID = 0, DESCR = "SELECCIONE" });
                _elementos.Add(new Herramientas.Utilerias.cComboBox() { ID = 1, DESCR = "4 CHAN" });
                ComboPlataforma.DisplayMemberPath = "DESCR";
                ComboPlataforma.ItemsSource = _elementos;
                ComboPlataforma.SelectedIndex = 0;
                #endregion


                #region clasificaciones
                string[] _nombresClasificaciones = new string[] { "JAPANESE CULTURE", "VIDEO GAMES", "INTERESTS", "CREATIVE", "CREATIVE", "OTHER", "MISC.", "ADULT" };
                for (int i = 0; i < _nombresClasificaciones.Length; i++)
                    _clasificaciones.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { DESCR = _nombresClasificaciones[i], ID = i + 1, ID_PLATAFORMA = 1 });

                #endregion

                #region sub clasificaciones

                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "ANIME & MANGA", ID = 1, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "ANIME", ID = 2, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "ANIME/CUTE", ID = 3, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "ANIME/WALLPAPERS", ID = 4, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "MECHA", ID = 5, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "Cosplay & EGL", ID = 6, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "CUTE/MALE", ID = 7, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "FLASH", ID = 8, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "TRANSPORTATION", ID = 9, ID_CLASIFICACION = 1 });
                _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { DESCR = "OTAKU CULTURE", ID = 10, ID_CLASIFICACION = 1 });
                #endregion
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}