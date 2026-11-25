using Echecs.Controls;
using Echecs.Enums;
using Echecs.Helper;
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

        // Image
        public string CheminImagesPieces;

        // Grille
        public readonly List<List<Case>> Grille;
        public int TailleGrille;

        // Joueur
        public EnumJoueur TeamJoueur;
        public EnumJoueur TeamJoueurAdverse => TeamJoueur == EnumJoueur.Blanc ? EnumJoueur.Noir : EnumJoueur.Blanc;
        public EnumJoueur JoueurActuel;
        public EnumJoueur JoueurAdverse => JoueurActuel == EnumJoueur.Blanc ? EnumJoueur.Noir : EnumJoueur.Blanc;

        // Piece
        public Case? CaseSelectionnee
        {
            set
            {
                if (value == null)
                {
                    return;
                }

                if (PromotionEnCours)
                {
                    return;
                }

                if (value.Piece == PieceSelectionnee)
                {
                    PieceSelectionnee = null;
                    PlateauHelper.CacherCasesDisponibles(Grille);
                    return;
                }

                if (PieceSelectionnee != null)
                {
                    if (PieceSelectionnee.RecupererListeCasesDisponibles().Contains(value))
                    {
                        PlateauHelper.DeplacerPiece(Grille, PieceSelectionnee, value);
                        PieceSelectionnee = null;
                        PlateauHelper.CacherCasesDisponibles(Grille);

                        if (value.Piece is Pion pPion && pPion.EstSurDerniereLigne())
                        {
                            PromotionEnCours = true;
                            PromotionDemandee?.Invoke(value);
                            return;
                        }

                        JoueurActuel = JoueurAdverse;
                        return;
                    }
                }

                if (value.Piece != null)
                {
                    if (value.Piece.Team == JoueurAdverse)
                    {
                        return;
                    }
                }
                PieceSelectionnee = value.Piece;
            }
        }

        private Piece? _PieceSelectionnee;
        public Piece? PieceSelectionnee
        {
            get => _PieceSelectionnee;
            set
            {
                PlateauHelper.CacherCasesDisponibles(Grille);

                _PieceSelectionnee = value;

                if (value != null)
                {
                    value.AfficherCasesDisponibles();
                }
            }
        }

        public Action<Case>? PromotionDemandee;

        public bool PromotionEnCours;

        #endregion


        #region [Constructeurs - Initialisation]

        private Moteur()
        {
            // Image
            CheminImagesPieces = "pack://application:,,,/Ressources/Images/Pieces/";

            // Grille
            Grille = new(8);
            TailleGrille = 8;

            // Joueur
            TeamJoueur = EnumJoueur.Blanc;
            JoueurActuel = EnumJoueur.Blanc;

            // Piece
            PieceSelectionnee = null;
        }

        #endregion
    }
}
