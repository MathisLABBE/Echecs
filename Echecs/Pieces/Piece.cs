using Echecs.Controls;
using Echecs.Enums;
using Echecs.Helper;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Echecs.Pieces
{
    public class Piece : UserControl
    {
        #region [Propriétés]

        // Image
        public string? CheminImage { get; set; }
        public string Couleur { get; set; }
        public ImageSource? SourceImage => string.IsNullOrWhiteSpace(CheminImage) ? null : new BitmapImage(new Uri(CheminImage, UriKind.RelativeOrAbsolute));

        // Joueur
        public EnumJoueur Team { get; set; }

        // Moteur
        private readonly Moteur Moteur = Moteur.Instance;

        // Position
        public int NbDeplacement;
        public List<int> Position;
        public int Ligne => Position[0];
        public int Colonne => Position[1];

        #endregion


        #region [Constructeurs - Initialisation]

        public Piece()
        {
            // Image
            CheminImage = null;
            Couleur = "";

            // Joueur
            Team = EnumJoueur.Aucun;

            // Position
            NbDeplacement = 0;
            Position = [];
        }

        public Piece(EnumJoueur pJoueur, List<int> pPosition)
        {
            // Joueur
            Team = pJoueur;

            // Image
            if (Team == EnumJoueur.Blanc)
            {
                Couleur = "Blanc";
            }
            else
            {
                Couleur = "Noir";
            }
            CheminImage = Moteur.CheminImagesPieces + Couleur + "/";

            // Position
            NbDeplacement = 0;
            Position = pPosition;
        }

        #endregion


        #region [Séléctionner]

        public void Selectionner(Piece pPieceSelectionnee)
        {
            //Moteur.PieceSelectionnee = pPieceSelectionnee;
        }

        #endregion


        #region [Récupérer]

        public virtual List<Case> RecupererListeCasesDisponibles()
        {
            return [];
        }

        #endregion


        #region [Afficher]

        public void AfficherCasesDisponibles()
        {
            List<List<Case>> lGrille = Moteur.Grille;
            List<Case> lListeCasesDisponibles = RecupererListeCasesDisponibles();

            foreach (var lCaseDisponible in lListeCasesDisponibles)
            {
                PlateauHelper.SurlignerCase(Moteur.Grille, lCaseDisponible.Ligne, lCaseDisponible.Colonne);
            }
        }

        #endregion
    }
}
