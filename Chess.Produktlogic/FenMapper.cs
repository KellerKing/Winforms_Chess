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
      var splittedFen = fen.Split('/').Reverse().ToList();
      var output = new List<Piece>();

      for (int rankIndex = 0; rankIndex < splittedFen.Count; rankIndex++)
      {
        output.AddRange(GetPiecesFromRank(splittedFen[rankIndex], rankIndex));
      }

      return output;
    }

    public static string CreateFenFromPices(List<Piece> pieces, Player currentPlayer)
    {
      var figurenstellung = GetFigurenstellungFen(pieces);
      var aktiverSpieler = GetSpielerAmZug(currentPlayer);
      var rochadeRechtWeiss = GetRochardeRechtFuerSpieler(pieces, Player.WHITE);
      var rochadeRechtSchwarz = GetRochardeRechtFuerSpieler(pieces, Player.BLACK);
      var enPassantSchlat = GetEnPassantSchlag(pieces, currentPlayer);
      return figurenstellung;
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
      return ' ';
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
      var pawn = currentPlayer == Player.WHITE ?
        pieces.FirstOrDefault(x => x.Owner == Player.BLACK && x.Coord.Rank == 4 && x.MoveCounter == 1) :
        pieces.FirstOrDefault(x => x.Owner == Player.WHITE && x.Coord.Rank == 3 && x.MoveCounter == 1);

      if (pawn == null) return "-";

      var rankIndexToChar = new Dictionary<int, char> 
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

      var fileIndexToChar = new Dictionary<int, char>
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
        $"{fileIndexToChar[pawn.Coord.File]}{rankIndexToChar[pawn.Coord.Rank - 1]}" :
        $"{fileIndexToChar[pawn.Coord.File]}{rankIndexToChar[pawn.Coord.Rank + 1]}";
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
  }
}