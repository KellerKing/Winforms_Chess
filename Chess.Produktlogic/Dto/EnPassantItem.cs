﻿using Chess.Contracts.Productlogic;

namespace Chess.Produktlogic.Dto
{
  public class EnPassantItem
  {
    public Coords NewPosition { get; set; } = new(-1, -1);
    public Coords PiceToCapture { get; set; }
  }
}