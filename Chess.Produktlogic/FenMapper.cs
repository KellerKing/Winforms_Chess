using Chess.Contracts.Productlogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Productlogic
{
  public class FenMapper
  {
    private static readonly Dictionary<char, PieceType> MappingCharToPieceType = new Dictionary<char, PieceType>()
    {
      { 'K', PieceType.KING },

      { 'R', PieceType.ROOK },

      { 'B', PieceType.BISHOP },

      { 'N', PieceType.KNIGHT },

      { 'P', PieceType.PAWN },

      { 'Q', PieceType.QUEEN },
    };

    private static readonly Dictionary<PieceType, char> MappingPieceTypeToChar = new Dictionary<PieceType, char>()
    {
      { PieceType.KING, 'K' },

      { PieceType.ROOK, 'R' },

      { PieceType.BISHOP, 'B' },

      { PieceType.KNIGHT, 'N' },

      { PieceType.PAWN, 'P' },

      { PieceType.QUEEN, 'Q' },
    };

    public static List<Piece> CreatePiecesFromFen(string fen)
    {
      if (string.IsNullOrEmpty(fen)) return new List<Piece>();

      var fenbloecke = fen.Split(" "); //TODO: Den Rest sollte man irgendwann auswerten

      var figurenTeil = fenbloecke.FirstOrDefault() ?? String.Empty;
      var aktiverSpielerTeil = fenbloecke.Length > 1 ? fenbloecke[1] : String.Empty;
      var rochadeTeil = fenbloecke.Length > 2 ? fenbloecke[2] : String.Empty;
      var enPassantTeil = fenbloecke.Length > 3 ? fenbloecke[3] : String.Empty;
      var halbzuegeTeil = fenbloecke.Length > 4 ? fenbloecke[4] : String.Empty;
      var zugnummerTeil = fenbloecke.Length > 5 ? fenbloecke[5] : String.Empty;

      var result = CreatePiecePositionFromFen(figurenTeil).ToList();

      return result;
    }

    public static string CreateFenFromPices(List<Piece> pieces, Player currentPlayer)
    {
      var figurenstellung = GetFigurenstellungFen(pieces);
      var aktiverSpieler = GetSpielerAmZug(currentPlayer);
      var rochadeRechtWeiss = GetRochardeRechtFuerSpieler(pieces, Player.WHITE);
      var rochadeRechtSchwarz = GetRochardeRechtFuerSpieler(pieces, Player.BLACK);
      var rochadeRecht = string.IsNullOrEmpty(rochadeRechtSchwarz) && string.IsNullOrEmpty(rochadeRechtWeiss) ? "-" : rochadeRechtWeiss + rochadeRechtSchwarz;
      var enPassantSchlag = GetEnPassantSchlag(pieces, currentPlayer);
      var halbzuege = GetHalbzuege(pieces);
      var zugnummer = GetZugnummerNaechsterZug(pieces, currentPlayer);

      return $"{figurenstellung} {aktiverSpieler} {rochadeRecht} {enPassantSchlag} {halbzuege} {zugnummer}";
    }

    private static string GetFigurenstellungFen(IEnumerable<Piece> pieces)
    {
      const int maxRankZeroIndexed = 7;
      var result = new StringBuilder();

      for (int currentRank = maxRankZeroIndexed; currentRank >= 0; currentRank--)
      {
        var piecesCurrentRank = pieces?.Where(x => x.Coord.Rank == currentRank).ToList();
        if (piecesCurrentRank.Count == 0)
        {
          result.Append("8/");
          continue;
        }
        result.Append(ConvertRowToFen(piecesCurrentRank));
      }

      result.Remove(Math.Max(result.Length - 1, 0), 1);

      return result.ToString();
    }

    private static char GetSpielerAmZug(Player currentPlayer)
    {
      switch (currentPlayer)
      {
        case Player.BLACK:
          return 'b';
        case Player.WHITE:
          return 'w';
      }
      return '-';
    }

    private static string GetRochardeRechtFuerSpieler(IEnumerable<Piece> pieces, Player playerToCheck)
    {
      var result = "";
      var king = pieces?.FirstOrDefault(x => x.Owner == playerToCheck && x.PieceType == PieceType.KING);
      if (king == null) return result;

      if (king.HasCastleKingSideRight) result += "K";
      if (king.HasCastleQueenSideRight) result += "Q";

      return playerToCheck == Player.WHITE ? result : result.ToLower();
    }

    private static string GetEnPassantSchlag(IEnumerable<Piece> pieces, Player currentPlayer)
    {
      var bauerGegner = currentPlayer == Player.WHITE ?
        pieces.FirstOrDefault(x => x.Owner == Player.BLACK && x.PieceType == PieceType.PAWN && x.IsLastMovedPieceFromPlayer && x.Coord.Rank == 4 && x.MoveCounter == 1) :
        pieces.FirstOrDefault(x => x.Owner == Player.WHITE && x.PieceType == PieceType.PAWN && x.IsLastMovedPieceFromPlayer && x.Coord.Rank == 3 && x.MoveCounter == 1);

      if (bauerGegner == null) return "-";

      var fileIndexToChar = new Dictionary<int, char>
      {
        {0, 'a' },
        {1, 'b' },
        {2, 'c' },
        {3, 'd' },
        {4, 'e' },
        {5, 'f' },
        {6, 'g' },
        {7, 'h' },
      };

      var rankIndexToChar = new Dictionary<int, char>
      {
        {0, '1' },
        {1, '2' },
        {2, '3' },
        {3, '4' },
        {4, '5' },
        {5, '6' },
        {6, '7' },
        {7, '8' },
      };

      return currentPlayer == Player.WHITE ?
        $"{fileIndexToChar[bauerGegner.Coord.File]}{rankIndexToChar[bauerGegner.Coord.Rank + 1]}" :
        $"{fileIndexToChar[bauerGegner.Coord.File]}{rankIndexToChar[bauerGegner.Coord.Rank - 1]}";
    }

    private static string GetHalbzuege(IEnumerable<Piece> pieces)
    {
      return pieces.Sum(x => x.MovesSinceLastPawnOrCaptureMove).ToString();
    }

    private static string GetZugnummerNaechsterZug(IEnumerable<Piece> pieces, Player currentPlayer)
    {
      var anzahlZuege = Math.Ceiling(pieces.Sum(x => x.MoveCounter) / 2.0);
      var zusatz = currentPlayer == Player.BLACK ? 0 : 1;

      return Math.Max(anzahlZuege + zusatz, 1).ToString();
    }


    private static string ConvertRowToFen(List<Piece> piecesSorted)
    {
      var fen = new List<char>();

      for (int fileCurrent = 0; fileCurrent < 8; fileCurrent++)
      {
        fen.Add(GetFenSymbol(piecesSorted, fileCurrent));
      }
      fen.Add('/');
      return SumUpNumbers(fen);
    }

    private static string SumUpNumbers(List<char> fen)
    {
      var output = new StringBuilder();

      var value = 0;

      for (int i = 0; i < fen.Count; i++)
      {
        if (fen[i] == '1')
        {
          value++;
          continue;
        }
        if (value != 0)
          output.Append(Convert.ToString(value)[0]);

        output.Append(fen[i]);
        value = 0;
      }
      return output.ToString();
    }

    private static char GetFenSymbol(List<Piece> piecesSorted, int fileCurrent)
    {
      var piece = piecesSorted.Find(x => x.Coord.File == fileCurrent);

      if (piece == null) return '1';

      return piece.Owner == Player.WHITE ?
        MappingPieceTypeToChar[piece.PieceType] :
        Char.ToLowerInvariant(MappingPieceTypeToChar[piece.PieceType]);
    }


    private static IEnumerable<Piece> CreatePiecePositionFromFen(string fenBlock)
    {
      var result = new List<Piece>();
      var splittedFen = fenBlock.Split('/').Reverse().ToList();

      for (int rankIndex = 0; rankIndex < splittedFen.Count; rankIndex++)
      {
        result.AddRange(GetPiecesFromRank(splittedFen[rankIndex], rankIndex));
      }

      return result;
    }

    private static List<Piece> GetPiecesFromRank(string rank, int rankIndex)
    {
      var output = new List<Piece>();
      var fileCurrent = 0;

      for (int fileIndex = 0; fileIndex < rank.Length; fileIndex++)
      {
        var character = rank[fileIndex];

        if (Char.IsNumber(character))
        {
          fileCurrent += Convert.ToInt32(character.ToString());
          continue;
        }

        output.Add(new Piece(Char.IsLower(character) ? Player.BLACK : Player.WHITE)
        {
          PieceType = MappingCharToPieceType[char.ToUpper(character)],
          MoveCounter = 0,
          Coord = new(rankIndex, fileCurrent)
        });
        fileCurrent++;
      }
      return output;
    }

  }
}