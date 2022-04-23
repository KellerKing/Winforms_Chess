using Chess.Contracts.Productlogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Produktlogic
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

  public static string CreateFenFromPices(List<Piece> pieces, int rankToCheck = 7, string fen = "")
  {
    if (rankToCheck == -1) return fen.Remove(Math.Max(fen.Length - 1, 0));

    var piecesMaxRank = pieces.Where(x => x.Coord.Rank == rankToCheck).ToList();

    if (piecesMaxRank.Count == 0) return CreateFenFromPices(pieces, --rankToCheck, $"{fen}8/");

    fen += ConvertRowToFen(piecesMaxRank);
    piecesMaxRank.ForEach(x => pieces.Remove(x));
    rankToCheck--;

    return CreateFenFromPices(pieces, rankToCheck, fen);
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
        PiceType = MappingCharToPieceType[char.ToUpper(character)],
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
      MappingPieceTypeToChar[piece.PiceType] :
      Char.ToLowerInvariant(MappingPieceTypeToChar[piece.PiceType]);
  }
}
}
