using Echecs.Enums;

namespace Echecs
{
    public class Moteur
    {
        #region [Singleton]

        private static Moteur? _Instance;
        public static Moteur Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Moteur();
                }

                return _Instance;
            }
        }

        #endregion


        #region [Propriétés]

        public EnumJoueur Joueur;

        #endregion


        #region [Constructeurs - Initialisation]

        private Moteur()
        {
            Joueur = EnumJoueur.Joueur1;
        }

        #endregion
    }
}
