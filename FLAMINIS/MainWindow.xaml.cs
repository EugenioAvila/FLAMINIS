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
                string[] _nombresSubClasificaciones = new string[] { "ANIME & MANGA", "ANIME/CUTE", "ANIME/WALLPAPERS", "MECHA", "COSPLAY & EGL", "CUTE/MALE", "FLASH", "TRANSPORTATION", "OTAKU CULTURE" };
                for (int i = 0; i < _nombresSubClasificaciones.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = i + 1, DESCR = _nombresSubClasificaciones[i], ID_CLASIFICACION = 1 });

                string[] _nombresSubClasificaciones2 = new string[] { "VIDEO GAMES", "VIDEO GAME GENERALS", "POKÉMON", "RETRO GAMES" };
                for (int i = 0; i < _nombresSubClasificaciones2.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + 1 + i, DESCR = _nombresSubClasificaciones2[i], ID_CLASIFICACION = 2 });

                string[] _nombresSubClasificaciones3 = new string[] { "COMICS & CARTOONS", "TECHNOLOGY", "TELEVISION & FILM", "WEAPONS", "AUTO", "ANIMALS & NATURE", "TRADITIONAL GAMES", "SPORTS", "ALTERNATIVE SPORTS", "SCIENCE & MATH", "HISTORY & HUMANITIES", "INTERNATIONAL", "OUTDOORS", "TOYS" };
                for (int i = 0; i < _nombresSubClasificaciones3.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + 1 + i, DESCR = _nombresSubClasificaciones3[i], ID_CLASIFICACION = 3 });

                string[] _nombresSubClasificaciones4 = new string[] { "OEKAKI", "PAPERCRAFT & ORIGAMI", "PHOTOGRAPHY", "FOOD & COOKING", "ARTWORK/CRITIQUE", "WALLPAPERS/GENERAL", "LITERATURE", "MUSIC", "FASHION", "3DCG", "GRAPHIC DESIGN", "DO-IT-YOURSELF", "WORKSAFE GIF", "QUESTS" };
                for (int i = 0; i < _nombresSubClasificaciones4.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + 1 + i, DESCR = _nombresSubClasificaciones4[i], ID_CLASIFICACION = 3 });

                string[] _nombresSubClasificaciones5 = new string[] { "BUSINESS & FINANCE", "TRAVEL", "FITNESS", "PARANORMAL", "ADVICE", "LGBT", "PONY", "CURRENT NEWS", "WORKSAFE REQUESTS", "VERY IMPORTANT POSTS" };
                for (int i = 0; i < _nombresSubClasificaciones5.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length + 1 + i, DESCR = _nombresSubClasificaciones5[i], ID_CLASIFICACION = 3 });

                string[] _nombresSubClasificaciones6 = new string[] { "RANDOM", "ROBOT9001", "POLITICALLY INCORRECT", "INTERNATIONAL/RANDOM", "CAMS & MEETUPS", "SHIT 4CHAN SAYS" };
                for (int i = 0; i < _nombresSubClasificaciones6.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length + _nombresSubClasificaciones5.Length + 1 + i, DESCR = _nombresSubClasificaciones6[i], ID_CLASIFICACION = 3 });

                string[] _nombresSubClasificaciones7 = new string[] { "SEXY BEAUTIFUL WOMEN", "HARDCORE", "HANDSOME MEN", "HENTAI", "ECCHI", "YURI", "HENTAI/ALTERNATIVE", "YAOI", "TORRENTS", "HIGH RESOLUTION", "ADULT GIF", "ADULT CARTOONS", "ADULT REQUESTS" };
                for (int i = 0; i < _nombresSubClasificaciones7.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length + _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length + 1 + i, DESCR = _nombresSubClasificaciones7[i], ID_CLASIFICACION = 3 });

                #endregion
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}