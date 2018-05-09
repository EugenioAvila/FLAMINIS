using System.Linq;
namespace FLAMINIS
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        private System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion> _clasificaciones = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion>();
        private System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxSubClasificacion> _subClasificaciones = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxSubClasificacion>();
        public System.Collections.Generic.Dictionary<string, string> _diccionario = new System.Collections.Generic.Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            InicializaControles();
            LimpiaCombos();
            CargaDiccionario();
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
                string[] _nombresClasificaciones = new string[] { "JAPANESE CULTURE", "VIDEO GAMES", "INTERESTS", "CREATIVE", "OTHER", "MISC.", "ADULT" };
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
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + 1 + i, DESCR = _nombresSubClasificaciones4[i], ID_CLASIFICACION = 4 });

                string[] _nombresSubClasificaciones5 = new string[] { "BUSINESS & FINANCE", "TRAVEL", "FITNESS", "PARANORMAL", "ADVICE", "LGBT", "PONY", "CURRENT NEWS", "WORKSAFE REQUESTS", "VERY IMPORTANT POSTS" };
                for (int i = 0; i < _nombresSubClasificaciones5.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length + 1 + i, DESCR = _nombresSubClasificaciones5[i], ID_CLASIFICACION = 5 });

                string[] _nombresSubClasificaciones6 = new string[] { "RANDOM", "ROBOT9001", "POLITICALLY INCORRECT", "INTERNATIONAL/RANDOM", "CAMS & MEETUPS", "SHIT 4CHAN SAYS" };
                for (int i = 0; i < _nombresSubClasificaciones6.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length + _nombresSubClasificaciones5.Length + 1 + i, DESCR = _nombresSubClasificaciones6[i], ID_CLASIFICACION = 6 });

                string[] _nombresSubClasificaciones7 = new string[] { "SEXY BEAUTIFUL WOMEN", "HARDCORE", "HANDSOME MEN", "HENTAI", "ECCHI", "YURI", "HENTAI/ALTERNATIVE", "YAOI", "TORRENTS", "HIGH RESOLUTION", "ADULT GIF", "ADULT CARTOONS", "ADULT REQUESTS" };
                for (int i = 0; i < _nombresSubClasificaciones7.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion() { ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length + _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length + 1 + i, DESCR = _nombresSubClasificaciones7[i], ID_CLASIFICACION = 7 });

                #endregion
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        private void CargaDiccionario()
        {
            try
            {
                _diccionario.Clear();
                _diccionario.Add("ANIME & MANGA", "http://boards.4chan.org/a/");
                _diccionario.Add("ANIME/CUTE", "http://boards.4chan.org/c/");
                _diccionario.Add("ANIME/WALLPAPERS", "http://boards.4chan.org/w/");
                _diccionario.Add("MECHA", "http://boards.4chan.org/m/");
                _diccionario.Add("COSPLAY & EGL", "http://boards.4chan.org/cgl/");
                _diccionario.Add("CUTE/MALE", "http://boards.4chan.org/cm/");
                _diccionario.Add("FLASH", "http://boards.4chan.org/f/");
                _diccionario.Add("TRANSPORTATION", "http://boards.4chan.org/n/");
                _diccionario.Add("OTAKU CULTURE", "http://boards.4chan.org/jp/");
                _diccionario.Add("VIDEO GAMES", "http://boards.4chan.org/v/");
                _diccionario.Add("VIDEO GAME GENERALS", "http://boards.4chan.org/vg/");
                _diccionario.Add("POKÉMON", "http://boards.4chan.org/vp/");
                _diccionario.Add("RETRO GAMES", "http://boards.4chan.org/vr/");
                _diccionario.Add("COMICS & CARTOONS", "http://boards.4chan.org/co/");
                _diccionario.Add("TECHNOLOGY", "http://boards.4chan.org/g/");
                _diccionario.Add("TELEVISION & FILM", "http://boards.4chan.org/tv/");
                _diccionario.Add("WEAPONS", "http://boards.4chan.org/k/");
                _diccionario.Add("AUTO", "http://boards.4chan.org/o/");
                _diccionario.Add("ANIMALS & NATURE", "http://boards.4chan.org/an/");
                _diccionario.Add("TRADITIONAL GAMES", "http://boards.4chan.org/tg/");
                _diccionario.Add("SPORTS", "http://boards.4chan.org/sp/");
                _diccionario.Add("ALTERNATIVE SPORTS", "http://boards.4chan.org/asp/");
                _diccionario.Add("SCIENCE & MATH", "http://boards.4chan.org/sci/");
                _diccionario.Add("HISTORY & HUMANITIES", "http://boards.4chan.org/his/");
                _diccionario.Add("INTERNATIONAL", "http://boards.4chan.org/int/");
                _diccionario.Add("OUTDOORS", "http://boards.4chan.org/out/");
                _diccionario.Add("TOYS", "http://boards.4chan.org/toy/");
                _diccionario.Add("OEKAKI", "http://boards.4chan.org/i/");
                _diccionario.Add("PAPERCRAFT & ORIGAMI", "http://boards.4chan.org/po/");
                _diccionario.Add("PHOTOGRAPHY", "http://boards.4chan.org/p/");
                _diccionario.Add("FOOD & COOKING", "http://boards.4chan.org/ck/");
                _diccionario.Add("ARTWORK/CRITIQUE", "http://boards.4chan.org/ic/");
                _diccionario.Add("WALLPAPERS/GENERAL", "http://boards.4chan.org/wg/");
                _diccionario.Add("LITERATURE", "http://boards.4chan.org/lit/");
                _diccionario.Add("MUSIC", "http://boards.4chan.org/mu/");
                _diccionario.Add("FASHION", "http://boards.4chan.org/fa/");
                _diccionario.Add("3DCG", "http://boards.4chan.org/3/");
                _diccionario.Add("GRAPHIC DESIGN", "http://boards.4chan.org/gd/");
                _diccionario.Add("DO-IT-YOURSELF", "http://boards.4chan.org/diy/");
                _diccionario.Add("WORKSAFE GIF", "http://boards.4chan.org/wsg/");
                _diccionario.Add("QUESTS", "http://boards.4chan.org/qst/");
                _diccionario.Add("BUSINESS & FINANCE", "http://boards.4chan.org/biz/");
                _diccionario.Add("TRAVEL", "http://boards.4chan.org/trv/");
                _diccionario.Add("FITNESS", "http://boards.4chan.org/fit/");
                _diccionario.Add("PARANORMAL", "http://boards.4chan.org/x/");
                _diccionario.Add("ADVICE", "http://boards.4chan.org/adv/");
                _diccionario.Add("LGBT", "http://boards.4chan.org/lgbt/");
                _diccionario.Add("PONY", "http://boards.4chan.org/mlp/");
                _diccionario.Add("CURRENT NEWS", "http://boards.4chan.org/news/");
                _diccionario.Add("WORKSAFE REQUESTS", "http://boards.4chan.org/wsr/");
                _diccionario.Add("VERY IMPORTANT POSTS", "http://boards.4chan.org/vip/");
                _diccionario.Add("RANDOM", "http://boards.4chan.org/b/");
                _diccionario.Add("ROBOT9001", "http://boards.4chan.org/r9k/");
                _diccionario.Add("POLITICALLY INCORRECT", "http://boards.4chan.org/pol/");
                _diccionario.Add("INTERNATIONAL/RANDOM", "http://boards.4chan.org/bant/");
                _diccionario.Add("CAMS & MEETUPS", "http://boards.4chan.org/soc/");
                _diccionario.Add("SHIT 4CHAN SAYS", "http://boards.4chan.org/s4s/");
                _diccionario.Add("SEXY BEAUTIFUL WOMEN", "http://boards.4chan.org/s/");
                _diccionario.Add("HARDCORE", "http://boards.4chan.org/hc/");
                _diccionario.Add("HANDSOME MEN", "http://boards.4chan.org/hm/");
                _diccionario.Add("HENTAI", "http://boards.4chan.org/h/");
                _diccionario.Add("ECCHI", "http://boards.4chan.org/e/");
                _diccionario.Add("YURI", "http://boards.4chan.org/u/");
                _diccionario.Add("HENTAI/ALTERNATIVE", "http://boards.4chan.org/d/");
                _diccionario.Add("YAOI", "http://boards.4chan.org/y/");
                _diccionario.Add("TORRENTS", "http://boards.4chan.org/t/");
                _diccionario.Add("HIGH RESOLUTION", "http://boards.4chan.org/hr/");
                _diccionario.Add("ADULT GIF", "http://boards.4chan.org/gif/");
                _diccionario.Add("ADULT CARTOONS", "http://boards.4chan.org/aco/");
                _diccionario.Add("ADULT REQUESTS", "http://boards.4chan.org/r/");
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        private void LimpiaCombos()
        {
            try
            {
                ComboClasificacion.DisplayMemberPath = "DESCR";
                System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion> _datosLimpios = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion>();
                _datosLimpios.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { ID = 0, DESCR = "SELECCIONE" });
                ComboClasificacion.ItemsSource = _datosLimpios;
                ComboClasificacion.SelectedIndex = 0;
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        public async void Buscar()
        {
            try
            {

            }
            catch (System.Exception exc)
            {
                throw;
            }
        }

        private void ComboPlataforma_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var _seleccion = ((sender as System.Windows.Controls.ComboBox).SelectedItem as Herramientas.Utilerias.cComboBox);
                if (_seleccion != null)
                {
                    var _lista = from x in _clasificaciones where x.ID_PLATAFORMA == _seleccion.ID select x;
                    LimpiaCombos();
                    ComboClasificacion.DisplayMemberPath = "DESCR";
                    ComboClasificacion.ItemsSource = _lista;
                    ComboClasificacion.SelectedIndex = 0;
                }
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        private void ComboClasificacion_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var _seleccion = ((sender as System.Windows.Controls.ComboBox).SelectedItem as Herramientas.Utilerias.cComboBoxClasificacion);
                if (_seleccion != null)
                {
                    var _lista = from x in _subClasificaciones where x.ID_CLASIFICACION == _seleccion.ID select x;
                    ComboSubClasificacion.DisplayMemberPath = "DESCR";
                    ComboSubClasificacion.ItemsSource = _lista;
                    ComboSubClasificacion.SelectedIndex = 0;
                }
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var _seleccion = ComboSubClasificacion.SelectedItem as Herramientas.Utilerias.cComboBoxSubClasificacion;
            if (_seleccion == null)
            {
                System.Windows.MessageBox.Show("Seleccione una sub clasificacion");
                return;
            }

            var _elegido = _diccionario.FirstOrDefault(x => x.Key == _seleccion.DESCR);
        }
    }
}