namespace FLAMINIS.Herramientas
{
    public class Utilerias
    {
        public class cComboBox
        {
            public string DESCR { get; set; }
            public int ID { get; set; }
        }

        public class cComboBoxClasificacion
        {
            public string DESCR { get; set; }
            public int ID { get; set; }
            public int ID_PLATAFORMA { get; set; }
        }

        public class cComboBoxSubClasificacion
        {
            public string DESCR { get; set; }
            public int ID { get; set; }
            public int ID_CLASIFICACION { get; set; }
        }

        public enum ePlataformas
        {
            LAINCHAN = 2,
            XCHAN = 3,
            UBOACHAN = 4,
            TOHNO_CHAN = 5,
            FINAL_CHAN = 6,
            CHAN420 = 7
        };
    }
}