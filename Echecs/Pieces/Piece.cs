using Echecs.Enums;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Echecs.Pieces
{
    public class Piece : UserControl
    {
        #region [Propriétés]

        public EnumJoueur Joueur { get; set; }

        public string? CheminImage { get; set; }

        public string CouleurImage { get; set; }

        private readonly Moteur Moteur = Moteur.Instance;

        public ImageSource? SourceImage => string.IsNullOrWhiteSpace(CheminImage) ? null : new BitmapImage(new Uri(CheminImage, UriKind.RelativeOrAbsolute));

        #endregion


        #region [Constructeurs - Initialisation]

        public Piece()
        {
            Joueur = EnumJoueur.Aucun;
            CheminImage = null;
        }

        public Piece(EnumJoueur pJoueur)
        {
            Joueur = pJoueur;

            if (Joueur == EnumJoueur.Joueur1)
            {
                CouleurImage = "Blanc";
            }
            else
            {
                CouleurImage = "Noir";
            }
            CheminImage = Moteur.CheminImages + CouleurImage + "/";
        }

        #endregion
    }
}
