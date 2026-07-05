using Echecs.Controls;
using Echecs.Pieces;
using System.Windows.Media;

namespace Echecs.Helper
{
    public static class PlateauHelper
    {
        #region [Récupérer]

        public static Brush RecupererCouleurCase(int pLigne, int pColonne)
        {
            if ((pLigne + pColonne) % 2 == 0)
            {
                return Brushes.White;
            }
            else
            {
                return Brushes.DarkGreen;
            }
        }

        public static Case? RecupererCase(List<List<Case>> pGrille, int pLigne, int pColonne)
        {
            try
            {
                return pGrille[pLigne][pColonne];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCase(List<List<Case>> pGrille, List<int> pCoordonnees)
        {
            if (pCoordonnees.Count != 2)
            {
                return null;
            }

            return RecupererCase(pGrille, pCoordonnees[0], pCoordonnees[1]);
        }

        public static Case? RecupererCaseGauche(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX][pPositionY - 1];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCaseDroite(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX][pPositionY + 1];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCaseHaut(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX - 1][pPositionY];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCaseBas(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX + 1][pPositionY];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCaseHautGauche(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX - 1][pPositionY - 1];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCaseHautDroite(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX - 1][pPositionY + 1];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCaseBasGauche(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX + 1][pPositionY - 1];
            }
            catch
            {
                return null;
            }
        }

        public static Case? RecupererCaseBasDroite(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            try
            {
                return pGrille[pPositionX + 1][pPositionY + 1];
            }
            catch
            {
                return null;
            }
        }

        #endregion


        #region [Afficher]

        public static void SurlignerCase(List<List<Case>> pGrille, int pPositionX, int pPositionY)
        {
            pGrille[pPositionX][pPositionY].CouleurSurlignage = new SolidColorBrush(Color.FromArgb(220, 128, 128, 128));
        }

        #endregion


        #region [Cacher]

        public static void CacherCasesDisponibles(List<List<Case>> pGrille)
        {
            foreach (var lLigne in pGrille)
            {
                foreach (var lCase in lLigne)
                {
                    lCase.CouleurSurlignage = Brushes.Transparent;
                }
            }
        }

        #endregion


        #region [Déplacer]

        public static void DeplacerPiece(List<List<Case>> pGrille, Piece pPieceADeplacer, Case pCaseDestination)
        {
            Case? lCaseSource = PlateauHelper.RecupererCase(pGrille, pPieceADeplacer.Position);

            if (lCaseSource == null)
            {
                return;
            }

            pPieceADeplacer.Position = pCaseDestination.Position;
            if (pPieceADeplacer is Pion pPion)
            {
                if (pPion.EstSurDerniereLigne())
                {
                    pPieceADeplacer = new Dame(pPieceADeplacer.Team, pPieceADeplacer.Position);
                }
            }

            pCaseDestination.Piece = pPieceADeplacer;
            pPieceADeplacer.NbDeplacement++;
            lCaseSource.Piece = null;
        }

        #endregion
    }
}
