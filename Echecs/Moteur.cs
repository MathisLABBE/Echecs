using Echecs.Controls;
using Echecs.Enums;
using Echecs.Pieces;

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

        public string CheminImagesPieces;

        public readonly List<List<Case>> Grille = new(8);

        public EnumJoueur Joueur;

        public Piece? PieceSelectionnee;

        #endregion


        #region [Constructeurs - Initialisation]

        private Moteur()
        {
            CheminImagesPieces = "pack://application:,,,/Ressources/Images/Pieces/";
            Joueur = EnumJoueur.Joueur1;
            PieceSelectionnee = null;
        }

        #endregion
    }
}
