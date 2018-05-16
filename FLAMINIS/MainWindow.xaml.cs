using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace FLAMINIS
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        WebClient webClient;
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        private System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion> _clasificaciones = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion>();
        private System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxSubClasificacion> _subClasificaciones = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxSubClasificacion>();
        public System.Collections.Generic.Dictionary<string, string> _diccionario = new System.Collections.Generic.Dictionary<string, string>();
        public MainWindow()
        {
            //BuscarPrueba();
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
                System.Collections.Generic.List<Herramientas.Utilerias.cComboBox> _elementos = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBox>
                {
                    new Herramientas.Utilerias.cComboBox() { ID = 0, DESCR = "SELECCIONE" },
                    //_elementos.Add(new Herramientas.Utilerias.cComboBox() { ID = 1, DESCR = "4 CHAN" });
                    new Herramientas.Utilerias.cComboBox() { ID = 2, DESCR = "LAINCHAN" },
                    new Herramientas.Utilerias.cComboBox() { ID = 3, DESCR = "XCHAN" },
                    new Herramientas.Utilerias.cComboBox() { ID = 4, DESCR = "UBOACHAN" },
                    new Herramientas.Utilerias.cComboBox() { ID = 5, DESCR = "TOHNO-CHAN" },
                    new Herramientas.Utilerias.cComboBox() { ID = 6, DESCR = "FINAL CHAN" }
                };

                ComboPlataforma.DisplayMemberPath = "DESCR";
                ComboPlataforma.ItemsSource = _elementos;
                ComboPlataforma.SelectedIndex = 0;
                #endregion
                #region clasificaciones
                string[] _nombresClasificaciones = new string[] { "JAPANESE CULTURE", "VIDEO GAMES", "INTERESTS", "CREATIVE", "OTHER", "MISC.", "ADULT" };
                for (int i = 0; i < _nombresClasificaciones.Length; i++)
                    _clasificaciones.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { DESCR = _nombresClasificaciones[i], ID = i + 1, ID_PLATAFORMA = 1 });

                string[] _nombresClasificaciones2 = new string[] { "STEM", "PEOPLE", "MISC", "OVERBOARDS 1", "OVERBOARDS 2" };
                for (int i = 0; i < _nombresClasificaciones2.Length; i++)
                    _clasificaciones.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { DESCR = _nombresClasificaciones2[i], ID = _nombresClasificaciones.Length + i + 1, ID_PLATAFORMA = 2 });

                string[] _nombresClasificaciones3 = new string[] { "GRAL", "SERIOUS BUSINESS", "CONOC & CULT", "18+" };
                for (int i = 0; i < _nombresClasificaciones3.Length; i++)
                    _clasificaciones.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { DESCR = _nombresClasificaciones3[i], ID = _nombresClasificaciones.Length + _nombresClasificaciones2.Length + i + 1, ID_PLATAFORMA = 3 });

                string[] _nombresClasificaciones4 = new string[] { "YUME NIKKI", "ARTS & ENT", "MISCELLANEOUS" };
                for (int i = 0; i < _nombresClasificaciones4.Length; i++)
                    _clasificaciones.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { DESCR = _nombresClasificaciones4[i], ID = _nombresClasificaciones.Length + _nombresClasificaciones2.Length + _nombresClasificaciones3.Length + i + 1, ID_PLATAFORMA = 4 });

                string[] _nombresClasificaciones5 = new string[] { "MEDIA/ENTERTAINMENT", "HOBBIES/INTERESTS", "GENERAL DISCUSSION", "OTHER TOHNO CHAN" };
                for (int i = 0; i < _nombresClasificaciones5.Length; i++)
                    _clasificaciones.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { DESCR = _nombresClasificaciones5[i], ID = _nombresClasificaciones.Length + _nombresClasificaciones2.Length + _nombresClasificaciones3.Length + _nombresClasificaciones4.Length + i + 1, ID_PLATAFORMA = 5 });

                string[] _nombresClasificaciones6 = new string[] { "SECCION 1", "SECCION 2", "SECCION 3", "SECCION 4" };
                for (int i = 0; i < _nombresClasificaciones6.Length; i++)
                    _clasificaciones.Add(new Herramientas.Utilerias.cComboBoxClasificacion() { DESCR = _nombresClasificaciones6[i], ID = _nombresClasificaciones.Length + _nombresClasificaciones2.Length + _nombresClasificaciones3.Length + _nombresClasificaciones4.Length + _nombresClasificaciones5.Length + i + 1, ID_PLATAFORMA = 6 });
                #endregion

                #region sub clasificaciones
                #region 4chan
                string[] _nombresSubClasificaciones = new string[] { "ANIME & MANGA", "ANIME/CUTE", "ANIME/WALLPAPERS", "MECHA", "COSPLAY & EGL", "CUTE/MALE", "FLASH", "TRANSPORTATION", "OTAKU CULTURE" };
                for (int i = 0; i < _nombresSubClasificaciones.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = i + 1,
                        DESCR = _nombresSubClasificaciones[i],
                        ID_CLASIFICACION = 1
                    });

                string[] _nombresSubClasificaciones2 = new string[] { "VIDEO GAMES", "VIDEO GAME GENERALS", "POKÉMON", "RETRO GAMES" };
                for (int i = 0; i < _nombresSubClasificaciones2.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones2[i],
                        ID_CLASIFICACION = 2
                    });

                string[] _nombresSubClasificaciones3 = new string[] { "COMICS & CARTOONS", "TECHNOLOGY", "TELEVISION & FILM", "WEAPONS", "AUTO", "ANIMALS & NATURE", "TRADITIONAL GAMES", "SPORTS", "ALTERNATIVE SPORTS", "SCIENCE & MATH", "HISTORY & HUMANITIES", "INTERNATIONAL", "OUTDOORS", "TOYS" };
                for (int i = 0; i < _nombresSubClasificaciones3.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones3[i],
                        ID_CLASIFICACION = 3
                    });

                string[] _nombresSubClasificaciones4 = new string[] { "OEKAKI", "PAPERCRAFT & ORIGAMI", "PHOTOGRAPHY", "FOOD & COOKING", "ARTWORK/CRITIQUE", "WALLPAPERS/GENERAL", "LITERATURE", "MUSIC", "FASHION", "3DCG", "GRAPHIC DESIGN", "DO-IT-YOURSELF", "WORKSAFE GIF", "QUESTS" };
                for (int i = 0; i < _nombresSubClasificaciones4.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones4[i],
                        ID_CLASIFICACION = 4
                    });

                string[] _nombresSubClasificaciones5 = new string[] { "BUSINESS & FINANCE", "TRAVEL", "FITNESS", "PARANORMAL", "ADVICE", "LGBT", "PONY", "CURRENT NEWS", "WORKSAFE REQUESTS", "VERY IMPORTANT POSTS" };
                for (int i = 0; i < _nombresSubClasificaciones5.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones5[i],
                        ID_CLASIFICACION = 5
                    });

                string[] _nombresSubClasificaciones6 = new string[] { "RANDOM", "ROBOT9001", "POLITICALLY INCORRECT", "INTERNATIONAL/RANDOM", "CAMS & MEETUPS", "SHIT 4CHAN SAYS" };
                for (int i = 0; i < _nombresSubClasificaciones6.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones6[i],
                        ID_CLASIFICACION = 6
                    });

                string[] _nombresSubClasificaciones7 = new string[] { "SEXY BEAUTIFUL WOMEN", "HARDCORE", "HANDSOME MEN", "HENTAI", "ECCHI", "YURI", "HENTAI/ALTERNATIVE", "YAOI", "TORRENTS", "HIGH RESOLUTION", "ADULT GIF", "ADULT CARTOONS", "ADULT REQUESTS" };
                for (int i = 0; i < _nombresSubClasificaciones7.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones7[i],
                        ID_CLASIFICACION = 7
                    });

                #endregion
                #region lain chan
                string[] _nombresSubClasificaciones8 = new string[] { "PROGRAMMING LAINCHAN", "DO IT YOURSELF LAINCHAN", "SECURITY LAINCHAN", "TECHNOLOGY LAINCHAN" };
                for (int i = 0; i < _nombresSubClasificaciones8.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones8[i],
                        ID_CLASIFICACION = 8
                    });

                string[] _nombresSubClasificaciones9 = new string[] { "INTER LAINCHAN", "LIT LAINCHAN", "MUSIC LAINCHAN", "VIS LAINCHAN", "HUM LAINCHAN", "DRG LAINCHAN", "ZZZ LAINCHAN" };
                for (int i = 0; i < _nombresSubClasificaciones9.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones9[i],
                        ID_CLASIFICACION = 9
                    });

                string[] _nombresSubClasificaciones10 = new string[] { "LAYER LAINCHAN", "Q LAINCHAN", "R LAINCHAN" };
                for (int i = 0; i < _nombresSubClasificaciones10.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones10[i],
                        ID_CLASIFICACION = 10
                    });

                string[] _nombresSubClasificaciones11 = new string[] { "CULT LAINCHAN", "PSY LAINCHAN" };
                for (int i = 0; i < _nombresSubClasificaciones11.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones11[i],
                        ID_CLASIFICACION = 11
                    });

                string[] _nombresSubClasificaciones12 = new string[] { "MEGA LAINCHAN", "RND LAINCHAN" };
                for (int i = 0; i < _nombresSubClasificaciones12.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones12[i],
                        ID_CLASIFICACION = 12
                    });

                #endregion
                #region xchan
                string[] _nombresSubClasificaciones13 = new string[] { "ALEATORIO", "C-C-C-CANCER", "HUEHUE" };
                for (int i = 0; i < _nombresSubClasificaciones13.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones13[i],
                        ID_CLASIFICACION = 13
                    });

                string[] _nombresSubClasificaciones14 = new string[] { "ANIMES-MANGA", "ENTRETENIMIENTO", "JOGOS CONSOLAS", "MUSIC XCHAN", "XCHAN", "DESENVOLVIMENTO" };
                for (int i = 0; i < _nombresSubClasificaciones14.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones14[i],
                        ID_CLASIFICACION = 14
                    });

                string[] _nombresSubClasificaciones15 = new string[] { "GNU/LINUX", "PROGRAMACAO", "TEC & GADG" };
                for (int i = 0; i < _nombresSubClasificaciones15.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones15[i],
                        ID_CLASIFICACION = 15
                    });

                string[] _nombresSubClasificaciones16 = new string[] { "HENTAI XCHAN", "PORN XCHAN" };
                for (int i = 0; i < _nombresSubClasificaciones16.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length
                             + _nombresSubClasificaciones15.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones16[i],
                        ID_CLASIFICACION = 16
                    });
                #endregion
                #region uboachan
                string[] _nombresSubClasificaciones17 = new string[] { "YUME NIKKI GENERAL", "YUME NIKKI - DREAM DIARY", "FANGAMES", "DREAMS" };
                for (int i = 0; i < _nombresSubClasificaciones17.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length +
                             _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones17[i],
                        ID_CLASIFICACION = 17
                    });

                string[] _nombresSubClasificaciones18 = new string[] { "ART / OEKAKI", "LITERATURE / FANFIC / POETRY", "MUSIC / UPLOADS", "OTHER GAMES", "RPGMAKER / GAMEDEV" };
                for (int i = 0; i < _nombresSubClasificaciones18.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length +
                             _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length
                             + _nombresSubClasificaciones17.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones18[i],
                        ID_CLASIFICACION = 18
                    });

                string[] _nombresSubClasificaciones19 = new string[] { "OFF-TOPIC", "NEET / ADVICE", "CREEPY-CUTE", "PARANORMAL / OCCULT", "SUGGESTIONS / META" };
                for (int i = 0; i < _nombresSubClasificaciones19.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length
                             + _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length
                             + _nombresSubClasificaciones17.Length + +_nombresSubClasificaciones18.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones19[i],
                        ID_CLASIFICACION = 19
                    });
                #endregion
                #region tohno chan
                string[] _nombresSubClasificaciones20 = new string[] { "-ANIME", "-MANGA", "-VIDEO GAMES", "-TOUHOU", "-MUSIC", "-VISUAL NOVEL" };
                for (int i = 0; i < _nombresSubClasificaciones20.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length +
                             _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length +
                             _nombresSubClasificaciones17.Length + _nombresSubClasificaciones18.Length +
                             _nombresSubClasificaciones19.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones20[i],
                        ID_CLASIFICACION = 20
                    });

                string[] _nombresSubClasificaciones21 = new string[] { "-COLLECTIBLES", "-SCIENCE", "-CREATIVITY" };
                for (int i = 0; i < _nombresSubClasificaciones21.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length +
                             _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length +
                             _nombresSubClasificaciones17.Length + _nombresSubClasificaciones18.Length +
                             _nombresSubClasificaciones19.Length + _nombresSubClasificaciones20.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones21[i],
                        ID_CLASIFICACION = 21
                    });

                string[] _nombresSubClasificaciones22 = new string[] { "-RONERY", "-WAIFU", "-OTAKU TANGENTS" };
                for (int i = 0; i < _nombresSubClasificaciones22.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length +
                             _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length +
                             _nombresSubClasificaciones17.Length + +_nombresSubClasificaciones18.Length +
                             _nombresSubClasificaciones19.Length + _nombresSubClasificaciones20.Length +
                             _nombresSubClasificaciones21.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones22[i],
                        ID_CLASIFICACION = 22
                    });

                string[] _nombresSubClasificaciones23 = new string[] { "-IRC", "-DATA", "-ARCHIVE", "-HENTAI", "-KEMONO FRIENDS", "-DUMPS", "-FUNPOSTING", "-DEBATES" };
                for (int i = 0; i < _nombresSubClasificaciones23.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length +
                             _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length +
                             _nombresSubClasificaciones17.Length + +_nombresSubClasificaciones18.Length +
                             _nombresSubClasificaciones19.Length + _nombresSubClasificaciones20.Length +
                             _nombresSubClasificaciones21.Length + _nombresSubClasificaciones22.Length +
                             1 + i,
                        DESCR = _nombresSubClasificaciones23[i],
                        ID_CLASIFICACION = 23
                    });
                #endregion
                #region final chan
                string[] _nombresSubClasificaciones24 = new string[] { "ANIME & MANGA FINAL CHAN", "COMICS & CARTOONS", "VIDEO GAMES FINAL CHAN", "TECHNOLOGY FINAL CHAN" };
                for (int i = 0; i < _nombresSubClasificaciones24.Length; i++)
                    _subClasificaciones.Add(new Herramientas.Utilerias.cComboBoxSubClasificacion()
                    {
                        ID = _nombresSubClasificaciones.Length + _nombresSubClasificaciones2.Length +
                             _nombresSubClasificaciones3.Length + _nombresSubClasificaciones4.Length +
                             _nombresSubClasificaciones5.Length + _nombresSubClasificaciones6.Length +
                             _nombresSubClasificaciones7.Length + _nombresSubClasificaciones8.Length +
                             _nombresSubClasificaciones9.Length + _nombresSubClasificaciones10.Length +
                             _nombresSubClasificaciones11.Length + _nombresSubClasificaciones12.Length +
                             _nombresSubClasificaciones13.Length + _nombresSubClasificaciones14.Length +
                             _nombresSubClasificaciones15.Length + _nombresSubClasificaciones16.Length +
                             _nombresSubClasificaciones17.Length + +_nombresSubClasificaciones18.Length +
                             _nombresSubClasificaciones19.Length + _nombresSubClasificaciones20.Length +
                             _nombresSubClasificaciones21.Length + _nombresSubClasificaciones22.Length +
                             _nombresSubClasificaciones23.Length + 1 + i,
                        DESCR = _nombresSubClasificaciones24[i],
                        ID_CLASIFICACION = 24
                    });


                #endregion
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
                #region 4chan
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
                #endregion
                #region lainchan
                _diccionario.Add("PROGRAMMING LAINCHAN", "https://lainchan.org/\u03BB/index.html");
                _diccionario.Add("DO IT YOURSELF LAINCHAN", "https://lainchan.org/Δ/index.html");
                _diccionario.Add("SEC LAINCHAN", "https://lainchan.org/sec/index.html");
                _diccionario.Add("TECH LAINCHAN", "https://lainchan.org/Ω/index.html");
                _diccionario.Add("INTER LAINCHAN", "https://lainchan.org/inter/index.html");
                _diccionario.Add("LIT LAINCHAN", "https://lainchan.org/lit/index.html");
                _diccionario.Add("MUSIC LAINCHAN", "https://lainchan.org/music/index.html");
                _diccionario.Add("VIS LAINCHAN", "https://lainchan.org/vis/index.html");
                _diccionario.Add("HUM LAINCHAN", "https://lainchan.org/hum/index.html");
                _diccionario.Add("DRG LAINCHAN", "https://lainchan.org/drug/index.html");
                _diccionario.Add("ZZZ LAINCHAN", "https://lainchan.org/zzz/index.html");
                _diccionario.Add("LAYER LAINCHAN", "https://lainchan.org/layer/index.html");
                _diccionario.Add("Q LAINCHAN", "https://lainchan.org/q/index.html");
                _diccionario.Add("R LAINCHAN", "https://lainchan.org/r/index.html");
                _diccionario.Add("CULT LAINCHAN", "https://lainchan.org/culture/index.html");
                _diccionario.Add("PSY LAINCHAN", "https://lainchan.org/psy/index.html");
                _diccionario.Add("MEGA LAINCHAN", "https://lainchan.org/mega/index.html");
                _diccionario.Add("RND LAINCHAN", "https://lainchan.org/random/index.html");
                #endregion
                #region xchan
                _diccionario.Add("ALEATORIO", "https://xchan.pw/board/b/");
                _diccionario.Add("C-C-C-CANCER", "https://xchan.pw/board/c/");
                _diccionario.Add("HUEHUE", "https://xchan.pw/board/int/");
                _diccionario.Add("ENTRETENIMIENTO", "https://xchan.pw/board/e/");
                _diccionario.Add("JOGOS CONSOLAS", "https://xchan.pw/board/jo/");
                _diccionario.Add("MUSIC XCHAN", "https://xchan.pw/board/mu/");
                _diccionario.Add("XCHAN", "https://xchan.pw/board/x/");
                _diccionario.Add("DESENVOLVIMENTO", "https://xchan.pw/board/dev/");
                _diccionario.Add("GNU/LINUX", "https://xchan.pw/board/gnu/");
                _diccionario.Add("PROGRAMACAO", "https://xchan.pw/board/prog");
                _diccionario.Add("TEC & GADG", "https://xchan.pw/board/tech/");
                _diccionario.Add("HENTAI XCHAN", "https://xchan.pw/board/h/");
                _diccionario.Add("PORN XCHAN", "https://xchan.pw/board/porn/");
                #endregion
                #region uboachan
                _diccionario.Add("YUME NIKKI GENERAL", "https://uboachan.net/yn/");
                _diccionario.Add("YUME NIKKI - DREAM DIARY", "https://uboachan.net/yndd/");
                _diccionario.Add("FANGAMES", "https://uboachan.net/fg/");
                _diccionario.Add("DREAMS", "https://uboachan.net/yume/");

                _diccionario.Add("ART / OEKAKI", "https://uboachan.net/o/");
                _diccionario.Add("LITERATURE / FANFIC / POETRY", "https://uboachan.net/lit/");
                _diccionario.Add("MUSIC / UPLOADS", "https://uboachan.net/media/");
                _diccionario.Add("OTHER GAMES", "https://uboachan.net/og/");
                _diccionario.Add("RPGMAKER / GAMEDEV", "https://uboachan.net/ig/");

                _diccionario.Add("OFF-TOPIC", "https://uboachan.net/ot/");
                _diccionario.Add("NEET / ADVICE", "https://uboachan.net/hikki/");
                _diccionario.Add("CREEPY-CUTE", "https://uboachan.net/cc/");
                _diccionario.Add("PARANORMAL / OCCULT", "https://uboachan.net/x/");
                _diccionario.Add("SUGGESTIONS / META", "https://uboachan.net/sugg/");
                #endregion
                #region tohno chan
                _diccionario.Add("-ANIME", "http://tohno-chan.com/an/");
                _diccionario.Add("-MANGA", "http://tohno-chan.com/ma/");
                _diccionario.Add("-VIDEO GAMES", "http://tohno-chan.com/vg/");
                _diccionario.Add("-TOUHOU", "http://tohno-chan.com/foe/");
                _diccionario.Add("-MUSIC", "http://tohno-chan.com/mp3/");
                _diccionario.Add("-VISUAL NOVEL", "http://tohno-chan.com/vn/");

                _diccionario.Add("-COLLECTIBLES", "http://tohno-chan.com/fig/");
                _diccionario.Add("-SCIENCE", "http://tohno-chan.com/navi/");
                _diccionario.Add("-CREATIVITY", "http://tohno-chan.com/cr/");

                _diccionario.Add("-RONERY", "http://tohno-chan.com/so/");
                _diccionario.Add("-WAIFU", "http://tohno-chan.com/mai/");
                _diccionario.Add("-OTAKU TANGENTS", "http://tohno-chan.com/ot/");

                _diccionario.Add("-IRC", "http://tohno-chan.com/irc/");
                _diccionario.Add("-DATA", "http://tohno-chan.com/ddl/");
                _diccionario.Add("-ARCHIVE", "http://tohno-chan.com/arc/");
                _diccionario.Add("-HENTAI", "http://tohno-chan.com/ns/");
                _diccionario.Add("-KEMONO FRIENDS", "http://tohno-chan.com/kf");
                _diccionario.Add("-DUMPS", "http://tohno-chan.com/pic");
                _diccionario.Add("-FUNPOSTING", "http://tohno-chan.com/lol/");
                _diccionario.Add("-DEBATES", "http://tohno-chan.com/tat/");
                #endregion
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
                System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion> _datosLimpios = new System.Collections.Generic.List<Herramientas.Utilerias.cComboBoxClasificacion>
                {
                    new Herramientas.Utilerias.cComboBoxClasificacion() { ID = 0, DESCR = "SELECCIONE" }
                };

                ComboClasificacion.ItemsSource = _datosLimpios;
                ComboClasificacion.SelectedIndex = 0;
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        public async void BuscarPrueba()
        {
            try
            {
                var _cliente = new HttpClient();
                var _respuesta = await _cliente.GetByteArrayAsync("http://finalchan.net/t/index.html");
                System.String source = System.Text.Encoding.GetEncoding("utf-8").GetString(_respuesta, 0, _respuesta.Length - 1);
                source = WebUtility.HtmlDecode(source);
                var _doc = new HtmlAgilityPack.HtmlDocument();
                _doc.LoadHtml(source);
                var aaa = _doc.DocumentNode.ChildNodes;
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        public async void Buscar(string _url)
        {
            try
            {
                System.Collections.Generic.List<Herramientas.ClasesCustomizadas.cPrincipal> _menu = new System.Collections.Generic.List<Herramientas.ClasesCustomizadas.cPrincipal>();
                var _plataformaSeleccionada = ComboPlataforma.SelectedItem as Herramientas.Utilerias.cComboBox;
                var _cliente = new HttpClient();
                var _respuesta = await _cliente.GetByteArrayAsync(_url);
                System.String source = System.Text.Encoding.GetEncoding("utf-8").GetString(_respuesta, 0, _respuesta.Length - 1);
                source = WebUtility.HtmlDecode(source);
                var _doc = new HtmlAgilityPack.HtmlDocument();
                _doc.LoadHtml(source);
                foreach (HtmlAgilityPack.HtmlNode _data in _doc.DocumentNode.ChildNodes)
                {
                    var _nodos = _data.ChildNodes;
                    if (_nodos != null)
                        if (_nodos.Any())
                        {
                            var _subNodos = _nodos.ToList();
                            var _cuerpo = _subNodos.FirstOrDefault(x => x.Name == "body");
                            if (_cuerpo != null)
                            {
                                var _detalleCuerpo = _cuerpo.ChildNodes;
                                if (_detalleCuerpo != null)
                                    if (_detalleCuerpo.Any())
                                        foreach (var item2 in _detalleCuerpo)
                                        {
                                            switch (_plataformaSeleccionada.ID)
                                            {
                                                #region lainchan
                                                case 2:
                                                    _doc.DocumentNode.Descendants("img").Select(e => e.GetAttributeValue("src", null)).Where(s => !System.String.IsNullOrEmpty(s)).ToList().ForEach(z =>
                                                    {
                                                        var _validacion = z.Split('.');
                                                        if (_validacion != null)
                                                            if (_validacion.Any())
                                                            {
                                                                var _ex = _validacion.LastOrDefault();
                                                                if (_ex != "php" && _ex != "js")
                                                                {
                                                                    if (!_menu.Any(x => Path.GetFileName(x._url) == Path.GetFileName(z)))
                                                                    {
                                                                        _menu.Add(new Herramientas.ClasesCustomizadas.cPrincipal()
                                                                        {
                                                                            _url = "https://lainchan.org" + z
                                                                        });
                                                                    }
                                                                }
                                                            }
                                                    });
                                                    break;
                                                #endregion
                                                #region xchan
                                                case 3:
                                                    _doc.DocumentNode.Descendants("img").Select(e => e.GetAttributeValue("src", null)).Where(s => !System.String.IsNullOrEmpty(s)).ToList().ForEach(z =>
                                                    {
                                                        var _validacion = z.Split('.');
                                                        if (_validacion != null)
                                                            if (_validacion.Any())
                                                            {
                                                                var _ex = _validacion.LastOrDefault();
                                                                if (_ex != "php" && _ex != "js")
                                                                {
                                                                    if (!_menu.Any(x => Path.GetFileName(x._url) == Path.GetFileName(z)))
                                                                    {
                                                                        _menu.Add(new Herramientas.ClasesCustomizadas.cPrincipal()
                                                                        {
                                                                            _url = "https://xchan.pw" + z
                                                                        });
                                                                    }
                                                                }
                                                            }
                                                    });
                                                    break;
                                                #endregion
                                                #region uboachan
                                                case 4:
                                                    _doc.DocumentNode.Descendants("img").Select(e => e.GetAttributeValue("src", null)).Where(s => !System.String.IsNullOrEmpty(s)).ToList().ForEach(z =>
                                                    {
                                                        var _validacion = z.Split('.');
                                                        if (_validacion != null)
                                                            if (_validacion.Any())
                                                            {
                                                                var _ex = _validacion.LastOrDefault();
                                                                if (_ex != "php" && _ex != "js")
                                                                {
                                                                    if (!_menu.Any(x => Path.GetFileName(x._url) == Path.GetFileName(z)))
                                                                    {
                                                                        _menu.Add(new Herramientas.ClasesCustomizadas.cPrincipal()
                                                                        {
                                                                            _url = "https://uboachan.net" + z
                                                                        });
                                                                    }
                                                                }
                                                            }
                                                    });

                                                    break;
                                                #endregion
                                                #region tohno chan
                                                case 5:
                                                    _doc.DocumentNode.Descendants("a").Select(e => e.Attributes["href"]).ToList().ForEach(z =>
                                                    {
                                                        if (z != null)
                                                            if (z.Value != null)
                                                                if (!string.IsNullOrEmpty(z.Value))
                                                                {
                                                                    var _validacion = z.Value.Split('.');
                                                                    if (_validacion != null)
                                                                        if (_validacion.Any())
                                                                        {
                                                                            var _ex = _validacion.LastOrDefault();
                                                                            if (_ex == "png" || _ex == "jpg")
                                                                            {
                                                                                if (!_menu.Any(x => Path.GetFileName(x._url) == Path.GetFileName(z.Value)))
                                                                                {
                                                                                    _menu.Add(new Herramientas.ClasesCustomizadas.cPrincipal()
                                                                                    {
                                                                                        _url = z.Value
                                                                                    });
                                                                                }
                                                                            }
                                                                        }
                                                                }
                                                    });
                                                    break;
                                                #endregion
                                                default:
                                                    break;
                                            }
                                        }
                            }
                        }
                }


                lstMenuPrincipal.ItemsSource = _menu;
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
            if (!(ComboSubClasificacion.SelectedItem is Herramientas.Utilerias.cComboBoxSubClasificacion _seleccion))
            {
                System.Windows.MessageBox.Show("Seleccione una sub clasificación");
                return;
            }

            var _elegido = _diccionario.FirstOrDefault(x => x.Key == _seleccion.DESCR);
            if (string.IsNullOrEmpty(_elegido.Value))
            {
                System.Windows.MessageBox.Show("La selección elegida no cuenta con una URL asociada");
                return;
            }

            Buscar(_elegido.Value);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lstMenuPrincipal.Items != null)
                if (lstMenuPrincipal.Items.Count > 0)
                {
                    var _elementos = lstMenuPrincipal.Items.Cast<Herramientas.ClasesCustomizadas.cPrincipal>().Select(item => item._url).ToList();
                    foreach (var item in _elementos)
                    {
                        using (webClient = new WebClient())
                        {
                            System.Uri URL = new System.Uri(item);
                            sw.Start();
                            try
                            {
                                webClient.DownloadFile(URL, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/" + new System.Random().Next(1, 5000) + "." + Path.GetExtension(item));
                            }
                            catch (System.Exception ex)
                            {
                                System.Windows.MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("No hay resultados para descargar");
                    return;
                }
        }
    }
}